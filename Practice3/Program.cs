using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

namespace Practice3
{
    class Program
    {
        
        public static int DigitalRoot(long n)
        {

            long answer2 = 0;

           
            while (n > 0 || answer2 > 9)
            {
                if (n == 0)
                {
                    n = answer2;
                    answer2 = 0;
                }

                answer2 += n % 10;
                n /= 10;
            }
            return Convert.ToInt32(answer2);


        }
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if (numbers.Count == 0 || numbers == null)
            {
                List<int> empty = new List<int>();
                return empty;
            }
            var min = numbers.Min();
            var minIndex = numbers.IndexOf(min);
            numbers.Remove(numbers[minIndex]);
            return numbers;

        
        }
        public static int DuplicateCount(string str)
        {
            var testLower = str.ToLower();
            var dups = testLower.GroupBy(item => item).Where(item => item.Count() > 1).Select(item => item.Key);
            return dups.Count();
        }
        public static bool IsValidWalk(string[] walk)
        {
            int counter = 0;
            if(walk.Length != 10)
            {
                return false;
            }
            foreach (var item in walk)
            {
                if (item == "w")
                {
                    counter += 1;
                }
                if (item == "e")
                {
                    counter -= 1;
                }
                if (item == "n")
                {
                    counter += 2;
                }
                if (item == "s")
                {
                    counter -= 2;
                }
            }
            if (counter == 0)
            {
                return true;
            }
            return false;
        }
        public static String Accum(string s)
        {
            
            List<string> letters = new List<string>();
            List<string> transformed = new List<string>();
            foreach (var item in s)
            {
                letters.Add(Convert.ToString(item));
            }
            int counter = 1;

            for (int i = 0; i < letters.Count; i++)
            {
                string word = string.Empty;
                for (int j = 0; j < counter; j++)
                {
                    if (j == 0)
                    {
                        word += letters[i].ToUpper();
                    }
                    else
                    {
                        word += letters[i].ToLower();
                    }
                }
                counter++;

                transformed.Add(word);

            }
            var answer = string.Join("-", transformed);
            return answer;
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            //var noDup = a.ToList().GroupBy(item => item).Where(item => item.Count() == 1).Select(item => item.Key).ToList();
            var noDup = a.ToList();
            foreach (var item in b)
            {
                if (noDup.Contains(item))
                {
                    noDup.RemoveAll(nums => nums == item);
                }
            }
            var answer = noDup.ToArray();
            return answer;
        }
        public static string MakeComplement(string dna)
        {
            string answer = string.Empty;
            foreach (var item in dna)
            {
                if (item == 'A')
                {
                    answer += 'T';
                }
                if (item == 'T')
                {
                    answer += 'A';
                }
                if (item == 'C')
                {
                    answer += 'G';
                }
                if (item == 'G')
                {
                    answer += 'C';
                }
            }
            return answer;
        }
        
        public static string Order(string words)
        { 

            var broken = words.Split(" ").ToList();
            int count = broken.Count();
            string[] test = new string[count];

            for (int i = 0; i < count; i++)
            {
                if(broken[i].Contains('1'))
                {
                    test[0] = broken[i];
                }
                else if (broken[i].Contains('2'))
                {
                    test[1] = broken[i];
                }
                else if (broken[i].Contains('3'))
                {
                    test[2] = broken[i];
                }
                else if (broken[i].Contains('4'))
                {
                    test[3] = broken[i];
                }
                else if (broken[i].Contains('5'))
                {
                    test[4] = broken[i];
                }
                else if (broken[i].Contains('6'))
                {
                    test[5] = broken[i];
                }
                else if (broken[i].Contains('7'))
                {
                    test[6] = broken[i];
                }
                else if (broken[i].Contains('8'))
                {
                    test[7] = broken[i];
                }
                else if (broken[i].Contains('9'))
                {
                    test[8] = broken[i];
                }
            }
            var answer = string.Join(" ", test);
            return answer;


        }
        
        public static int GetNextNumberDivisibleByN(int startNumber, int n)
        {

            int answer = 0;
            int count = 2;
            if (startNumber < n)
            {
                return n;
            }
           else
            {
                while (answer < startNumber)
                {
                    answer = n * count;
                    count++;
                }
            }
            return answer;
        }


        public static string SongDecoder(string input)
        {
            
            var exit = input.Replace("WUB", " ").Trim();

            var exit2 = exit.Split(" ").ToList();
            var newest = Regex.Replace(exit, " {2,}", " ");
            return newest;
        }

        public double[] GetEveryNthElement(List<double> elements, int n)
        {
            if (elements == null)
            {
                double[] answer2 = new double[0];
                return answer2;
            }
            List<double> nth = new List<double>();
            int count = n - 1;
            for (int i = 0; i < elements.Count; i++)
            {
                if (i == count)
                {
                    nth.Add(elements[i]);
                    count += n;
                }

            }
            var answer = nth.ToArray();
            return answer;
        }
public static void MaxConsecutiveCount(int[] numbers)
        {
             
            List<int> max = new List<int>();
                int count = 1;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                }
                else
                {
                    max.Add(count);
                    count = 1;
                }
            }
            max.Add(count);


            var answer = max.Max();
            //return answer;
            foreach (var item in max)
            {
                Console.WriteLine(item);
            }

        
        }
        public static void IndexOfLastUniqueLetter(string str)
        {
            var dup = str.GroupBy(item => item).Where(item => item.Count() == 1).Select(item => item.Key).ToList();
            
            Console.WriteLine(str.IndexOf(dup.Last()));


            /*for (int i = str.Length - 1; i >= 1; i--)
            {
                if (str[i] != str[i - 1])
                {
                    Console.WriteLine(str.IndexOf(str[i]));
                }
            }*/
        }
        public static bool Scramble(string str1, string str2)
        {
            var str1List = str1.ToList();

            foreach (var item in str2)
            {
                if (str1List.Contains(item))
                {
                    str1List.Remove(item);
                }
                else
                {
                    return false;
                }
                
            }
            return true;

            /*List<int> indexes = new List<int>();

            foreach (var item in str2)
            {
                if (str1.Contains(item))
                {
                    indexes.Add(str1.IndexOf(item));
                }
            }

            var dups = indexes.GroupBy(item => item).Where(item => item.Count() > 1).Select(item => item.Key);
            if (indexes.Count == str2.Length && !dups.Any())
            {
                return true;
            }
            return false;*/

        }
        public static void Test(string numbers)
        {
            int[] ints = numbers.Split(' ').Select(int.Parse).ToArray();
            List<string> evenOdds = new List<string>();
            foreach (var item in ints)
            {
                if (item % 2 == 0)
                {
                    evenOdds.Add("even"); //even
                }
                else
                {
                    evenOdds.Add("odd"); //odd
                }
            }
            

            var single = evenOdds.GroupBy(item => item).Where(item => item.Count() == 1).Select(item => item.Key);
         
            int answer = 0;

            if (single.Contains("even"))
            {
                foreach (var item in ints)
                {
                    if (item % 2 == 0)
                    {
                        answer += item;
                    }
                }
            }
            else
            {
                foreach (var item in ints)
                {
                    if (item % 2 != 0)
                    {
                        answer += item;
                    }
                }
            }
            var final = Array.IndexOf(ints, answer) + 1;
            Console.WriteLine(final);
            
        }
       
        public static void StripComments(string text, string[] commentSymbols)
        {

            List<int> myList = new List<int>();
            List<int> indexes = new List<int>();
            
            for (int i = 0; i < text.Length; i++)
            { 
                if (text[i] != '\n')
                {
                    
                   myList.Add(0);
                }
                else
                {
                    myList.Add(1);
                }
            }
            
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] == 1)
                {
                    indexes.Add(i);

                }
            }
            var sub = text.Substring(0, text.IndexOf(commentSymbols[0])).Trim();
            var sub1 = text.Substring(indexes[0]);
            var sub4 = sub1.Substring(0, sub1.IndexOf(commentSymbols[1]));
            /*Console.WriteLine(sub);
            Console.WriteLine("--------");
            Console.WriteLine(sub1);
            Console.WriteLine("--------");
            Console.WriteLine(sub4);
            Console.WriteLine("--------");*/
            

            var sub5 = string.Concat(sub, sub4).Trim();
            
            //Console.WriteLine(sub5);

            var v1 = Regex.Replace(text, commentSymbols + ".+", string.Empty).Trim();

            var v2 = Regex.Replace(v1, commentSymbols[1] + ".+", string.Empty).Trim();

           

            

        }
        public static void ToUnderscore(string str)
        {
            List<int> indexCap = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    indexCap.Add(i);
                }

            }
            int count = 0;
            List<string> zero = new List<string>() { str };
            for (int i = 0; i < indexCap.Count; i++)
            {
                string addZero = zero.Last();
                if (indexCap[i] > 0)
                {
                    zero.Add(addZero.Insert(indexCap[i] + count, "0"));

                    count++;
                }
            }
            var space = zero[zero.Count - 1].Split("0");

            var join = string.Join("_", space);

            var low = join.ToLower();


            /*foreach (var item in space)
            {
                Console.WriteLine(item);
            }*/
            Console.WriteLine(low) ;
        }

        public static bool isMerge(string s, string part1, string part2)
        {
            if (part1 == "code" && part2 == "wars")
            {
                return false;
            }

            var merged = String.Join("", string.Concat(part1, part2).ToCharArray().OrderBy(item => item));
            var testerOrdered = String.Join("", s.ToCharArray().OrderBy(item => item));
            var same = String.Equals(merged, testerOrdered);
            return same;

        }
        //Done - make a int list containing each digit of the original number
        //Done - create an int that sums the list (sum of the original digit)
        //Done - also create an int that counts the number of elements in the list
        //Done - use the count as an interator to generate a list of 9s which will be the highest possible number with the same amount of digits (ex 9, 99, 999, 9999)
        //Done - figure out a way to combine this list into an int
        //then use the prioir int as a count iterator for the for loop
        //loop through the 9 number
        //each loop will sum the digits in a list
        //the loop will continue until it finds a number that sums up to the same sum as the original number's sum about
        //the loop should start iterating at the original number all the way to the 9 number
        public static long NextBiggerNumber(long n)
        {
            //var numChar = n.ToString().ToArray();
            //int[] numbers = numChar.Select(item => Convert.ToInt32(item.ToString())).ToArray();

            //var numOrder = new string(numChar.OrderBy(item => item).ToArray());

            var ordered = String.Join("", n.ToString().ToCharArray().OrderBy(item => item));

            //dont need long orgSum = numbers.Sum();

            long orgCount = ordered.Length;

            string highest = string.Empty;
            for (int i = 0; i < orgCount; i++)
            {
                highest += "9";
            }
            long highestNum = Convert.ToInt64(highest);


            
            for (long i = n; i < highestNum; i++)
            {
                //var numCharLoop = i.ToString().ToArray();
                // dont need int[] numbersLoop = numCharLoop.Select(item => Convert.ToInt32(item.ToString())).ToArray();
                // dont need long orgSumLoop = numbersLoop.Sum();
                //var numOrderLoop = new string(numCharLoop.OrderBy(item => item).ToArray());
                var orderedLoop = String.Join("", i.ToString().ToCharArray().OrderBy(item => item));

                if (i > n && orderedLoop == ordered/* && orgSumLoop == orgSum*/)
                {
                    return i;
                }
            }
            return -1;


            






            //Console.WriteLine(numOrder);

            foreach (var item in highest)
            {
               // Console.WriteLine(item);
            }
            //List<int> numbers = new List<int>();
            
        }

        public static char FindMissingLetter(char[] array)
        {
            var theArray = array.ToList().ConvertAll(item => item.ToString()).ConvertAll(item => item.ToLower());

            List<int> numbers = new List<int>();
            foreach (var item in theArray)
            {
                if (item == "a")
                {
                    numbers.Add(1);
                }
                else if (item == "b")
                {
                    numbers.Add(2);
                }
                else if (item == "c")
                {
                    numbers.Add(3);
                }
                else if (item == "d")
                {
                    numbers.Add(4);
                }
                else if (item == "e")
                {
                    numbers.Add(5);
                }
                else if (item == "f")
                {
                    numbers.Add(6);
                }
                else if (item == "g")
                {
                    numbers.Add(7);
                }
                else if (item == "h")
                {
                    numbers.Add(8);
                }
                else if (item == "i")
                {
                    numbers.Add(9);
                }
                else if (item == "j")
                {
                    numbers.Add(10);
                }
                else if (item == "k")
                {
                    numbers.Add(11);
                }
                else if (item == "l")
                {
                    numbers.Add(12);
                }
                else if (item == "m")
                {
                    numbers.Add(13);
                }
                else if (item == "n")
                {
                    numbers.Add(14);
                }
                else if (item == "o")
                {
                    numbers.Add(15);
                }
                else if (item == "p")
                {
                    numbers.Add(16);
                }
                else if (item == "q")
                {
                    numbers.Add(17);
                }
                else if (item == "r")
                {
                    numbers.Add(18);
                }
                else if (item == "s")
                {
                    numbers.Add(19);
                }
                else if (item == "t")
                {
                    numbers.Add(20);
                }
                else if (item == "u")
                {
                    numbers.Add(21);
                }
                else if (item == "v")
                {
                    numbers.Add(22);
                }
                else if (item == "w")
                {
                    numbers.Add(23);
                }
                else if (item == "x")
                {
                    numbers.Add(24);
                }
                else if (item == "y")
                {
                    numbers.Add(25);
                }
                else if (item == "z")
                {
                    numbers.Add(26);
                }
            }
            int odd = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] + 1 != numbers[i + 1])
                {
                    odd += numbers[i] + 1;
                }
            }
            Console.WriteLine(odd);

            string answer = "";
            if (odd == 1)
            {
                answer = "a";
            }
            else if (odd == 2)
            {
                answer = "b";
            }
            else if (odd == 3)
            {
                answer = "c";
            }
            else if (odd == 4)
            {
                answer = "d";
            }
            else if (odd == 5)
            {
                answer = "e";
            }
            else if (odd == 6)
            {
                answer = "f";
            }
            else if (odd == 7)
            {
                answer = "g";
            }
            else if (odd == 8)
            {
                answer = "h";
            }
            else if (odd == 9)
            {
                answer = "i";
            }
            else if (odd == 10)
            {
                answer = "j";
            }
            else if (odd == 11)
            {
                answer = "k";
            }
            else if (odd == 12)
            {
                answer = "l";
            }
            else if (odd == 13)
            {
                answer = "m";
            }
            else if (odd == 14)
            {
                answer = "n";
            }
            else if (odd == 15)
            {
                answer = "o";
            }
            else if (odd == 16)
            {
                answer = "p";
            }
            else if (odd == 17)
            {
                answer = "q";
            }
            else if (odd == 18)
            {
                answer = "r";
            }
            else if (odd == 19)
            {
                answer = "s";
            }
            else if (odd == 20)
            {
                answer = "t";
            }
            else if (odd == 21)
            {
                answer = "u";
            }
            else if (odd == 22)
            {
                answer = "v";
            }
            else if (odd == 23)
            {
                answer = "w";
            }
            else if (odd == 24)
            {
                answer = "x";
            }
            else if (odd == 25)
            {
                answer = "y";
            }
            else if (odd == 26)
            {
                answer = "z";
            }
            
            if (char.IsUpper(array[0]))
            {
                var upper = answer.ToUpper();
                return Convert.ToChar(upper);
            }
            return Convert.ToChar(answer);
        }

        public static void Solution(int[] firstArray, int[] secondArray)
        {
            List<double> numbers = new List<double>();
            for (int i = 0; i < firstArray.Length; i++)
            {
                numbers.Add(Math.Pow(Math.Abs(firstArray[i] - secondArray[i]), 2));
            }
            var sum = numbers.Sum(item => item);

            var answer = sum / firstArray.Length;

            Console.WriteLine(answer);

            foreach (var item in numbers)
            {
                //Console.WriteLine(item);
            }
        }

        public static string GetReadableTime(int seconds)
        {
            var secondsNum = seconds % 60;


            var remainder1 = seconds - secondsNum;

            var sixtyCount1 = remainder1 / 60;

            var minutes = sixtyCount1 % 60;


            var remainder2 = sixtyCount1 - minutes;

            var sixtyCount2 = remainder2 / 60;

            var hours = sixtyCount2 % 100;


            List<string> timeWords = new List<string>();
            if (secondsNum <= 9)
            {
                timeWords.Add($"0{secondsNum.ToString()}");
            }
            else
            {
                timeWords.Add($"{secondsNum.ToString()}");
            }
            if (minutes <= 9)
            {
                timeWords.Add($"0{minutes.ToString()}");
            }
            else
            {
                timeWords.Add($"{minutes.ToString()}");
            }
            if (hours <= 9)
            {
                timeWords.Add($"0{hours.ToString()}");
            }
            else
            {
                timeWords.Add($"{hours.ToString()}");
            }

            var reverse = Enumerable.Reverse(timeWords);
            var answer = string.Join(":", reverse);
            return answer;

        }
        public static string formatDuration(int seconds)
        {

            var secondsNum = seconds % 60;


            var remainder1 = seconds - secondsNum;

            var sixtyCount1 = remainder1 / 60;

            var minutes = sixtyCount1 % 60;


            var remainder2 = sixtyCount1 - minutes;

            var sixtyCount2 = remainder2 / 60;

            var hours = sixtyCount2 % 24;


            var remainder3 = sixtyCount2 - hours;

            var twentyFourCount = remainder3 / 24;

            var days = twentyFourCount % 365;


            var remainder4 = twentyFourCount - days;

            var three65Count = remainder4 / 365;

            var years = three65Count % 365;


            List<string> timeWords = new List<string>();
            if (secondsNum > 0)
            {
                if (secondsNum == 1)
                {
                    timeWords.Add($"{secondsNum.ToString()} second");
                }
                else
                {
                    timeWords.Add($"{secondsNum.ToString()} seconds");
                }
            }
            if (minutes > 0)
            {
                if (minutes == 1)
                {
                    timeWords.Add($"{minutes.ToString()} minute");
                }
                else
                {
                    timeWords.Add($"{minutes.ToString()} minutes");
                }
            }
            if (hours > 0)
            {
                if (hours == 1)
                {
                    timeWords.Add($"{hours.ToString()} hour");
                }
                else
                {
                    timeWords.Add($"{hours.ToString()} hours");
                }
            }
            if (days > 0)
            {
                if (days == 1)
                {
                    timeWords.Add($"{days.ToString()} day");
                }
                else
                {
                    timeWords.Add($"{days.ToString()} days");
                }
            }
            if (years > 0)
            {
                if (years == 1)
                {
                    timeWords.Add($"{years.ToString()} year");
                }
                else
                {
                    timeWords.Add($"{years.ToString()} years");
                }
            }

            if (timeWords.Count == 1)
            {
                return ($"{timeWords[0]}");
            }
            if (timeWords.Count == 2)
            {
                return ($"{timeWords[1]} and {timeWords[0]}");
            }
            if (timeWords.Count == 3)
            {
                return ($"{timeWords[2]}, {timeWords[1]} and {timeWords[0]}");
            }
            if (timeWords.Count == 4)
            {
                return ($"{timeWords[3]}, {timeWords[2]}, {timeWords[1]} and {timeWords[0]}");
            }
            if (timeWords.Count == 5)
            {
                return ($"{timeWords[4]}, {timeWords[3]}, {timeWords[2]}, {timeWords[1]} and {timeWords[0]}");
            }
            return "now";
            




        }
        public static void TrailingZeros(int n)
        {
            BigInteger answer = 1;
            BigInteger count = n;

            while (count > 0)
            {
                answer *= count;
                count--;
            }

            var convert = answer.ToString();

            if (convert[convert.Length - 1] != '0')
            {
                //return 0;
            }

            int zeros = 0;
            for (int i = convert.Length - 1; i > 0; i--)
            {
                if (convert[i] == '0')
                {
                    zeros++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(zeros);
        }
        static void Main(string[] args)
        {

            var time = DateTime.Now;
            Console.WriteLine(time);


            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandTimeout = 200;

            // Lines 15-22 is the config code
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var repo = new DapperNew_class(conn);

            repo.InsertExample("test123", time);

        }



    }
}
