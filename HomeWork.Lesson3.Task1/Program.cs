/*
 * Author : Alexander Dolgosheev
 * Github : https://github.com/dolgosheev
 * Mailto : alexanderdolgosheev@gmail.com
 * Lesson 3
 * Task Generic delegates | exapmle
 */

using HomeWork.Lesson3.Task1.Classes;
using HomeWork.Lesson3.Task1.Interfaces;
using System;
using System.Threading;

namespace HomeWork.Lesson3.Task1
{
    internal static class Program
    {
        private static void Main()
        {
            Humans.HumanEditions += Human_HumanEditions;
            Humans.HumanCreated += Humans_HumanCreated;

            IHuman men = new Mens("Alexander", "Dolgosheev", 33);
            IHuman women = new Womens("Stanislav", "Bairakovskiy", 32);

            Thread.Sleep(2000);
            men.PlusYearAge();
            Thread.Sleep(2000);
            women.PlusYearAge();

            Console.ReadKey();
        }

        private static void Humans_HumanCreated(object sender, IHuman e)
        {
            Console.WriteLine($"Created {e.Fname} {e.Sname} age {e.Age}");
        }

        private static void Human_HumanEditions(object sender, IHuman e)
        {
            Console.WriteLine($"Age for {e.Fname} {e.Sname} has been changed to {e.Age}");
        }

    }
}
