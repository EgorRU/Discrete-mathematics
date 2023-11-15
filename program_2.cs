using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static int word_to_number(string array, string word, int len) //������� �������� ����� � ��� �����
        {
            int number = 0; //���������� ��� ������
            //��������� ����� � �������� �� �������� (��� ����� ������) ������� ��������� � ���������
            for (int i = len � 1; i > 0; i--) //�������� �� ���� 7 �������� �����
                for (int k = 0; k < array.Length; k++) //���������� ����� � ��������
                if (word[i] == array[k]) //���� � ����� ������� ����� �� ��������
                    number += k * (int)Math.Pow(array.Length, (word.Length � i � 1)); //�� ��������� �����         
            return number; //������� ���������
        }

        static char[] number_to_word(string array, int number, int len) //������� �������� ������ ����� � ���� �����
        {
            char[] word = { '3', '3', '3', '3', '3', '3', '3' }; //���������� ��������� ������������ ���������� �� ���������
            while (number > 4)
            {
                int i = 0;
                for (; i < 10;) //���� ��� �������� ���������� �������
                {
                    if (number > (int)Math.Pow(array.Length, i))
                        i++;
                    else break;
                }
                int count = 0;
                for (; count < 10;) //���� ��� �������� ��������� ���-�� ��� ������ ����� ������� � �����
                {
                    if (number > (int)Math.Pow(array.Length, i � 1) * count)
                        count++;
                    else break;
                }
                number -= (int)Math.Pow(array.Length, i � 1) * (count - 1); //�������� �������� ��� ����������� ��������� �������
                word[len � i � 2] = array[count � 1]; //����������� �����
            }
            word[len � 1] = array[number]; //����������� ��������� �����
            return word; //������� ���������
        }

        static void Main(string[] args)
        {
            string array = "35678";
            int len = 7;

            Console.WriteLine("������� ������ �������");
            string word1 = Console.ReadLine();
            Console.WriteLine("������� ����� �������");
            string word2 = Console.ReadLine();
            int num1 = word_to_number(array, word1, len), num2 = word_to_number(array, word2, len);
            Console.WriteLine("������� 1 � ��������� ���-�� ����� �� �������, 2 � ������� ��� ����� � ����������");
            int switcher = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            if (num1 >= num2)
                Console.WriteLine("����� � ���������� ���");
            if (switcher == 1)
                Console.WriteLine(num2 � num1 + 1);
            if (switcher == 2)
            {
                for (int i = num1; i <= num2; i++)
                    Console.WriteLine(number_to_word(array, i, len));
            }
            Console.ReadKey();
        }
    }
}