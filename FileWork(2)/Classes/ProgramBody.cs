using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pagination.Classes
{
    static class ProgramBody
    {
        public static List<Teacher> MenuFunct(IEnumerable<Teacher> teachers)
        {
            int skipped = 0;
            var coll = teachers.Skip(skipped * 5).Take(5);
            while (true)
            {
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                do
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    coll = teachers.Skip(skipped * 5).Take(5);
                    if (coll.Count() <= 0)
                    {
                        skipped--;
                        break;
                    }

                    Console.WriteLine("    ================================");
                    foreach (var item in coll)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.ResetColor();
                    }
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("    ================================");
                    Console.SetCursorPosition(7, 27);
                    Console.WriteLine("\t (<)  Сторiнка: " + (skipped + 1) + "  (>)");

                    Console.SetCursorPosition(50, 10);
                    Console.WriteLine("\t Додати жмiть +");
                    Console.SetCursorPosition(50, 11);
                    Console.WriteLine("\t Видалити жмiть -");
                    Console.SetCursorPosition(50, 12);
                    Console.WriteLine("\t Вийти жмiть Enter");


                    for (int y = 1; y <= 25; y++)
                    {
                        Console.SetCursorPosition(35, y);
                        Console.WriteLine("|");
                        Console.SetCursorPosition(4, y);
                        Console.WriteLine("|");
                    }


                    keyInfo = Console.ReadKey();
                } while (keyInfo.Key != ConsoleKey.LeftArrow 
                && keyInfo.Key != ConsoleKey.RightArrow 
                && keyInfo.Key != ConsoleKey.Enter
                && keyInfo.Key != ConsoleKey.OemPlus
                && keyInfo.Key != ConsoleKey.OemMinus);


                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (skipped > 0)
                            {
                                skipped--;
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (skipped < teachers.Count() / 5)
                            {
                                skipped++;
                            }
                            break;
                        }
                    case ConsoleKey.Enter: 
                        {
                            Console.Clear();
                            return teachers.ToList();
                        }
                    case ConsoleKey.OemPlus:
                        {
                            Console.Clear();
                            Console.Write("Write a name: ");
                            string name = Console.ReadLine();

                            Console.Write("Write a surname: ");
                            string surname = Console.ReadLine();

                            Console.Write("Write a salary: ");
                            int salary = int.Parse(Console.ReadLine());

                            Teacher teacher = new Teacher(name, surname, salary);

                            teachers = teachers.Append(teacher);
                            coll = coll.Append(teacher);

                            break;
                        }
                    case ConsoleKey.OemMinus: 
                        {
                            Console.Clear();
                            Console.Write("Ведiть прiзвище: ");
                            string surname = Console.ReadLine();

                            Teacher remTeacher = teachers.FirstOrDefault((Teacher t) => { return t.GetSurname == surname; });
                            if (remTeacher != null)
                            {
                                List<Teacher> newTeachers = new List<Teacher>();
                                foreach (Teacher t in teachers) 
                                {
                                    if (!t.Equals(remTeacher)) 
                                    {
                                        newTeachers.Add(t);
                                    }
                                }
                                teachers = newTeachers;
                            }
                            else 
                            {
                                Console.WriteLine($"Not Found surname: {surname}");
                                Console.ReadKey();
                            }
                            break;
                        }
                }
            }

             
        }

        public static List<Teacher> FillTeachers(List<Teacher> teachers)
        {
            string[] names = new string[]
           {
         "Denys",
         "Sasha",
         "Andriy",
         "Maksym",
         "Vasyliy",
         "Anatoliy",
         "Stepan",
         "Dmytro",
         "Yura",
         "Olia",
         "Viktoria",
         "Oksana",
         "Diana",
         "Nazar",
         "Vitaliy",
         "Kostja"
           };
            string surname = "Surname";

            Random random = new Random();
            for (int i = 0; i < random.Next(30, 42); i++)
            {
                teachers
                      .Add(new Teacher(names[random.Next(0, names.Length - 1)],
                      surname + random.Next(1, 10000).ToString(),
                      random.Next(10000, 300000)));
            }

            return teachers;
        }
    }
}
