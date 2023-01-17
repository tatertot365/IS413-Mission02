using System;
using System.Collections.Generic;

namespace Mission02
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");
            Console.Write("How many dice rolls would you like to simulate? ");

            int numRolls = int.Parse(Console.ReadLine());

            int[] rollsArray = DiceRolls(numRolls);
            int[] rollPerc = ValueCounts(rollsArray);

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine("Total number of rolls = " + numRolls + "\n");

            for (int j = 0; j<11; j++)
            {
                int num = j + 2;
                string output = num.ToString() + ": ";
                int k = 0;
                while (k < rollPerc[j])
                {
                    output += "*";
                    k++;
                }
                Console.WriteLine(output);
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");

        }

        public static int[] DiceRolls(int rolls)
        {
            int i = 0;
            int[] DiceRolls = new int[rolls];

            while (i < rolls)
            {
                Random rd = new Random();

                int di1 = rd.Next(1, 7);
                int di2 = rd.Next(1, 7);

                int sum = di1 + di2;

                DiceRolls[i] = sum;

                i++;
            }

            return DiceRolls;
        }

        static int[] ValueCounts(int[] rolls)
        {
            Dictionary<int, int> NumCounts = new Dictionary<int, int>() { { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 0 }, { 12, 0 } };

            for (int i = 0; i < rolls.Length; i++)
            {
                NumCounts[rolls[i]] += 1;
            }

            int[] rollPerc = new int[12];
            int j = 0;
            foreach(KeyValuePair<int, int> ele in NumCounts)
            {
                double numDec = ((ele.Value / (double)rolls.Length) * 100);
                rollPerc[j] = (int) Math.Round(numDec);
                j++;
            }

            return rollPerc;
        }
    }
}

