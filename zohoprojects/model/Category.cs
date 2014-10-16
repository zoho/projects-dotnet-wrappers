// ***********************************************************************
// Assembly         : zohoprojects
// Author           : hari-2197
// Created          : 06-19-2014
//
// Last Modified By : hari-2197
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Category.cs" company="Zoho Corporation">
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
    /// This class is used to make an object for Category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// To the parameter map.
        /// </summary>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> toParamMap()
        {
            var requestBody = new Dictionary<object, object>();
            if (name != null)
                requestBody.Add("name", name);
            return requestBody;
        }
    }
}
