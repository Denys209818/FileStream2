using FileWork_3_.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FileWork_3_
{
    class Program
    {
        static void Main()
        {
            //  3) Разработать класс «Счет для оплаты». В классе преду -
            //  смотреть следующие поля:
            //  оплата за день;
            //  количество дней;
            //  штраф за один день задержки оплаты;
            //  количество дней задержи оплаты;
            //  сумма к оплате без штрафа(вычисляемое поле);
            //  штраф(вычисляемое поле);
            //  общая сумма к оплате(вычисляемое поле).
            //  В классе объявить статическое свойство типа bool,
            //  значение которого влияет на процесс форматирования
            //  объектов этого класса. 
            //  Если значение этого свойства рав -
            //  но true, тогда сериализуются и десериализируются все
            //  поля, если false — вычисляемые поля не сериализуются.
            //  Разработать приложение, в котором необходимо про -
            //  демонстрировать использование этого класса, результаты
            //  должны записываться и считываться из файла.



            //  Пароль до аккаунта директора 88888888 

            bool isAdmin = IsAdmin();
            string path = "fileXml.txt";
            
            if (!isAdmin) 
            {
                path = "fileXmlUser.txt";
                AccountForPayment.isFormating = false;
            }

            AccountForPayment account;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer x = new XmlSerializer(typeof(AccountForPayment));
                if (fs.Length > 0)
                {
                    account = (AccountForPayment)x.Deserialize(fs);
                }
                else
                {
                    account = new AccountForPayment("50", "4", "100", "1");
                }
            }
            
                Console.WriteLine("Зарплата за день: " + account.salaryForDay);
                Console.WriteLine("Кiлькiсть днiв: " + account.days);
                Console.WriteLine("штраф за один день: " + account.oneDayPenaltyForLatePayment);
                Console.WriteLine("Кiлькiсть просрочених днiв: " + account.numberOfDaySoverdue);
                
                if (AccountForPayment.isFormating) 
                {
                    Console.WriteLine("Штраф: " + account.penalty);
                    Console.WriteLine("Виплата без штрафу: " + account.amountPayableWithoutPenalty);
                    Console.WriteLine("Вся виплата: " + account.totalAmountToBePaid);
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Якщо ви не хочете змiнити тиснiть 'Enter'");
                    Console.Write("\nЗмiнити зарплату за день:");
                    try
                    {
                        int salaryForDay = int.Parse(Console.ReadLine());
                         if (salaryForDay < 0) 
                    {
                        throw new Exception();
                    }
                        account.ChangeSalaryOfDay(salaryForDay);
                    }
                    catch { }
                    Console.Write("\nЗмiнити кiлькiсть днiв:");
                    try
                    {
                        int days = int.Parse(Console.ReadLine());
                    if (days <= 0 || days > 31) 
                    {
                        throw new Exception();
                    }
                        account.ChangeDay(days);
                    }
                    catch { }
                    Console.Write("\nЗмiнити штраф за один день:");
                    try
                    {
                        int oneDayPenalty = int.Parse(Console.ReadLine());
                          if (oneDayPenalty < 0) 
                    {
                        throw new Exception();
                    }
                        account.ChangeOneDayPenaltyForLatePayment(oneDayPenalty);
                    }
                    catch { }
                    Console.Write("\nЗмiнити кiлькiсть просрочених днiв:");
                    try
                    {
                        int numberOfDaySoverdue = int.Parse(Console.ReadLine());
                        if (numberOfDaySoverdue < 0) 
                    {
                        throw new Exception();
                    }
                        account.ChangeNumberOfDaySoverdue(numberOfDaySoverdue);
                    }
                    catch { }


                }
            

            XmlDocument document = AddToDoc(account);

            document.Save(path);


        }

        public static XmlDocument AddToDoc(AccountForPayment account)  
        {
            XmlDocument document = new XmlDocument();

            XmlElement el = document.CreateElement("AccountForPayment");
            document.AppendChild(el);
            
            XmlElement el1 = document.CreateElement("salaryForDay");
            el1.InnerText = account.salaryForDay.ToString();
            el.AppendChild(el1);

            XmlElement el2 = document.CreateElement("days");
            el2.InnerText = account.days.ToString();
            el.AppendChild(el2);

            XmlElement el3 = document.CreateElement("oneDayPenaltyForLatePayment");
            el3.InnerText = account.oneDayPenaltyForLatePayment.ToString();
            el.AppendChild(el3);

            XmlElement el4 = document.CreateElement("numberOfDaySoverdue");
            el4.InnerText = account.numberOfDaySoverdue.ToString();
            el.AppendChild(el4);

            

            if (AccountForPayment.isFormating)
            {
                XmlElement el5 = document.CreateElement("amountPayableWithoutPenalty");
            el5.InnerText = account.amountPayableWithoutPenalty.ToString();

            XmlElement el6 = document.CreateElement("penalty");
            el6.InnerText = account.penalty.ToString();

            XmlElement el7 = document.CreateElement("totalAmountToBePaid");
            el7.InnerText = account.totalAmountToBePaid.ToString();
                
                el.AppendChild(el5);
                el.AppendChild(el6);
                el.AppendChild(el7);
            }

            return document;
        }

        public static bool IsAdmin() 
        {
            Console.Write("Вiйти як директор (Якщо як гость то жмiть 'Enter'): ");
            string password = Console.ReadLine();

            if (password == "88888888") 
            {
                return true;
            }
            return false;
        }
    }
}
