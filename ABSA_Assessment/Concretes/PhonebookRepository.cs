using ABSA_Assessment.Interfaces;
using ABSA_Assessment.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;

namespace ABSA_Assessment.Concretes
{
    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly string _connectionString;

        public PhonebookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public MessageResponse AddPhonebook(PhonebookViewModel phonebook)
        {
            var query = "procInsertPhoneBook";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            var parameters = new { PhonebookName = phonebook.BookName };

            var rowsAffected = connection.Query(query, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            if (rowsAffected.Rows > 0)
            {
                return new MessageResponse()
                {
                    SuccessResponse = true,
                    ErrorMessage = "Phone book has been added successfully.",
                    NewId = Convert.ToInt32(rowsAffected.NewID)
                };
            }

            return new MessageResponse()
            {
                SuccessResponse = false,
                ErrorMessage = "Phone book could not be added."
            };
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public PhonebookViewModel SelectPhonebook(int? phonebookId)
        {
            var query = "procSelectPhonebook";

            using var connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using var multiResults = connection.QueryMultiple(query, new { PhonebookID = phonebookId });
            var phonebook = multiResults.Read<PhonebookViewModel>().First();
            var phonebookEntries = multiResults.Read<PhonebookEntryViewModel>().ToList();

            if (phonebook != null)
                phonebook.PhonebookEntries = phonebookEntries;

            return phonebook;
        }
    }
}