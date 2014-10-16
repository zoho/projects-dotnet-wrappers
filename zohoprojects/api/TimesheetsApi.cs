// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TimesheetsApi.cs" company="Zoho Corporation">
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
    /// Class TimesheetsApi is used <br></br>
    ///     To get the all the time logs,<br></br>
    ///     To get details of the specified task,bug,general log,<br></br>
    ///     To add a new task,bug,general logs,<br></br>
    ///     To update or delete the existing task,bug,general log.
    /// </summary>
    public class TimesheetsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the timesheets Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public TimesheetsApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the time logs in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index of the time log</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the time logs.</td></tr>
        /// <tr><td>users_list*</td><td>string or Long</td><td>User of the time logs must be provided as <b>all </b>or user ID. For multiple users, the user ID must be separated by commas.(all - String, user ID - Long).</td></tr>
        /// <tr><td>view_type*</td><td>string</td><td>View type of the timesheet must be provided as <b>day </b>or <b>week </b>or <b>month</b>.</td></tr>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet view type.</td></tr>
        /// <tr><td>bill_status*</td><td>string</td><td>Timesheet billable status must be provided as <b>All</b> or <b>Billable</b> or <b>Non Billable</b>.</td></tr>
        /// <tr><td>component_type*</td><td>string</td><td>Type of the component must be provided as <b>task</b> or <b>bug</b> or <b>general</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Timelogs object.</returns>
        public Timelogs GetTimeLogs(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/logs/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<TimesheetParser>().Result.timelogs;
        }
        /// <summary>
        /// Adds the time log to a task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_tasklog_info">The new_tasklog_info is the Tasklog object which contains the following requested attributes to create a new tasklog.<br></br>
        /// <table>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet.</td></tr>
        /// <tr><td>billstatus*</td><td>string</td><td>Timesheet billable status must be provided as <b>Billable</b> or <br>Non Billable</br>.</td></tr>
        /// <tr><td>hours*</td><td>string [hh:mm]</td><td>Time period of the timesheet.</td></tr>
        /// <tr><td>notes</td><td>string</td><td>Additional information about the time log.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Tasklog object.</returns>
        public Tasklog AddTaskLog(string project_id,Tasklog new_tasklog_info)
        {
            string url=getBaseUrl()+"/projects/"+project_id+"/tasks/"+new_tasklog_info.task.id+"/logs/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_tasklog_info.toParamMap()));
            return TimesheetParser.getTasklog(response);
        }
        /// <summary>
        /// Updates the time log for a task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_tasklog_info">The update_tasklog_info is the Tasklog object which contains the following requested attributes to update a tasklog.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Tasklog id.</td></tr>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet.</td></tr>
        /// <tr><td>billstatus*</td><td>string</td><td>Timesheet billable status must be provided as <b>Billable</b> or <br>Non Billable</br>.</td></tr>
        /// <tr><td>hours*</td><td>string [hh:mm]</td><td>Time period of the timesheet.</td></tr>
        /// <tr><td>notes</td><td>string</td><td>Additional information about the time log.</td></tr>
        /// </table></param>
        /// <returns>Tasklog.</returns>
        public Tasklog UpdateTasklog(string project_id,Tasklog update_tasklog_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" + update_tasklog_info.task.id + "/logs/" + update_tasklog_info.id+"/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_tasklog_info.toParamMap()));
            return TimesheetParser.getTasklog(response);
        }
        /// <summary>
        /// Deletes the time log for a task.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="task_id">The task_id is the identifier of the task.</param>
        /// <param name="log_id">The log_id is the idenfier of the tasklog.</param>
        /// <returns>System.String.<br></br>
        /// The Success message is "Timesheet log Deleted Successfully"
        /// </returns>
        public string DeleteTasklog(string project_id,string task_id,string log_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/tasks/" +task_id+ "/logs/" +log_id+ "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<TimesheetParser>().Result.response;
        }
        /// <summary>
        /// Adds the time log to a bug.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_buglog_info">The new_buglog_info is the Buglog object which contains the following requested attributes to create a new buglog.<br></br>
        /// <table>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet.</td></tr>
        /// <tr><td>billstatus*</td><td>string</td><td>Timesheet billable status must be provided as <b>Billable</b> or <br>Non Billable</br>.</td></tr>
        /// <tr><td>hours*</td><td>string [hh:mm]</td><td>Time period of the timesheet.</td></tr>
        /// <tr><td>notes</td><td>string</td><td>Additional information about the time log.</td></tr>
        /// </table></param>
        /// <returns>Buglog object.</returns>
        public Buglog AddBuglog(string project_id,Buglog new_buglog_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/" + new_buglog_info.bug.id + "/logs/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_buglog_info.toParamMap()));
            return TimesheetParser.getBuglog(response);
        }
        /// <summary>
        /// Updates the time log for a bug.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_buglog_info">The update_buglog_info is the Buglog object which contains the following requested attributes to update a buglog.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Bug log id.</td></tr>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet.</td></tr>
        /// <tr><td>billstatus*</td><td>string</td><td>Timesheet billable status must be provided as <b>Billable</b> or <br>Non Billable</br>.</td></tr>
        /// <tr><td>hours*</td><td>string [hh:mm]</td><td>Time period of the timesheet.</td></tr>
        /// <tr><td>notes</td><td>string</td><td>Additional information about the time log.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Buglog object.</returns>
        public Buglog UpdateBuglog(string project_id,Buglog update_buglog_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/" + update_buglog_info.bug.id + "/logs/" + update_buglog_info.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_buglog_info.toParamMap()));
            return TimesheetParser.getBuglog(response);
        }
        /// <summary>
        /// Deletes the time log for a bug.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="bug_id">The bug_id is the identifier of the bug.</param>
        /// <param name="log_id">The log_id is the identifier of the log for the specified bug.</param>
        /// <returns>System.String.<br></br>
        /// The Success message is "Timesheet log Deleted Successfully"</returns>
        public string DeleteBuglog(string project_id,string bug_id,string log_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/bugs/" + bug_id + "/logs/" + log_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<TimesheetParser>().Result.response;
        }
        /// <summary>
        /// Adds the time log to the projects.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="new_generallog_info">The new_generallog_info is the Generallog object which contains the following requested attributes to create a new generallog.<br></br>
        /// <table>
        /// <tr><td>name*</td><td>string</td><td>Name of the other tasks.</td></tr>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet.</td></tr>
        /// <tr><td>billstatus*</td><td>string</td><td>Timesheet billable status must be provided as <b>Billable</b> or <br>Non Billable</br>.</td></tr>
        /// <tr><td>hours*</td><td>string [hh:mm]</td><td>Time period of the timesheet.</td></tr>
        /// <tr><td>notes</td><td>string</td><td>Additional information about the time log.</td></tr>
        /// </table></param>
        /// <returns>Generallog object.</returns>
        public Generallog AddGenerallog(string project_id,Generallog new_generallog_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/logs/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_generallog_info.toParamMap()));
            return TimesheetParser.getGenerallog(response);
        }
        /// <summary>
        /// Updates the time log for project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_generallog_info">The update_generallog_info is the Generallog object which contains the following requested attributes to update a generallog.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>General log id</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the other tasks.</td></tr>
        /// <tr><td>date*</td><td>String [MM-DD-YYYY]</td><td>Date of the timesheet.</td></tr>
        /// <tr><td>billstatus*</td><td>string</td><td>Timesheet billable status must be provided as <b>Billable</b> or <br>Non Billable</br>.</td></tr>
        /// <tr><td>hours*</td><td>string [hh:mm]</td><td>Time period of the timesheet.</td></tr>
        /// <tr><td>notes</td><td>string</td><td>Additional information about the time log.</td></tr>
        /// </table></param>
        /// <returns>Generallog object.</returns>
        public Generallog UpdateGenerallog(string project_id,Generallog update_generallog_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/logs/" + update_generallog_info.id+ "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_generallog_info.toParamMap()));
            return TimesheetParser.getGenerallog(response);
        }
        /// <summary>
        /// Deletes the generallog.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="log_id">The log_id is the identifier of the log for the project.</param>
        /// <returns>System.String.<br></br>
        /// The Success message is "Timesheet log Deleted Successfully"</returns>
        public string DeleteGenerallog(string project_id,string log_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/logs/" + log_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<TimesheetParser>().Result.response;
        }
    }
}
