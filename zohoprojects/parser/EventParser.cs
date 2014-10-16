// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EventParser.cs" company="Zoho Corporation">
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
    /// Class EventsApiParser is use to parse the http responses of EventsApi.
    /// </summary>
    class EventParser
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        public List<Event> events { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Event.</returns>
        public static Event getEvent(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<EventParser>().Result.events[0];
        }
    }
}
