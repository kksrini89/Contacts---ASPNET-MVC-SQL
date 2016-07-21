using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ContactsAPI.Repository
{
    /// <summary>
    /// Repository for Contacts
    /// </summary>
    public class ContactRepository
    {
        #region Member Variables

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ContactsDBConnectionString"].ConnectionString;
        private SqlConnection connection = null;
        private SqlCommand command = null;
        //SqlDataAdapter dataAdapter = null;
        private SqlDataReader dataReader = null;

        #endregion

        #region Methods

        /// <summary>
        /// Get a contact for the given Id
        /// </summary>
        /// <param name="contactId">Id input</param>
        /// <returns>Existing Contact</returns>
        public Contact GetContact(int contactId)
        {
            var contact = new Contact();
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("SELECT * FROM dbo.Contact WHERE ID = " + contactId, connection);
                    command.Parameters.AddWithValue("@contactId", contactId);
                    dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            contact.Id = Int32.Parse(dataReader["ID"].ToString());
                            contact.Name = (string)dataReader["Name"];
                            contact.MobileNumber = Int64.Parse(dataReader["Mobile"].ToString());
                            contact.Relationship = (string)dataReader["Relationship"];
                            contact.City = (string)dataReader["Street"];
                            contact.State = (string)dataReader["City"];
                            contact.Country = (string)dataReader["State"];
                            contact.Street = (string)dataReader["Country"];
                        }
                    }
                    return contact;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Retrieve all contacts
        /// </summary>
        /// <returns>List of contacts</returns>
        public IEnumerable<Contact> GetContacts()
        {
            var contactsList = new List<Contact>();
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("sp_GetAllContacts", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var contact = new Contact();
                            contact.Id = Int32.Parse(dataReader["Id"].ToString());
                            contact.Name = (string)dataReader["Name"];
                            contact.MobileNumber = Int64.Parse(dataReader["Mobile"].ToString());
                            contact.Relationship = (string)dataReader["Relationship"];
                            contact.City = (string)dataReader["Street"];
                            contact.State = (string)dataReader["City"];
                            contact.Country = (string)dataReader["State"];
                            contact.Street = (string)dataReader["Country"];
                            contactsList.Add(contact);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return contactsList;
        }

        /// <summary>
        /// Save a new contact
        /// </summary>
        /// <param name="newContact">Object to be added</param>
        /// <returns></returns>
        public string SaveContact(Contact newContact)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_AddContact";
                    command.Parameters.AddWithValue("@NAME", newContact.Name);
                    command.Parameters.AddWithValue("@MOBILE", newContact.MobileNumber);
                    command.Parameters.AddWithValue("@RELATIONSHIP", newContact.Relationship);
                    command.Parameters.AddWithValue("@STREET", newContact.Street);
                    command.Parameters.AddWithValue("@CITY", newContact.City);
                    command.Parameters.AddWithValue("@STATE", newContact.State);
                    command.Parameters.AddWithValue("@COUNTRY", newContact.Country);
                    //dataAdapter = new SqlDataAdapter(command);
                    //DataSet set = new DataSet();
                    //dataAdapter.Fill(set);                   
                    var affectedRowsCount = command.ExecuteNonQuery();
                    if (affectedRowsCount > 0)
                    {
                        return "Success";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return "Failure";
        }

        /// <summary>
        /// Update an existing contact
        /// </summary>
        /// <param name="Id">Id input</param>
        /// <param name="existContact">Object to be updated</param>
        public void UpdateContact(int Id, Contact existContact)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("sp_UpdateContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@NAME", existContact.Name);
                    command.Parameters.AddWithValue("@MOBILE", existContact.MobileNumber);
                    command.Parameters.AddWithValue("@RELATIONSHIP", existContact.Relationship);
                    command.Parameters.AddWithValue("@STREET", existContact.Street);
                    command.Parameters.AddWithValue("@CITY", existContact.City);
                    command.Parameters.AddWithValue("@STATE", existContact.State);
                    command.Parameters.AddWithValue("@COUNTRY", existContact.Country);
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Delete existing contact
        /// </summary>
        /// <param name="Id">Id</param>
        public void DeleteContact(int Id)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("sp_DeleteContact", connection);
                    command.Parameters.AddWithValue("@id", Id);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion
    }
}