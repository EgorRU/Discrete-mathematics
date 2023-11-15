using System;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static int x_to_y(int i, int count)
        {
            if (i < count) //���� � ��� 0 �� 1 ��� 2 �� 3 �� ������� 0
                return 0;

            int result = -1;

            int a = Enumerable.Range(1, i).Aggregate(1, (p, item) => p * item); //������� ��������� i!
            int b = Enumerable.Range(1, count).Aggregate(1, (p, item) => p * item); //������� ������ ���� ����������� count!
            int c = Enumerable.Range(1, i - count).Aggregate(1, (p, item) => p * item); //������� ������ ���� ����������� (i-count)!

            result = a / b / c; //�������� ���������
            return result;
        }

        static int word_to_number(string word)
        {
            int count = 0; //������� ��������
            int sum = 0; // ��������� ��� �������� ������
            for (int i = word.Length - 1; i >= 0; i--) // ���� �� ����� � �����
            {
                if (word[i] == '1') // ���� ����� ��������
                {
                    count++; // ����������� ������� ��������
                    sum += x_to_y(word.Length - i - 1, count); //����������� ����� �� ����� � ����� �� ���-�� ��������
                }
            }
            if (count != 6)
                return -1;
            return sum; //���������� ���������� ���������
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
            Console.WriteLine("������� ������ �����");
            word1 = Console.ReadLine();
            Console.WriteLine("������� ������ �����");
            word2 = Console.ReadLine();
            if (word1.Length != 12)
                Console.WriteLine("������ ����� ������ (");
            else
            {
                number1 = word_to_number(word1);
                if (number1 == -1)
                    Console.WriteLine("������ ����� ������ (");
            }

            if (word2.Length != 12)
                Console.WriteLine("������ ����� ������ (");
            else
            {
                number2 = word_to_number(word2);
                if (number2 == -1)
                    Console.WriteLine("������ ����� ������ (");
            }
            if (number1 > number2)
            {
                Console.WriteLine("���������� �������������, ��� ������ ����� ������ �������, \n��� ��� ��������� ���� �������� ����� ������� )");
                number1 += number2;
                number2 = number1 - number2;
                number1 = number1 - number2;
            }
            int count_if_numbers = number2 - number1 - 1;
            Console.WriteLine("���-�� ����� ����� " + count_if_numbers);
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