using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalcultor
{
    public class Operation
    {
        #region Properties
        /// <summary>
        /// The leftside of the operation
        /// </summary>
        public string LeftSide { get; set; }

        /// <summary>
        /// The rightside of the operation
        /// </summary>
        public string RightSide { get; set; }

        /// <summary>
        /// Type of operation to perform
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// The innner operation to be performed
        /// </summary>
        public OperationType InnerOperation { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Operation()
        {
            // replace null with empty string
            this.LeftSide = string.Empty;
            this.RightSide = string.Empty;
        }
        #endregion
    }
}
