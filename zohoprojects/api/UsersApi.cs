// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="UsersApi.cs" company="Zoho Corporation">
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
    /// Class UsersApi is used to get the list of users associated with the project.
    /// </summary>
    public class UsersApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the users Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public UsersApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the users in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <returns>List of User objects.</returns>
        public List<User> GetUsers(string project_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/users/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return response.Content.ReadAsAsync<UserParser>().Result.users;
        }
    }
}
