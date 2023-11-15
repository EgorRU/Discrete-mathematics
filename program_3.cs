using System;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static int x_to_y(int i, int count)
        {
            if (i < count) //если у нас 0 по 1 иил 2 по 3 то выводим 0
                return 0;

            int result = -1;

            int a = Enumerable.Range(1, i).Aggregate(1, (p, item) => p * item); //считаем числитель i!
            int b = Enumerable.Range(1, count).Aggregate(1, (p, item) => p * item); //считаем первый член знаменателя count!
            int c = Enumerable.Range(1, i - count).Aggregate(1, (p, item) => p * item); //считаем второй член знаменателя (i-count)!

            result = a / b / c; //получаем результат
            return result;
        }

        static int word_to_number(string word)
        {
            int count = 0; //счетчик единичек
            int sum = 0; // перменная для хранения номера
            for (int i = word.Length - 1; i >= 0; i--) // идем по слову с конца
            {
                if (word[i] == '1') // если видим единичку
                {
                    count++; // увеличиваем счетчик единичек
                    sum += x_to_y(word.Length - i - 1, count); //увеличиваем число на номер с конца по кол-во единичек
                }
            }
            if (count != 6)
                return -1;
            return sum; //возвращаем полученный результат
        }

        static string number_to_word(int number)
        {
            string word = "";
            int[] places = new int[6];
            int k1 = 6;
            while (number != 0)
            {
                int c = 0;
                int prev = 0;
                int e = k1;
                while (number >= c)
                {
                    prev = c;
                    c = x_to_y(e, k1);
                    e++;
                }
                number -= prev;
                places[k1 - 1] = e - 1;
                k1--;
            }
            for (int i = 0; i < k1; i++)
                places[i] = i + 1;
            for (int i = 12; i > 0; i--)
                if (places.Contains(i))
                    word += "1";
                else
                    word += "0";
            return word;
        }


        static void Main(string[] args)
        {
            string word1, word2;
            int number1 = -1, number2 = -1;
            Console.WriteLine("Введите первое слово");
            word1 = Console.ReadLine();
            Console.WriteLine("Введите второе слово");
            word2 = Console.ReadLine();
            if (word1.Length != 12)
                Console.WriteLine("Первое слово плохое (");
            else
            {
                number1 = word_to_number(word1);
                if (number1 == -1)
                    Console.WriteLine("Первое слово плохое (");
            }

            if (word2.Length != 12)
                Console.WriteLine("Второе слово плохое (");
            else
            {
                number2 = word_to_number(word2);
                if (number2 == -1)
                    Console.WriteLine("Второе слово плохое (");
            }
            if (number1 > number2)
            {
                Console.WriteLine("Промежуток подразумевает, что второе число больше первого, \nтак что программа сама поменяет числа местами )");
                number1 += number2;
                number2 = number1 - number2;
                number1 = number1 - number2;
            }
            int count_if_numbers = number2 - number1 - 1;
            Console.WriteLine("кол-во чисел между " + count_if_numbers);
            if (count_if_numbers > 0)
                for (int i = 1; i <= count_if_numbers; i++)
                {
                    int temp_number = number1 + i;
                    Console.WriteLine(number_to_word(temp_number));
                }
            Console.Read();
        }
    }
}