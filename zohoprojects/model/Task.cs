// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Task.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Task.
    /// </summary>
    public class Task
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
        /// Gets or sets a value indicating whether this <see cref="Task"/> is completed.
        /// </summary>
        /// <value><c>true</c> if completed; otherwise, <c>false</c>.</value>
        public bool completed { get; set; }
        /// <summary>
        /// Gets or sets the created_by.
        /// </summary>
        /// <value>The created_by.</value>
        public string created_by { get; set; }
        /// <summary>
        /// Gets or sets the created_person.
        /// </summary>
        /// <value>The created_person.</value>
        public string created_person { get; set; }
        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public string priority { get; set; }
        /// <summary>
        /// Gets or sets the percent_complete.
        /// </summary>
        /// <value>The percent_complete.</value>
        public int percent_complete { get; set; }
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
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public string duration { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>The details.</value>
        public Details details { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public Link link { get; set; }
        /// <summary>
        /// Gets or sets the tasklist.
        /// </summary>
        /// <value>The tasklist.</value>
        public Tasklist tasklist { get; set; }
        /// <summary>
        /// Gets or sets the owners.
        /// </summary>
        /// <value>The owners.</value>
        public List<Owner> owners { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if(owners!=null)
            { 
                string responsiblePersons = "";
                foreach (var owner in owners)
                    responsiblePersons += owner.id + ",";
                requestBody.Add("person_responsible", responsiblePersons);
            }
            if (tasklist != null)
                requestBody.Add("tasklist_id", tasklist.id);
            if (name != null)
                requestBody.Add("name", name);
            if (start_date != null)
                requestBody.Add("start_date", start_date);
            if (end_date != null)
                requestBody.Add("end_date", end_date);
            if (duration != null)
                requestBody.Add("duration", duration);
            if (priority != null)
                requestBody.Add("priority", priority);
            if (percent_complete.ToString() != null)
                requestBody.Add("percent_complete", percent_complete);
            return requestBody;
        }
    }
}
