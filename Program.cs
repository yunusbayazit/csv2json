using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv2json
{
    class Program
    {
        static void Main(string[] args)
        {
            csvtojson(@"eventList.csv");
        }
          public static dynamic csvtojson(string filename)
        {
            string jsonLine=string.Empty;
            string js = string.Empty;
            string[] head;
            var csv = new List<string[]>();
            var lines = System.IO.File.ReadAllLines(filename);
            var oneline = lines[0];
            int count = 0;
            int counter2 = 0;
            head = oneline.Split(',');

            foreach (string line in lines)
            {  
                    csv.Add(line.Split(',')); // or, populate YourClass  
            }
            csv.RemoveAt(0);
            while (count<csv.Count)
            {
                js = string.Empty;
                counter2 = 0;
                while (counter2<head.Length-1)
                {
                    js += string.Format("'{0}':'{1}'", head[counter2], csv[count][counter2]);

                    if (!(counter2== head.Length - 2))
                    {
                        js += ",";
                    }
                    counter2++;
                }
                jsonLine += "{" + js + "}";
                if (!(count==csv.Count-1))
                {
                    jsonLine += ",";
                }
                count++;
            }
            jsonLine = "[" + jsonLine + "]";

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonLine);
            return data;
        }
    }
}
