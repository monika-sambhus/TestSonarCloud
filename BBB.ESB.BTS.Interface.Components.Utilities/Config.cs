using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{


    /// <summary>
    /// Class for accessing pre-config valuee.
    /// </summary>
    public class Config
    {
        private static string Process = "BBB.ESB.BTS.Components.Interface.Utilities.Config";

        // Number of minutes that elapse after the last read before the settings cache expires
        private static int iConfigAgeMins = 10;

        // Settings cache
        private static Dictionary<string, string> _AllConfig;

        // Date/time settings were last read
        private static DateTime _lastRead;

        /// <summary>
        /// Constructor that read in ALL config values
        /// </summary>
        static Config()
        {
            _AllConfig = new Dictionary<string, string>();
            GetAllConfig();
        }

        public static int GetIntConfigValue(string key)
        {
            try
            {
                return GetIntConfigValue(key, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int GetIntConfigValue(string key, int defaultValue)
        {
            try
            {
                var val = GetStringConfigValue(key);
                int valAsInt;
                if (int.TryParse(val, out valAsInt))
                {
                    return valAsInt;
                }

                return defaultValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetStringConfigValue(string key)
        {
            try
            {
               
                if (_lastRead < DateTime.Now.AddMinutes(-iConfigAgeMins))                   
                    GetAllConfig();
                    

                string value = string.Empty;

                if (_AllConfig.ContainsKey(key))
                    value = _AllConfig[key];

              
                
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetStringConfigValue(string key, string value)
        {
            using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_ConfigSetValue";
                    cmd.Parameters.Add(new SqlParameter("key", key));
                    cmd.Parameters.Add(new SqlParameter("value", value));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    //write into key/value set in memory
                    if (_AllConfig.Keys.Contains(key))
                    {
                        _AllConfig[key] = value;
                    }
                    else
                    {
                        _AllConfig.Add(key, value);
                    }

                    Log.WriteDebug(Process, "SetStringConfigValue Key:'" + key + "'. Value:'" + value + "'", null);
                }
                catch (Exception ex)
                {
                    Log.WriteError(Process, "SetStringConfigValue  Key:'" + key + "'. Value:'" + value + "' |" + ex.Message, null);
                    throw ex;
                }
                finally
                {

                    if (conn.State != ConnectionState.Closed)
                        conn.Close();

                }
            }
            
        }

      

        /// <summary>
        /// Read all key/value in Config table
        /// </summary>
        public static void GetAllConfig()
        {
            

            using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_ConfigGetAllValues";

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string key = reader["Key"].ToString();
                        string value = reader["Value"].ToString();

                        if (_AllConfig.Keys.Contains(key))
                        {
                            _AllConfig[key] = value;
                        }
                        else
                        {
                            _AllConfig.Add(key, value);
                        }

                       
                        if (key == "Components.ConfigAgeMins")
                        {
                            int mins = 0;
                            if (!int.TryParse(value, out mins))
                            {
                                mins = 10;
                            }

                            iConfigAgeMins = mins;
                        }
                    }

                    conn.Close();

                    _lastRead = DateTime.Now;
                }
                catch (Exception)
                {                  
                    throw;
                }
                finally
                {
                   
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                   
                }

            }
        }

        

       
    }
}
