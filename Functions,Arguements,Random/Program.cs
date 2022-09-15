using System;
using System.Threading;


namespace Functions_Arguements_Random
{

	unsafe internal class Program
	{
		static void SlotRolling(Random RanGen, int* num1, int* num2, int* num3)
		{
			Console.WriteLine(@"
┌───┬───┬───┐
│ x │ x │ x │
└───┴───┴───┘"); /* Draw "slot machine" window */

			Console.CursorTop -= 2; /* Move cursor to be in line of number display */
			for(int i = 0; i < 15; i++) /* Roll 15 times with 100 millisecond delay (1.5 seconds to roll) */
			{
				*num1 = RanGen.Next(0, 9); *num2 = RanGen.Next(0, 9); *num3 = RanGen.Next(0, 9); /* each time, generate New number between 0 and 9 for each number var */


				Console.Write($"│ {*num1} │ {*num2} │ {*num3} │"); /* reprint middle section with the numbers replaced */
				Console.CursorLeft = 0; /* reset cursor back to the back */
				Thread.Sleep(100);
			}

			Console.CursorTop += 2;
		}

		static void Gambling(int GambleBetInt)
		{
			Console.Write("Press any key to Gamble"); /* Final confirmation to start rolling */
			Console.ReadKey();

			Random RanGen = new Random(); /* Random number object */

			int num1 = 0, num2 = 0, num3 = 0; /* int Vars for the points to get the address of */
			int* num1p = &num1, num2p = &num2, num3p = &num3; /* Points of the previous num vars */

			SlotRolling(RanGen, num1p, num2p, num3p); /* Pass pointers plus RanGen object to function */

			if(num1 == num2 && num2 == num3) /* If all numbers matching */
			{
				Console.WriteLine($"You got all matching numbers\nyou hit the jackpot\nYou get +${GambleBetInt*5}");
			}
			else if (num1 == num2 || num1 == num3 || num2 == num3) /* if 2 numbers matching */
			{
				Console.WriteLine($"You only got 2 matching numbers\nYou get +${GambleBetInt * 2}");
			}
			else /* if no match */
			{
				Console.WriteLine($"You lost\nyou lost -${GambleBetInt}");
			}
		}

		static void Main(string[] args)
		{
			bool ContinuePlaying = true;

			while (ContinuePlaying) /* Loop incase the player wants to play multiple times */
			{
				try
				{
					Console.WriteLine("\n\nYou need to get all numbers to be the same in order to win");
					Console.Write("Please input your gambling bet: ");
					/*
					3 operations in one line for less memory usage (not using multiple variables) 
					1. Readline from console (input)
					2. Convert to int32 (try to catch incorrect formats)
					3. call Gambling Function to start the addiction
					*/
					Gambling(Convert.ToInt32(Console.ReadLine()));

					while (true) /* while true loop which gets broke when a valid response is gotten */
					{
						Console.Write("Continue playing (Y/N): ");
						string ConPlayRes = Console.ReadLine();
						if (ConPlayRes.ToLower() == "y")
						{
							ContinuePlaying = true;
							break;
						}
						else if (ConPlayRes.ToLower() == "n")
						{
							ContinuePlaying = false;
							break;
						}
						else
						{
							Console.WriteLine("unrecognised Response");
						}
					}
				}
				catch (Exception Ex) /* Get the exception to allow for multiple resposes */
				{
					if (Ex is System.FormatException) /* if it is the Format exception, give the specific error */
					{
						Console.WriteLine("\nException: Incorrect String Format (None numerical digits)");
					}
					else /* Else, output console the error message and ackowledge the fact its unaccounted */
					{
						Console.WriteLine($"\nException: Unaccounted Error\nError Message: {Ex.Message}");
					}
				}
			}
		}
	}
}