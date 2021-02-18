using System;
using ABSA_Assessment.Interfaces;
using ABSA_Assessment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABSA_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : Controller
    {
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IEntryRepository _entryRepository;

        public PhonebookController(IPhonebookRepository phonebookRepository, IEntryRepository entryRepository)
        {
            _phonebookRepository = phonebookRepository;
            _entryRepository = entryRepository;
        }

        [HttpGet]
        [Route("{phonebookId}")]
        public IActionResult SelectPhonebook(Guid phonebookId)
        {
            var book = _phonebookRepository.SelectPhonebook(phonebookId);
            return Json(book);
        }

        [HttpGet]
        [Route("Entries/{phonebookId}")]
        public IActionResult SelectPhonebookEntries(Guid phonebookId)
        {
            var entries = _entryRepository.SelectPhoneBookEntries(phonebookId);
            return Json(entries);
        }

        [HttpPost]
        [Route("Books")]
        public IActionResult AddPhonebook(PhonebookViewModel phonebook)
        {
            var message = _phonebookRepository.AddPhonebook(phonebook);
            return Json(message);
        }

        [HttpPost]
        [Route("Entries")]
        public IActionResult AddPhonebookEntry(PhonebookEntryViewModel entry)
        {
            var message = _entryRepository.AddPhonebookEntry(entry);
            return Json(message);
        }
    }
}