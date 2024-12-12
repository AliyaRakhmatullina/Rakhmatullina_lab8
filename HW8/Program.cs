using HW8.Model;

namespace HW8
{
    internal class Program
    {
        static public void SearchMail(ref string s)
        {
            string[] a = s.Split('#');
            s = a[1].Trim();
        }

         //Домашнее задание 8.1 Работа со строками.Дан текстовый файл, содержащий ФИО и e-mail
         //адрес.Разделителем между ФИО и адресом электронной почты является символ #:
         //Иванов Иван Иванович # iviviv@mail.ru
         //Петров Петр Петрович # petr@mail.ru
         //Сформировать новый файл, содержащий список адресов электронной почты.
         // Предусмотреть метод, выделяющий из строки адрес почты.Методу в
         //качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
           
        static void Task1()
        {
            Console.WriteLine("Введите название файла");
            string filename = Console.ReadLine();
            string path = $"../../../TextFiles/{filename}";

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                Console.WriteLine("Введите имя выходного файла");
                string outFilename = Console.ReadLine();
                string outPath = $"../../../TextFiles/{outFilename}";

                for (int i = 0; i < lines.Length; i++)
                {
                    SearchMail(ref lines[i]);
                }
                File.WriteAllLines(outPath, lines);
            }
            else
            {
                Console.WriteLine("Нет такого файла");
            }
        }

        //Домашнее задание 8.2 Список песен.В методе Main создать список из четырех песен.В
        //цикле вывести информацию о каждой песне.Сравнить между собой первую и вторую
        //песню в списке.Песня представляет собой класс с методами для заполнения каждого из
        //полей, методом вывода данных о песне на печать, методом, который сравнивает между
        //собой два объекта:
        static void Task2()
        {
            Song song1 = new Song();
            song1.SetName("Так хочется жить");
            song1.SetAuthor("Рождество");

            Song song2 = new Song();
            song2.SetName("А у реки");
            song2.SetAuthor("Отпетые мошенники");
            song2.SetPrev(song1);

            Song song3 = new Song();
            song3.SetName("Война");
            song3.SetAuthor("Фактор 2");
            song3.SetPrev(song2);

            Song song4 = new Song();
            song4.SetName("Рождество");
            song4.SetAuthor("Народная");
            song4.SetPrev(song3);

            List<Song> list = new List<Song>() { song1, song2, song3, song4 };
            foreach (Song s in list)
            {
                Console.WriteLine(s.Title());
            }

            Console.WriteLine("Сравнение первой и второй песни");
            if (list[0].Equals(list[1]))
            {
                Console.WriteLine("Песни равны");
            }
            else
            {
                Console.WriteLine("Песни не равны");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Домашнее задание 8.1");
            Task1();
            Console.WriteLine("Доиашнее задание 8.2");
            Task2();
        }
    }
}
