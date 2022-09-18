using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    internal class ResearchTeam
    {
        private string _nameOfresearch;
        private TimeFrame _duration;
        private string _nameOfOrganisation;
        private int _registrationNumber;
        private Paper[] _papers;

        public string NameOfResearch { get => _nameOfresearch; set => _nameOfresearch = value; }
        public TimeFrame Duration { get => _duration; set => _duration = value; }
        public string NameOfOrganisation { get => _nameOfOrganisation; set => _nameOfOrganisation = value; }
        public int RegistrationNumber { get => _registrationNumber; set => _registrationNumber = value; }
        public Paper[] Papers { get => _papers; set => _papers = value; }

        public Paper LastPaper { get => _papers?.MaxBy(x => x.DateofPublishing); }

        public ResearchTeam(string nameOfresearch, TimeFrame duration, string nameOfOrganisation, int registrationNumber)
        {
            _nameOfresearch = nameOfresearch;
            _duration = duration;
            _nameOfOrganisation = nameOfOrganisation;
            _registrationNumber = registrationNumber;
        }
        public ResearchTeam()
        {
            _nameOfresearch = string.Empty;
            _nameOfOrganisation = string.Empty;
        }



        public bool IsThatRating(TimeFrame timeframe)
        {
            return timeframe == _duration;
        }

        public void AddPapers(params Paper[] articles)
        {
            _papers = _papers.Concat(articles).ToArray();
        }

        public override string ToString()
        {
            return string.Join(" ", _nameOfresearch, _duration, _registrationNumber, _nameOfOrganisation,  "\n" + string.Join("\n", (IEnumerable<Paper>)_papers));
        }
        public string ToShortString()
        {
            return string.Join(" ", _nameOfresearch, _duration, _registrationNumber, _nameOfOrganisation, LastPaper);
        }

    }
}
