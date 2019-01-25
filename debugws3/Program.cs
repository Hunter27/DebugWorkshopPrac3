using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace debugws3
{
  public struct Result
  {
    public double result;
    public string err;

    public Result(double _result, string _err)
    {
      result = _result;
      err = _err;
    }
  }

  public class Calc
  {
    private static void WelcomeMessage()
    {
      Console.WriteLine(
          "\n\n  --------------------------- Welcome to Calculator.NET! --------------------------" +
          "\n\n Enter any calculation you would like to perform using any of the four operators" +
          "\n\n\n\t\t\t\t `+` `-` `*` `/`                                      " +
          "\n" +
          "\n\tExamples: 45 + 16" +
          "\n\t          65 * 4 / 531" +
          "\n\t          49 - 2 + 134 * 648" +
          "\n\n" +
          "\t\t\t\t You can type `EXIT` any time to leave the application." +
          "\n\n");
    }

    //Method invoked as long as the user is running the calculator
    private static bool CalculatorOn()
    {
      var userInput = Console.ReadLine();

      if (String.IsNullOrEmpty(userInput))
      {
        const string message = "Type something! :)";
        Console.WriteLine(message);
        return true;
      }

      if (userInput.ToLower() == "exit")
        return false;

      var result = Calculate(userInput);

      if (result.err != "")
      {
        Console.WriteLine("Error: {0}", result.err);
      }
      else
      {
        Console.WriteLine("Result: {0}", result.result);
        Console.WriteLine("\nType 'Exit' to leave :( Or try another calculation :)\n");
      }

      return true;
    }

    public static (int[] , char[]) Bondmath (string input)
        {
            var numArray = Regex.Matches(input, "[0-9]+").Cast<Match>().Select(m => m.Value).ToArray();
            var opArray = Regex.Matches(input, @"[+-\/*]").Cast<Match>().Select(m => m.Value).ToArray();

            //Casting Arrays to the correct data type
            int[] numbersToBeCalculated = Array.ConvertAll(numArray, int.Parse);
            char[] operations = Array.ConvertAll(opArray, char.Parse);
            List<int> nums = new List<int>();
            List<char> ops = new List<char>();

            for (int i = 0; i < operations.Length+1; i++)
            {
                if (i> operations.Length-1)
                {
                    nums.Add(numbersToBeCalculated[i]);
                }
                else
                {
                    if (operations[i] == '/' || operations[i] == '*')
                    {
                        switch (operations[i])
                        {
                            case '/':
                                {
                                    int num = numbersToBeCalculated[i] / numbersToBeCalculated[i + 1];
                                    nums.Add(num);
                                    i += 2;
                                    break;
                                }
                            case '*':
                                {
                                    int num = numbersToBeCalculated[i] * numbersToBeCalculated[i + 1];
                                    nums.Add(num);
                                    i += 2;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        nums.Add(numbersToBeCalculated[i]);
                        ops.Add(operations[i]);
                    }
                }
          
            }
            return (nums.ToArray(),ops.ToArray());
        }

    public static Result Calculate(string input)
    {
            if (input == null)
            {
                return new Result(0, "Wrong entry. Try again using one or more operations");
            }
            var numArray = Regex.Matches(input, "[0-9]+").Cast<Match>().Select(m => m.Value).ToArray();
        var opArray = Regex.Matches(input, @"[+-\/*]").Cast<Match>().Select(m => m.Value).ToArray();

        //Casting Arrays to the correct data type
        int[] numbers = Array.ConvertAll(numArray, int.Parse);
        char[] ope = Array.ConvertAll(opArray, char.Parse);
        if (ope.Length >= numbers.Length)
        {
            return new Result(0, "Wrong entry. Try again using one or more operations");
        }

       (int[] numbersToBeCalculated, char[] operations) =  Bondmath(input);
       for (var i = 0; i < numbersToBeCalculated.Length; i++)
            {
                Console.WriteLine(numbersToBeCalculated[i]);
            }
        for (var i = 0; i < operations.Length; i++)
        {
            Console.WriteLine(operations[i]);
        }



            //Casting Arrays to the correct data type


            //Checking if math operators are equal or more than the numbers to be calculated


      double result = numbersToBeCalculated[0];

      var j = 0;
      for (var i = 1; i < numbersToBeCalculated.Length; i++)
      {
        switch (operations[j])
        {
          case '+':
            {
              result += numbersToBeCalculated[i];
              break;
            }
          case '-':
            {
              result -= numbersToBeCalculated[i];
              break;
            }
          case '*':
            {
              result *= numbersToBeCalculated[i];
              break;
            }
          case '/':
            {
              result /= numbersToBeCalculated[i];
              break;
            }
          default:
            break;
        }
        j++;
      }

      return new Result(result, "");
    }

    public static void ExitAndThankYouMessage()
    {
      Console.Clear();
      Console.WriteLine("\n\n\n\n");
      Console.WriteLine(@"
                         _____  _   _  _____  _   _  _   _     _     _  _____  _   _
                        (_   _)( ) ( )(  _  )( ) ( )( ) ( )   ( )   ( )(  _  )( ) ( )
                          | |  | |_| || (_) || `\| || |/'/'   `\`\_/'/'| ( ) || | | |
                          | |  |  _  ||  _  || , ` || , <       `\ /'  | | | || | | |
                          | |  | | | || | | || |`\ || |\`\       | |   | (_) || (_) |
                          (_)  (_) (_)(_) (_)(_) (_)(_) (_)      (_)   (_____)(_____)
                                    |\
                            /    /\/o\_
                           (.-.__.(   __o
                        /\_(      .----'
                         .' \____/
                        /   /  / \
                    ___:____\__\__\__________________________________________________________");
    }

    private static void Main(string[] args)
    {
      WelcomeMessage();

      Console.WriteLine("-> Calculate ");

      bool calculatorOn = true;
      while (calculatorOn)
      {
        calculatorOn = CalculatorOn();
      }

      ExitAndThankYouMessage();
    }

  }
}