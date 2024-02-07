using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class DelphiDetectRule
    {

        public static string Process(XmlDocument ExperianXMLData)
        {
            int MaxRuleNumber = Utilities.Config.GetIntConfigValue("DelphiDetect.MaxRuleNumber");

            string GetAllowedRules = Utilities.Config.GetStringConfigValue("DelphiDetect.AllowedRules");
            List<string> allowedRulesToList = new List<string>(GetAllowedRules.Split(','));

            List<int> AllYesRules = new List<int>();

            var RuleIndicator = ExperianXMLData.GetElementsByTagName("RuleIndicator");

            //get all innertext into array
            foreach(XmlNode rule in  RuleIndicator)
                AllYesRules.Add(Convert.ToInt32(rule.InnerText));

            StringBuilder sb = new StringBuilder();

            for (int i= 1; i<= MaxRuleNumber; i++)
            {
                var RuleExists = AllYesRules.Exists(e => e == i);
                var IsAllowed = allowedRulesToList.Exists(e => e == i.ToString());
                string nodename = "All_Det" + i.ToString() + "__c";

                if (RuleExists && IsAllowed)
                {
                    var s = "<" + nodename + ">Y</" + nodename + ">";
                    sb.Append(s);
                }                
            }

            return sb.ToString();
        }
    }

}