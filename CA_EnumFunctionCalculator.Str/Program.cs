using System;

namespace CA_EnumCalculator
{
    public enum Operation
    {
        NONE,
        ADD,
        SUBTRACT,
        DIVIDE,
        MULTIPLY,
        POWER,
        PERCENT
    }

    class Program
    {
        //*****************************************
        // Title: A Simple Calculator Refactored
        // Application Type: Console
        // Authors: Miles Hanbury, Lauren Lempe
        // Date Created: 03-18-2019
        // Last Modified: 03-20-2019
        //*****************************************

        /// <summary>
        /// application flow and loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            double operandX = 0, num1, num2;
            string userResponse = "";
            int operandCount=1;
            Operation operation = Operation.NONE;
            bool quitting = false, validResponse = true;

            DisplayOpeningScreen();

            //
            // application loop
            //
            while (!quitting)
            {
                num1 = 0;
                operandCount = 1;
                for (int i = 0; i < operandCount; i++)
                {
                    num2 = DisplayGetOperandX(operandX, userResponse, operandCount);
                    if (operandCount>1)
                    {
                        do
                        {
                            validResponse = true;

                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Calculating:");
                            
                            //
                            // Displays answer and replaces num1 with the answer
                            //
                            DisplayAnswer(operation, num1, num2);
                            num1 = PerformOperation(num1, num2, operation);
                            Console.WriteLine(num1);
                            DisplayContinuePrompt();

                            //
                            // asks user if they want to calculate another solution with the answer from the previous solution
                            //
                            Console.WriteLine();
                            Console.WriteLine("Would you like to make a new calculation with this answer?");
                            Console.WriteLine("[YES/NO]");
                            userResponse = Console.ReadLine();
                            userResponse = userResponse.ToUpper();
                            if (userResponse=="YES")
                            {
                                operation = DisplayGetOperation(userResponse, validResponse, operation);
                                operandCount = operandCount + 1;
                                DisplayContinuePrompt();
                            }
                            else if (userResponse=="NO")
                            {
                                operandCount = 0;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid response.");
                                DisplayContinuePrompt();
                                validResponse = false;
                            }
                        } while (!validResponse);

                    }
                    else
                    {
                        num1 = num2;
                        operation = DisplayGetOperation(userResponse , validResponse, operation);
                        operandCount = operandCount + 1;
                    }
                }
                
                quitting = DisplayGetQuitResponse(userResponse,validResponse, quitting);
            }

            DisplayClosingScreen();
        }

        /// <summary>
        /// Gets the operands for the calculation
        /// </summary>
        private static double DisplayGetOperandX(double operandX, string userResponse, int operandCount)
        {
            bool validOperand = true;
            do
            {
                validOperand = true;
                Console.Clear();
                //
                // ask user for operand
                //
                Console.WriteLine();
                Console.WriteLine($"\t\tOperand {operandCount}");
                Console.WriteLine();
                Console.Write($"Enter Operand {operandCount}: ");
                userResponse = Console.ReadLine();

                //
                // test for valid
                //
                if (double.TryParse(userResponse, out operandX))
                {
                    DisplayContinuePrompt();
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                    validOperand = false;
                    DisplayContinuePrompt();
                }
            } while (!validOperand);
            return operandX;
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

        /// <summary>
        /// get the operation and validate the user's response
        /// </summary>
        private static Operation DisplayGetOperation(string userResponse, bool validResponse, Operation operation)
        {
            string operationAsString;

            //
            // reset bool to use for validation
            //
            validResponse = false;

            while (!validResponse)
            {
                ResetConsoleScreen();

                Console.Write("\tEnter the operation ( ADD SUBTRACT MULTIPLY DIVIDE POWER PERCENT):");
                operationAsString = Console.ReadLine().ToUpper();

                if (!Enum.TryParse(operationAsString, out operation))
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
                        operation = Operation.ADD;
                        validResponse = true;
                        break;

                    case "SUBTRACT":
                        operation = Operation.SUBTRACT;
                        validResponse = true;
                        break;

                    case "MULTIPLY":
                        operation = Operation.MULTIPLY;
                        validResponse = true;
                        break;

                    case "DIVIDE":
                        operation = Operation.DIVIDE;
                        validResponse = true;
                        break;
                    case "POWER":
                        operation = Operation.POWER;
                        validResponse = true;
                        break;
                    case "PERCENT":
                        operation = Operation.PERCENT;
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

            return operation;
        }

        /// <summary>
        /// perform the calculation
        /// </summary>
        private static double PerformOperation(double num1, double num2, Operation operation)
        {
            switch (operation)
            {
                case Operation.ADD:
                    num1 = num1 + num2;
                    break;

                case Operation.SUBTRACT:
                    num1 = num1 - num2;
                    break;

                case Operation.MULTIPLY:
                    num1 = num1 * num2;
                    break;

                case Operation.DIVIDE:
                    num1 = num1 / num2;
                    break;
                case Operation.POWER:
                    num1 = Math.Pow(num1, num2);
                    break;
                case Operation.PERCENT:
                    num1 = (num1 * 100) / num2;
                    break;

                default:
                    //
                    // note: the operation was already validated, but we do need
                    //       to ensure that the operation names match or our 
                    //       answer value will always equal 0
                    //
                    break;
            }
            return num1;
        }

        /// <summary>
        /// display the answer
        /// </summary>
        private static void DisplayAnswer(Operation operation, double num1, double num2)
        {
            Console.WriteLine();
            switch (operation)
            {
                case Operation.ADD:
                    Console.Write($"{num1}+{num2}=");
                    break;

                case Operation.SUBTRACT:
                    Console.Write($"{num1}-{num2}=");
                    break;

                case Operation.MULTIPLY:
                    Console.Write($"{num1}*{num2}=");
                    break;

                case Operation.DIVIDE:
                    Console.Write($"{num1}/{num2}=");
                    break;
                case Operation.POWER:
                    Console.Write($"{num1}^{num2}=");
                    break;
                case Operation.PERCENT:
                    Console.Write($"{num1}/{num2}=");
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
        /// ask the user to continue and validate the user's response
        /// </summary>
        private static bool DisplayGetQuitResponse(string userResponse, bool validResponse, bool quitting)
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
            return quitting;
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

        /// <summary>
        /// Prompts user to press any key to continue
        /// </summary>
        private static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
