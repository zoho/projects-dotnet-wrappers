// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Date.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Date.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Gets or sets the date_long.
        /// </summary>
        /// <value>The date_long.</value>
        public object date_long { get; set; }
        /// <summary>
        /// Gets or sets the display_format.
        /// </summary>
        /// <value>The display_format.</value>
        public string display_format { get; set; }
        /// <summary>
        /// Gets or sets the totalhours.
        /// </summary>
        /// <value>The totalhours.</value>
        public string totalhours { get; set; }
        /// <summary>
        /// Gets or sets the buglogs.
        /// </summary>
        /// <value>The buglogs.</value>
        public List<Buglog> buglogs { get; set; }
    }
}
