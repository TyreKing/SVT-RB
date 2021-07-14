using SVT_RB.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_RB.ViewModels
{
    /// <summary>
    /// Optimal Bot View Model
    /// </summary>
    public class OptimalBotVM
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
        /// Battery Level
        /// </summary>
        public int BatteryLevel { get; set; }


        /// <summary>
        /// Vm from Dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static OptimalBotVM FromDto(BotObjectiveDto dto)
        {
            return new OptimalBotVM()
            {
                RobotId = dto.RobotId,
                DistanceGoal = dto.DistanceGoal,
                BatteryLevel = dto.BatteryLevel
            };
        }
    }
}
