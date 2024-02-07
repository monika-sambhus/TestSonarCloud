using System;
using System.Text;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    [Serializable]
    public class DebugLog
    {
        

        private StringBuilder Body = new StringBuilder();

        public void Append(string data)
        {
            Body.AppendLine(data );
        }

        public string GetData()
        {
            return Body.ToString();
        }
    }
}
