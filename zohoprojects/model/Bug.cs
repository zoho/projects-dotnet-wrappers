// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Bug.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Bug.
    /// </summary>
    public class Bug
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string title { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string key { get; set; }
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public Project project { get; set; }
        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>The flag.</value>
        public string flag { get; set; }
        /// <summary>
        /// Gets or sets the reporter_id.
        /// </summary>
        /// <value>The reporter_id.</value>
        public string reporter_id { get; set; }
        /// <summary>
        /// Gets or sets the reported_person.
        /// </summary>
        /// <value>The reported_person.</value>
        public string reported_person { get; set; }
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
        /// Gets or sets the assignee_name.
        /// </summary>
        /// <value>The assignee_name.</value>
        public string assignee_name { get; set; }
        /// <summary>
        /// Gets or sets the assignee.
        /// </summary>
        /// <value>The assignee.</value>
        public long assignee { get; set; }
        /// <summary>
        /// Gets or sets the classification.
        /// </summary>
        /// <value>The classification.</value>
        public Classification classification { get; set; }
        /// <summary>
        /// Gets or sets the severity.
        /// </summary>
        /// <value>The severity.</value>
        public Severity severity { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public Status status { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Bug"/> is closed.
        /// </summary>
        /// <value><c>true</c> if closed; otherwise, <c>false</c>.</value>
        public bool closed { get; set; }
        /// <summary>
        /// Gets or sets the reproducible.
        /// </summary>
        /// <value>The reproducible.</value>
        public Reproducible reproducible { get; set; }
        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public Module module { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public Link link { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the milestone_id.
        /// </summary>
        /// <value>The milestone_id.</value>
        public long milestone_id { get; set; }
        /// <summary>
        /// Gets or sets the created_time_format.
        /// </summary>
        /// <value>The created_time_format.</value>
        public string created_time_format { get; set; }
        /// <summary>
        /// Gets or sets the due_date.
        /// </summary>
        /// <value>The due_date.</value>
        public string due_date { get; set; }
        /// <summary>
        /// To the parm map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParmMap()
        {
            var requestBody = new Dictionary<object, object>();
            if(title!=null)
            {
                requestBody.Add("title", title);
            }
            if (description != null)
                requestBody.Add("description", description);
            if (assignee > 0)
                requestBody.Add("assignee", assignee);
            if (flag != null)
                requestBody.Add("flag", flag);
            if (classification != null)
            {
                if (classification.id > 0)
                    requestBody.Add("classification_id", classification);
            }
            if (milestone_id > 0)
                requestBody.Add("milestone_id", milestone_id);
            if (due_date != null)
                requestBody.Add("due_date", due_date);
            if(module!=null)
                if (module.id > 0)
                    requestBody.Add("module_id", module.id);
            if (severity != null)
                if (severity.id > 0)
                    requestBody.Add("severity_id", severity.id);
            if (reproducible != null)
                if (reproducible.id > 0)
                    requestBody.Add("reproducible_id", reproducible.id);
            return requestBody;
        }
    }
}
