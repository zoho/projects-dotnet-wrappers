// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TasklistsApi.cs" company="Zoho Corporation">
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
    /// Class TasklistsApi is used<br></br>
    ///     To get the tasklists for the specified project,<br></br>
    ///     To create the tasklist to the project,<br></br>
    ///     To update or delete the exist tasklist.
    /// </summary>
    public class TasklistsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the tasklists Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public TasklistsApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the tasklists in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the tasklist.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the tasklists.</td></tr>
        /// <tr><td>flag*</td><td>string</td><td>Tasklists of the flag must be <b>internal</b> or <b>external</b>. </td></tr> 
        /// </table>
        /// </param>
        /// <returns>List of Tasklist objects.</returns>
        public List<Tasklist> GetTasklists(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasklists/";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return responce.Content.ReadAsAsync<TasklistParser>().Result.tasklists;
        }
        /// <summary>
        /// Creates the tasklist.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_tasklist_info">The new_tasklist_info is the Tasklist object which contains the following requested attributes to create the tasklist.<br></br>
        /// <table>
        /// <tr><td>milestone_id*</td><td>Long</td><td>ID of the milestone.</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the tasklist</td></tr>
        /// <tr><td>flag*</td><td>string</td><td>Tasklist flag must be <b>internal</b> or <b>external</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Tasklist object.</returns>
        public Tasklist Create(string project_id,Tasklist new_tasklist_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasklists/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_tasklist_info.toParamMap()));
            return TasklistParser.getTasklist(response);
        }
        /// <summary>
        /// Updates the tasklist.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_tasklist">The update_tasklist is the Tasklist object which contains the following requested attributes to update the tasklist.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Tasklist id.</td></tr>
        /// <tr><td>milestone_id*</td><td>Long</td><td>ID of the milestone.</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the tasklist</td></tr>
        /// <tr><td>flag*</td><td>string</td><td>Tasklist flag must be <b>internal</b> or <b>external</b>.</td></tr>
        /// <tr><td>status*</td><td>string</td><td>Tasklist status must be <b>active</b> or <b>completed</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Tasklist object.</returns>
        public Tasklist Update(string project_id,Tasklist update_tasklist)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasklists/" + update_tasklist.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_tasklist.toParamMap()));
            return TasklistParser.getTasklist(response);
        }
        /// <summary>
        /// Deletes the tasklist.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="tasklist_id">The tasklist_id is the identifier of the tasklist.</param>
        /// <returns>System.String.<br></br>
        /// The success message is "Tasklist Deleted Successfully".
        /// </returns>
        public string Delete(string project_id,string tasklist_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasklists/" + tasklist_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<TasklistParser>().Result.response;
        }

    }
}
