// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Timelogs.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohoprojects.model
{
    /// <summary>
    /// This class is used to make an object for Timelogs.
    /// </summary>
    public class Timelogs
    {
        /// <summary>
        /// Gets or sets the grandtotal.
        /// </summary>
        /// <value>The grandtotal.</value>
        public string grandtotal { get; set; }
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public string role { get; set; }
        /// <summary>
        /// Gets or sets the timelog.
        /// </summary>
        /// <value>The timelog.</value>
        public Timelog timelog { get; set; }
        /// <summary>
        /// Gets or sets the tasklogs.
        /// </summary>
        /// <value>The tasklogs.</value>
        public List<Tasklog> tasklogs { get; set; }
        /// <summary>
        /// Gets or sets the buglogs.
        /// </summary>
        /// <value>The buglogs.</value>
        public List<Buglog> buglogs { get; set; }
        /// <summary>
        /// Gets or sets the generallogs.
        /// </summary>
        /// <value>The generallogs.</value>
        public List<Generallog> generallogs { get; set; }
    }
}
