// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Comment.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string content { get; set; }
        /// <summary>
        /// Gets or sets the posted_by.
        /// </summary>
        /// <value>The posted_by.</value>
        public string posted_by { get; set; }
        /// <summary>
        /// Gets or sets the posted_person.
        /// </summary>
        /// <value>The posted_person.</value>
        public string posted_person { get; set; }
        /// <summary>
        /// Gets or sets the post_date.
        /// </summary>
        /// <value>The post_date.</value>
        public string post_date { get; set; }
        /// <summary>
        /// Gets or sets the post_date_long.
        /// </summary>
        /// <value>The post_date_long.</value>
        public long post_date_long { get; set; }
        /// <summary>
        /// Gets or sets the created_time_long.
        /// </summary>
        /// <value>The created_time_long.</value>
        public long created_time_long { get; set; }
        /// <summary>
        /// Gets or sets the added_by.
        /// </summary>
        /// <value>The added_by.</value>
        public string added_by { get; set; }
        /// <summary>
        /// Gets or sets the added_person.
        /// </summary>
        /// <value>The added_person.</value>
        public string added_person { get; set; }
        /// <summary>
        /// Gets or sets the created_time_format.
        /// </summary>
        /// <value>The created_time_format.</value>
        public string created_time_format { get; set; }
        /// <summary>
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }

        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object, object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (content != null)
                requestBody.Add("content",content);
            return requestBody;
        }
    }
}
