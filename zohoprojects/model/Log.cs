// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Log.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Log.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the log_date.
        /// </summary>
        /// <value>The log_date.</value>
        public string log_date { get; set; }
        /// <summary>
        /// Gets or sets the log_date_long.
        /// </summary>
        /// <value>The log_date_long.</value>
        public long log_date_long { get; set; }
        /// <summary>
        /// Gets or sets the bill_status.
        /// </summary>
        /// <value>The bill_status.</value>
        public string bill_status { get; set; }
        /// <summary>
        /// Gets or sets the hours_display.
        /// </summary>
        /// <value>The hours_display.</value>
        public string hours_display { get; set; }
        /// <summary>
        /// Gets or sets the hours.
        /// </summary>
        /// <value>The hours.</value>
        public string hours { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }
        /// <summary>
        /// Gets or sets the minutes.
        /// </summary>
        /// <value>The minutes.</value>
        public int minutes { get; set; }
        /// <summary>
        /// Gets or sets the total_minutes.
        /// </summary>
        /// <value>The total_minutes.</value>
        public int total_minutes { get; set; }
        /// <summary>
        /// Gets or sets the owner_id.
        /// </summary>
        /// <value>The owner_id.</value>
        public string owner_id { get; set; }
        /// <summary>
        /// Gets or sets the owner_name.
        /// </summary>
        /// <value>The owner_name.</value>
        public string owner_name { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public Link link { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody=new Dictionary<object,object>();
            if (name != null)
                requestBody.Add("name", name);
            if (log_date != null)
                requestBody.Add("date", log_date);
            if (bill_status != null)
                requestBody.Add("bill_status", bill_status);
            if (hours!= null)
                requestBody.Add("hours", hours);
            if (notes != null)
                requestBody.Add("notes", notes);
            return requestBody;
        }
    }
}
