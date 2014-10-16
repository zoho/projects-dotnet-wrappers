// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TasklistParser.cs" company="Zoho Corporation">
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
    /// Class TasklistsApiParser is use to parse the http responses of TasklistsApi.
    /// </summary>
    class TasklistParser
    {
        /// <summary>
        /// Gets or sets the tasklists.
        /// </summary>
        /// <value>The tasklists.</value>
        public List<Tasklist> tasklists { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets the tasklist.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Tasklist.</returns>
        public static Tasklist getTasklist(HttpResponseMessage response)
        {
            var tasklist = new Tasklist();
            var tasklists = response.Content.ReadAsAsync<TasklistParser>().Result.tasklists;
            foreach (var temp in tasklists)
                tasklist = temp;
            return tasklist;
        }
    }
}
