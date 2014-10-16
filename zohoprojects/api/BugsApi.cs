// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-20-2014
// ***********************************************************************
// <copyright file="BugsApi.cs" company="">
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
using zohoprojects.parser;
using zohoprojects.util;
using zohoprojects.model;

namespace zohoprojects.api
{
    /// <summary>
    /// Class BugsApi is used to <br></br>
    ///     Get the list of bugs or the specified bug detatils,<br></br>
    ///     create a new bug for the project,<br></br>
    ///     update or delete the bug.<br></br>
    /// </summary>
    public class BugsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the bugs Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public BugsApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets the list of bugs for the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters to refine the list.<br></br>
        /// The requested parameters are listed below <br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the bug.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the bugs.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Bug objects.</returns>
        public List<Bug> GetBugs(string project_id, Dictionary<object, object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<BugParser>().Result.bugs;
        }
        /// <summary>
        /// Gets the details of the specified bug.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project in which going to get the bug.</param>
        /// <param name="bug_id">The bug_id is the identifier of the bug.</param>
        /// <returns>Bug.</returns>
        public Bug Get(string project_id,string bug_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/" + bug_id + "/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return BugParser.getBug(response);
        }
        /// <summary>
        /// Creates the bug using the provided information.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project for which going to create the bug.</param>
        /// <param name="new_bug_info">The new_bug_info is the bug object which conatins the information to create a new bug.<br></br>
        /// The requested attributes are<br></br>
        /// <table>
        /// <tr><td>title*</td><td>string</td><td>Name of the bug.</td></tr>
        /// <tr><td>description</td><td>string</td><td>Description of the bug.</td></tr>
        /// <tr><td>assignee</td><td>Long</td><td> Assignee for the bug.</td></tr>
        /// <tr><td>flag</td><td>string</td><td>Bug flag must be Internal or External.</td></tr>
        /// <tr><td>classification_id</td><td>Long</td><td>Classification ID of the project.</td></tr>
        /// <tr><td>milestone_id</td><td>Long</td><td>Milestone ID of the project.</td></tr>
        /// <tr><td>due_date</td><td>String [MM-DD-YYYY]</td><td>Due date of the bug.</td></tr>
        /// <tr><td>module_id</td><td>Long</td><td> Module ID of the project.</td></tr>
        /// <tr><td>severity_id</td><td>Long</td><td>Severity ID of the project.</td></tr>
        /// <tr><td>reproducible_id</td><td>Long</td><td> Reproducible ID of the project.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Bug object.</returns>
        public Bug Create(string project_id,Bug new_bug_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_bug_info.toParmMap()));
            return BugParser.getBug(response);
        }
        /// <summary>
        /// Updates the specified bug information.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_info">The update_info is the Bug object which contains the update informaion.<br></br>
        /// The requested attributes are<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>The bug id</td></tr>
        /// <tr><td>title*</td><td>string</td><td>Name of the bug.</td></tr>
        /// <tr><td>description</td><td>string</td><td>Description of the bug.</td></tr>
        /// <tr><td>assignee</td><td>Long</td><td> Assignee for the bug.</td></tr>
        /// <tr><td>flag</td><td>string</td><td>Bug flag must be Internal or External.</td></tr>
        /// <tr><td>classification_id</td><td>Long</td><td>Classification ID of the project.</td></tr>
        /// <tr><td>milestone_id</td><td>Long</td><td>Milestone ID of the project.</td></tr>
        /// <tr><td>due_date</td><td>String [MM-DD-YYYY]</td><td>Due date of the bug.</td></tr>
        /// <tr><td>module_id</td><td>Long</td><td> Module ID of the project.</td></tr>
        /// <tr><td>severity_id</td><td>Long</td><td>Severity ID of the project.</td></tr>
        /// <tr><td>reproducible_id</td><td>Long</td><td> Reproducible ID of the project.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Bug object.</returns>
        public Bug Update(string project_id,Bug update_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/" + update_info.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_info.toParmMap()));
            return BugParser.getBug(response);
        }
        /// <summary>
        /// Deletes the specified bug.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="bug_id">The bug_id is the identifier of the bug which is gpoing to be deleted.</param>
        /// <returns>System.String .<br></br>
        /// The Success message is "Bug Deleted Successfully"
        /// </returns>
        public string Delete(string project_id,string bug_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/" + bug_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<BugParser>().Result.response;
        }
    }
}
