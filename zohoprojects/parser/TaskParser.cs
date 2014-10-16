// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TaskParser.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using zohoprojects.model;

namespace zohoprojects.parser
{
    /// <summary>
    /// Class TasksApiParser is use to parse the http responses of TasksApi.
    /// </summary>
    class TaskParser
    {
        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>The tasks.</value>
        public List<Task> tasks { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <param name="responce">The responce.</param>
        /// <returns>Task.</returns>
        public static Task getTask(HttpResponseMessage responce)
        {
            var task = new Task();
            var tasks = responce.Content.ReadAsAsync<TaskParser>().Result.tasks;
            foreach (var temptask in tasks)
                task = temptask;
            return task;
        }

    }
}
