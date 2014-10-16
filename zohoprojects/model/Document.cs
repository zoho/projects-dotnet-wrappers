// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Document.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Document.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the file_name.
        /// </summary>
        /// <value>The file_name.</value>
        public string file_name { get; set; }
        /// <summary>
        /// Gets or sets the content_type.
        /// </summary>
        /// <value>The content_type.</value>
        public string content_type { get; set; }
        /// <summary>
        /// Gets or sets the versions.
        /// </summary>
        /// <value>The versions.</value>
        public List<DocVersion> versions { get; set; }
        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        /// <value>The folder.</value>
        public Folder folder { get; set; }
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
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public string tags { get; set; }
        /// <summary>
        /// Gets or sets the notify.
        /// </summary>
        /// <value>The notify.</value>
        public string notify { get; set; }
        /// <summary>
        /// Gets or sets the uploaddoc.
        /// </summary>
        /// <value>The uploaddoc.</value>
        public string uploaddoc { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object, object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (folder != null)
                if (folder.id > 0)
                    requestBody.Add("folder_id", folder.id);
            if (description != null)
                requestBody.Add("description", description);
            if (tags != null)
                requestBody.Add("tags", tags);
            if (notify != null)
                requestBody.Add("notify", notify);
            return requestBody;
        }
    }
}
