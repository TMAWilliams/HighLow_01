/**       
 *--------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: HighLow_01
 *--------------------------------------------------------------------
 * Author’s name and email:	 Tessa Williams williamstm5@etsu.edu				
 *          Course-Section: CSCI-4250-002
 *           Creation Date:	 09/10/2023		
 * -------------------------------------------------------------------
 */
namespace HighLow_01
{
    internal class Program
    {
        static void Main()
        {
            //Global Variables
            string title = "Guess a Random Number";
            string end = "Goodbye!";
            string exit = "";
            bool success = false;
            int input = 0;
            int counterSameGuess;
            int counterWrongGuess;
            int previousAnswer = 0;

            while (exit != "0")
            {
                Console.Clear();
                Divider();
                CenterText(title);
                Divider();
                //Generate random number to guess
                Random rand = new Random();
                int num = rand.Next(1, 11);
                counterSameGuess = 0;
                counterWrongGuess = 0;

                do
                {
                    //Prompt user for guess and validate that it is an integer between 1-10 inclusive
                    do
                    {
                        Console.WriteLine("Please guess a number 1-10: ");
                        try
                        {
                            input = Convert.ToInt32(Console.ReadLine());
                            if (input < 1 || input > 10)
                            {
                                throw new Exception();
                            }
                            success = true;
                        }
                        catch
                        {
                            Console.WriteLine("*Invalid Input*");
                        }
                    }
                    while (!success);

                    /*Checks to see if input is the same as the previous input.
                     If so, increses a counter by 1. If counter reaches 3, game ends.*/
                    if (input == previousAnswer)
                    {
                        counterSameGuess++;
                    }
                    else
                    {
                        counterSameGuess = 0;
                    }
                    /*Compare user input to randomly generated number and print whether
                     they guessed the number correctly or if the random number is 
                     higher or lower than their guess.*/
                    if (num == input)
                    {
                        Console.WriteLine("Correct");
                        success = true;
                    }
                    else if (num > input)
                    {
                        Console.WriteLine("Higher");
                        counterWrongGuess++;
                        success = false;
                    }
                    else
                    {
                        Console.WriteLine("Lower");
                        counterWrongGuess++;
                        success = false;
                    }
                    previousAnswer = input;
                }
                while (!success && counterSameGuess < 2 && counterWrongGuess < 5);
                if (counterWrongGuess == 5)
                {
                    Console.WriteLine("**Too many wrong guesses**");
                }
                if (counterSameGuess == 2)
                {
                    Console.WriteLine("**Same number guessed too many times**");
                }
                Console.WriteLine("Press 0 to exit otherwise any key to try again.");
                exit = Console.ReadLine();
            }
            Divider();
            CenterText(end);
            Divider();
        }
        //Methods
        public static void Divider()
        {
            string divider = "";
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                divider += "*";
            }
            Console.WriteLine(divider);
        }

        public static void CenterText(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}