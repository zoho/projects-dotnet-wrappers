// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MilestonesApi.cs" company="Zoho Corporation">
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
using zohoprojects.parser;
using zohoprojects.util;

namespace zohoprojects.api
{
    /// <summary>
    /// Class MilestonesApi is used <br></br>
    ///     To get the details of the all the milestones or specified milestone of the project,<br></br>
    ///     To create,update or delete the milestone from specified project,<br></br>
    ///     To update the status of the milestone.
    /// </summary>
    public class MilestonesApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the milestones Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public MilestonesApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the milestones in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following requested parameters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the milestone.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the milestones.</td></tr>
        /// <tr><td>status</td><td>string</td><td>Status of the milestone must be <b>all</b> or <b>completed</b> or <b>notcompleted</b>. </td></tr>
        /// <tr><td>display_type</td><td>string</td><td>Milestone type must be <b>all</b> or <b>upcoming</b> or <b>delayed</b>.</td></tr>
        /// <tr><td>flag</td><td>string</td><td>Milestone flag must be <b>allflag</b> or <b>internal</b> or <b>external</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Milestone objects.</returns>
        public List<Milestone> GetMilestones(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/milestones/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<MilestoneParser>().Result.milestones;
        }
        /// <summary>
        /// Gets the details of the milestone.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="milestone_id">The milestone_id is the identifier of the milestone which is present in the spcified project.</param>
        /// <returns>Milestone object.</returns>
        public Milestone Get(string project_id,string milestone_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/milestones/"+milestone_id+"/";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return MilestoneParser.getMilestone(response);
        }
        /// <summary>
        /// Creates the milestone to the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="milestone_info">The milestone_info is the Milestone object which is having the following attributes to create the new milestone.<br></br>
        /// <table>
        /// <tr><td>name*</td><td>string</td><td>Name of the milestone.</td></tr>
        /// <tr><td>start_date*</td><td>String [MM-DD-YYYY]</td><td>Start date of the milestone.</td></tr>
        /// <tr><td>end_date*</td><td>String [MM-DD-YYYY]</td><td>End date of the milestone.</td></tr>
        /// <tr><td>owner*</td><td>Long</td><td>User ID of the project.</td></tr>
        /// <tr><td>flag*</td><td>string</td><td>Milestone flag must be <b>internal</b> or <b>external</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Milestone.</returns>
        public Milestone Create(string project_id,Milestone milestone_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/milestones/";
            var response = ZohoHttpClient.post(url, getQueryParameters(milestone_info.toParamMap()));
            return MilestoneParser.getMilestone(response);
        }
        /// <summary>
        /// Updates the mile stone in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_info">The update_info is the Milestone object which is having the following attributes to update the new milestone.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Milestone id.</td></tr>
        /// <tr><td>name*</td><td>string</td><td>Name of the milestone.</td></tr>
        /// <tr><td>start_date*</td><td>String [MM-DD-YYYY]</td><td>Start date of the milestone.</td></tr>
        /// <tr><td>end_date*</td><td>String [MM-DD-YYYY]</td><td>End date of the milestone.</td></tr>
        /// <tr><td>owner*</td><td>Long</td><td>User ID of the project.</td></tr>
        /// <tr><td>flag*</td><td>string</td><td>Milestone flag must be <b>internal</b> or <b>external</b>.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Milestone object.</returns>
        public Milestone Update(string project_id,Milestone update_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/milestones/" + update_info.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_info.toParamMap()));
            return MilestoneParser.getMilestone(response);
        }
        /// <summary>
        /// Updates the milestone status.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="milestone_id">The milestone_id is the identifier of the milestone.</param>
        /// <param name="status_info">The status_info is the parameter which indicates the status of the milestone.
        /// <table>
        /// <tr><td>status_info</td><td>int[1 or 2]</td><td>Modify the status of the milestone.(1 - notcompelted, 2 - completed).</td></tr>
        /// </table>
        /// </param>
        /// <returns>Milestone object.</returns>
        public Milestone UpdateStatus(string project_id,string milestone_id,int status_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/milestones/" + milestone_id + "/status/";
            var requestBody = new Dictionary<object, object>();
            requestBody.Add("status", status_info);
            var response=ZohoHttpClient.post(url,getQueryParameters(requestBody));
            return MilestoneParser.getMilestone(response);
        }
        /// <summary>
        /// Deletes the specified milestone in the project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="milestone_id">The milestone_id is the identifier of the milestone.</param>
        /// <returns>System.String.<br></br>
        /// The success message is "Milestone Deleted Successfully".
        /// </returns>
        public string Delete(string project_id,string milestone_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/milestones/" + milestone_id + "/";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return response.Content.ReadAsAsync<MilestoneParser>().Result.response;
        }

    }
}
