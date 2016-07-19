using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Http;

namespace ContactsAPI.Repository
{
    [RoutePrefix("api/contacts")]
    public class ContactsRepository
    {
        public const string connectionString = ConfigurationManager.AppSettings["ContactsDAL"];
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;
        SqlParameter parameter = null;

        [Route("get")]
        public IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();

            var one = new Contact()
            {
                Name = "Srinivasan",
                Mobile = 9791166630,
                Relationship = "Self",
                Street = "6F, New mahalipatti Road",
                City = "Madurai",
                State = "TN",
                Country = "IN"
            };
            var two = new Contact()
            {
                Name = "Asvini",
                Mobile = 1236547896,
                Relationship = "Woodbie",
                Street = "Munichalai",
                City = "Madurai",
                State = "TN",
                Country = "IN"
            };
            contacts.Add(one);
            contacts.Add(two);


            return contacts;
        }

        public Contact GetContact(int contactId)
        {
            return new Contact();
        }

        [Route("save")]
        public void SaveContact(Contact contact)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {

                    command = new SqlCommand("sp_addnewcontact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = contact.Name;
                    command.Parameters.Add("@mobile", SqlDbType.Int).Value = contact.Mobile;
                    command.Parameters.Add("@relationship", SqlDbType.VarChar).Value = contact.Relationship;
                    command.Parameters.Add("@street", SqlDbType.VarChar).Value = contact.Street;
                    command.Parameters.Add("@city", SqlDbType.VarChar).Value = contact.City;
                    command.Parameters.Add("@state", SqlDbType.VarChar).Value = contact.State;
                    command.Parameters.Add("@country", SqlDbType.VarChar).Value = contact.Country;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //ex.StackTrace
                }               
            }
        }
    }
}