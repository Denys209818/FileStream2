using Newtonsoft.Json;
using Pagination.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FileWork_2_
{
    class Program
    {
        static void Main()
        {
            //   2)створити програму використовуючи клас Студенти та набір даних з попередньої домашньої
            //   Програма дозволяє додавати студентів до колекції, і видаляти по прізвищу. 
            //   При виході весь список зберігається в файл.При загрузці -зчитується з файлу.
            //   використати json серіалізацію
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Teacher>));

            List<Teacher> teachers = new List<Teacher>();

            using (FileStream fs = new FileStream("Users.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fs.Length > 0)
                {
                    teachers = dcjs.ReadObject(fs) as List<Teacher>;
                }
                else 
                {
                    teachers = ProgramBody.FillTeachers(teachers); 
                }
            }
            
            teachers = ProgramBody.MenuFunct(teachers);

            File.Delete("Users.txt");
            using (FileStream fs = new FileStream("Users.txt", FileMode.OpenOrCreate, FileAccess.Write)) 
            {
                dcjs.WriteObject(fs, teachers);
            }
            
        }
    }
}
