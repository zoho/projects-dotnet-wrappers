// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TimesheetParser.cs" company="Zoho Corporation">
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
    /// Class TimesheetsApiParser is use to parse the http responses of TimesheetsApi.
    /// </summary>
    class TimesheetParser
    {
        /// <summary>
        /// Gets or sets the timelogs.
        /// </summary>
        /// <value>The timelogs.</value>
        public Timelogs timelogs { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets the tasklog.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Tasklog.</returns>
        public static Tasklog getTasklog(HttpResponseMessage response)
        {
            var tasklog = new Tasklog();
            var tasklogs = response.Content.ReadAsAsync<TimesheetParser>().Result.timelogs.tasklogs;
            foreach (var templog in tasklogs)
                tasklog = templog;
            return tasklog;
        }
        /// <summary>
        /// Gets the buglog.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Buglog.</returns>
        public static Buglog getBuglog(HttpResponseMessage response)
        {
            var buglog = new Buglog();
            var buglogs = response.Content.ReadAsAsync<TimesheetParser>().Result.timelogs.buglogs;
            foreach (var templog in buglogs)
                buglog = templog;
            return buglog;
        }
        /// <summary>
        /// Gets the generallog.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Generallog.</returns>
        public static Generallog getGenerallog(HttpResponseMessage response)
        {
            var generallog = new Generallog();
            var generallogs = response.Content.ReadAsAsync<TimesheetParser>().Result.timelogs.generallogs;
            foreach (var templog in generallogs)
                generallog = templog;
            return generallog;
        }
    }
}
