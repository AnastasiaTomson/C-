using System;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string catName, message;
            string menu = "------------------------------------------- \n" +
                          " Назвать кошку - нажмите 0 \n" +
                          " Накормить кошку - нажмите 1 \n" +
                          " Наказать кошку - нажмите 2 \n" +
                          " Здоровье кошки - нажмите 3 \n" +
                          " Полная информация о кошке - нажмите 4 \n" +
                          " Выход - нажмите 5 \n" +
                          "------------------------------------------- \n";
            bool isNum, isRu;
            short key;
            Cat cat = new Cat();
            Console.WriteLine(menu);
            while (true)
            {
                Int16.TryParse(Console.ReadLine(), out key);
                Console.WriteLine("------------------------------------------");
                switch (key)
                {
                    case 0:
                        message = " Введите имя кошки \n" +
                                  "------------------------------------------- \n" +
                                  " Требования к имени: \n" +
                                  "1. Не должно содержать цифр; \n" +
                                  "2. Минимальная длинна имени 3, а максимальная 15; \n" +
                                  "3. Русские символы; \n" +
                                  "4. Не пустое значение. \n" +
                                  "------------------------------------------- \n";
                        isRu = true;
                        do
                        {
                            Console.WriteLine(message);
                            catName = Console.ReadLine();
                            isNum = false;
                            for (int i = 0; i < catName.Length; i++)
                            {
                                try
                                {
                                    int.Parse(catName[i].ToString());
                                    isNum = true;
                                    i = catName.Length;
                                }
                                catch (Exception)
                                {
                                    if (catName[i] > 127)
                                    {
                                        isRu = false;
                                    }
                                    else
                                    {
                                        isRu = true;
                                    }
                                    continue;
                                }
                            }
                            message = "Неверно введено имя, попробуйте еще раз!";
                        } while (catName == "" || catName.Length < 3 || catName.Length > 15 || isNum || isRu);
                        cat.Name = catName;
                        break;
                    case 1:
                        cat.FeedTheCat();
                        break;
                    case 2:
                        cat.PunishCat();
                        break;
                    case 3:
                        cat.GetHealthCat();
                        break;
                    case 4:
                        cat.GetInforamtionCat();
                        break;
                    case 5:
                        Console.Write(" Пока, я буду скучать! ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("<3");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Нет такой команды \n" +
                                          "Ознакомтесь с меню \n" +
                                          menu);
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("------------------------------------------");
            }
        }
    }

    class Cat
    { 
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != null)
                {
                    Console.WriteLine("Нельзя переименовать кошку! Её имя " + name);
                }
                name = value;
            }
        }

        public int Health = 10;
        
        public void PunishCat()
        {
            if (Health == 0)
            {
                Console.Write(" Кошку нельзя наказывать, ее здоровье равно ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0");
                Console.ResetColor();
            }
            else
            {
                Health -= 1;
                Console.Write(" Кошка наказана и очень сожалеет");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("  (￢_￢;)");
                Console.ResetColor();
                Console.Write(" Здоровье");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  -1");
            }
        }

        public void FeedTheCat()
        {
            if (Health == 10)
            {
                Console.Write(" Кошка сыта");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  (^ ω ^)");                
            }else
            {
                Health += 1;
                Console.Write(" Кошка накормлена! Спасибо ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<3");
                Console.ResetColor();
                Console.Write(" Здоровье ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+1");
            }
        }

        public void GetHealthCat()
        {
            if (Health <= 10 && Health > 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (Health <= 6 && Health > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (Health <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(" Здоровье кошки: " + Health);
        }

        public void GetInforamtionCat()
        {
            Console.WriteLine(" Имя кошки: " + Name);

            if (Health <= 10 && Health > 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (Health <= 6 && Health > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (Health <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(" Здоровье кошки: " + Health);
        }
    }
}