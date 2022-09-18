using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Student
    {
        private Person _aboutIndividual;
        private Education _education;
        private int _groupNumber;
        private Exam[] _exams;

        public Person AboutIndividual { get => _aboutIndividual; set => _aboutIndividual = value; }
        public Education Education { get => _education; set => _education = value; }
        public int GroupNumber { get => _groupNumber; set => _groupNumber = value; }
        public Exam[] Exams { get => _exams; set => _exams = value; }

        public double AverageMark { get => _exams.Sum(x => x.Mark) / (double) _exams.Count(); }


        public Student(Person aboutIndividual, Education education, int groupNumber)
        {
            _aboutIndividual = aboutIndividual;
            _education = education;
            _groupNumber = groupNumber;
            _exams = new Exam[] { new Exam() };
        }

        public Student()
        {
            _aboutIndividual = new Person();
            _exams = new Exam[] { new Exam() };
        }

        public bool IsThatGrade(Education education)
        {
            return education == _education;
        }

        public void AddExams(params Exam[] exams)
        {
            if(exams.Length != 0)
            {
                _exams = _exams.Concat(exams).ToArray();
            }
            
        }

        public override string ToString()
        {
            return string.Join(" ", _aboutIndividual.ToString(), _education, GroupNumber, string.Join("\nExam: ", (IEnumerable<Exam>)_exams));
        }
        public string ToShortString()
        {
            return string.Join(" ", _aboutIndividual.ToString(), _education, GroupNumber, AverageMark);
        }




    }
}
