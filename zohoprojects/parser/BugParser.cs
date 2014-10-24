// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="BugParser.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using zohoprojects.model;

/// <summary>
/// The parser namespace.
/// </summary>
namespace zohoprojects.parser
{
    /// <summary>
    /// Class BugsApiParser is use to parse the http responses of BugsAPi.
    /// </summary>
    class BugParser
    {
        /// <summary>
        /// Gets or sets the bugs.
        /// </summary>
        /// <value>The bugs.</value>
        public List<Bug> bugs { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets or sets the defaultfields.
        /// </summary>
        /// <value>The defaultfields.</value>
        public Defaultfields defaultfields { get; set; }
        /// <summary>
        /// Gets or sets the customfields.
        /// </summary>
        /// <value>The customfields.</value>
        public List<Customfield> customfields { get; set; }
        /// <summary>
        /// Gets the bug.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Bug.</returns>
        public static Bug getBug(HttpResponseMessage response)
        {
            var bug = response.Content.ReadAsAsync<BugParser>().Result.bugs[0];
            return bug;
        }


    }
}
