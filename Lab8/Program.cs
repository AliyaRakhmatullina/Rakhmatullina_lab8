using Lab8.Model;

namespace Lab8
{
    internal class Program
    {
        
        static void ShowAccount(BankAccount account)
        {
            Console.WriteLine($"Номер счета {account.Number}, Баланс {account.Balance}");
        }

        
        static string ReverseString(string s)
        {
            string result = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += s[i];
            }
            return result;
        }

        static BankAccount CreateBankAccount()
        {
            Console.WriteLine("Введите номер счета");
            int number = EnterInt();
            Console.WriteLine("Выберите тип счета 0.Текущий 1.Сберегательный");
            TypeAccount typeAccount = (TypeAccount)EnterTypeAccount();
            Console.WriteLine("Введите баланс");
            decimal balance = EnterInt();

            BankAccount bankAccount = new BankAccount(balance, typeAccount);
            bankAccount.Number = number;
            return bankAccount;
        }


        //Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
        //метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
        //на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
        static void Task1() 
        {
            
            BankAccount account1 = new BankAccount(10000, TypeAccount.Savings);
            BankAccount account2 = new BankAccount(5000, TypeAccount.Current);
            ShowAccount(account1);
            ShowAccount(account2);

            account1.Transfer(account2, 3000);

            Console.WriteLine("После перевода");
            ShowAccount(account1);
            ShowAccount(account2);
        }

        //Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает
        //строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
        //Протестировать метод.
        static void Task2()
        {
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();

            string reverseStr = ReverseString(str);
            Console.WriteLine(reverseStr);
        }

        //Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла.Если
        //такого файла не существует, то программа выдает пользователю сообщение и заканчивает
        //работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
        //буквами.
        static void Task3()
        {
            Console.WriteLine("Введите имя исходного файла");
            string filename = Console.ReadLine();
            string path = $"../../../TextFiles/{filename}";

            if (!File.Exists(path))
            {
                Console.WriteLine("Нет такого файла");
            }
            else
            {
                Console.WriteLine("Введите имя выходного файла");
                string outFilename = Console.ReadLine();

                string text = File.ReadAllText(path);
                text = text.ToUpper();
                string outPath = $"../../../TextFiles/{outFilename}";
                File.WriteAllText(outPath, text);
            }
        }

        static bool CheckFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                Console.WriteLine($"Переменная {obj} является IFormattable, проверка через is");
                return true;
            }
            else
            {
                IFormattable b = obj as IFormattable;
                if (b != null)
                {
                    Console.WriteLine($"Переменная {obj} является IFormattable, проверка через as");
                    return true;
                }
                Console.WriteLine($"Переменная {obj} не является IFormattable");
                return false;
            }
        }


        //Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
        //метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
        //IFormattable обеспечивает функциональные возможности форматирования значения объекта
        //в строковое представление.)
        static void Task4()
        {
            string a = "checker";
            int b = 20;

            CheckFormattable(a);
            CheckFormattable(b);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            Task1();
            Console.WriteLine("Упражнение 8.2");
            Task2();
            Console.WriteLine("Упражнение 8.3");
            Task3();
            Console.WriteLine("Упражнение 8.4");
            Task4();
        }

        static int EnterInt()
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести неотрицательное целое число");
                }
            }
            while (flag);

            return number;
        }

        static int EnterTypeAccount()
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    if (number == 0 || number == 1)
                        flag = false;
                    else
                    {
                        Console.WriteLine("Введите число 0 или 1");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести неотрицательное целое число");
                }
            }
            while (flag);

            return number;
        }
    }
}
