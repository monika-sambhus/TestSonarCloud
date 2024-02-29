using System;
using System.Linq;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class LogicalGlue
    {
        public static string GetLogicStringFromBinaryData(string binaryData)
        {
            byte[] b = System.Convert.FromBase64String(binaryData);
            return System.Text.Encoding.UTF8.GetString(b);
        }
        public static string GetLogicalGlueIds(string sfTriggerMsg, string idType)
        {
            //var splitArray = sfTriggerMsg.Split('&');
            //return (idType.Equals("ApplicationId")) ? splitArray[1].Substring(14) : splitArray[0].Substring(20);
            
            //Changed the logic to ignore order of parameters
            if (string.IsNullOrEmpty(sfTriggerMsg)) { throw new ArgumentNullException(sfTriggerMsg); }
            if (string.IsNullOrEmpty(idType)) { throw new ArgumentNullException(idType); }

            string idValue = String.Empty;
            var splitArray = sfTriggerMsg.Split('&').ToList();
            if (splitArray.Where(x => x.ToLower().Contains(idType.ToLower())).Count() > 0)
            {
                idValue = splitArray.Where(x => x.ToLower().Contains(idType.ToLower())).FirstOrDefault().Split('=')[1].ToString();
            }

            return idValue;
        }
    }
}
