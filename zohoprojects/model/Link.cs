// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Link.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Link.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public UrlString project { get; set; }
        /// <summary>
        /// Gets or sets the self.
        /// </summary>
        /// <value>The self.</value>
        public UrlString self { get; set; }
        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>The activity.</value>
        public UrlString activity { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public UrlString status { get; set; }
        /// <summary>
        /// Gets or sets the milestone.
        /// </summary>
        /// <value>The milestone.</value>
        public UrlString milestone { get; set; }
        /// <summary>
        /// Gets or sets the tasklist.
        /// </summary>
        /// <value>The tasklist.</value>
        public UrlString tasklist { get; set; }
        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>The task.</value>
        public UrlString task { get; set; }
        /// <summary>
        /// Gets or sets the bug.
        /// </summary>
        /// <value>The bug.</value>
        public UrlString bug { get; set; }
        /// <summary>
        /// Gets or sets the timesheet.
        /// </summary>
        /// <value>The timesheet.</value>
        public UrlString timesheet { get; set; }
        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        /// <value>The event.</value>
        public UrlString @event { get; set; }
        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public UrlString document { get; set; }
        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        /// <value>The folder.</value>
        public UrlString folder { get; set; }
        /// <summary>
        /// Gets or sets the forum.
        /// </summary>
        /// <value>The forum.</value>
        public UrlString forum { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public UrlString user { get; set; }
        /// <summary>
        /// Gets or sets the subtask.
        /// </summary>
        /// <value>The subtask.</value>
        public UrlString subtask { get; set; }
    }
}
