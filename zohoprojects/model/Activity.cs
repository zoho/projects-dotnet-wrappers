// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Activity.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Activity.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public object id { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string state { get; set; }
        /// <summary>
        /// Gets or sets the activity_for.
        /// </summary>
        /// <value>The activity_for.</value>
        public string activity_for { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the activity_by.
        /// </summary>
        /// <value>The activity_by.</value>
        public string activity_by { get; set; }
        /// <summary>
        /// Gets or sets the time_long.
        /// </summary>
        /// <value>The time_long.</value>
        public object time_long { get; set; }
        /// <summary>
        /// Gets or sets the display_time.
        /// </summary>
        /// <value>The display_time.</value>
        public string display_time { get; set; }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public string time { get; set; }
    }
}
