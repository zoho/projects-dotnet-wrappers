// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Tasklist.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Tasklist.
    /// </summary>
    public class Tasklist
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the milestone.
        /// </summary>
        /// <value>The milestone.</value>
        public Milestone milestone { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Tasklist"/> is completed.
        /// </summary>
        /// <value><c>true</c> if completed; otherwise, <c>false</c>.</value>
        public bool completed { get; set; }
        /// <summary>
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }
        /// <summary>
        /// Gets or sets the created_time_long.
        /// </summary>
        /// <value>The created_time_long.</value>
        public long created_time_long { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Tasklist"/> is rolled.
        /// </summary>
        /// <value><c>true</c> if rolled; otherwise, <c>false</c>.</value>
        public bool rolled { get; set; }
        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>The sequence.</value>
        public int sequence { get; set; }
        /// <summary>
        /// Gets or sets the view_type.
        /// </summary>
        /// <value>The view_type.</value>
        public string view_type { get; set; }
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
            var requestBody=new Dictionary<object,object>();
            if (milestone.id.HasValue)
                requestBody.Add("milestone_id", milestone.id);
            if (name != null)
                requestBody.Add("name", name);
            if (milestone.flag != null)
                requestBody.Add("flag", milestone.flag);
            if (milestone.status != null)
                requestBody.Add("status", milestone.status);
            return requestBody;
        }
    }
}
