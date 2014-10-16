// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Forum.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Forum.
    /// </summary>
    public class Forum
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
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string content { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Forum"/> is is_sticky_post.
        /// </summary>
        /// <value><c>true</c> if is_sticky_post; otherwise, <c>false</c>.</value>
        public bool is_sticky_post { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Forum"/> is is_announcement_post.
        /// </summary>
        /// <value><c>true</c> if is_announcement_post; otherwise, <c>false</c>.</value>
        public bool is_announcement_post { get; set; }
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
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public Link link { get; set; }
        /// <summary>
        /// Gets or sets the post_date_format.
        /// </summary>
        /// <value>The post_date_format.</value>
        public string post_date_format { get; set; }
        /// <summary>
        /// Gets or sets the category_id.
        /// </summary>
        /// <value>The category_id.</value>
        public long category_id { get; set; }
        /// <summary>
        /// Gets or sets the notify.
        /// </summary>
        /// <value>The notify.</value>
        public string notify { get; set; }
        /// <summary>
        /// Gets or sets the uploadfile.
        /// </summary>
        /// <value>The uploadfile.</value>
        public string uploadfile { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (name != null)
                requestBody.Add("name", name);
            if (content != null)
                requestBody.Add("content", content);
            if (category_id>0)
                requestBody.Add("category_id", category_id);
            if (notify != null)
                requestBody.Add("notify", notify);
            return requestBody;
        }
    }
}
