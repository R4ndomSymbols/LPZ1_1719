using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Exam
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public DateTime ExamDate { get; set; }

        public Exam(string subject, int mark, DateTime examDate)
        {
            Subject = subject;
            Mark = mark;
            ExamDate = examDate;
        }

        public Exam()
        {
            Subject = string.Empty;          
        }

        public override string ToString()
        {
            return String.Join(" ", Subject, Mark, ExamDate);
        }


    }
}
