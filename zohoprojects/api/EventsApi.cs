// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EventsApi.cs" company="Zoho Corporation">
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
    /// Class EventsApi is used<br></br>
    ///     To get the details of the events,
    ///     To add new event to the project,
    ///     To update or delete the event.
    /// </summary>
    public class EventsApi:Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// Constructs the events Api using user's authtoken and portal id.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="portal_id">The portal_id is the identifier of the portal on which user is working currently.</param>
        public EventsApi(string auth_token, string portal_id)
            : base(auth_token, portal_id)
        {

        }
        /// <summary>
        /// Gets all the events in the specified project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project for which you are going to get the evevnts.</param>
        /// <param name="parameters">The parameters is the Dictionary object which is having the following requested parameters as a filters to refine the list.<br></br>
        /// <table>
        /// <tr><td>index</td><td>int</td><td>Index number of the event.</td></tr>
        /// <tr><td>range</td><td>int</td><td>Range of the events.</td></tr>
        /// <tr><td>status*</td><td>string</td><td>Status of the event must be open or closed.</td></tr>
        /// </table>
        /// </param>
        /// <returns>List of Event object.</returns>
        public List<Event> GetEvents(string project_id,Dictionary<object,object> parameters)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/events/";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return response.Content.ReadAsAsync<EventParser>().Result.events;
        }
        /// <summary>
        /// Adds an event to the project.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project .</param>
        /// <param name="new_evevnt_info">The new_evevnt_info is the Event object which contains the following requested attributes.<br></br>
        /// <table>
        /// <tr><td>title*</td><td>string</td><td>Name of the event.</td></tr>
        /// <tr><td>date*</td><td>string[MM-DD-YYYY]</td><td>Date of the event.</td></tr>
        /// <tr><td>hour*</td><td>string[hh]</td><td>Hour of the event.</td></tr>
        /// <tr><td>minutes*</td><td>string[mm]</td><td>Minutes of the event.</td></tr>
        /// <tr><td>ampm*</td><td>string</td><td>am or pm of the event.</td></tr>
        /// <tr><td>duration_hour*</td>string[hh]<td></td><td>Duration of the event in hours.</td></tr>
        /// <tr><td>duration_mins*</td><td>string[mm]</td><td>Duration of the event in minutes.</td></tr>
        /// <tr><td>participants*</td><td>Long</td><td>Participants of the event. Multiple particpants must be provided with comma separated user ID's.</td></tr>
        /// <tr><td>remind_before</td><td>string</td><td>Participants of the event. Multiple particpants must be provided with comma separated user ID's.</td></tr>
        /// <tr><td>repeat</td><td>string</td><td>Reminder occurrences for the event. It must be only once or every day or every week or every month or every year. </td></tr>
        /// <tr><td>nooftimes_repeat</td><td>string</td><td>Count of the reminder occurrence. It must be an integer value between 2 to 10.</td></tr>
        /// <tr><td>location</td><td>string</td><td>Location of the event.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Event.</returns>
        public Event Add(string project_id,Event new_evevnt_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/events/";
            var response = ZohoHttpClient.post(url, getQueryParameters(new_evevnt_info.toParamMap()));
            return EventParser.getEvent(response);
        }
        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="update_event_info">The update_event_info is the Event object which contains the following requested attributes.<br></br>
        /// <table>
        /// <tr><td>id*</td><td>Long</td><td>Event id.</td></tr>
        /// <tr><td>title*</td><td>string</td><td>Name of the event.</td></tr>
        /// <tr><td>date*</td><td>string[MM-DD-YYYY]</td><td>Date of the event.</td></tr>
        /// <tr><td>hour*</td><td>string[hh]</td><td>Hour of the event.</td></tr>
        /// <tr><td>minutes*</td><td>string[mm]</td><td>Minutes of the event.</td></tr>
        /// <tr><td>ampm*</td><td>string</td><td>am or pm of the event.</td></tr>
        /// <tr><td>duration_hour*</td>string[hh]<td></td><td>Duration of the event in hours.</td></tr>
        /// <tr><td>duration_mins*</td><td>string[mm]</td><td>Duration of the event in minutes.</td></tr>
        /// <tr><td>participants*</td><td>Long</td><td>Participants of the event. Multiple particpants must be provided with comma separated user ID's.</td></tr>
        /// <tr><td>remind_before</td><td>string</td><td>Participants of the event. Multiple particpants must be provided with comma separated user ID's.</td></tr>
        /// <tr><td>repeat</td><td>string</td><td>Reminder occurrences for the event. It must be only once or every day or every week or every month or every year. </td></tr>
        /// <tr><td>nooftimes_repeat</td><td>string</td><td>Count of the reminder occurrence. It must be an integer value between 2 to 10.</td></tr>
        /// <tr><td>location</td><td>string</td><td>Location of the event.</td></tr>
        /// </table> 
        /// </param>
        /// <returns>Event.</returns>
        public Event Update(string project_id,Event update_event_info)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/events/" + update_event_info.id + "/";
            var response = ZohoHttpClient.post(url, getQueryParameters(update_event_info.toParamMap()));
            return EventParser.getEvent(response);
        }
        /// <summary>
        /// Deletes the specified project_id.
        /// </summary>
        /// <param name="project_id">The project_id is the identifier of the project.</param>
        /// <param name="event_id">The event_id is the identifier of the event.</param>
        /// <returns>System.String.<br></br>
        /// The success message is "Event Deleted Successfully".</returns>
        public string Delete(string project_id,string event_id)
        {
            string url = getBaseUrl() + "/projects/" + project_id + "/events/" + event_id + "/";
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return responce.Content.ReadAsAsync<EventParser>().Result.response;
        }
    }
}
