/*
 * Author : Alexander Dolgosheev
 * Github : https://github.com/dolgosheev
 * Mailto : alexanderdolgosheev@gmail.com
 * Lesson 4
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Lesson4.Task1
{
    internal static class Program
    {
        private static void Main()
        {

            /*
             * Task 2 from homework
             */

            Console.WriteLine("*** TASK 2 ***\n");

            // declaration
            var intList = GenerateList(1,2,3,4,5,5,6,7,8,8,9,0);
            var stringList = GenerateList("Hello","World","Improve","Level","World","Skills");
            var charList = GenerateList('a', 'b','c', 'd', 'a', 'c');
            var objList = GenerateList(new float(), new float(), new double(), new object());

            // using
            Console.WriteLine($"Start array of ints : {string.Join(" ,", intList)}");
            intList.ShowList();

            Console.WriteLine($"\nStart array of strings : {string.Join(" ,", stringList)}");
            stringList.ShowList();

            Console.WriteLine($"\nStart array of chars : {string.Join(" ,", charList)}");
            charList.ShowList();

            Console.WriteLine($"\nStart array of objects : {string.Join(" ,", objList.Select(r=>r.GetType()))}");
            objList.ShowList(true);


            /*
             * Task 3 from homework
             */

            Console.WriteLine("\n*** TASK 3 ***\n");

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            // my version
            Console.WriteLine("\n*** my version ***\n");
            foreach (var r in dict.OrderBy(pair => pair.Value))
                Console.WriteLine("{0} - {1}", r.Key, r.Value);

            //end
            Console.ReadKey();
        }

        private static List<T> GenerateList<T>(params T[] args)
        {
            var list = new List<T>();
            list.AddRange(args);
            return list;
        }

        private static void ShowList<T>(this List<T> list,bool showtype = false)
        {
            var countInts = list.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            foreach (var (val, cnt) in countInts)
                Console.WriteLine(" '{0}'\tentry occurs {1}", showtype ? (object) val.GetType() : val, cnt);
        }



    }
}
