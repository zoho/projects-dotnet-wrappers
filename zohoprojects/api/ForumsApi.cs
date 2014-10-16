// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ForumsApi.cs" company="Zoho Corporation">
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
using zohoprojects.util;
using zohoprojects.parser;

namespace zohoprojects.api
{
    /// <summary>
    /// Class ForumsApi is used<br></br>
    ///     To Get the list of forums,forum categories and comments,<br></br>
    ///     To update and delete the existing forum,<br></br>
    ///     To add a category and comments to the specified forum.
    /// </summary>
    public class ForumsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the forums Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public ForumsApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the forums in the given project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following requested parameters.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the forum.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the forums.</td></tr>
        /// <tr><td>category_id</td><td>Long</td><td>ID of the project category.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Forum objects.</returns>
        public List<Forum> GetForums(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/forums/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<ForumParser>().Result.forums;
        }
        /// <summary>
        /// Adds the forum post to th specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_forum_info">The new_forum_info is the Forum object which contains the following attributes to create a new forum.<br></br>
        /// <table>
        /// <tr><td>name*</td><td>string</td><td>Name of the forum post.</td></tr>
        /// <tr><td>content*</td><td>string</td><td>content of the forum post.</td></tr>
        /// <tr><td>category_id*</td><td>Long</td><td>ID of the project category.</td></tr>
        /// <tr><td>uploadfile</td><td>File</td><td>The file to upload in the forum.</td></tr>
        /// <tr><td>notify</td><td>string</td><td>User ID's must be separated by commas for multiple users.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Forum object.</returns>
        public Forum Add(string project_id,Forum new_forum_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/forums/";
            var response=new HttpResponseMessage();
                var filePath = new string[] { new_forum_info.uploadfile };
                var file = new KeyValuePair<string, string[]>("uploadfile", filePath);
                 response = ZohoHttpClient.post(url, getQueryParameters(), new_forum_info.toParamMap(), file);
            
            
            return ForumParser.getForum(response);
        }
        /// <summary>
        /// Updates the forum post in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_forum_info">The update_forum_info is the Forum object which contains the following attributes.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>id of the forum.</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the forum post.</td></tr>
        /// <tr><td>content*</td><td>string</td><td>content of the forum post.</td></tr>
        /// <tr><td>category_id*</td><td>Long</td><td>ID of the project category.</td></tr>
        /// <tr><td>uploadfile</td><td>File</td><td>The file to upload in the forum.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Forum object.</returns>
        public Forum Update(string project_id,Forum update_forum_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/forums/" + update_forum_info.id + "/";
            
            
                var filePath = new string[] { update_forum_info.uploadfile };
                var file = new KeyValuePair<string, string[]>("uploadfile", filePath);

                var response = ZohoHttpClient.post(url, getQueryParameters(), update_forum_info.toParamMap(), file);
            return ForumParser.getForum(response);
        }
        /// <summary>
        /// Deletes the forum post.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="forum_id">The forum_id is the identifier of the forum which is going to be deleted.</param>
        /// <returns>System.String.<br></br>
        /// The Success message is "Forum Deleted Successfully"
        /// </returns>
        public string Delete(string project_id,string forum_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/forums/" + forum_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<ForumParser>().Result.response;
        }
        /// <summary>
        /// Gets all the forum categories.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <returns>List of Category objects.</returns>
        public List<Category> GetCategories(string project_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/categories/";
            var respose = ZohoHttpClient.get(url, getQueryParameters());
            return respose.Content.ReadAsAsync<ForumParser>().Result.categories;
        }
        /// <summary>
        /// Adds the forum category.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_category_info">The new_category_info is the Category object which contains the follwing attributes to create a new category.<br></br>
        /// <table>
        /// <tr><td>name*</td><td>string</td><td>Name of the category.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Category object.</returns>
        public Category AddCategory(string project_id,Category new_category_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/categories/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_category_info.toParamMap()));
            return ForumParser.getCategory(response);
        }
        /// <summary>
        /// Gets all the forum comments.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="forum_id">The forum_id is the identifier of the forum for which going to get the comments.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the comment.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the comments.</td></tr>
        /// </table> 
        /// </param>
        /// <returns>List of Comment object.</returns>
        public List<Comment> GetComments(string project_id,string forum_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/forums/" + forum_id + "/comments/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<ForumParser>().Result.comments;
        }
        /// <summary>
        /// Adds the forum comment.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="forum_id">The forum_id is the identifier of the forum in the specified project.</param>
        /// <param name="new_comment_info">The new_comment_info is the Comment objecct which contains the following attributes to create a new comment to the forum.</param>
        /// <returns>Comment object.</returns>
        public Comment AddComment(string project_id,string forum_id,Comment new_comment_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/forums/" + forum_id + "/comments/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_comment_info.toParamMap()));
            return ForumParser.getComment(response);
        }
    }
}
