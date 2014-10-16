// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Status.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Status.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public object id { get; set; }
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
        /// Gets or sets the posted_time.
        /// </summary>
        /// <value>The posted_time.</value>
        public string posted_time { get; set; }
        /// <summary>
        /// Gets or sets the posted_time_long.
        /// </summary>
        /// <value>The posted_time_long.</value>
        public object posted_time_long { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (content != null & content != "")
                requestBody.Add("content", content);
            return requestBody;
        }
    }
}
