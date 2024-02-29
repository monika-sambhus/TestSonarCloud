
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class IdHubCategoryData
    {
        /// <summary>
        /// Mapping from Experian TO SF
        /// </summary>
        /// <returns></returns>
        private static List<IdHubCategoryData> GetAllIdHubCategoryDatas()
        {
            List<IdHubCategoryData> IdHubCategoryDatas = new List<Utilities.IdHubCategoryData>();
            IdHubCategoryDatas.Add(new IdHubCategoryData("Category_Text__c", "CategoryText"));
            IdHubCategoryDatas.Add(new IdHubCategoryData("Category_Type__c", "CategoryType"));
            IdHubCategoryDatas.Add(new IdHubCategoryData("Num_Cat_Data_Items__c", "NumCatDataItems"));
            IdHubCategoryDatas.Add(new IdHubCategoryData("Num_Cat_Data_Sources__c", "NumCatDataSources"));
            IdHubCategoryDatas.Add(new IdHubCategoryData("Start_Date_Oldest_Cat__c", "StartDateOldestCat"));

            return IdHubCategoryDatas;
        }


        private string SF, Experian, InnerText;

        public IdHubCategoryData()
        { }

        private IdHubCategoryData(string sf, string exp)
        {
            SF = sf;
            Experian = exp;
        }





        public static string Process(XmlDocument xdoc, string path, string Authenticate_Result__c, string Section__c)
        {
            string output = "";

            string[] names = path.Split('.');
            string prefix = "eih:";

            var nodes = xdoc.GetElementsByTagName(prefix + names[0])[0];

            XmlNode thisnode = null;
            XmlNode parent = null;

            for (int i = 1; i < names.Length; i++)
            {
                parent = thisnode;
                thisnode = SearchForNode(nodes.ChildNodes, prefix + names[i]);
                if (thisnode == null) break; //node not found
                nodes = thisnode;
            }


            if (thisnode != null)   //found parent with CategoryData node
            {
                foreach (XmlNode n in parent.ChildNodes)
                {
                    if (n.LocalName == "CategoryData")
                    {
                        var result = ProcessCategoryData(n);
                        var soap = GenerateSFMsg(result, Authenticate_Result__c, Section__c);
                        output += soap;
                    }

                }
            }
            return output;

        }

        private static XmlNode SearchForNode(XmlNodeList nodes, string name)
        {
            if (nodes == null) return null;

            foreach (XmlNode n in nodes)
            {
                if (n.Name == name)
                    return n;
            }

            return null;
        }

        private static List<IdHubCategoryData> ProcessCategoryData(XmlNode CategoryData)
        {
            List<IdHubCategoryData> IdHubCategoryDatas = GetAllIdHubCategoryDatas();

            foreach (XmlNode n in CategoryData.ChildNodes)
            {
                var q = (from p in IdHubCategoryDatas
                         where p.Experian == n.LocalName
                         select p).ToList();

                if (q.Count > 0)
                {
                    q[0].InnerText = n.InnerText.TrimEnd();
                }

            }

            return IdHubCategoryDatas;

        }

        private static string GenerateSFMsg(List<IdHubCategoryData> datas, string Authenticate_Result__c, string Section__c)
        {
            //Category_Data__c.Category_Text__c

            StringBuilder sb = new StringBuilder();
            sb.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            sb.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Category_Data__c</type>");
            // sb.Append("<sObjects xsi:type='urn1:Category_Data__c'>");
            sb.Append("<Authenticate_Result__c>");
            sb.Append(System.Security.SecurityElement.Escape(Authenticate_Result__c));
            sb.Append("</Authenticate_Result__c>");
            if (Section__c.CompareTo("LocAtPloc") != 0)
            {
                sb.Append("<Section__c>");
                sb.Append(System.Security.SecurityElement.Escape(Section__c));
                sb.Append("</Section__c>");
            }

            foreach (IdHubCategoryData d in datas)
            {
                //BPB-80 - Fixed
                if (d.InnerText == null) { d.InnerText = ""; }
                string s = "<" + d.SF + ">" + System.Security.SecurityElement.Escape(d.InnerText.Trim()) + "</" + d.SF + ">";
                sb.Append(s);
            }
            sb.Append("</sObjects>");

            return sb.ToString();
        }

    }
}
