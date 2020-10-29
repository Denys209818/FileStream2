using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Pagination.Classes
{
    [DataContract]
    class Teacher
    {
        [DataMember]
        private string name;
        [DataMember]
        private string surname;
        [DataMember]
        private int salary;

        public string GetSurname 
        {
            get 
            {
                return this.surname;
            }
        }

        public Teacher(string name, string surname, int salary)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
        }

        public override string ToString()
        {
            
            string str = "\t=========================\n";
            str += "\tName: " + name + "\n";
            str += "\tSurname: " + surname + "\n";
            str += "\tSalary: " + salary;
            str += "\n\t=========================";
            return str;
        }

        
    }
}
