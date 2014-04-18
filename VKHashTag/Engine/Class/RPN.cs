using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VKHashTag.Engine.Class
{
    class RPN
    {
        static public double get(string input)
        {
            return new RPN().Calculate(input);
        }

        public double Calculate(string input)
        {
            string s1 = Regex.Replace(input.Replace(@".", ",").Replace(" ", "").Replace("--", "&-"), @"([0-9\)])-([0-9\(])", "$1&$2");
            string output = GetExpression(s1); //Преобразовываем выражение в постфиксную запись
            input = null; s1 = null;
            return Counting(output); //Решаем полученное выражение и возвращаем результат
        }


        private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }


        private bool IsOperator(char с)
        {
            if (("+&/*^()%".IndexOf(с) != -1))
                return true;
            return false;
        }


        private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '&': return 3;
                case '*': return 4;
                case '/': return 5;
                case '%': return 6;
                case '^': return 7;
                default: return 8;
            }
        }


        private string GetExpression(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                //Разделители пропускаем
                if (IsDelimeter(input[i]))
                    continue; //Переходим к следующему символу

                //Если символ - цифра, то считываем все число
                if (Char.IsDigit(input[i]) || input[i] == '-') //Если цифра
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу

                        if (i == input.Length)
                            break; //Если символ - последний, то выходим из цикла
                    }

                    output += " "; //Дописываем после числа пробел в строку с выражением
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }

                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {
                    if (input[i] == '(') //Если символ - открывающая скобка
                        operStack.Push(input[i]); //Записываем её в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) //Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";


            operStack = null; input = null;
            return output; //Возвращаем выражение в постфиксной записи
        }


        private double Counting(string input)
        {
            double result = 0; //Результат
            Stack<double> temp = new Stack<double>(); //Dhtvtyysq стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]) || (input[i] == '-'))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+': result = b + a; break;
                        case '&': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '%': result = b % a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }

            input = null;
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }
    }
}
