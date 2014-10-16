// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Milestone.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Milestone.
    /// </summary>
    public class Milestone
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long? id { get; set; }
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
        /// Gets or sets the owner_name.
        /// </summary>
        /// <value>The owner_name.</value>
        public string owner_name { get; set; }
        /// <summary>
        /// Gets or sets the owner_id.
        /// </summary>
        /// <value>The owner_id.</value>
        public string owner_id { get; set; }
        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>The flag.</value>
        public string flag { get; set; }
        /// <summary>
        /// Gets or sets the start_date.
        /// </summary>
        /// <value>The start_date.</value>
        public string start_date { get; set; }
        /// <summary>
        /// Gets or sets the start_date_long.
        /// </summary>
        /// <value>The start_date_long.</value>
        public long start_date_long { get; set; }
        /// <summary>
        /// Gets or sets the end_date.
        /// </summary>
        /// <value>The end_date.</value>
        public string end_date { get; set; }
        /// <summary>
        /// Gets or sets the end_date_long.
        /// </summary>
        /// <value>The end_date_long.</value>
        public long end_date_long { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the completed_date.
        /// </summary>
        /// <value>The completed_date.</value>
        public string completed_date { get; set; }
        /// <summary>
        /// Gets or sets the completed_date_long.
        /// </summary>
        /// <value>The completed_date_long.</value>
        public long completed_date_long { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (name != null & name != "")
                requestBody.Add("name", name);
            if (start_date != null & start_date != "")
                requestBody.Add("start_date", start_date);
            if (end_date != null & end_date != "")
                requestBody.Add("end_date", end_date);
            if (owner_id!= null)
            {
                requestBody.Add("owner",Convert.ToInt64(owner_id));
            }
            if (flag != null & flag != "")
                requestBody.Add("flag", flag);
            return requestBody;
        }
    }
}
