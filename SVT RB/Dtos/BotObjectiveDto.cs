using SVT_RB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_RB.Dtos
{
    /// <summary>
    /// Bot Objective Dto
    /// </summary>
    public class BotObjectiveDto
    {
        /// <summary>
        /// Robot Id
        /// </summary>
        public int RobotId { get; set; }

        /// <summary>
        /// Distance Goal
        /// </summary>
        public double DistanceGoal { get; set; }


        /// <summary>
        /// BatteryLevel
        /// </summary>
        public int BatteryLevel { get; set; }

    }
}
