// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="DashboardApi.cs" company="Zoho Corporation">
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
    /// Class DashboardApi is used <br></br>
    ///     To get the projects recent activities and the statuses,<br></br>
    ///     To add the status to the project.
    /// </summary>
    public class DashboardApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the dashboard Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public DashboardApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// List all the recent activities of the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters to refine the search.<br></br>
        /// The requested parameters are listed below <br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the project activity.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the project activities.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Activity objects.</returns>
        public List<Activity> GetProjectActivities(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/activities/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<DashboardParser>().Result.activities;
        }
        /// <summary>
        /// Gets the statuses of the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following filters.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the project status.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the project statuses.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Status object.</returns>
        public List<Status> GetStatus(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/statuses/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<DashboardParser>().Result.statuses;
        }
        /// <summary>
        /// Adds a new status for the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project for which the status is going to added.</param>
        /// <param name="status">The status is the status object with the following requested attributes.<be></be>
        /// <table>
        /// <tr><td>content*</td><td>string</td><td>Status of the project.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Status.</returns>
        public Status AddStatus(string project_id,Status status)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/statuses/";
            var response = ZohoHttpClient.post(url, getQueryParameters(status.toParamMap()));
            return DashboardParser.getStatus(response);
        }

    }
}
