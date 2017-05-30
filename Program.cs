using System;

namespace number_guess_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int correctNumber = new Random().Next(4);
            int numberOfTries = 3;
            int userGuesses = 0;
            bool gameOver = false;

            Console.WriteLine("I'm thinking of a number between 0 - 3. Can you guess it in 3 tries?");

            int ParseInt(string s)
            {
                int output = -1;
                if (int.TryParse(s, out output))
                {
                    return output;
                }
                else
                {
                    return -1;
                }
            }

            void CheckUserInput()
            {
                if (userGuesses == numberOfTries)
                {
                    Console.WriteLine("You're out of tries. Game over man! Game over!");
                    gameOver = true;
                    return;
                }

                Console.WriteLine($"You have {numberOfTries - userGuesses} tries remaining. What's your guess?");
                string input = Console.ReadLine();
                int parsedInput = ParseInt(input);

                if (parsedInput == -1)
                {
                    Console.WriteLine($"'{input}' is not a number. Please try again, but with a number this time.");
                    return;
                }
                else if (parsedInput < correctNumber)
                {
                    userGuesses+=1;
                    Console.WriteLine("Too low!");
                    return;
                }
                else if (parsedInput > correctNumber)
                {
                    userGuesses+=1;
                    Console.WriteLine("Too high!");
                    return;
                }
                else
                {
                    Console.WriteLine($"You got it! {input} was the correct number!");
                    gameOver = true;
                    return;
                }
            }

            while (!gameOver)
            {
                CheckUserInput();
            }

            Console.WriteLine("Thanks for playing.");
        }
    }
}
