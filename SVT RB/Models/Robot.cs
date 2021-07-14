using SVT_RB.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_RB.Models
{
    /// <summary>
    /// Robot model
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Robot Id
        /// </summary>
        public int RobotId { get; set; }

        /// <summary>
        /// Robot x point location
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Robot y point location
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Robot BatteryLevel
        /// </summary>
        public int BatteryLevel { get; set; }

        /// <summary>
        /// ToDto Method
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        public BotObjectiveDto ToDto(PayLoad payLoad)
        {

            return new BotObjectiveDto()
            {
                BatteryLevel = BatteryLevel,
                DistanceGoal = Math.Round(Math.Sqrt(Math.Pow(payLoad.X - X, 2) + Math.Pow(payLoad.Y - Y, 2)), 2),
                RobotId = RobotId
            };
        }
    }
}
