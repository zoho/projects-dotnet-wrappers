// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="DocumentsApi.cs" company="Zoho Corporation">
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
using zohoprojects.util;
using zohoprojects.model;
using zohoprojects.parser;

namespace zohoprojects.api
{
    /// <summary>
    /// Class DocumentsApi is used <br></br>
    ///     To get the list of documents,<br></br>
    ///     To get the details of the specified document,<br></br>
    ///     To add a document to the project,<br></br>
    ///     To update and delete the existing document.
    /// </summary>
    public class DocumentsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the documents Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public DocumentsApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the documents details for the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following filters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the document.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the documents.</td></tr>
        /// <tr><td>folder_id</td><td>Long</td><td>ID of the project folder.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Document objects.</returns>
        public List<Document> GetDocuments(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/documents/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<DocumentParser>().Result.documents;
        }
        /// <summary>
        /// Gets the version details of the document.
        /// </summary>
        /// <param name="project_id">The project_id is the identifer of the project.</param>
        /// <param name="document_id">The document_id is the identifier of the document.</param>
        /// <param name="parameters">The parameters is the Dictionary object which is having the following requested parameter.<br></br>
        /// <table>
        /// <tr><td>version</td><td>string</td><td>Version number of the document.</td></tr></table>
        /// </param>
        /// <returns>Document object.</returns>
        public Document Get(string project_id,string document_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/documents/" + document_id + "/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return DocumentParser.getDocument(response);
        }
        /// <summary>
        /// Uploads the document to the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_document_info">The new_document_info is the Document object which contains the following requested attributes.<br></br>
        /// <table>
        /// <tr><td>uploaddoc*</td><td>File</td><td>The selected file for upload.</td></tr>
        /// <tr><td>folder_id</td><td>Long</td><td>ID of the project folder.</td></tr>
        /// <tr><td>description</td><td>string</td><td>Description of the document.</td></tr>
        /// <tr><td>tags</td><td>string</td><td>Document tags must be separated by space or comma.</td></tr>
        /// <tr><td>notify</td><td>Long</td><td>User ID's must be separated by commas for multiple users. </td></tr>
        /// </table>
        /// </param>
        /// <returns>Document.</returns>
        public Document Add(string project_id,Document new_document_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/documents/";
            var docPath = new string[] { new_document_info.uploaddoc };
            var file = new KeyValuePair<string, string[]>("uploaddoc",docPath);
            var response = ZohoHttpClient.post(url,getQueryParameters(new_document_info.toParamMap()),null,file);
            return DocumentParser.getDocument(response);
        }
        /// <summary>
        /// Uploads the latest version of the document for the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_document_info">The update_document_info is the Document object which contains latest version document details with the following requested attributes.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Document id.</td></tr>
        /// <tr><td>uploaddoc*</td><td>File</td><td>The selected file for upload.</td></tr>
        /// <tr><td>folder_id*</td><td>Long</td><td>ID of the project folder.</td></tr>
        /// <tr><td>description</td><td>string</td><td>Description of the document.</td></tr>
        /// <tr><td>tags</td><td>string</td><td>Document tags must be separated by space or comma.</td></tr>
        /// <tr><td>notify</td><td>Long</td><td>User ID's must be separated by commas for multiple users. </td></tr>
        /// </table>
        /// </param>
        /// <returns>Document object.</returns>
        public Document Update(string project_id,Document update_document_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/documents/" + update_document_info.id + "/";
            var file=new KeyValuePair<string,string[]>("uploaddoc",new string[]{update_document_info.uploaddoc});
            var response = ZohoHttpClient.post(url, getQueryParameters(update_document_info.toParamMap()), null, file);
            return DocumentParser.getDocument(response);
        }
        /// <summary>
        /// Deletes the specified document.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="document_id">The document_id is the identifier of the document.</param>
        /// <returns>System.String.<br></br>
        /// The Success message is "Document Deleted Successfully"
        /// </returns>
        public string Delete(string project_id,string document_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/documents/" + document_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<DocumentParser>().Result.response;
        }
        /// <summary>
        /// Gets all the folders in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <returns>List of Folder objects.</returns>
        public List<Folder> GetFolders(string project_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/folders/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return response.Content.ReadAsAsync<DocumentParser>().Result.folders;
        }
        /// <summary>
        /// Adds the folder to the project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_folder_info">The new_folder_info is the Folder object which contains the following attribute to create a new folder.<br></br>
        /// <table>
        /// <tr><td>name*</td><td>string</td><td>Name of the folder.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Folder object.</returns>
        public Folder AddFolder(string project_id,Folder new_folder_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/folders/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_folder_info.toParamMap()));
            return DocumentParser.getFolder(response);
        }
        /// <summary>
        /// Updates the folder.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_folder_info">The update_folder_info is the Folder object which contains the update information with the following requested attributes.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Folder id</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the folder.</td></tr>
        /// </table> 
        /// </param>
        /// <returns>Folder object.</returns>
        public Folder UpdateFolder(string project_id,Folder update_folder_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/folders/" + update_folder_info.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_folder_info.toParamMap()));
            return DocumentParser.getFolder(response);
        }
        /// <summary>
        /// Deletes the specified folder.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="folder_id">The folder_id is the identifier of the folder.</param>
        /// <returns>System.String.<br></br>
        /// The success message is "Folder Deleted Successfully"
        /// </returns>
        public string DeleteFolder(string project_id,string folder_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/folders/" + folder_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<DocumentParser>().Result.response;
        }
    }
}
