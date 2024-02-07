namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class SalesForce
    {
        public static string GetLoginSoapRequest()
        {
            string loginsoaprequest = "<ns0:login xmlns:ns0='urn:partner.soap.sforce.com' xmlns:ns1='urn:sobject.partner.soap.sforce.com'><ns0:username>[username]</ns0:username><ns0:password>[password]</ns0:password></ns0:login>";

            string UserName = Config.GetStringConfigValue("SalesForce.UserName");
            string Password = Config.GetStringConfigValue("SalesForce.Password");


            loginsoaprequest = loginsoaprequest.Replace("[username]", UserName);
            loginsoaprequest = loginsoaprequest.Replace("[password]", Password);

            return loginsoaprequest;

        }

        public static string GetQueryAllSoapRequest(string queryString)
        {
            string req = "<ns0:queryAll xmlns:ns0='urn:partner.soap.sforce.com' xmlns:ns1='urn:sobject.partner.soap.sforce.com'><ns0:queryString>[queryString]</ns0:queryString></ns0:queryAll>";

            req = req.Replace("[queryString]", queryString);


            return req;

        }

        public static string GetQueryAllContact(string SearchId)
        {
            string req = Config.GetStringConfigValue("SalesForce.QueryAll.Contact");

            req = req.Replace("SearchId", SearchId);

            return req;

        }

        public static string GetQueryAllUser(string SearchId)
        {
            string req = Config.GetStringConfigValue("SalesForce.QueryAll.User");

            req = req.Replace("SearchId", SearchId);

            return req;

        }

        public static string GetQueryAllIovation(string SearchId)
        {
            string req = Config.GetStringConfigValue("SalesForce.QueryAll.Iovation");

            req = req.Replace("SearchId", SearchId);

            return req;

        }

      

        public static string GetQueryAllExperianIDHub(string SearchId)
        {
            string req = Config.GetStringConfigValue("SalesForce.QueryAll.Experian.IDHub");

            req = req.Replace("SearchId", SearchId);

            return req;

        }
    }
}
