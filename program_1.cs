using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static bool Check(string word, int[] arr_count)
        {
            int[] count_of_i = { 0, 0, 0, 0, 0 };
            Console.WriteLine(word);
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == '0')
                    count_of_i[0]++;
                if (word[i] == '1')
                    count_of_i[1]++;
                if (word[i] == '2')
                    count_of_i[2]++;
                if (word[i] == '3')
                    count_of_i[3]++;
                if (word[i] == '4')
                    count_of_i[4]++;
            }
            for (int i = 0; i < arr_count.Length; i++)
                if (arr_count[i] != count_of_i[i])
                    return false;
            return true;
        }

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
            return sum; //���������� ���������� ���������
        }

        public static string number_to_word(double number, double length, double count_of_1)
        {
            string s = "";
            double[] places = new double[(int)count_of_1];
            while (number != 0)
            {
                double c = 0;
                double prev = 0;
                double e = count_of_1;
                while (number >= c)
                {
                    prev = c;
                    if (e == count_of_1)
                        c = 1;
                    else
                        c = c * (e / (e - count_of_1));
                    e++;
                }
                number -= prev;
                places[(int)count_of_1 - 1] = e - 1;
                count_of_1--;
            }
            for (int i = 0; i < count_of_1; i++)
            {
                places[i] = i + 1;
            }
            for (int i = (int)length; i > 0; i--)
            {
                if (places.Contains(i)) s += "1";
                else s += "0";
            }
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("������� ����� �������\n1) - �� ����� �������� 4 ������\n2) - �� 4 ������� �������� �����\n");
            char[] arr = { '0', '1', '2', '3', '4' };
            int[] arr_count = { 4, 3, 2, 3, 2 };
            if (int.TryParse(Console.ReadLine(), out int task))
            {
                switch (task)
                {
                    case 1:
                        {
                            int len = 14; //����� �����
                            Console.WriteLine("������� �����");
                            string word1 = Console.ReadLine(); //��������� �����

                            if (word1.Length != len || !Check(word1, arr_count))
                                Console.WriteLine("����� ������ (");
                            else
                            {
                                int number1;
                                number1 = word_to_number(word1);
                                if (number1 == -1)
                                    Console.WriteLine("����� ������ (");
                            }
                            string word = String.Copy(word1); //������� ����� �����
                            string wordlast;
                            int count_of_1 = 0;
                            for (int j = 0; j < arr.Length - 1; j++) //�������� �� ������� �������� ��������
                            {
                                wordlast = word;
                                word = "";
                                string word2 = "";
                                for (int i = 0; i < wordlast.Length; i++) //�������� �� ����� �����
                                {
                                    if (wordlast[i] != arr[j])
                                    {
                                        word2 += "1";
                                        word += wordlast[i];
                                        count_of_1++;
                                    }
                                    else
                                        word2 += "0";
                                }
                                Console.WriteLine("�����: " + word2 + ", �����: " + word_to_number(word2));
                            }
                            break;
                        }
                    case 2:
                        {
                            int[] arr_num = { 0, 0, 0, 0 };
                            int[] arr_len = { 14, 10, 7, 5 };
                            int[] arr_ones = { 10, 7, 5, 2 };
                            Console.WriteLine("������� ������:");
                            string s = Console.ReadLine();
                            string[] str = s.Split();
                            for (int i = 0; i < arr.Length - 1; i++)
                                arr_num[i] = Convert.ToInt32(str[i]);
                            string word = "";
                            for (int i = 0; i < arr_count[arr.Length - 1]; i++)
                                word += arr[arr.Length - 1];
                            for (int i = 0; i < arr.Length - 1; i++)
                            {
                                string temp = "";
                                int a = arr_num[arr_num.Length - 1 - i];
                                int b = arr_len[arr_len.Length - 1 - i];
                                int c = arr_ones[arr_ones.Length - 1 - i];
                                string word1 = number_to_word(a, b, c);
                                int k = 0;
                                for (int j = 0; j < word1.Length; j++)
                                {
                                    if (word1[j] == '0')
                                        temp += arr[arr.Length - 2 - i];
                                    else
                                    {
                                        temp += word[k];
                                        k++;
                                    }

                                }
                                word = temp;
                            }
                            Console.WriteLine("��������� ����� " + word);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("������ ������ �� ���������� (");
                            break;
                        }
                }
            }
            Console.ReadKey();
        }
    }
}