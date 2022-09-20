using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPZ1_1719.Lpz2;

namespace LPZ1_1719
{
    public class Student : Person
    {
        private Education _education;
        private int _groupNumber;
        private ArrayList _exams;
        private ArrayList _tests;

        public Person AboutIndividual { get => (Person)((Person)this).DeepCopy(); set 
            { 
                Name = new string(value.Name);
                Surname = new string(value.Surname);
                Birthday = value.Birthday;

            } 
        }
        public Education Education { get => _education; set => _education = value; }
        public int GroupNumber { get => _groupNumber; set
            {
                if(value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException(nameof(value) + " не может быть меньше 101 или больше чем 599");
                }
            } 
        }
        public ArrayList Exams { get => _exams; set => _exams = value; }
        public ArrayList Tests { get => _tests; set => _tests = value; }

        public override DateTime Date { get => base.Date; set => base.Date = value; }

        public double AverageMark
        {
            get
            {
                double sum = 0;
                foreach (var exam in _exams)
                {
                    sum += ((Exam)exam).Mark;
                }
                return sum / _exams.Count;
            }
        }

        public Student(Person aboutIndividual, Education education, int groupNumber) :
            base (aboutIndividual.Name, aboutIndividual.Surname, aboutIndividual.Birthday)
        {
            _education = education;
            _groupNumber = groupNumber;
            _exams = new ArrayList();
            _tests = new ArrayList();
        }

        public Student() : base()
        {
            _exams = new ArrayList();
            _tests = new ArrayList();
        }

        public bool IsThatGrade(Education education)
        {
            return education == _education;
        }

        public void AddExams(params Exam[] exams)
        {
            if(exams.Length != 0)
            {
                _exams.AddRange(exams);
            }
            
        }

        public IEnumerable<object> EnumerateExamsAndTests()
        {
            var temporaryCollection = new ArrayList();
            temporaryCollection.AddRange(_tests);
            temporaryCollection.AddRange(_exams);
            for (int i = 0; i < _exams.Count; i++)
            {
                yield return temporaryCollection[i];
            }
        }
        public IEnumerable<Exam> EnumerateExams(int minMark)
        {
            var selected = _exams.ToArray().Cast<Exam>().Where(exam => exam.Mark > minMark).ToArray();
            
            for (int i = 0; i < selected.Count(); i++)
            {
                yield return selected[i];
            }
        }

        public override string ToString()
        {
            return string.Join(" ", base.ToString(), _education, GroupNumber, 
                "\n Exam: " + string.Join("\n Exam: ", _exams.ToArray().Cast<Exam>()) +
                "\n Test: " + string.Join("\n Test: ", _tests.ToArray().Cast<Test>()));
        }
        public override string ToShortString()
        {
            return string.Join(" ", base.ToString(), _education, GroupNumber, AverageMark);
        }

        public override object DeepCopy()
        {
            Person copiedUnderlied = (Person)base.DeepCopy();
            var std = new Student(copiedUnderlied, this.Education, GroupNumber);
            std.Tests = new ArrayList(_tests);
            std.Exams = new ArrayList(_exams);
            return std;
        }




    }
}
