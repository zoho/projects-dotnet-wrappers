// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Buglog.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Buglog.
    /// </summary>
    public class Buglog:Log
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public Project project { get; set; }
        /// <summary>
        /// Gets or sets the bug.
        /// </summary>
        /// <value>The bug.</value>
        public Bug bug { get; set; }
    }
}
