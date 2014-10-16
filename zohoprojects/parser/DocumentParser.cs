// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="DocumentParser.cs" company="Zoho Corporation">
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

namespace zohoprojects.parser
{
    /// <summary>
    /// Class DocumentsApiParser is use to parse the http responses of DocumentsApi.
    /// </summary>
    class DocumentParser
    {
        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>The documents.</value>
        public List<Document> documents { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets or sets the folders.
        /// </summary>
        /// <value>The folders.</value>
        public List<Folder> folders { get; set; }
        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Document.</returns>
        public static Document getDocument(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<DocumentParser>().Result.documents[0];
        }
        /// <summary>
        /// Gets the folder.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Folder.</returns>
        public static Folder getFolder(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<DocumentParser>().Result.folders[0];
        }
    }
}
