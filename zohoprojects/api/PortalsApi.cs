// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="PortalsApi.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using zohoprojects.model;
using zohoprojects.parser;
using zohoprojects.util;

namespace zohoprojects.api
{
    /// <summary>
    /// Class PortalsApi is used get the all the portals belonging to the user.
    /// </summary>
    public class PortalsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the portals Api using user's authtoken.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        public PortalsApi(string auth_token):base(auth_token,null)
        {

        }
        /// <summary>
        /// Gets all the portals for the logged in user.
        /// </summary>
        /// <returns>List of Portal object.</returns>
        public List<Portal> GetPortals()
        {
            string url = baseurl + "/portals/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return response.Content.ReadAsAsync<PortalParser>().Result.portals;
        }
    }
}
