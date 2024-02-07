using System;
using System.Data;
using System.Data.SqlClient;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public static class CRMContactHelper
    {
        private static string Process = "BBB.ESB.BTS.Components.Interface.Utilities.Config";

        public static string GetContactsById(int applicantCRMContactId)
        {
            string salesforceContactId = string.Empty;

            using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_CRMGetAllContacts";

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string CRMContactId = reader["Applicant_CRM_Id__c"].ToString();
                        if (CRMContactId.Equals(applicantCRMContactId.ToString()))
                        {
                            salesforceContactId = reader["ContactId"].ToString();
                            break;
                        }
                    }

                    conn.Close();                    
                }
                catch (Exception ex)
                {
                    Log.WriteError(Process, "GetContactsById Exception: " + ex.ToString(), null);
                    throw;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    Log.WriteDebug(Process, "GetContactsById completed. ", null);
                }                
                return (string.IsNullOrEmpty(salesforceContactId) ? "0" : salesforceContactId);
            }
        }

        public static int InsertContactDetails(string crmContactId, string salesforceContactId)
        {
            int rowsReturned = 0;
            using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_CRMAddContact";
                    cmd.Parameters.Add(new SqlParameter("@CRMContactId", crmContactId));
                    cmd.Parameters.Add(new SqlParameter("@SalesforceContactId", salesforceContactId));

                    conn.Open();

                    rowsReturned = cmd.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    Log.WriteError(Process, "InsertContactDetails Exception: " + ex.ToString(), null);
                    throw ex;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    Log.WriteDebug(Process, "InsertContactDetails completed. ", null);
                }
                return rowsReturned;
            }
        }
    }
}
