using ABSA_Assessment.Interfaces;
using ABSA_Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ABSA_Assessment.Concretes
{
    public class EntryRepository : IEntryRepository
    {
        private readonly string _connectionString;

        public EntryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IList<PhonebookEntryViewModel> SelectPhoneBookEntries(Guid phonebookId)
        {
            var query = "procSelectPhonebookEntries";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            var entries = connection.Query<PhonebookEntryViewModel>(query, new {PhonebookID = phonebookId}).ToList();
            return entries;
        }

        public MessageResponse AddPhonebookEntry(PhonebookEntryViewModel entry)
        {
            var query = "procInsertPhoneBookEntry";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            int rowsAffected = connection.Query(query).FirstOrDefault();

            if (rowsAffected > 0)
            {
                return new MessageResponse()
                {
                    SuccessResponse = true,
                    ErrorMessage = "Phone book entry has been added successfully."
                };
            }

            return new MessageResponse()
            {
                SuccessResponse = false,
                ErrorMessage = "Phone book entry could not be added."
            };
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
