using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        /// <summary>
        /// Used by GetTriangleTypeFromLengthOfSides()
        /// </summary>
        private enum TriangleTypes
        {
            Scalene = 1,
            Isosceles,   /* 2 */
            Equilateral, /* 3 */
            Error        /* 4 */
        }
        
        /// <summary>
        /// Start here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Build list of integers from 2 to 11...
            IEnumerable<int> Integers = from value in Enumerable.Range(2, 10)
                                        select value;

            // Define n
            int n = 5;

            // Get the nth element from this list
            int Result = GetElementNumberFromList(Integers,n);

            Console.WriteLine("The result is {0}",Result);

            Console.WriteLine("Triangle sides...");

            Console.WriteLine("Number of equal sides (3) {0}",GetTriangleTypeFromLengthOfSides(1, 1, 1));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(1, 1, 2));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(1, 1, 3));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(1, 2, 1));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(1, 2, 2));
            Console.WriteLine("Number of equal sides (1) {0}", GetTriangleTypeFromLengthOfSides(1, 2, 3));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(1, 3, 1));
            Console.WriteLine("Number of equal sides (1) {0}", GetTriangleTypeFromLengthOfSides(1, 3, 2));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(1, 3, 3));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(2, 1, 1));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(2, 1, 2));
            Console.WriteLine("Number of equal sides (1) {0}", GetTriangleTypeFromLengthOfSides(2, 1, 3));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(2, 2, 1));
            Console.WriteLine("Number of equal sides (3) {0}", GetTriangleTypeFromLengthOfSides(2, 2, 2));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(2, 2, 3));
            Console.WriteLine("Number of equal sides (1) {0}", GetTriangleTypeFromLengthOfSides(2, 3, 1));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(2, 3, 2));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(2, 3, 3));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(3, 1, 1));
            Console.WriteLine("Number of equal sides (1) {0}", GetTriangleTypeFromLengthOfSides(3, 1, 2));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(3, 1, 3));
            Console.WriteLine("Number of equal sides (1) {0}", GetTriangleTypeFromLengthOfSides(3, 2, 1));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(3, 2, 2));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(3, 2, 3));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(3, 3, 1));
            Console.WriteLine("Number of equal sides (2) {0}", GetTriangleTypeFromLengthOfSides(3, 3, 2));
            Console.WriteLine("Number of equal sides (3) {0}", GetTriangleTypeFromLengthOfSides(3, 3, 3));

            Console.WriteLine("Number of equal sides (Error) {0}", GetTriangleTypeFromLengthOfSides(1, 1, 0));
            Console.WriteLine("Number of equal sides (Error) {0}", GetTriangleTypeFromLengthOfSides(1, 0, 2));
            Console.WriteLine("Number of equal sides (Error) {0}", GetTriangleTypeFromLengthOfSides(0, 1, 0));

            Console.WriteLine("'Cat and dog' reversed is {0}",ReverseString("Cat and dog"));

        }

        /// <summary>
        /// Return the nth element from the tail of a list
        /// </summary>
        /// <param name="Integers">The list IEnumerable of type Int</param>
        /// <param name="ElementNumber">n</param>
        /// <returns></returns>
        private static int GetElementNumberFromList(IEnumerable<int> Integers, int ElementNumber)
        {
            int Result = -1;  // Default to a value to indicate an error

            // Pretty simple... Reverse the elements, get the last n elements, reverse it again, then get the 1st one
            Result = Integers.Reverse().Take(ElementNumber).Reverse().First();

            return Result;
        }

        /// <summary>
        /// Return the triangle type, given the length of each side
        /// </summary>
        /// <param name="Length1">The length of side 1</param>
        /// <param name="Length2">The length of side 2</param>
        /// <param name="Length3">The length of side 3</param>
        /// <returns></returns>
        private static TriangleTypes GetTriangleTypeFromLengthOfSides(int Length1, int Length2, int Length3)
        {
            // Determine the number of sides that are equal
            // If 3, triangle is equilateral
            // If 2, triangles is isosceles
            // If none, triangle is Scalene
            // If any value is <=0, the values entered are in error

            int HighestCount = -1;

            if (Length1 <= 0 | Length2 <= 0 | Length3 <= 0)
            {
                return TriangleTypes.Error;
            }
            else
            {
                int[] Lengths = new int[3];

                Lengths[0] = Length1;
                Lengths[1] = Length2;
                Lengths[2] = Length3;

                for (int Counter = 0; Counter < 3; Counter++)
                {
                    int CountOfInstances = CountInstances(Lengths[Counter], Lengths);

                    if (CountOfInstances > HighestCount) HighestCount = CountOfInstances;

                }

                return (TriangleTypes)HighestCount;
            }
        }

        /// <summary>
        /// Count the number of instances of the ValueToCount in Values[]
        /// </summary>
        /// <param name="ValueToCount">The value to count</param>
        /// <param name="Values">The Values to count within</param>
        /// <returns></returns>
        private static int CountInstances(int ValueToCount, int[] Values)
        {
            int Result = -1;

            Result = ((from temp in Values where temp.Equals(ValueToCount) select temp).Count());

            return Result;
        }

        /// <summary>
        /// Reverse the given string, preserving Whitespace
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private static string ReverseString(string Input)
        {
            string Output = "";
            string Whitespace = " ";
            System.Collections.Stack TempStack = new System.Collections.Stack();
            StringBuilder Builder = new StringBuilder();
            
            for (int Counter = 0; Counter < Input.Length + 1 ; Counter++)
            {
                // Go through the Input string until whitespace or the end of the string is found
                if ((Counter == Input.Length) || (Input[Counter].ToString() == Whitespace))
                {
                    int StackCount = TempStack.Count;

                    for (int InnerCounter = 0; InnerCounter < StackCount ; InnerCounter++)
                    {
                        Builder.Append(TempStack.Pop());
                    }

                    // If we haven't already reached the end of the input string, add whitespace between the words
                    if (Counter != Input.Length)
                        Builder.Append(Whitespace);
                }
                else
                {
                    // Save this single character onto a stack (ie it reverses the input string)
                    TempStack.Push(Input[Counter].ToString());
                }
            }

            Output = Builder.ToString();

            return Output;
        }
    }
}
