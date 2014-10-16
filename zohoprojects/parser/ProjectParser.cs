// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ProjectParser.cs" company="Zoho Corporation">
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

namespace zohoprojects.parser
{
    /// <summary>
    /// Class ProjectsApiParser is use to parse the http responses of ProjectsApi.
    /// </summary>
    class ProjectParser
    {
        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public List<Project> projects { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Project.</returns>
        public static Project getProject(HttpResponseMessage response)
        {
            var project=new Project();
            var projects=response.Content.ReadAsAsync<ProjectParser>().Result.projects;
            foreach(var temp in projects)
                project=temp;
            return project;
        }
    }
}
