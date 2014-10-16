// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="PortalParser.cs" company="Zoho Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohoprojects.model;

namespace zohoprojects.parser
{
    /// <summary>
    /// Class PortalsApiParser  is use to parse the http responses of PortalsApi.
    /// </summary>
    class PortalParser
    {
        /// <summary>
        /// Gets or sets the login_id.
        /// </summary>
        /// <value>The login_id.</value>
        public int login_id { get; set; }
        /// <summary>
        /// Gets or sets the portals.
        /// </summary>
        /// <value>The portals.</value>
        public List<Portal> portals { get; set; }
    }
}
