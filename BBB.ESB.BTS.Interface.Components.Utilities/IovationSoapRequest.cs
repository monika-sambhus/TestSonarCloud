using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{

    public class IovationSoapRequest
    {
        private List<System.Xml.XmlElement> xElements;

        public string enduserip, beginblackbox, type, accountcode;

        private string Application__c, Contact__c;


        private List<Mapper> MapList = new List<Mapper>();

        /// <summary>
        /// Constructor
        /// </summary>
        public IovationSoapRequest(System.Xml.XmlElement[] xEle)
        {
            this.xElements = xEle.ToList();
            this.enduserip = GetElementInnerText("End_User_IP__c");
            this.beginblackbox = GetElementInnerText("Begin_Black_Box__c");
            this.type = GetElementInnerText("Type__c");


            this.Application__c = GetElementInnerText("Application__c");
            this.Contact__c = GetElementInnerText("Contact__c");
            
            this.accountcode = this.Contact__c;


            ConfigureMapper();


            //extract the Contact__r element from xElements
            var Contact_R = xElements.Find(delegate (System.Xml.XmlElement e)
            {
                return e.LocalName == "Contact__r";
            });

            if (Contact_R != null)
            {
                var children = Contact_R.ChildNodes;

                //loop through all the children of Contact_R in order to update the "value" field of all the Mapper in MapList
                for (int i = 0; i < children.Count; i++)
                {
                    var c = children[i];
                    var mapp = MapList.Find(delegate (Mapper m)
                    {
                        return m.SourceFieldName == c.LocalName;
                    });
                    if (mapp != null)
                    {
                        mapp.Value = c.InnerText;
                    }
                }

            }



        }


        /// <summary>
        /// Get the inner text of an element from xElements whose LocalName matches the supplied name
        /// </summary>
        /// <param name="localname">LocalName of the element to search for</param>
        /// <returns></returns>
        private string GetElementInnerText(string localname)
        {
            string value = null;

            var q = xElements.Find(delegate (System.Xml.XmlElement e)
            {
                return e.LocalName == localname;
            });

            if (q != null)
                value = q.InnerText;

            return value;

        }


        /// <summary>
        /// This is where fields in Iovation_Result__c.Contact__r.XXX is mapped to IovationRequest
        /// </summary>
        private void ConfigureMapper()
        {

            MapList = new List<Mapper>();



            AppendToMapList("MailingCity", "BillingCity", null);
            AppendToMapList("MailingState", "BillingRegion", null);
            AppendToMapList("MailingCountry", "BillingCountry", null);
            AppendToMapList("OtherCity", "ShippingCity", null);
            AppendToMapList("OtherState", "ShippingRegion", null);
            AppendToMapList("OtherCountry", "ShippingCountry", null);
            AppendToMapList("", "ValueAmount", null);
            AppendToMapList("", "ValueCurrency", null);
            AppendToMapList("", "SKU", null);
            AppendToMapList("", "UPC", null);
            AppendToMapList("", "CreditCardBin", null);
            AppendToMapList("Id", "eventId", null);
            AppendToMapList("", "billingShippingMismatch", null);
            AppendToMapList("", "emailVerified", null);
            AppendToMapList("", "mobilePhoneVerified", null);
            AppendToMapList("", "mobilePhoneSmsEnabled", null);
            AppendToMapList("", "homePhoneVerified", null);
            AppendToMapList("", "homePhoneSmsEnabled", null);
            AppendToMapList("", "officePhoneVerified", null);
            AppendToMapList("", "officePhoneSmsEnabled", null);
            AppendToMapList("", "serviceId", null);
            AppendToMapList("", "referrerUrl", null);
            AppendToMapList("FirstName", "firstName", null);
            AppendToMapList("LastName", "lastName", null);
            AppendToMapList("Email", "Email", null);

        }

        /// <summary>
        /// Create a Mapper object and append to MapList. Only used by the method ConfigureMapper
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        private void AppendToMapList(string source, string target, string value)
        {
            Mapper m = new Mapper(source, target, value);
            MapList.Add(m);
        }

        public string Txn_Properties()
        {
            string nspc = "ns0";
            StringBuilder body = new StringBuilder();

            //header
            body.Append("<" + nspc + ":txn_properties>");


            foreach (Mapper m in MapList)
            {
                body.Append("<" + nspc + ":property>");
                body.Append("<" + nspc + ":name>" + m.TargetFieldName + "</" + nspc + ":name>");
                body.Append("<" + nspc + ":value>" + m.Value + "</" + nspc + ":value>");
            }

            //footer
            body.Append("</" + nspc + ":txn_properties>");


            string s = body.ToString();

            return s;

        }

        public static IovationSoapRequest LoadData(System.Xml.XmlElement[] xElements)
        {

            IovationSoapRequest m = new IovationSoapRequest(xElements);
            return m;


        }





    }

    public class Mapper
    {
        public string SourceFieldName, TargetFieldName, Value;

        public Mapper(string source, string target, string value)
        {
            SourceFieldName = source;
            TargetFieldName = target;
            Value = value;
        }
    }

}
