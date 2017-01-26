using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using templatemethodConsole;

namespace TemplateMethodTests
{
    [TestClass]
    public class TestSorting
    {
        [TestMethod]
        public void Can_Array_Sort_Use_My_CompareTo_Method()
        {
            // my DUCK objects provide an implimentation of CompareTo()

            Duck[] ducks = new Duck[]
            {
                new Duck("Daffy", 8),
                new Duck("Dewey", 2),
                new Duck("Howard", 7),
                new Duck("Louie", 2),
                new Duck("Donald", 10),
                new Duck("Huey", 2),
            };

            Console.WriteLine("Before Sorting: ");
            display(ducks);

            // test to see if the static class Array.Sort() will use my CompareTo()
            Array.Sort(ducks);


            // Sort() Summary:
            //     Sorts the elements in an entire one-dimensional System.Array using the System.IComparable
            //     implementation of each element of the System.Array.
            // 
            // The Sort() method controls the algorithm; no class can change this.
            // Sort() counds on an IComparible class to provide the implimentation of CompareTo()

            Console.WriteLine("After Sorting: ");
            display(ducks);

        }

        private void display(Duck[] ducks)
        {
            foreach (var duck in ducks)
            {
                Console.WriteLine(duck);
            }
            Console.WriteLine();
        }
    }
}