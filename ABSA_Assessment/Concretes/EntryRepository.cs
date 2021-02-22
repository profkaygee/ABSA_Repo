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

        public IList<PhonebookEntryViewModel> SelectPhoneBookEntries(int? phonebookId)
        {
            var query = "procSelectPhonebookEntries";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            var parameters = new { PhonebookID = phonebookId };
            var entries = connection.Query<PhonebookEntryViewModel>(query, parameters, commandType: CommandType.StoredProcedure).ToList();
            return entries;
        }

        public MessageResponse AddPhonebookEntry(PhonebookEntryViewModel entry)
        {
            var query = "procInsertPhoneBookEntry";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            var parameters = new { Name = entry.Name, PhoneNumber = entry.PhoneNumber, PhonebookID = entry.PhonebookId };
            var rowsAffected = connection.Query(query, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            if (rowsAffected.Rows > 0)
            {
                return new MessageResponse()
                {
                    NewId = Convert.ToInt32(rowsAffected.NewID),
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

        public IList<PhonebookEntryViewModel> SelectSearchedEntries(string phrase)
        {
            var query = "procSelectSearchedPhonebookEntries";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            var parameters = new { Phrase = phrase };
            var entries = connection.Query<PhonebookEntryViewModel>(query, parameters, commandType: CommandType.StoredProcedure).ToList();
            return entries;
        }
    }
}
