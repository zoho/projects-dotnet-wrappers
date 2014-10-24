using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohoprojects.model
{
    /// <summary>
    /// Class Customfield.
    /// </summary>
    public class Customfield
    {
        /// <summary>
        /// Gets or sets the label_name.
        /// </summary>
        /// <value>The label_name.</value>
        public string label_name { get; set; }
        /// <summary>
        /// Gets or sets the column_name.
        /// </summary>
        /// <value>The column_name.</value>
        public string column_name { get; set; }
        /// <summary>
        /// Gets or sets the default_ value.
        /// </summary>
        /// <value>The default_ value.</value>
        public string default_Value { get; set; }
        /// <summary>
        /// Gets or sets the picklist_values.
        /// </summary>
        /// <value>The picklist_values.</value>
        public List<string> picklist_values { get; set; }
    }
}
