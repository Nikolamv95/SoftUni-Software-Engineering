using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebProjectExample.Filters;

namespace WebProjectExample.Controllers
{
    //This filter is registered as attribute and it will works only for this controller
    //[AddHeaderActionFilter]

    //If we have constructor (dependency container) and we want to return data with the attribute we have to use
    [TypeFilter(typeof(AddHeaderActionFilterAttribute))]
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> Logger;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache cacheService;

        public InfoController(ILogger<InfoController> logger, IMemoryCache memoryCache, IDistributedCache cacheService)
        {
            this.Logger = logger;
            this.memoryCache = memoryCache;
            this.cacheService = cacheService;
        }

        //This filter is registered as attribute and it will works only for this action
        //[AddHeaderActionFilter]
        public IActionResult Time()
        {
            // 1234 is random number written by us to specify the information
            this.Logger.LogInformation(12334, "User asked for the time");
            try
            {
                //return this.Content(DateTime.Now.ToLongTimeString());


                // If the value is not found in the cache we take the needed data and save it in to the cache
                if (!memoryCache.TryGetValue<DateTime>("DateTime", out var cacheTime))
                {
                    // the name in TryGetValue "DateTime" and the name in Set "DateTime" should be similar this is the name of the cache
                    cacheTime = this.GetData();

                    //All seconds are manageable

                    // Keep the cache info 20 seconds
                    memoryCache.Set("DateTime", cacheTime, TimeSpan.FromSeconds(20));

                    // Keep the cache for 2 seconds after the user stop refreshing the information
                    memoryCache.Set("DateTime", cacheTime, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = new TimeSpan(0, 0, 2),
                    });
                }


                return this.Content(DateTime.Now.ToLongTimeString() + $" --Cache: {cacheTime}");

            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, "Second message optional");
                throw new Exception(ex.Message);
            }

        }

        private DateTime GetData()
        {
            Thread.Sleep(5000);
            var cacheTime = DateTime.Now;
            return cacheTime;
        }

        public async Task<IActionResult> Date()
        {
            var dataAsString = await this.cacheService.GetStringAsync("DateTimeInfo");
            DateTime data;

            if (dataAsString == null)
            {
                data = this.GetData();
                await this.cacheService
                    .SetStringAsync("DateTimeInfo", JsonConvert.SerializeObject(data), new DistributedCacheEntryOptions
                {
                    SlidingExpiration = new TimeSpan(0,0,10),
                });
            }
            else
            {
                data = JsonConvert.DeserializeObject<DateTime>(dataAsString);
            }

            return this.Content(data.ToString());
        }
    }
}
