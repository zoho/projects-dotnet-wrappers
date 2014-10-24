using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohoprojects.model
{
    /// <summary>
    /// Class Defaultfields.
    /// </summary>
    public class Defaultfields
    {
        /// <summary>
        /// Gets or sets the severity_details.
        /// </summary>
        /// <value>The severity_details.</value>
        public List<Severity> severity_details { get; set; }
        /// <summary>
        /// Gets or sets the status_deatils.
        /// </summary>
        /// <value>The status_deatils.</value>
        public List<Status> status_deatils { get; set; }
        /// <summary>
        /// Gets or sets the module_details.
        /// </summary>
        /// <value>The module_details.</value>
        public List<Module> module_details { get; set; }
        /// <summary>
        /// Gets or sets the priority_details.
        /// </summary>
        /// <value>The priority_details.</value>
        public List<Priority> priority_details { get; set; }
        /// <summary>
        /// Gets or sets the classification_details.
        /// </summary>
        /// <value>The classification_details.</value>
        public List<Classification> classification_details { get; set; }
    }
}
