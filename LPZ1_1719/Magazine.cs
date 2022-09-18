using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Magazine
    {
        private string _name;
        private Frequency _frequency;
        private DateTime _dateOfPublishing;
        private int _circulation;
        private Article[] _articles;

        public string Name { get => _name; set => _name = value; }
        public Frequency Frequency { get => _frequency; set => _frequency = value; }
        public DateTime DateOfPublishing { get => _dateOfPublishing; set => _dateOfPublishing = value; }
        public int Circulation { get => _circulation; set => _circulation = value; }
        public Article[] Articles { get => _articles; set => _articles = value; }

        public double AverageRatings { get => _articles?.Sum(x => x.Rating) ?? 0; }

        public Magazine(string name, Frequency frequency, DateTime dateOfPublishing, int circulation)
        {
            _name = name;
            _frequency = frequency;
            _dateOfPublishing = dateOfPublishing;
            _circulation = circulation;
        }

        public Magazine()
        {
            _name = string.Empty;
        }

        public bool IsThatRating(Frequency frequency)
        {
            return frequency == _frequency;
        }

        public void AddArtiles(params Article[] articles)
        {
            if(_articles == null)
            {
                _articles = articles;
            }
            else
            {
                _articles = _articles.Concat(articles).ToArray();
            }
            
        }

        public override string ToString()
        {
            return string.Join(" ", _name, _frequency, _circulation, _dateOfPublishing,  "\n" + string.Join("\n", (IEnumerable<Article>)_articles));
        }
        public string ToShortString()
        {
           return string.Join(" ", _name, _frequency, _circulation, _dateOfPublishing, AverageRatings);
        }


    }
}
