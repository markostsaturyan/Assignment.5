using System;
using System.Collections.Generic;
using System.Linq;


namespace RollingADie
{
    public class Die
    {
        /// <summary>
        /// Delehate int to void
        /// </summary>
        /// <param name="count"></param>
        public delegate void IntToVoid(int count);

        /// <summary>
        /// Event for two six in row
        /// </summary>
        public event IntToVoid TwoSixEventHandler;

        /// <summary>
        /// Delegate int array two void
        /// </summary>
        /// <param name="arr"></param>
        public delegate void IntArrayToVoid(int[] arr);

        /// <summary>
        /// Event for sum is greater 20
        /// </summary>
        public event IntArrayToVoid SumIsGreatEventHandler;

        /// <summary>
        /// Rolling a die.
        /// </summary>
        /// <param name="countOfRoll">Count of tosses.</param>
        public void Rolling(int countOfRoll)
        {
            Random random = new Random(0);

            // The last consequent five tosses.
            int[] arr = new int[5];

            // The count of two six in row.
            int count = 0;

            // The next and previous tosses.
            int next;
            int prev=0;

            for (int i = 0; i < countOfRoll; i++)
            {
                next = random.Next(1,7);

                // Condition to check if there are two sixes in a row.
                if (next == 6 &&  prev == 6)
                {
                    count++;

                    TwoSixEventHandler?.Invoke(count);
                }

                prev = next;

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length-1] = next;

                if (arr.Sum() >= 20)
                {
                    SumIsGreatEventHandler?.Invoke(arr);
                }
            }
        }
    }
}
