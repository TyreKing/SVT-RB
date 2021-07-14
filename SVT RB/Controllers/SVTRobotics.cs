using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SVT_RB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SVT_RB.ViewModels;

namespace SVT_RB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SVTRobotics : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();


        /**
         * The solution below was not as fun to make but did provide the best results 
         */

        /// <summary>
        /// Gets the Most Optimal Bot to retrieve the payload.
        /// best for just getting to the pay load the quickest making distance a priority with batterylevel sencond.
        /// </summary>
        /// <param name="loadId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OptimalBotVM>> OptimalUsingLinq(int loadId, int x, int y)
        {
            var payload = PayLoad.Create(loadId, x, y);
            var responseString = await client.GetStringAsync(" https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
            var robots = JsonConvert.DeserializeObject<List<Robot>>(responseString);
            var botData = robots.Select(x => x.ToDto(payload))
                .OrderBy(x => x.DistanceGoal)
                .ThenByDescending(x => x.BatteryLevel)
                .FirstOrDefault();
            return Ok(OptimalBotVM.FromDto(botData));
        }



        /**
         * This one was fun to play around with 
         * Gets the average minimum, so not the closest nor the most battery life but It was fun to make.
         * Can be useful the payload has to be moved to a further place (more battery life to move around)
         */

        /// <summary>
        /// Gets the "average minimum" Bot to get the payload
        /// </summary>
        /// <param name="loadId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult<OptimalBotVM>> RecursiveBot(int loadId, int x, int y)
        //{
        //    var payload = PayLoad.Create(loadId, x, y);
        //    var responseString = await client.GetStringAsync(" https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
        //    var robots = JsonConvert.DeserializeObject<List<Robot>>(responseString);
        //    var botData = robots.Select(x => x.ToDto(payload)).Select(x => OptimalBotVM.FromDto(x)).ToList();
        //    var firstbot = botData.First(x => x.DistanceGoal == botData.Min(x => x.DistanceGoal));
        //    var batterAvg = botData.Average(x => x.BatteryLevel);
        //    var distanceAvg = botData.Average(x => x.DistanceGoal);
        //    botData.Remove(firstbot);
        //    var result = RecursiveHelper(firstbot, botData, distanceAvg, batterAvg);
        //    return Ok(result);
        //}

        //private OptimalBotVM RecursiveHelper(OptimalBotVM bot, List<OptimalBotVM> optimalBots, double distanceAvg, double batterAvg)
        //{
        //    var possibleBots = optimalBots.Where(x => x.BatteryLevel >= bot.BatteryLevel &&
        //    x.BatteryLevel != 0 && x.DistanceGoal <= distanceAvg && x.BatteryLevel <= batterAvg).ToList();

        //    if (null != possibleBots && possibleBots.Any())
        //    {
        //        bot = possibleBots.First(x => x.DistanceGoal == possibleBots.Min(x => x.DistanceGoal));
        //        batterAvg = possibleBots.Average(x => x.BatteryLevel);
        //        distanceAvg = possibleBots.Average(x => x.DistanceGoal);
        //        possibleBots.Remove(bot);
        //        RecursiveHelper(bot, possibleBots, distanceAvg, batterAvg);
        //    }
        //    return bot;
        //} 



        /**
         * This would give the best result
         * But it is entensive and not the quickest
         * Ran out of time
         */

        //[HttpPost]
        //public async Task<ActionResult<OptimalBotVM>> BruteForceBot(int loadId, int x, int y)
        //{
        //    var payload = PayLoad.Create(loadId, x, y);
        //    var responseString = await client.GetStringAsync(" https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
        //    var robots = JsonConvert.DeserializeObject<List<Robot>>(responseString);
        //    var botData = robots.Select(x => x.ToDto(payload));

        //        /**
        //         * Compare each bot against eachother to find the best possible bot
        //         * for(botData)
        //         *    for(botData)
        //         *  
        //         *  nested for loop to compare each bot
        //         */
        //    return Ok();
        //}

    }
}
