// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-20-2014
// ***********************************************************************
// <copyright file="DashboardParser.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohoprojects.model;
using System.Net.Http;


namespace zohoprojects.parser
{

    /// <summary>
    /// Class DashboardApiParser is use to parse the http responses of DashboardApi.
    /// </summary>
    class DashboardParser
    {
        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        public List<Activity> activities { get; set; }
        /// <summary>
        /// Gets or sets the statuses.
        /// </summary>
        /// <value>The statuses.</value>
        public List<Status> statuses { get; set; }
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Status.</returns>
        public static Status getStatus(HttpResponseMessage response)
        {
            var status=new Status();
            var statuses = response.Content.ReadAsAsync<DashboardParser>().Result.statuses;
            foreach (var temp in statuses)
                status = temp;
            return status;
        }
    }
}
