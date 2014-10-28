// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ProjectsApi.cs" company="Zoho Corporation">
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
using System.Reflection;

namespace zohoprojects.api
{
    /// <summary>
    /// Class ProjectsApi is used<br></br>
    ///     To get the list projects in the specified portal,<br></br>
    ///     To get the details of the specified project,<br></br>
    ///     To create the new project to the portal,<br></br>
    ///     To update or delete the existing project.
    /// </summary>
    public class ProjectsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the projects Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public ProjectsApi(string auth_token,string portal_id):base(auth_token,portal_id)
        {

        }
        /// <summary>
        /// Gets all the projects in the portal for the logged in user.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which conatins the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the project.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the projects.</td></tr>
        /// <tr><td>status</td><td>string</td><td>Status of the project must be <b>active</b> or <b>archived</b> or <b>template</b>. </td></tr> 
        /// </param>
        /// <returns>List of Project objects.</returns>
        public List<Project> GetProjects(Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<ProjectParser>().Result.projects;
        }
        /// <summary>
        /// Gets the details of the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <returns>Project object.</returns>
        public Project Get(string project_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id+"/";
            var project=new Project();
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return ProjectParser.getProject(response);
        }
        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="new_project_info">The new_project_info is the Project object which contains the following requested attributes to create the project.<br></br>
        /// <table>
        /// <tr><td>name*</td><td>string</td><td>Name of the project</td></tr>
        /// <tr><td>description</td><td>string</td><td>Description of the project</td></tr>
        /// <tr><td>template_id</td><td>Long</td><td>Template ID of the project.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Project object .</returns>
        public Project Create(Project new_project_info)
        {
            string url = getBaseUrl() + "/projects/";
            var requestBody=new_project_info.toParamMap();
            var response = ZohoHttpClient.post(url, getQueryParameters(requestBody));
            return ProjectParser.getProject(response);
        }
        /// <summary>
        /// Updates the specified project.
        /// </summary>
        /// <param name="project">The project is the Project object which contains the following requested attributes to update the project.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Project id</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the project</td></tr>
        /// <tr><td>description</td><td>string</td><td>Description of the project</td></tr>
        /// <tr><td>status*</td><td>string</td><td>Status of the project must be active or archived.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Project object.</returns>
        public Project Update(Project project)
        {
            string url = getBaseUrl() + "/projects/" + project.id + "/";
            var requestBody = project.toParamMap();
            var response = ZohoHttpClient.post(url, getQueryParameters(requestBody));
            return ProjectParser.getProject(response);
        }
        /// <summary>
        /// Deletes the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <returns>System.String.<br></br>
        /// The success message is "Project Deleted Successfully"
        /// </returns>
        public string delete(long project_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<ProjectParser>().Result.response;
        }
    }
}
