using System;
using System.Text;
using System.Net.Mail;
using System.Reflection;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public static class SMTP
    {
        public static string EmailNewLine
        {
            get
            {
                return @"<BR/>";
            }
        }

        /// <summary>
        /// Wrapper to send Object
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="objEmailAlert"></param>
        public static void SendErrorEmail(string Subject, EmailAlert objEmailAlert)
        {
            SendErrorEmail(Subject, ClassToTable(objEmailAlert));
        }
        /// <summary>
        /// Covert object table format
        /// </summary>
        /// <param name="objEmailAlert"></param>
        /// <returns></returns>
        private static string ClassToTable(EmailAlert objEmailAlert)
        {
            StringBuilder sObject = new StringBuilder();
            sObject.Append("<table>");
            foreach (FieldInfo info in objEmailAlert.GetType().GetFields())
            {
                if (!System.String.IsNullOrEmpty(info.GetValue(objEmailAlert).ToString()))
                {
                    sObject.Append("<tr>");
                    sObject.Append("<td>" + info.Name + "</td>");
                    sObject.Append("<td>:</td>");
                    sObject.Append("<td>" + info.GetValue(objEmailAlert) + "</td>");
                    sObject.Append("</tr>");
                }
            }
            sObject.Append("</table>");

            return sObject.ToString();
        }


        /// <summary>
        /// Send HTML email
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        public static void SendErrorEmail(string Subject, string Body)
        {
            string ToAddress = Utilities.Config.GetStringConfigValue("SMTP.ErrorEmailAddress");


            String userName = Utilities.Config.GetStringConfigValue("SMTP.UserName");
            String password = Utilities.Config.GetStringConfigValue("SMTP.Password");
            MailMessage msg = new MailMessage();


            foreach (string s in ToAddress.Split(';'))
            {
                //Fixed extra semi colon issue
                if(!string.IsNullOrEmpty(s))
                msg.To.Add(s);
            }

            msg.From = new MailAddress(Utilities.Config.GetStringConfigValue("SMTP.FromAddress"));
            msg.Subject = Utilities.Config.GetStringConfigValue("SMTP.SubjectStatus") + " " + Subject;
            msg.Body = Body + EmailNewLine + EmailNewLine;
            msg.IsBodyHtml = true;

            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = Utilities.Config.GetStringConfigValue("SMTP.Host");
                client.Credentials = new System.Net.NetworkCredential(userName, password);
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                Utilities.Log.WriteError("SMTP.SendErrorEmail", "Encountered error sending email. " + ex.Message, "");

            }
        }
    }

    [Serializable]
    public class EmailAlert
    {
        public string IntegrationType = String.Empty;        
        public string OrchestrationName = String.Empty;
        public string ProcessingServerName = String.Empty;
        public string BizTalkProcessID = String.Empty;      

        public string ApplicationName = String.Empty;
        public string ApplicationUrl = String.Empty;
        public string IovationResultName = String.Empty;
        public string IovationResultUrl = String.Empty;
        public string IntegrationActionUrl = String.Empty;
        public string LoanUrl = String.Empty;

        public DateTime ErrorDateTime;
        public string ErrorDescription = String.Empty;
        public string MessageContent = String.Empty;
        public string ProcessSummary = String.Empty;
    }
}

