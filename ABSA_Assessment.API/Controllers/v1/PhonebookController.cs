using ABSA_Assessment.Application.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using ABSA_Assessment.Mappings;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net;
using System.Threading.Tasks;
using ABSA_Assessment.Application.Commands;

namespace ABSA_Assessment.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [EnableCors("AllowAllPolicy")]
    public class PhonebookController : BaseApiController
    {
        private readonly IMemoryCache _memoryCache;

        public PhonebookController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Phonebook), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SelectPhonebook()
        {
            if (_memoryCache.TryGetValue(ConstantKeys.PhonebookKey, out Phonebook phonebook))
            {
                return Ok(phonebook);
            }

            // Set the cache options here and then add the value to cache.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            phonebook = await Mediator.Send(new SelectPhonebookQuery());
            _memoryCache.Set(ConstantKeys.PhonebookKey, phonebook, cacheOptions);
            return Ok(phonebook);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPhonebook(Phonebook phonebook)
        {
            // Set the cache options here and then add the value to cache.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            var response = await Mediator.Send(new AddPhonebookCommand(phonebook));
            _memoryCache.Set(ConstantKeys.PhonebookKey, response, cacheOptions);
            return Ok(phonebook);
        }
    }
}