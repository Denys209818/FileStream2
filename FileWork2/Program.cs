using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork2
{
    class Program
    {
        static void Main()
        {
            //  1)Написати програму яка приймає шлях та назву зображення і кількість копій
            //  Програма здійснює копіювання зображень в туж папку, кількість копій яку ввели

            string path;
            string img;

            Console.Write("Write a path: ");
            path = Console.ReadLine();
            while (true) 
            {

                Console.Write("Write a img name: ");
                img = Console.ReadLine();
                FileInfo fileInfo = new FileInfo(path + @"\" + img);
                if (fileInfo.Exists)
            {
                byte[] bytes;
                using (FileStream fs = new FileStream(path + @"\" + img, FileMode.Open, FileAccess.ReadWrite))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                int copies;

                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Enter count copies: ");
                        copies = int.Parse(Console.ReadLine());

                        break;
                    }
                    catch { }
                }

                for (int i = 0; i < copies; i++)
                {

                    using (FileStream fs = new FileStream(path + @"\" +
                        img.
                        Insert(img.Length - 4, "_copy [" + (i + 1).ToString() + "]"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                    return;
            }
                else 
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                path = path.TrimEnd(new char[] { '/' });
                Console.WriteLine($"File {path + "/" + img} Not Found!");
                FileInfo[] files = 
                    directory.GetFiles()
                    .Where((FileInfo f) => { return f.Name.Contains(img) && (f.Extension == ".jpg" || f.Extension == ".png"); })
                    .ToArray();
                if (files.Length > 0) 
                {
                    Console.WriteLine("Maybe do you wanted to: ");
                    foreach (var item in files) 
                    {
                        Console.WriteLine(item.Name);
                    }

                    Console.WriteLine("\nPress Enter");
                }
            }

                Console.ReadKey();
            }
        }
    }
}
