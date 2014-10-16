// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-18-2014
// ***********************************************************************
// <copyright file="Api.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace zohoprojects.api
{
    /// <summary>
    /// Class Api is the super class to all API classes.
    /// This class will maintains the service URL and credentials.
    /// </summary>
    public class Api
    {
        /// <summary>
        /// It is the API base URL for the Zoho projects service.
        /// </summary>
        
        public static string baseurl = "https://projectsapi.zoho.com/restapi";
        /// <summary>
        /// Initializes static members of the <see cref="Api" /> class.
        /// </summary>
        static Api()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }
        /// <summary>
        /// The authtoken is the authentication parameter which authenticates the API call.
        /// </summary>
        protected string authtoken;
        /// <summary>
        /// The portal identifier is used to choose on which portal,the API call has been applied.
        /// </summary>
        protected string portalId;
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public Api(String auth_token, String portal_id)
        {
            authtoken = auth_token;
            portalId = portal_id;
        }
        /// <summary>
        /// Constructs the QueryString using users authToken and portal id.
        /// </summary>
        /// <returns>A queryString as a Dictionary object.</returns>
        public Dictionary<object, object> getQueryParameters()
        {
            var queryParameters = new Dictionary<object, object>();
            queryParameters.Add("authtoken", authtoken);
            return queryParameters;
        }
        /// <summary>
        /// Constructs the Dictionary object using user's auth token,portal id and using the query parameters.
        /// </summary>
        /// <param name="queryParameters">The query parameters.</param>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object, object> getQueryParameters(Dictionary<object, object> queryParameters)
        {
            if (queryParameters == null)
                queryParameters = new Dictionary<object, object>();
            queryParameters.Add("authtoken", authtoken);
            return queryParameters;
        }
        /// <summary>
        /// portal id will be added to the url.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getBaseUrl()
        {
            return baseurl+"/portal/"+portalId;
        }
    }
}
