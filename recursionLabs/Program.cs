using System;

namespace recursionLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://habr.com/ru/post/275813/
            //нельзя использовать строки, списки, массивы, циклы

            //(1)
            int n = Convert.ToInt32(Console.ReadLine());
            //OutputFrom1ToN(1, n);

            //(2)
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //OutputFromAToB(a, b);

            //(3)
            //Console.WriteLine(DoFunctionAkkerman(a, b));

            //(4)
            //Console.WriteLine(DoPowerOfTwo(n));

            //(5)
            //Console.WriteLine(FindSumOfDigits(n, 0));

            //(6)
            //Console.WriteLine(DigitsFromRightToLeft(n));

            //(7)
            //Console.WriteLine(DigitsFromLeftToRight(n));

            //(8)
            //Console.WriteLine(CheckForSimpleNumber(n, 2));

            //(9)
            Console.WriteLine(Factorization(n, 2));
        }

        //(1) От 1 до n
        //Дано натуральное число n. Выведите все числа от 1 до n.
        public static void OutputFrom1ToN(int one, int number)
        {
            Console.WriteLine(one++);
            if (one <= number)
                OutputFrom1ToN(one, number);
            else
                Console.ReadKey();
        }

        //(2) От A до B
        //Даны два целых числа A и В(каждое в отдельной строке).
        //Выведите все числа от A до B включительно, в порядке возрастания, если A < B
        //или в порядке убывания в противном случае.
        public static void OutputFromAToB(int numFirst, int numSecond)
        {
            if (numFirst <= numSecond)
                OutputFrom1ToN(numFirst, numSecond);
            else OutputBackWard(numFirst, numSecond);
        }
        public static void OutputBackWard(int numFirst, int numSecond)
        {
            Console.WriteLine(numFirst--);
            if (numFirst >= numSecond)
                OutputBackWard(numFirst, numSecond);
            else
                Console.ReadKey();
        }

        //(3) Функция Аккермана
        //В теории вычислимости важную роль играет функция Аккермана A(m,n);
        //          [ n + 1              m = 0
        //A(m, n) = [ A(m−1, 1)          m > 0, n = 0
        //          [ A(m−1, A(m, n−1))  m > 0, n > 0
        //Даны два целых неотрицательных числа m и n, каждое в отдельной строке. Выведите A(m, n).
        public static int DoFunctionAkkerman(int m, int n)
        {
            if (m == 0)
                return n + 1;
            else if (m > 0 && n == 0)
                return DoFunctionAkkerman(m - 1, 1);
            else if (m > 0 && n > 0)
                return DoFunctionAkkerman(m - 1, DoFunctionAkkerman(m, n - 1));
            return DoFunctionAkkerman(m, n);
        }

        //(4) Точная степень двойки
        //Дано натуральное число N. Выведите слово YES, если число N является точной степенью двойки,
        //или слово NO в противном случае.
        public static string DoPowerOfTwo(int number)
        {
            if (number / 1 == 2)
                return "Yes";
            else if (number > 2 && number % 2 == 0)
                return DoPowerOfTwo(number / 2);
            else return "No";
        }

        //(5) Сумма цифр числа
        //Дано натуральное число N. Вычислите сумму его цифр.
        public static int FindSumOfDigits(int number, int sum)
        {
            if (number > 0)
            {
                sum += number % 10;
                return FindSumOfDigits(number / 10, sum);
            }
            else return sum;
        }

        //(6) Цифры числа справа налево
        //Дано натуральное число N. Выведите все его цифры по одной,
        //в обратном порядке, разделяя их пробелами или новыми строками.
        public static string DigitsFromRightToLeft(int number)
        {
            if (number > 9)
                return (number % 10).ToString() + " " + DigitsFromRightToLeft(number / 10);
            else
                return number.ToString();
        }

        //(7) Цифры числа слева направо
        //Дано натуральное число N. Выведите все его цифры по одной,
        //в обычном порядке, разделяя их пробелами или новыми строками.
        public static string DigitsFromLeftToRight(int number)
        {
            if (number < 10)
                return number.ToString();
            else
                return DigitsFromLeftToRight(number / 10) + " " + number % 10;
        }

        //(8) Проверка числа на простоту
        //Дано натуральное число n > 1. Проверьте, является ли оно простым.
        //вывести слово YES, если число простое и NO, если число составное.
        //задача сама по себе нерекурсивна, т.к. проверка числа n на простоту никак не сводится к проверке на простоту меньших чисел
        //Поэтому нужно сделать еще один параметр рекурсии: делитель числа, и именно по этому параметру и делать рекурсию.
        public static string CheckForSimpleNumber(int number, int i)
        {
            if (number == 2)
                return "Yes";
            else if (number % i == 0)
                return "No";
            else if (i < number / 2)
                return CheckForSimpleNumber(number, i + 1);
            else
                return "Yes";
        }

        //(9) Разложение на множители
        //Дано натуральное число n > 1.
        //Выведите все простые делители этого числа в порядке неубывания с учетом кратности.
        public static string Factorization(int number, int i)
        {
            if (number == 1)
                return "";
            else if (number % i == 0)
            {
                return i + " " + Factorization(number / i, i);
            }
            else
                return Factorization(number, ++i);
        }

    }
}
