using System;

namespace NumberParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            Console.WriteLine("Enter numbers and File format");
            inputString = Console.ReadLine();
            string numbers = inputString.Split(' ')[0];
            string fileFormat = inputString.Split(' ')[inputString.Split(' ').Length - 1];
            Console.Write(SortNumberByDescendingOrder(numbers) + ' ' + fileFormat);
            Console.ReadLine();

        }

        private static string SortNumberByDescendingOrder(string numbers)
        {
            string[] intArray = numbers.Split(',');
            for (int i=0; i<intArray.Length - 1; i++)
            {
                for(int j=i+1; j<intArray.Length; j++)
                {
                    if(Convert.ToInt32(intArray[i]) < Convert.ToInt32(intArray[j]))
                    {
                    int temp = Convert.ToInt32(intArray[i]);
                    intArray[i] = intArray[j];
                    intArray[j] = temp.ToString();

                    }
                }
            }
            return string.Join(",", intArray);
        }
    }
}
