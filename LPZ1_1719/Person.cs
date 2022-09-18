using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Person
    {
        private string _name = string.Empty;
        private string _surname = string.Empty;
        private DateTime _birthday;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }

        public int BirthdayYear { get => _birthday.Year; set => _birthday = new DateTime(value, _birthday.Month, _birthday.Day); }

        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }

        public Person()
        {

        }

        public override string ToString()
        {
            return string.Join(" ", _name, _surname, _birthday);
        }

        public string ToShortString()
        {
            return _name + " " + _surname;
        }


    }
}
