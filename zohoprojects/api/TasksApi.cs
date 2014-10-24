// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TasksApi.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using zohoprojects.model;
using zohoprojects.util;
using zohoprojects.parser;

namespace zohoprojects.api
{
    /// <summary>
    /// Class TasksApi is used <br></br>
    ///     To get all the tasks in the project,<br></br>
    ///     To get the tasks in the specified tasklist,<br></br>
    ///     To get the specified task information,<br></br>
    ///     To ccreate a new task to the project,<br></br>
    ///     To update or delete the existing task.
    /// </summary>
    public class TasksApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the tasks Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public TasksApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {
            
        }
        /// <summary>
        /// Gets all the tasks in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which conatins the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>index of the task</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of thetasks</td></tr>
        /// <tr><td>owner</td><td>string or Long</td><td>Owner of the task must be provided as <b>all</b> or user ID. (<b>all</b> - String, user ID - Long)</td></tr>
        /// <tr><td>status</td><td>string</td><td>Status of the task must be <b>all</b> or <b>completed</b> or <b>notcompleted</b>.</td></tr>
        /// <tr><td>time</td><td>string</td><td>Time period of the task must be <b>all</b> or <b>overdue</b> or <b>today</b> or <b>tomorrow</b>.</td></tr>
        /// <tr><td>priority</td><td>string</td><td>Priority of the task must be <b>all</b> or <b>none</b> or <b>low</b> or <b>medium</b> or <b>high</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Task objects.</returns>
        public List<Task> GetTasks(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<TaskParser>().Result.tasks;
        }
        /// <summary>
        /// Gets all the tasks in the specified tasklist.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="tasklist_id">The tasklist_id is the identifier of the tasklist.</param>
        /// <param name="parameters">The parameters is the Dictionary object which conatins the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>index number of the task</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the tasks</td></tr>
        /// </table>
        /// </param>
        /// <returns>List Task object.</returns>
        public List<Task> GetTasklistTasks(string project_id,string tasklist_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasklists/" + tasklist_id + "/tasks/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<TaskParser>().Result.tasks;
        }
        /// <summary>
        /// Gets all the details for the task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="task_id">The task_id is the identifier of the task.</param>
        /// <returns>Task object.</returns>
        public Task Get(string project_id,string task_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + task_id + "/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return TaskParser.getTask(response);
        }

        /// <summary>
        /// Lists the sub tasks of the specified task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="task_id">The task_id is the identifier of the task.</param>
        /// <param name="parameters">The parameters is the Dictionary object which conatins the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>index number of the task</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the tasks</td></tr>
        /// </table>
        /// </param>
        /// <returns>Tasks list object.</returns>
        public List<Task> GetSubTasks(string project_id, string task_id, Dictionary<object, object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + task_id + "/subtasks/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<TaskParser>().Result.tasks;
        }

        /// <summary>
        /// Creates a tsk.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_task_info">The new_task_info is the Task object which contains the following requested attributes to create a new task.<br></br>
        /// <table>
        /// <tr><td>person_responsible</td><td>Long</td><td>Owner ID of the task. User ID for multiple owners must be separated by commas.</td></tr>
        /// <tr><td>tasklist_id</td><td>Long</td><td>ID of the tasklist.</td></tr>
        /// <tr><td>name*</td><td>string</td><td> Name of the task.</td></tr>
        /// <tr><td>start_date</td><td>String [MM-DD-YYYY]</td><td>Start date of the task.</td></tr>
        /// <tr><td>end_date</td><td>String [MM-DD-YYYY]</td><td>End date of the task.</td></tr>
        /// <tr><td>duration</td><td>int</td><td> Duration of the task.</td></tr>
        /// <tr><td>priority</td><td>string</td><td>Priority of the task must be None or <b>Low</b> or <b>Medium</b> or <b>High</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Task object.</returns>
        public Task Create(string project_id,Task new_task_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_task_info.toParamMap()));
            return TaskParser.getTask(response);
        }


        /// <summary>
        /// Updates the task in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_task_info">The update_task_info is the Task object which contains the following requested attributes to update a task.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Task id.</td></tr>
        /// <tr><td>person_responsible*</td><td>Long</td><td>Owner ID of the task. User ID for multiple owners must be separated by commas.</td></tr>
        /// <tr><td>name*</td><td>string</td><td> Name of the task.</td></tr>
        /// <tr><td>start_date</td><td>String [MM-DD-YYYY]</td><td>Start date of the task.</td></tr>
        /// <tr><td>end_date</td><td>String [MM-DD-YYYY]</td><td>End date of the task.</td></tr>
        /// <tr><td>duration</td><td>int</td><td> Duration of the task.</td></tr>
        /// <tr><td>priority</td><td>string</td><td>Priority of the task must be None or <b>Low</b> or <b>Medium</b> or <b>High</b>.</td></tr>
        /// <tr><td>percent_complete</td><td>int</td><td>Task completed percentage must be provided in multiple of 10's. [10 to 100].</td></tr>
        /// </table>
        /// </param>
        /// <returns>Task object.</returns>
        public Task Update(string project_id,Task update_task_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + update_task_info.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_task_info.toParamMap()));
            return TaskParser.getTask(response);
        }
        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="task_id">The task_id is the identifier of the task.</param>
        /// <returns>System.String.<br></br>
        /// The Success message is "Task Deleted Successfully".
        /// </returns>
        public string Delete(string project_id, string task_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + task_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<TaskParser>().Result.response;
        }
        /// <summary>
        /// Gets the comments of the specified task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="task_id">The task_id is the identifier of the task.</param>
        /// <returns>Comments list.</returns>
        public List<Comment> GetComments(string project_id,string task_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + task_id + "/comments/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return response.Content.ReadAsAsync<TaskParser>().Result.comments;
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="project_id">The project_id.</param>
        /// <param name="task_id">The task_id.</param>
        /// <param name="comment">The comment object which contains the following attributes as mandatory.<br></br>
        ///  <table>
        /// <tr><td>content*</td><td>string</td><td>comment description.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Comment object.</returns>
        public Comment AddComment(string project_id,string task_id,Comment comment)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + task_id + "/comments/";
            var response = ZohoHttpClient.post(url,getQueryParameters(comment.toParamMap()));
            return TaskParser.getComment(response);
        }

        /// <summary>
        /// Deletes the commentn of the specified task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="task_id">The task_id is the identifier of the task.</param>
        /// <param name="comment_id">The comment_id is the identifier of the task which is going to be deleted.</param>
        /// <returns>System.String.</returns>
        public string DeleteComment(string project_id,string task_id,string comment_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + task_id + "/comments/" + comment_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<TasklistParser>().Result.response;
        }

    }
}

