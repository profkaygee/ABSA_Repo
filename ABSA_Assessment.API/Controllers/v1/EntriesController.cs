using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ABSA_Assessment.Application.Commands;
using ABSA_Assessment.Application.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using ABSA_Assessment.Mappings;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ABSA_Assessment.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [EnableCors("AllowAllPolicy")]
    public class EntriesController : BaseApiController
    {
        private readonly IMemoryCache _memoryCache;

        public EntriesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("{phonebookId}")]
        [ProducesResponseType(typeof(Entry), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SelectPhonebookEntries(Guid phonebookId)
        {
            if (_memoryCache.TryGetValue(ConstantKeys.PhonebookEntriesKey, out IList<Entry> entries))
            {
                return Ok(entries);
            }

            // Set the cache options here and then add the value to cache.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            entries = await Mediator.Send(new SelectPhonebookEntriesQuery(phonebookId));
            _memoryCache.Set(ConstantKeys.PhonebookEntriesKey, entries, cacheOptions);
            return Ok(entries);
        }

        [HttpGet]
        [Route("search/{searchPhrase}")]
        [ProducesResponseType(typeof(Entry), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SearchPhonebookEntry(string searchPhrase)
        {
            if (_memoryCache.TryGetValue(ConstantKeys.PhonebookEntriesKey, out IList<Entry> entries))
            {
                entries = entries.Where(x => x.Name.ToLower().Contains(searchPhrase.ToLower())).ToList();
                return Ok(entries);
            }

            // Set the cache options here and then add the value to cache.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            entries = await Mediator.Send(new SearchPhonebookEntriesQuery(searchPhrase));
            _memoryCache.Set(ConstantKeys.PhonebookEntriesKey, entries, cacheOptions);

            entries = entries.Where(x => x.Name.ToLower().Contains(searchPhrase.ToLower())).ToList();
            return Ok(entries);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPhonebookEntry(Entry entry)
        {
            // Set the cache options here and then add the value to cache.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            var response = await Mediator.Send(new AddPhonebookEntryCommand(entry));
            _memoryCache.Set(ConstantKeys.PhonebookEntriesKey, response, cacheOptions);
            return Ok(response);
        }
    }
}