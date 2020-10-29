using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileWork_3_.Classes
{
    [Serializable]
    public class AccountForPayment
    {
        public AccountForPayment(string sOfDay, string days, string oneDayPenaltyForLatePayment,
            string numberOfDaySoverdue)
        {
            this.salaryForDay = sOfDay;
            this.days = days;
            this.oneDayPenaltyForLatePayment = oneDayPenaltyForLatePayment;
            this.numberOfDaySoverdue = numberOfDaySoverdue;
            this.ChangeParams();
        }
        public AccountForPayment()
        {

        }
        public static bool isFormating = true;
        [XmlElement]
        public string salaryForDay;
        [XmlElement]
        public string days;
        [XmlElement]
        /// <summary>
        /// штраф за один день задержки оплаты
        /// </summary>
        public string oneDayPenaltyForLatePayment;
        [XmlElement]
        /// <summary>
        /// количество дней задержи оплаты
        /// </summary>
        /// 
        public string numberOfDaySoverdue;



        [XmlElement]
        /// <summary>
        /// сумма к оплате без штрафа (вычисляемое поле)
        /// </summary>
        public string amountPayableWithoutPenalty;
        [XmlElement]
        /// <summary>
        /// штраф (вычисляемое поле)
        /// </summary>
        public string penalty;
        
        [XmlElement]
        /// <summary>
        /// общая сумма к оплате (вычисляемое поле)
        /// </summary>
        public string totalAmountToBePaid;

        public void ChangeSalaryOfDay(int number) 
        {
            this.salaryForDay = number.ToString();
            this.ChangeParams();
        }

        public void ChangeDay(int days) 
        {
            this.days = days.ToString();
            this.ChangeParams();
        }

        public void ChangeOneDayPenaltyForLatePayment(int number) 
        {
            this.oneDayPenaltyForLatePayment = number.ToString();
            this.ChangeParams();
        }

        public void ChangeNumberOfDaySoverdue(int number) 
        {
            this.numberOfDaySoverdue = number.ToString();
            this.ChangeParams();
        }

        public void ChangeParams() 
        {   //  Зарплата за день
            int salaryForday = int.Parse(this.salaryForDay);
            //  Кількість днів
            int days = int.Parse(this.days);
            //  штраф за неоплечний день
            int oneDayPenaltyForLatePayment = int.Parse(this.oneDayPenaltyForLatePayment);
            //  кількість неоплачених днів
            int numberOfDaySoverdue = int.Parse(this.numberOfDaySoverdue);


            this.amountPayableWithoutPenalty = (salaryForday * days).ToString();
            this.penalty = (oneDayPenaltyForLatePayment * numberOfDaySoverdue).ToString();
            this.totalAmountToBePaid = ((salaryForday * days) + (oneDayPenaltyForLatePayment * numberOfDaySoverdue))
                .ToString();
        }

    }
}
