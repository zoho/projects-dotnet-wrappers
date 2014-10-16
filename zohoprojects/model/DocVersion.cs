// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="DocVersion.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for DocVersion.
    /// </summary>
    public class DocVersion
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the uploaded_by.
        /// </summary>
        /// <value>The uploaded_by.</value>
        public string uploaded_by { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the file_size.
        /// </summary>
        /// <value>The file_size.</value>
        public string file_size { get; set; }
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string version { get; set; }
        /// <summary>
        /// Gets or sets the uploaded_date.
        /// </summary>
        /// <value>The uploaded_date.</value>
        public string uploaded_date { get; set; }
        /// <summary>
        /// Gets or sets the uploaded_date_long.
        /// </summary>
        /// <value>The uploaded_date_long.</value>
        public long uploaded_date_long { get; set; }
        /// <summary>
        /// Gets or sets the uploaded_date_format.
        /// </summary>
        /// <value>The uploaded_date_format.</value>
        public string uploaded_date_format { get; set; }
    }
}
