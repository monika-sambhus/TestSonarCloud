using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class IdHubMap
    {
        public static string Prefix = "eih:";

        private static List<IdHubMap> IdHubAuthMaps = new List<IdHubMap>();

        //Defined to serlise, static variables
        public List<IdHubMap> IdHubAuthMaps_Serialize { get { return IdHubAuthMaps; } }

        private string SFFieldName, ExperianFieldName, Type;

        public IdHubMap()
        { }

        /// <summary>
        /// Extract the inner text of the ExperianXMLData
        /// </summary>
        /// <param name="ExperianXMLData"></param>
        private string ExtractInnerText(XmlDocument ExperianXMLData)
        {
            //ProcessConfigResultsBlock.EIAResults.ReturnedHRP.HighRiskPolRuleID

            string prefix = Prefix;

            string[] names = ExperianFieldName.Split('.');

            if (names[0] == "EIHHeader")
                prefix = "header:";

            string rootname = prefix + names[0];

            var nodes = ExperianXMLData.GetElementsByTagName(rootname)[0];

            XmlNode thisnode = null;

            for (int i = 1; i < names.Length; i++)
            {
                thisnode = SearchForNode(nodes.ChildNodes, prefix + names[i]);
                if (thisnode == null) break; //node not found
                nodes = thisnode;
            }

            if (thisnode != null)
                return thisnode.InnerText;

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

            if (InnerText != null)
                return "<" + this.SFFieldName + ">" + InnerText + "</" + this.SFFieldName + ">";
            else
                return null;
        }

        /// <summary>
        /// read all the mapping data from table [IdHub_AuthMap]
        /// </summary>
        /// <returns></returns>
        private static List<IdHubMap> GetAllIdHubMaps(string type)
        {
            lock (IdHubAuthMaps)
            {
                if (IdHubAuthMaps.Count == 0)
                {
                    using (SqlConnection conn = new SqlConnection(ESBConfig.ConnectionString))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "usp_IdHubMap_GetAllValues";

                            conn.Open();
                            SqlDataReader R = cmd.ExecuteReader();
                            while (R.Read())
                            {
                                IdHubMap I = new Utilities.IdHubMap();
                                I.SFFieldName = R["SFFieldName"].ToString();
                                I.ExperianFieldName = R["ExperianFieldName"].ToString();
                                I.Type = R["Type"].ToString();
                                IdHubAuthMaps.Add(I);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.WriteError("", "IdHubMap.AllIdHubAuthMaps: " + ex.Message, null);
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
            var q = from p in IdHubAuthMaps
                    where p.Type == type
                    select p;


            return q.ToList();
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
            foreach (IdHubMap m in GetAllIdHubMaps(type))
            {
                //m.ExtractInnerText(ExperianXMLData);
                sb.Append(m.GenerateSFSoapMsg(ExperianXMLData));
            }

            return sb.ToString();


        }

    }
}
