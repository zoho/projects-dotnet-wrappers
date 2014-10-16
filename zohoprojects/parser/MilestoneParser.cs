// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MilestoneParser.cs" company="Zoho Corporation">
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
    /// Class MilestonesApiParser  is use to parse the http responses of MilestonesApi.
    /// </summary>
    class MilestoneParser
    {
        /// <summary>
        /// Gets or sets the milestones.
        /// </summary>
        /// <value>The milestones.</value>
        public List<Milestone> milestones { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public string response { get; set; }
        /// <summary>
        /// Gets the milestone.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Milestone.</returns>
        public static Milestone getMilestone(HttpResponseMessage response)
        {
           var milestone=new Milestone();
            var milestones = response.Content.ReadAsAsync<MilestoneParser>().Result.milestones;
            foreach(var temp in milestones)
                 milestone=temp;
            return milestone;
        }
        
    }
}
