// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ForumParser.cs" company="Zoho Corporation">
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
    /// Class ForumsApiParser is use to parse the http responses of ForumsApi.
    /// </summary>
    class ForumParser
    {
        /// <summary>
        /// Gets or sets the forums.
        /// </summary>
        /// <value>The forums.</value>
        public List<Forum> forums { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public List<Category> categories { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public List<Comment> comments { get; set; }
        /// <summary>
        /// Gets the forum.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Forum.</returns>
        public static Forum getForum(HttpResponseMessage response)
        {
           var forums= response.Content.ReadAsAsync<ForumParser>().Result.forums;
           return forums[0];
        }
        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Category.</returns>
        public static Category getCategory(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<ForumParser>().Result.categories[0];
        }
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Comment.</returns>
        public static Comment getComment(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<ForumParser>().Result.comments[0];
        }
    }
}
