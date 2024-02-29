using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;


namespace ESB.BTS.Components.Interface.Utilities
{
    public class DelphiMap
    {    
        private static List<DelphiMap> DelphiMaps = new List<DelphiMap>();

        private string SF, Experian, Type;

        public DelphiMap()
        { }

        /// <summary>
        /// read all the mapping data from table [DelphiMap]
        /// </summary>
        /// <returns></returns>
        public static List<DelphiMap> GetAllDelphiMap (string type)
        {
            lock (DelphiMaps)
            {
                if (DelphiMaps.Count == 0)
                {
                    using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "usp_DelphiMap_GetAllValues";

                            conn.Open();
                            SqlDataReader R = cmd.ExecuteReader();
                            while (R.Read())
                            {
                                DelphiMap I = new Utilities.DelphiMap();
                                I.SF = R["SF"].ToString();
                                I.Experian = R["Experian"].ToString();
                                I.Type = R["Type"].ToString();
                                DelphiMaps.Add(I);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.WriteError("", "DelphiMap.GetAllDelphiMap: " + ex.Message, null);
                            throw ex;
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                                conn.Close();
                        }
                    }
                }
            }

            //only return those that matches type
            var q = from p in DelphiMaps
                    where p.Type == type
                    select p;

            return q.ToList();
        }

        /// <summary>
        /// Extract the inner text of the ExperianXMLData
        /// </summary>
        /// <param name="ExperianXMLData"></param>
        private string ExtractInnerText(XmlDocument ExperianXMLData)
        {            
            string[] names = Experian.Split('.');            
            string rootname = names[0];
            var nodes = ExperianXMLData.GetElementsByTagName(rootname)[0];
            XmlNode thisnode = null;

            for (int i = 1; i < names.Length; i++)
            {
                thisnode = SearchForNode(nodes.ChildNodes, names[i]);
                if (thisnode == null) break; //node not found
                nodes = thisnode;
            }

            if (thisnode != null)
                return thisnode.InnerText;

            //default
            return "";
        }


        /// <summary>
        /// search for node with matching name
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private XmlNode SearchForNode(XmlNodeList nodes, string name)
        {
            if (nodes == null) return null;

            foreach (XmlNode n in nodes)
            {
                if (n.Name == name)
                    return n;
            }

            return null;
        }

        /// <summary>
        /// generate the xml node 
        /// </summary>
        /// <returns></returns>
        private string GenerateSFSoapMsg(XmlDocument ExperianXMLData)
        {
            String InnerText = ExtractInnerText(ExperianXMLData);

            //Changed IndexOf to EndsWith
            //CPB-11 Defect fix
            if (this.Experian.EndsWith("MM") || this.Experian.EndsWith("DD"))
                return "";

            //handle YY
            //Changed IndexOf to EndsWith
            //CPB-11 Defect fix
            if (this.Experian.EndsWith("YY"))
            {
                try
                {
                    //get prefix
                    string[] nodes = this.Experian.Split('.');
                    string prefix = "";
                    for (int i = 0; i < nodes.Length - 1; i++)
                        prefix += nodes[i] + ".";

                    //get MM
                    var MM = (from p in DelphiMaps
                              where p.Experian == prefix + "MM"
                              select p).ToList();

                    //get DD
                    var DD = (from p in DelphiMaps
                              where p.Experian == prefix + "DD"
                              select p).ToList();

                    InnerText = DD[0].ExtractInnerText(ExperianXMLData) + "-" + MM[0].ExtractInnerText(ExperianXMLData) + "-" + InnerText;

                    //return data;
                }
                catch (Exception Ex)
                {
                    Utilities.Log.WriteError("", "Error in DelphiMap.GenerateSFSoapMsg." + Ex.Message, "");
                }

            }

            if (InnerText != null)
                return "<" + this.SF.Replace("YY__c", "__c") + ">" + InnerText + "</" + this.SF.Replace("YY__c", "__c") + ">";
            else
                return "<" + this.SF.Replace("YY__c", "__c") + "/>";

        }

        /// <summary>
        /// Convert Experian IdHub return data (xml) into SF's soap message (Authenticate)
        /// </summary>
        /// <param name="ExperianXMLData"></param>
        /// <returns></returns>
        public static string Process(XmlDocument ExperianXMLData, string type)
        {           
            StringBuilder sb = new StringBuilder();
              
            //loop through each field and extract the innerText            
            foreach (DelphiMap m in GetAllDelphiMap (type))
            {
                //m.ExtractInnerText(ExperianXMLData);
                sb.Append(m.GenerateSFSoapMsg(ExperianXMLData));
            }
            return sb.ToString();


        }
    }
}
