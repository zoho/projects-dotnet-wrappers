// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Project.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohoprojects.model
{
    /// <summary>
    /// This class is used to make an object for Project.
    /// </summary>
    public class Project
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the task_count.
        /// </summary>
        /// <value>The task_count.</value>
        public Count task_count { get; set; }
        /// <summary>
        /// Gets or sets the milestone_count.
        /// </summary>
        /// <value>The milestone_count.</value>
        public Count milestone_count { get; set; }
        /// <summary>
        /// Gets or sets the bug_count.
        /// </summary>
        /// <value>The bug_count.</value>
        public Count bug_count { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the created_date.
        /// </summary>
        /// <value>The created_date.</value>
        public string created_date { get; set; }
        /// <summary>
        /// Gets or sets the created_date_long.
        /// </summary>
        /// <value>The created_date_long.</value>
        public long created_date_long { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
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
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public Link link { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (name != null)
                requestBody.Add("name", name);
            if (description != null)
                requestBody.Add("description", description);
            if (status != null & status!="")
                requestBody.Add("status", status);
            return requestBody;
        }
    }
}
