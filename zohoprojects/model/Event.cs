// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Event.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohoprojects.model
{
    /// <summary>
    /// This class is used to make an object for Event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string title { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string location { get; set; }
        /// <summary>
        /// Gets or sets the scheduled_on.
        /// </summary>
        /// <value>The scheduled_on.</value>
        public string scheduled_on { get; set; }
        /// <summary>
        /// Gets or sets the scheduled_on_long.
        /// </summary>
        /// <value>The scheduled_on_long.</value>
        public long scheduled_on_long { get; set; }
        /// <summary>
        /// Gets or sets the reminder.
        /// </summary>
        /// <value>The reminder.</value>
        public string reminder { get; set; }
        /// <summary>
        /// Gets or sets the repeat.
        /// </summary>
        /// <value>The repeat.</value>
        public string repeat { get; set; }
        /// <summary>
        /// Gets or sets the occurred.
        /// </summary>
        /// <value>The occurred.</value>
        public int occurred { get; set; }
        /// <summary>
        /// Gets or sets the duration_hour.
        /// </summary>
        /// <value>The duration_hour.</value>
        public string duration_hour { get; set; }
        /// <summary>
        /// Gets or sets the duration_minutes.
        /// </summary>
        /// <value>The duration_minutes.</value>
        public string duration_minutes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Event"/> is is_open.
        /// </summary>
        /// <value><c>true</c> if is_open; otherwise, <c>false</c>.</value>
        public bool is_open { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the participants.
        /// </summary>
        /// <value>The participants.</value>
        public List<Participant> participants { get; set; }
        /// <summary>
        /// Gets or sets the occurrences.
        /// </summary>
        /// <value>The occurrences.</value>
        public int occurrences { get; set; }
        /// <summary>
        /// Gets or sets the hour.
        /// </summary>
        /// <value>The hour.</value>
        public string hour { get; set; }
        /// <summary>
        /// Gets or sets the minutes.
        /// </summary>
        /// <value>The minutes.</value>
        public string minutes { get; set; }
        /// <summary>
        /// Gets or sets the ampm.
        /// </summary>
        /// <value>The ampm.</value>
        public string ampm { get; set; }
        /// <summary>
        /// Gets or sets the remind_before.
        /// </summary>
        /// <value>The remind_before.</value>
        public string remind_before { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody=new Dictionary<object,object>();
            if (title != null)
                requestBody.Add("title", title);
            if (date != null)
                requestBody.Add("date", date);
            if (hour != null)
                requestBody.Add("hour", hour);
            if (minutes != null)
                requestBody.Add("minutes", minutes);
            if (ampm != null)
                requestBody.Add("ampm", ampm);
            if (duration_hour != null)
                requestBody.Add("duration_hour", duration_hour);
            if (duration_minutes != null)
                requestBody.Add("duration_mins", duration_minutes);
            if(participants!=null)
            {
                var partcipants = "";
                foreach (var participant in participants)
                    partcipants += participant.participant_id + ",";
                requestBody.Add("participants",partcipants);
            }
            if (remind_before != null)
                requestBody.Add("remind_before", remind_before);
            if (repeat != null)
                requestBody.Add("repeat", repeat);
            if (occurrences > 0)
                requestBody.Add("nooftimes_repeat", occurrences);
            if (location != null)
                requestBody.Add("location", location);
            return requestBody;

        }

    }
}
