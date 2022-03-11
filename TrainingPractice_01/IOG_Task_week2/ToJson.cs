using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IOG_Task_week2
{
    public static class ToJson
    {
        public static string ToJs(object message)
        {
            var serial = new JavaScriptSerializer();
            string json = serial.Serialize(message);
            return json;
        }
        public static Player UnJs(string json)
        {
            var serial = new JavaScriptSerializer();
            Player player = serial.Deserialize<Player>(json);
            return player;
        }
    }
}
