// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ZohoProjects.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohoprojects.api;

namespace zohoprojects.service
{
    /// <summary>
    /// Class ZohoProjects is used to provide all API instances for the Zoho Project services.
    /// </summary>
    public class ZohoProjects
    {
        /// <summary>
        /// The authentication token
        /// </summary>
        string authToken;
        /// <summary>
        /// The portal identifier
        /// </summary>
        string portalId;
        /// <summary>
        /// Initializes the specified auth_token.
        /// </summary>
        /// <param name="auth_token">The auth_token.</param>
        /// <param name="portal_id">The portal_id.</param>
        public void initialize(string auth_token,string portal_id)
        {
            this.authToken = auth_token;
            this.portalId = portal_id;
        }
        /// <summary>
        /// Gets the dashboard API.
        /// </summary>
        /// <returns>DashboardApi.</returns>
        public DashboardApi GetDashboardApi()
        {
            var dashboardApi = new DashboardApi(authToken, portalId);
            return dashboardApi;
        }
        /// <summary>
        /// Gets the milestones API.
        /// </summary>
        /// <returns>MilestonesApi.</returns>
        public MilestonesApi GetMilestonesApi()
        {
            var milestonesApi = new MilestonesApi(authToken, portalId);
            return milestonesApi;
        }
        /// <summary>
        /// Gets the portals API.
        /// </summary>
        /// <returns>PortalsApi.</returns>
        public PortalsApi GetPortalsApi()
        {
            var portalsApi = new PortalsApi(authToken);
            return portalsApi;
        }
        /// <summary>
        /// Gets the projects API.
        /// </summary>
        /// <returns>ProjectsApi.</returns>
        public ProjectsApi GetProjectsApi()
        {
            var projectsApi = new ProjectsApi(authToken,portalId);
            return projectsApi;
        }
        /// <summary>
        /// Gets the tasklists API.
        /// </summary>
        /// <returns>TasklistsApi.</returns>
        public TasklistsApi GetTasklistsApi()
        {
            var tasklistsApi = new TasklistsApi(authToken, portalId);
            return tasklistsApi;
        }
        /// <summary>
        /// Gets the tasks API.
        /// </summary>
        /// <returns>TasksApi.</returns>
        public TasksApi GetTasksApi()
        {
            var tasksApi = new TasksApi(authToken, portalId);
            return tasksApi;
        }
        /// <summary>
        /// Gets the timesheets API.
        /// </summary>
        /// <returns>TimesheetsApi.</returns>
        public TimesheetsApi GetTimesheetsApi()
        {
            var timesheetsApi = new TimesheetsApi(authToken, portalId);
            return timesheetsApi;
        }
        /// <summary>
        /// Gets the bugs API.
        /// </summary>
        /// <returns>BugsApi.</returns>
        public BugsApi GetBugsApi()
        {
            var bugsApi = new BugsApi(authToken, portalId);
            return bugsApi;
        }
        /// <summary>
        /// Gets the events API.
        /// </summary>
        /// <returns>EventsApi.</returns>
        public EventsApi GetEventsApi()
        {
            var eventsApi = new EventsApi(authToken, portalId);
            return eventsApi;
        }
        /// <summary>
        /// Gets the documents API.
        /// </summary>
        /// <returns>DocumentsApi.</returns>
        public DocumentsApi GetDocumentsApi()
        {
            var documentsApi = new DocumentsApi(authToken, portalId);
            return documentsApi;
        }
        /// <summary>
        /// Gets the forums API.
        /// </summary>
        /// <returns>ForumsApi.</returns>
        public ForumsApi GetForumsApi()
        {
            var forumsApi = new ForumsApi(authToken, portalId);
            return forumsApi;
        }
        /// <summary>
        /// Gets the users API.
        /// </summary>
        /// <returns>UsersApi.</returns>
        public UsersApi GetUsersApi()
        {
            var usersApi = new UsersApi(authToken, portalId);
            return usersApi;
        }
    }
}
