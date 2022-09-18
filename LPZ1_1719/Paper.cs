using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Paper
    {
        public Person Author { get; set; }
        public string Title { get; set; }
        public DateTime DateofPublishing { get; set; }

        public Paper(Person author, string title, DateTime dateOfPublishing)
        {
            Author = author;
            Title = title;
            DateofPublishing = dateOfPublishing;
        }
        public Paper()
        {
            Author = new Person();
            Title = string.Empty;
        }

        public override string ToString()
        {
            return string.Join(" ", Author.ToString(), Title, DateofPublishing);
        }


    }
}
