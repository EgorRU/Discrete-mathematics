using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static int word_to_number(string array, string word, int len) //функци€ перевода слова в его номер
        {
            int number = 0; //переменна€ дл€ номера
            //структура схожа с перводом из двоичной (или любой другой) системы счислени€ в дес€тичую
            for (int i = len Ц 1; i > 0; i--) //проходим по всем 7 символам слова
                for (int k = 0; k < array.Length; k++) //перебираем буквы в алфавите
                if (word[i] == array[k]) //если в слове нашлась буква из алфавита
                    number += k * (int)Math.Pow(array.Length, (word.Length Ц i Ц 1)); //то вычисл€ем число         
            return number; //выводим результат
        }

        static char[] number_to_word(string array, int number, int len) //функци€ перевода номера слова в само слово
        {
            char[] word = { '3', '3', '3', '3', '3', '3', '3' }; //изначально заполн€ем минимальными значени€ми из афлфавита
            while (number > 4)
            {
                int i = 0;
                for (; i < 10;) //цикл дл€ подсчЄта наибольшей степени
                {
                    if (number > (int)Math.Pow(array.Length, i))
                        i++;
                    else break;
                }
                int count = 0;
                for (; count < 10;) //цикл дл€ подсчЄта наибольго кол-ва раз котрое можно забрать у числа
                {
                    if (number > (int)Math.Pow(array.Length, i Ц 1) * count)
                        count++;
                    else break;
                }
                number -= (int)Math.Pow(array.Length, i Ц 1) * (count - 1); //вычитаем максимум раз максимально возможную степень
                word[len Ц i Ц 2] = array[count Ц 1]; //редактируем слово
            }
            word[len Ц 1] = array[number]; //редактируем последнюю букву
            return word; //выводим результат
        }

        static void Main(string[] args)
        {
            string array = "35678";
            int len = 7;

            Console.WriteLine("¬ведите начало отрезка");
            string word1 = Console.ReadLine();
            Console.WriteLine("¬ведите конец отрезка");
            string word2 = Console.ReadLine();
            int num1 = word_to_number(array, word1, len), num2 = word_to_number(array, word2, len);
            Console.WriteLine("¬ведите 1 Ц посчитать кол-во чисел на отрезке, 2 Ц вывести все числа в промежутке");
            int switcher = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            if (num1 >= num2)
                Console.WriteLine("„исел в промежутке нет");
            if (switcher == 1)
                Console.WriteLine(num2 Ц num1 + 1);
            if (switcher == 2)
            {
                for (int i = num1; i <= num2; i++)
                    Console.WriteLine(number_to_word(array, i, len));
            }
            Console.ReadKey();
        }
    }
}