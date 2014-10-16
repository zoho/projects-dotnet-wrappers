// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Participant.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohoprojects.model
{
    /// <summary>
    /// This class is used to make an object for Participant.
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Gets or sets the participant_id.
        /// </summary>
        /// <value>The participant_id.</value>
        public string participant_id { get; set; }
        /// <summary>
        /// Gets or sets the participant_person.
        /// </summary>
        /// <value>The participant_person.</value>
        public string participant_person { get; set; }
    }
}
