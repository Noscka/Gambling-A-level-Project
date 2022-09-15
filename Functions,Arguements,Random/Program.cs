using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions_Arguements_Random
{
	internal class Program
	{
		static void Gambling(int GambleBetInt)
		{

		}

		static void Main(string[] args)
		{
			bool Validation = false;
			while (!Validation) /* Ask user untill they input a valid response */
			{
				Console.Write("Please input your gambling bet: ");
				try
				{
					/*
					3 operations in one line for less memory usage (not using multiple variables) 
					1. Readline from console (input)
					2. Convert to int32 (try to catch incorrect formats)
					3. call Gambling Function to start the addiction
					 */
					Gambling(Convert.ToInt32(Console.ReadLine()));
					Validation = true;
				}
				catch (Exception Ex) /* Get the exception to allow for multiple resposes */
				{
					if(Ex is System.FormatException) /* if it is the Format exception, give the specific error */
					{
						Console.WriteLine("Exception: Incorrect String Format (None numerical digits)");
					}
					else /* Else, output console the error message and ackowledge the fact its unaccounted */
					{
						Console.WriteLine($"Exception: Unaccounted Error\nError Message: {Ex.Message}");
					}
				}
			}
		}
	}
}