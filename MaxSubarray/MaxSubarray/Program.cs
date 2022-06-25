using System;

namespace MaxSubarray
{
    class Program
    {
        //finds max sum in array with the midpoint included 
        static double MaxCrossingSubarray(double[] a, int l, int m, int r)
        {
            //elements left of mid included
            double sum = 0;
            double leftsum = double.MinValue;
            for (int i = m; i >= l; i--)
            {
                sum = sum + a[i];
                if (sum > leftsum)
                {
                    leftsum = sum;
                }
            }

            //elements right of mid included
            sum = 0;
            double rightsum = double.MinValue;
            for (int i = m + 1; i <= r; i++)
            {
                sum = sum + a[i];
                if (sum > rightsum)
                {
                    rightsum = sum;
                }
            }
            //returns max number between the sum of the left and right and the max of the left and right sum themselves
            return Math.Max(leftsum + rightsum, Math.Max(leftsum, rightsum));
        }
        //returns max subarray sum
        static double MaxSubarray(double[] a, int l, int r)
        {
            //base case
            if (l == r)
            {
                return a[l];
            }

            //find middle
            int m = (l + r) / 2;

            //return max of three things: max subarray in left half, max subarray in right half, and max subarray in crossing
            return Math.Max(Math.Max(MaxSubarray(a, l, m), MaxSubarray(a, m + 1, r)), MaxCrossingSubarray(a, l, m, r));
        }
        //Main driver for program to test the sum of the max subarray
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers do you want in your array?");
            string s = Console.ReadLine();
            int size;
            //checking for numeric size of array
            if (int.TryParse(s, out size))
            {
                size = Convert.ToInt32(s);
                //checking for size over 0
                if (size <= 0)
                {
                    Console.WriteLine("You must put a positive number for the size of the array.");
                }
                else
                {
                    double[] Array = new double[size];
                    Console.WriteLine("Enter the " + size + " number(s) now.");
                    //checking for numbers being entered into array
                    for (int i = 0; i < Array.Length; i++)
                    {
                        string c = Console.ReadLine();
                        double numbers;
                        if (double.TryParse(c, out numbers))
                        {
                            numbers = Convert.ToDouble(c);
                            Array[i] = numbers;
                        }
                        else
                        {
                            Console.WriteLine("You must enter numbers into the array.");
                            Environment.Exit(0);
                        }
                    }
                    int n = Array.Length;
                    double maxsum = MaxSubarray(Array, 0, n - 1);
                    Console.WriteLine("max is " + maxsum);
                }

            }
            else
            {
                Console.WriteLine("You must have a numeric size/integer for the array.");
            }

        }
    }
}
