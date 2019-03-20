using System;

namespace CA_EnumCalculator
{
    public enum Operation
        {
            ADD,
            SUBTRACT,
            DIVIDE,
            MULTIPLY,
            POWER,
            PERCENT
        }
    class Program
    {
        //
        // declare global variables
        //
        static double operand, answer;
        //yjdtfhgjh

        static string userResponse;
        static string operationAsString;
        static Operation operation;
        static string operationSymbol;

        static bool quitting = false;
        static bool validResponse;

        /// <summary>
        /// application flow and loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayOpeningScreen();

            //
            // application loop
            //
            while (!quitting)
            {
                DisplayGetFirstNumber();

                DisplayGetSecondNumber();

                DisplayGetOperation();

                PerformOperation();

                DisplayAnswer();

                DisplayGetQuitResponse();
            }

            DisplayClosingScreen();
        }

        /// <summary>
        /// display the opening screen
        /// </summary>
        private static void DisplayOpeningScreen()
        {
            //
            // display opening screen
            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Simple Calculator");
            Console.WriteLine("\t\tLaughing Leaf Productions");
            Console.WriteLine();

            //
            // pause for user
            //
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
        }

        private static void GetOperandX()
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();
                int operandCount = 0;
                operandCount = operandCount + 1;

                Console.Write($"\tEnter Operand {operandCount}:");
                userResponse = Console.ReadLine();

                if (!double.TryParse(userResponse, out operand))
                {
                    Console.WriteLine("\tYou must enter a number. (2.4, 9, etc.)");
                    
                    //
                    // pause for user
                    //
                    Console.WriteLine("\t\tPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    validResponse = true;
                }
            }
            /* 
             * 
             * My email is hanbur3@mail.nmc.edu if have any questions
             * 
             * 
             * 
        /// <summary>
        /// get the first number and validate the user's response
        /// </summary>
        private static void DisplayGetFirstNumber()
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tEnter the first number:");
                userResponse = Console.ReadLine();

                if (!double.TryParse(userResponse, out number1))
                {
                    Console.WriteLine("\tYou must enter a number. (2.4, 9, etc.)");

                    //
                    // pause for user
                    //
                    Console.WriteLine("\t\tPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    validResponse = true;
                }
            }
        }

        /// <summary>
        /// get the second number and validate the user's response
        /// </summary>
        private static void DisplayGetSecondNumber()
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tEnter the second number:");
                userResponse = Console.ReadLine();

                if (!double.TryParse(userResponse, out number2))
                {
                    Console.WriteLine("\tYou must enter a number. (2.4, 9, etc.)");

                    //
                    // pause for user
                    //
                    Console.WriteLine("\t\tPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    validResponse = true;
                }
            }
        }
        */

        /// <summary>
        /// get the operation and validate the user's response
        /// </summary>
        private static void DisplayGetOperation()
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tEnter the operation ( ADD SUBTRACT MULTIPLY DIVIDE POWER PERCENT):");
                operationAsString = Console.ReadLine().ToUpper();

                if (!Enum.TryParse(userResponse, out operation))
                {
                    Console.WriteLine("Operation invalid. Please enter a new operation.");
                    validResponse = false;
                }

                //
                // validate the user response and process their choice
                //
                switch (operationAsString)
                {
                    case "ADD":
                        operationSymbol = "+";
                        validResponse = true;
                        break;

                    case "SUBTRACT":
                        operationSymbol = "-";
                        validResponse = true;
                        break;

                    case "MULTIPLY":
                        operationSymbol = "*";
                        validResponse = true;
                        break;

                    case "DIVIDE":
                        operationSymbol = "/";
                        validResponse = true;
                        break;
                    case "POWER":
                        operationSymbol = "^";
                        validResponse = true;
                        break;
                    case "PERCENT":
                        operationSymbol = "/";
                        validResponse = true;
                        break;
                    default:
                        Console.WriteLine("\tYou must enter a valid operation.");

                        //
                        // pause for user
                        //
                        Console.WriteLine("\t\tPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// perform the calculation
        /// </summary>
        private static void PerformOperation()
        {
            switch (operationAsString)
            {
                case "ADD":
                    answer = number1 + number2;
                    break;

                case "SUBTRACT":
                    answer = number1 - number2;
                    break;

                case "MULTIPLY":
                    answer = number1 * number2;
                    break;

                case "DIVIDE":
                    answer = number1 / number2;
                    break;
                case "POWER":
                    answer = Math.Pow(number1, number2);
                    break;
                case "PERCENT":
                    answer = (number1 * 100) / number2;
                    break;

                default:
                    //
                    // note: the operation was already validated, but we do need
                    //       to ensure that the operation names match or our 
                    //       answer value will always equal 0
                    //
                    break;
            }
        }

        /// <summary>
        /// display the answer
        /// </summary>
        private static void DisplayAnswer()
        {
            string answerString = "";

            ResetConsoleScreen();

            if (operationAsString == "DIVIDE" && number2 == 0)
            {
                Console.WriteLine("\tDividing by zero is not allowed.");
            }
            else
            {
                if (operationAsString == "DIVIDE")
                {
                    answerString = answer.ToString("N2");
                }
                else
                {
                    answerString = answer.ToString("N");
                }

                Console.WriteLine($"\tAnswer: {number1} {operationSymbol} {number2} = {answerString}");
            }
            
            //
            // pause for user
            //
            Console.WriteLine();
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// ask the user to continue and validate the user's response
        /// </summary>
        private static void DisplayGetQuitResponse()
        {
            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tWould you like to perform another calculation ( YES or NO ):");
                userResponse = Console.ReadLine().ToUpper();

                //
                // validate the user response and process their choice
                //
                if (!(userResponse == "NO" || userResponse == "YES"))
                {
                    Console.WriteLine("\tYou must enter either 'YES' or 'NO'.");

                    //
                    // pause for user
                    //
                    Console.WriteLine("\t\tPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    if (userResponse == "NO")
                    {
                        quitting = true;
                    }

                    validResponse = true;
                }
            }
        }

        /// <summary>
        /// display the closing screen
        /// </summary>
        private static void DisplayClosingScreen()
        {
            ResetConsoleScreen();

            Console.WriteLine("\tThank you for using our application");
            Console.WriteLine();
            Console.WriteLine("\tLaughing Leaf Productions");
            Console.WriteLine();

            //
            // pause for user
            //
            Console.WriteLine("\t\tPress any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// reset the console screen and add a header
        /// </summary>
        private static void ResetConsoleScreen()
        {
            Console.Clear();

            //
            // display header
            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Simple Calculator");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
