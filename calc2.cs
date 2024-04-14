using System;
using System.Collections.Generic;

public class Program
{
    public static bool TryConvertInfixToPostfixe(string expression, out string postfixExpression)
    {
        postfixExpression = InfixToPostfix(expression);
        return postfixExpression != null;
    }

    static int Main(string[] args)
    {
        Console.WriteLine("Please, write your example:");
        string expression = Console.ReadLine();

        //string postfixExpression = InfixToPostfix(expression);
        if (TryConvertInfixToPostfixe(expression, out var postfixExpression))
        {
            int result = Evaluate(postfixExpression);
            Console.WriteLine("Result: " + result);
            Console.ReadLine();            
            return 0;
        }
        else
        {
            Console.WriteLine("Error");
            Console.ReadLine();
            return 1;
        }
        
    }

    public static string InfixToPostfix(string expression)
    {
        int length = expression.Length;
        Stack<string> operation = new Stack<string>();
        Queue<string> numb_oper = new Queue<string>();
        int i = 0;
        int number;
        char bracket = '(';
        char plus = '+';
        char minus = '-';
        char multiply = '*';
        char bracket_r = ')';
        while (i < length)
        {
            string currentobject = expression[i].ToString();
            if (int.TryParse(currentobject, out number))
            {
                numb_oper.Enqueue(currentobject);
            }
            else
            {
                if (operation.Count == 0 || operation.Peek() == bracket.ToString())
                {
                    operation.Push(currentobject);
                }
                else
                {
                    if ((operation.Peek() == plus.ToString() || operation.Peek() == minus.ToString()) && (currentobject == multiply.ToString()))
                    {
                        operation.Push(currentobject);
                    }
                    else if (currentobject == bracket.ToString())
                    {
                        operation.Push(currentobject);
                    }
                    else if (currentobject == bracket_r.ToString())
                    {
                        while (operation.Peek() != bracket.ToString())
                        {
                            numb_oper.Enqueue(operation.Pop());
                        }
                        operation.Pop();
                    }
                    else
                    {
                        while (operation.Count > 0 && operation.Peek() != bracket.ToString() && GetPriority(operation.Peek()) >= GetPriority(currentobject))
                        {
                            numb_oper.Enqueue(operation.Pop());
                        }
                        operation.Push(currentobject);
                    }
                }
            }
            i++;
        }

        while (operation.Count > 0)
        {
            numb_oper.Enqueue(operation.Pop());
        }

        string postfixExpression = string.Join(" ", numb_oper);
        return postfixExpression;
    }

    public static int Evaluate(string expression)
    {
        string[] tokens = expression.Split(' ');
        Stack<int> stack = new Stack<int>();

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(operand1 + operand2);
                        break;
                    case "-":
                        stack.Push(operand1 - operand2);
                        break;
                    case "*":
                        stack.Push(operand1 * operand2);
                        break;
                    default:
                        throw new ArgumentException("Invalid token: " + token);
                }
            }
        }

        return stack.Pop();
    }

    static int GetPriority(string op)
    {
        switch (op)
        {
            case "+":
            case "-":
                return 1;
            case "*":
                return 2;
            default:
                return 0;
        }
    }
}