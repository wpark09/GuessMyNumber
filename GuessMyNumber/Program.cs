using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMyNumber
{
    public class Program
    {
        static int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static bool quit = false;
        static int minValue;
        static int maxValue;

        static public int _guess;

        static public int guess
        {
            get { return _guess; }
            set
            {
                if (value >= minValue && value <= maxValue) 
                {
                    _guess = value;
                }
                else
                    Console.WriteLine($"Choose between {minValue} and {maxValue}.");
            }
        }
        
        static void Main(string[] args)
        {
            int numberGuessed = 0;
            Random r = new Random();
            int answer = r.Next(1, 10);

            Console.WriteLine("");
            List<int> newIntList = new List<int>();

            foreach (int number in list)
            {
                newIntList.Add(number);
            }
            try
            {
                do
                {
                    foreach (int number in newIntList)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine("");
                    int autoGuess = (newIntList[0] + newIntList[newIntList.Count-1]) / 2;
                    Console.WriteLine($"Number Guessed: {autoGuess} \nAnswer: {answer}");
                    numberGuessed += 1;
                    Console.WriteLine($"Number of attempts: {numberGuessed}");
                    newIntList = GuessingNumber(newIntList, autoGuess, answer);
                    Console.ReadLine();
                    if (answer == autoGuess)
                    {
                        quit = true;
                    }            
                } while (!quit);

                List<int> humanIntList = new List<int>();
                quit = false;
                numberGuessed = 0;
                minValue = 0;
                maxValue = 1000;
                int humanAnswer = r.Next(minValue, maxValue);
                for (int i = 1;i<=1000;i++)
                {
                    humanIntList.Add(i);
                }
                
                do
                {
                    Console.Write("Choose a number between 1 and 1000: ");
                    guess = int.Parse(Console.ReadLine());
                    numberGuessed += 1;
                    humanIntList = GuessingNumber(humanIntList, guess, humanAnswer);
                    Console.WriteLine($"Number of attempts: {numberGuessed}");
                    if (humanAnswer == guess)
                    {
                        quit = true;
                    }
                } while (!quit);

                List<int> computerIntList = new List<int>();
                quit = false;
                numberGuessed = 0;
                minValue = 0;
                maxValue = 100;
                for (int i = 1; i <= 100; i++)
                {
                    computerIntList.Add(i);
                }

                Console.Write("Choose a number between 1 and 100: ");
                int computerAnswer = int.Parse(Console.ReadLine());

                do
                {
                    int guess = (computerIntList.First() + computerIntList.Last()) / 2;
                    Console.WriteLine($"Is it {guess}");
                    numberGuessed += 1;
                    humanIntList = GuessingNumber(computerIntList, guess, computerAnswer);
                    Console.WriteLine($"Number of attempts: {numberGuessed}");
                    if (computerAnswer == guess)
                    {
                        quit = true;
                    }
                } while (!quit);

            }
            catch (FormatException) {; }
            catch (IndexOutOfRangeException) {; }
        }

        public static List<int> GuessingNumber(List<int> intList, int guess, int answer)
        {
            int min = intList.First();
            int mid = intList.Count / 2;

            if (guess == answer)
            {
                Console.WriteLine("You got it! You guessed the number.");
                return intList;
            }

            else if (guess > answer)
            {
                Console.WriteLine("Your guess was too high.");
                intList.RemoveRange(0, intList.Count);
                for (int i = 0; i < mid; i++)
                {
                    intList.Add(min);
                    min++;
                }
                return intList;
            }
            else
            {
                Console.WriteLine("Your guess was too low.");
                intList.RemoveRange(0, intList.Count);
                for (int i = 0; i < mid; i++)
                {
                    intList.Add(guess+1);
                    guess++;
                }
                return intList;
            }

        }
    }
}
