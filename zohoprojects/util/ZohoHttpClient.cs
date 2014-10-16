// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-18-2014
// ***********************************************************************
// <copyright file="ZohoHttpClient.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using zohoprojects.exception;
using System.IO;
using System.Diagnostics;
using zohoprojects.model;
using zohoprojects.parser;

namespace zohoprojects.util
{
    class ZohoHttpClient
    {

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns>HttpClient.</returns>
        static HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 60);
            client.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");
            client.DefaultRequestHeaders.Add("User-Agent", "ZohoBooks-dotnet-Wrappers/1.0");
            return client;
        }
         /// <summary>
         /// Make a query string from the given parameters.
         /// </summary>
         /// <param name="url">Service URL passed by the user.</param>
         /// <param name="parameters">The parameters contains the query string parameters in the form of key, value pair.</param>
         /// <returns> Returns the Query String</returns>
         static string getqueryString(string url,Dictionary<object,object> parameters)
        {
            var client = getClient();
            var ub = new UriBuilder(url);
            var param = HttpUtility.ParseQueryString(ub.Query);
            foreach (var parameter in parameters)
                param.Add(parameter.Key.ToString(), parameter.Value.ToString());
            ub.Query = param.ToString();
            return ub.ToString();
        }

         /// <summary>
         /// Makes a GET request and fetch the responce for the given URL and Query Parameters.
         /// </summary>
         /// <param name="url">Service URL passed by the user.</param>
         /// <param name="parameters">The parameters contains the query string parameters in the form of key, value pair.</param>
         /// <returns>HttpResponseMessage which contains the data in the form of JSON .</returns>
         /// <exception cref="ProjectsException">Throws the Exception with error messege return from the server.</exception>
        public static HttpResponseMessage get(string url, Dictionary<object,object> parameters)
        {
            var client = getClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var responce= client.GetAsync(getqueryString(url,parameters)).Result;
            if (responce.IsSuccessStatusCode)
                return responce;
            else
                throw new ProjectsException(responce.Content.ReadAsAsync<ErrorParser>().Result.error.message);
        }

        /// <summary>
        /// Makes a POST request and creates a resource for the given URL and a request body.
        /// </summary>
        /// <param name="url">Service URL passed by the user.</param>
        /// <param name="requestBody">It contains the request body parameters to make the POST request.</param>
        /// <returns>HttpResponseMessage which contains the data in the form of JSON .</returns>
        /// <exception cref="ProjectsException">Throws the Exception with error messege return from the server.</exception>
        public static HttpResponseMessage post(string url,Dictionary<object,object> requestBody)
        {
            var client = getClient();
            List<KeyValuePair<string,string>> contentBody=new List<KeyValuePair<string,string>>();
            foreach (var requestbodyParam in requestBody)
            {
                var temp = new KeyValuePair<string, string>(requestbodyParam.Key.ToString(), requestbodyParam.Value.ToString());
                contentBody.Add(temp);
            }
            var content = new FormUrlEncodedContent(contentBody);
            var responce= client.PostAsync(url,content).Result;
            if (responce.IsSuccessStatusCode)
                return responce;
            else
                throw new ProjectsException(responce.Content.ReadAsAsync<ErrorParser>().Result.error.message);
        }

        /// <summary>
        /// Makes a POST request and creates a resource for the given URL and a MultiPart form data.
        /// </summary>
        /// <param name="url">Service URL passed by the user.</param>
        /// <param name="parameters">The parameters contains the query string parameters in the form of key, value pair.</param>
        /// <param name="requestBody">It contains the request body parameters to make the POST request.</param>
        /// <param name="attachments">It contains the files to attach or post for the requested URL .</param>
        /// <returns>HttpResponseMessage which contains the data in the form of JSON .</returns>
        /// <exception cref="ProjectsException">Throws the Exception with error messege return from the server.</exception>
        public static HttpResponseMessage post(string url, Dictionary<object, object> parameters,Dictionary<object,object> requestBody,KeyValuePair<string,string[]> attachments)
        {
            var client = getClient();
            var boundary =DateTime.Now.Ticks.ToString();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            MultipartFormDataContent content = new MultipartFormDataContent("--boundary--");
            if (requestBody!=null)
                foreach (var requestbodyParam in requestBody)
                    content.Add(new StringContent(requestbodyParam.Value.ToString()), requestbodyParam.Key.ToString());
            if (attachments.Value != null)
            {
                foreach (var file_path in attachments.Value)
                    if (file_path != null)
                    {
                        string _filename = Path.GetFileName(file_path);
                        FileStream fileStream = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.Read);
                        StreamContent fileContent = new StreamContent(fileStream);
                        fileContent.Headers.Add("Content-Type", "application/octet-stream");
                        content.Add(fileContent, attachments.Key, _filename);
                    }
            }
            var responce = client.PostAsync(getqueryString(url, parameters), content).Result;
            if (responce.IsSuccessStatusCode)
                return responce;
            else
                throw new ProjectsException(responce.Content.ReadAsAsync<ErrorParser>().Result.error.message);
        }

        

        /// <summary>
        /// Make a DELETE request for the given URL and a query string.
        /// </summary>
        /// <param name="url">Service URL passed by the user.</param>
        /// <param name="parameters">The parameters contains the query string parameters in the form of key, value pair.</param>
        /// <returns>HttpResponseMessage which contains the data in the form of JSON.</returns>
        /// <exception cref="ProjectsException">Throws the Exception with error messege return from the server.</exception>
         public static HttpResponseMessage delete(string url,Dictionary<object,object> parameters)
        {
            var client = getClient();
            var responce = client.DeleteAsync(getqueryString(url, parameters)).Result;
            if (responce.IsSuccessStatusCode)
                return responce;
            else
                throw new ProjectsException(responce.Content.ReadAsAsync<ErrorParser>().Result.error.message);
        }

         
    }
}
