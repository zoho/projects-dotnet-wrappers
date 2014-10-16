// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Settings.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets the company_name.
        /// </summary>
        /// <value>The company_name.</value>
        public string company_name { get; set; }
        /// <summary>
        /// Gets or sets the website_url.
        /// </summary>
        /// <value>The website_url.</value>
        public string website_url { get; set; }
        /// <summary>
        /// Gets or sets the time_zone.
        /// </summary>
        /// <value>The time_zone.</value>
        public string time_zone { get; set; }
        /// <summary>
        /// Gets or sets the date_format.
        /// </summary>
        /// <value>The date_format.</value>
        public string date_format { get; set; }
    }
}
