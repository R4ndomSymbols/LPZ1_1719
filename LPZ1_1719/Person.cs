using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPZ1_1719.Lpz2;


namespace LPZ1_1719
{
    public class Person : IDateAndCopy
    {
        protected string _name = string.Empty;
        protected string _surname = string.Empty;
        protected DateTime _birthday;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }

        public int BirthdayYear { get => _birthday.Year; set => _birthday = new DateTime(value, _birthday.Month, _birthday.Day); }
        public virtual DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public virtual string ToShortString()
        {
            return _name + " " + _surname;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                return false;
            }
            else
            {
                var conversed = obj as Person;
                return conversed.Birthday.Equals(this.Birthday) && 
                    conversed.Surname.Equals(this.Surname) &&
                    conversed.Name.Equals(this.Name);
            } 
        }
        public static bool operator == (Person a, Person b)
        {
            return a.Equals(b);
        }

        public static bool operator != (Person a, Person b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _surname.GetHashCode() ^ _birthday.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            return new Person(new string(_name), new string(_surname), _birthday);
        }
    }
}
