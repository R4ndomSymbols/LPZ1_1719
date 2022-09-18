using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Article
    {
        public Person Author { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        public Article(Person author, string title, double rating)
        {
            Author = author;
            Title = title;
            Rating = rating;
        }
        public Article()
        {
            Author = new Person();
            Title = string.Empty;
        }

        public override string ToString()
        {
            return string.Join(" ", Author, Title, Rating);
        }



    }
}
