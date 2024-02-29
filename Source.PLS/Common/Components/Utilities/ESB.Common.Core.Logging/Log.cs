using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace BBB.ESB.Common.Core.Logging
{
    /// <summary>
    /// Helper class to write to Log table
    /// </summary>
    public class Log
    {
        /// <summary>
        /// enum that reflect the data held in table ESBConfig.LogType
        /// </summary>
        public enum LogType
        {
            Debug = 1,  Log = 2, Alert = 3, Warning = 4, Error = 5
        };

        /// <summary>
        /// Used for generating new Process Id for Logging purposes
        /// </summary>
        /// <returns></returns>
        public static string GenerateNewProcessId()
        {
            string s = System.Guid.NewGuid().ToString();
            return s;
        }

        /// <summary>
        /// Write an entry to ESBConfig.Log table
        /// </summary>
        /// <param name="Process"></param>
        /// <param name="Message"></param>
        /// <param name="Type">foreign key to LogType</param>
        /// <param name="ProcessId">guid for process - can be null</param>
        public static void Write(string Process, string Message, LogType Type, string ProcessId)
        {
            //NOT writing to log if Components.IsLogDebug != 1 && type == debug
            if (Config.GetStringConfigValue("Components.IsLogDebug") != "1" && Type == LogType.Debug)
                return;


            //get the machine name
            string server = System.Environment.MachineName;

            using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString ))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Log_Insert";
                    cmd.Parameters.Add(new SqlParameter("Process", Process));
                    cmd.Parameters.Add(new SqlParameter("Message", Message));
                    cmd.Parameters.Add(new SqlParameter("server", server));
                    cmd.Parameters.Add(new SqlParameter("Type", (Type)));
                    cmd.Parameters.Add(new SqlParameter("ProcessId", (ProcessId)));

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    // Fixed BPB-78
                    //Logging framework is made Aysnc
                    System.Diagnostics.EventLog.WriteEntry("BBB.ESB.BTS", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }


        public static void WriteLog(string Process, string Message, string ProcessId)
        {
            Write(Process, Message, LogType.Log, ProcessId);
        }


        public static void WriteDebug(string Process, string Message, string ProcessId)
        {
            System.Diagnostics.Trace.WriteLine(Process + " : [" + ProcessId + "] :" + Message);

            Write(Process, Message, LogType.Debug, ProcessId);
        }

        public static void WriteDebug(string Process, XmlDocument xDoc, string ProcessId)
        {
            System.Diagnostics.Trace.WriteLine(Process + " : [" + ProcessId + "] :" + xDoc.InnerXml);

            Write(Process, xDoc.InnerXml, LogType.Debug, ProcessId);
        }



        public static void WriteError(string Process, string Message, string ProcessId)
        {
            Write(Process, Message, LogType.Error, ProcessId);            
        }


        /// <summary>
        /// This is now deprecated. Please use WriteDebug instead
        /// </summary>
        /// <param name="Process"></param>
        /// <param name="Message"></param>
        /// <param name="ProcessId"></param>
        public static void WriteTrace(string Process, string Message, string ProcessId)
        {
            System.Diagnostics.Trace.WriteLine(Process + " : [" + ProcessId + "] :" + Message);

            Write(Process, Message, LogType.Debug, ProcessId);
        }

        /// <summary>
        /// This is now deprecated. Please use WriteDebug instead
        /// </summary>
        /// <param name="Process"></param>
        /// <param name="xDoc"></param>
        /// <param name="ProcessId"></param>
        public static void WriteTrace(string Process, XmlDocument xDoc, string ProcessId)
        {
            System.Diagnostics.Trace.WriteLine(Process + " : [" + ProcessId + "] :" + xDoc.InnerXml);

            Write(Process, xDoc.InnerXml, LogType.Debug, ProcessId);
        }


    }


}
