using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_RB.Models
{
    /// <summary>
    /// PayLoad 
    /// </summary>
    public class PayLoad
    {
        /// <summary>
        /// Load Id
        /// </summary>
        public int LoadId { get; private set; }

        /// <summary>
        /// X location
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// y Location
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Creates a new instance of Payload
        /// </summary>
        /// <param name="loadId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static PayLoad Create(int loadId, int x, int y)
        {
            return new PayLoad()
            {
                LoadId = loadId,
                X = x,
                Y = y
            };
        }
    }
}
