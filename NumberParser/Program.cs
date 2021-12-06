using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.IO;

namespace NumberParser
{
    public interface IOutput
    {
        string SortNumberByDescendingOrderAndPersist(string numbers);
    }

    public class TxtOutput : IOutput
    {
        public string SortNumberByDescendingOrderAndPersist(string numbers)
        {
            string[] intArray = numbers.Split(',');
            for (int i = 0; i < intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (Convert.ToInt32(intArray[i]) < Convert.ToInt32(intArray[j]))
                    {
                        int temp = Convert.ToInt32(intArray[i]);
                        intArray[i] = intArray[j];
                        intArray[j] = temp.ToString();

                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Shelton Estibeiro\\Documents\\GitHub\\NumberParser\\NumberParser\\NumberParser\\Output.txt"))
            {
                sw.WriteLine(string.Join(',', intArray));
            }
            return string.Join(',', intArray);
        }

    }
    public class JsonOutput : IOutput
    {
        public string SortNumberByDescendingOrderAndPersist(string numbers)
        {
            string[] intArray = numbers.Split(',');
            for (int i = 0; i < intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (Convert.ToInt32(intArray[i]) < Convert.ToInt32(intArray[j]))
                    {
                        int temp = Convert.ToInt32(intArray[i]);
                        intArray[i] = intArray[j];
                        intArray[j] = temp.ToString();

                    }
                }
            }
            return JsonConvert.SerializeObject(string.Join(',', intArray).Split(','));
        }
    }

    public class XmlOutput : IOutput
    {
        public string SortNumberByDescendingOrderAndPersist(string numbers)
        {
            string[] intArray = numbers.Split(',');
            for (int i = 0; i < intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (Convert.ToInt32(intArray[i]) < Convert.ToInt32(intArray[j]))
                    {
                        int temp = Convert.ToInt32(intArray[i]);
                        intArray[i] = intArray[j];
                        intArray[j] = temp.ToString();

                    }
                }
            }
            var stringOut = string.Join(',', intArray);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Numbers>");
            foreach (string s in stringOut.Split(','))
            {
                sb.AppendFormat("<num Value=\"{0}\"/>", s);
            }
            sb.AppendFormat("</Numbers>");
            return sb.ToString();
        }
    }

    public abstract class FormatFactory
    {
        public abstract IOutput GetFormat(string format);
    }

    public class ConcreteFormatFactory : FormatFactory
    {
        public override IOutput GetFormat(string format)
        {
            switch (format)
            {
                case "TXT": return new TxtOutput();
                case "JSON": return new JsonOutput();
                case "XML": return new XmlOutput();
                default: throw new ApplicationException(string.Format("Format '{0}' cannot be created", format));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            Console.WriteLine("Enter numbers and File format");
            inputString = Console.ReadLine();
            string numbers = inputString.Split(' ')[0];
            string fileFormat = inputString.Split(' ')[inputString.Split(' ').Length - 1];
            FormatFactory factory = new ConcreteFormatFactory();
            if (fileFormat == "TXT")
            {
                IOutput xmlOut = factory.GetFormat("TXT");
                xmlOut.SortNumberByDescendingOrderAndPersist(numbers);
            }
            if (fileFormat == "JSON")
            {
                IOutput jsonOut = factory.GetFormat("JSON");
                Console.WriteLine(jsonOut.SortNumberByDescendingOrderAndPersist(numbers));
                Console.ReadLine();
            }
            if (fileFormat == "XML")
            {
                IOutput xmlOut = factory.GetFormat("XML");
                Console.WriteLine(xmlOut.SortNumberByDescendingOrderAndPersist(numbers));
                Console.ReadLine();
            }
            

        }
    }
}
