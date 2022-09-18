// See https://aka.ms/new-console-template for more information
using LPZ1_1719;
using System.Reflection;
using System.Text;


// additional variables

var originalPerson = new Person("Jack", "London", DateTime.Now);
var secondPerson = new Person("jeremy", "wattson", DateTime.Now);

var fdate = DateTime.Now;
var sdate = new DateTime(2000, 12, 20);
var tdate = new DateTime(2001, 01, 12);

// variant 1

var student = new Student(originalPerson, Education.Specialist, 100);

Console.WriteLine(student.ToShortString());

WriteEnum(typeof(Education));

student.Education = Education.Bachelor;
student.AboutIndividual = secondPerson;
student.Exams = new Exam[] { new Exam("russian", 5, tdate) };
student.GroupNumber = 20;

student.AddExams(new Exam("math", 5, fdate), new Exam("philosophy", 4, sdate));

Console.WriteLine(student);

Console.WriteLine(CheckArraysTimes<Student>(1000, 100, nameof(student.GroupNumber), 1000));

//variant 2

var magazine = new Magazine("journal", Frequency.Monthly, tdate, 10000);

Console.WriteLine(magazine.ToShortString());

WriteEnum(typeof(Frequency));

magazine.Articles = new Article[] { new Article(originalPerson, "reol_album", 15000) };
magazine.Circulation = 10000;
magazine.Name = "best_songs_of_the_year";
magazine.DateOfPublishing = tdate;
magazine.Frequency = Frequency.Yearly;

magazine.AddArtiles(new Article(originalPerson, "noTitle", 3), new Article(secondPerson,"C# programming guide", 500));

Console.WriteLine(magazine);

Console.WriteLine(CheckArraysTimes<Magazine>(1000, 100, nameof(magazine.Name), "noname"));

// variant 3

var researchTeam = new ResearchTeam("nuclear syntesis", TimeFrame.Long, "ITER", 132342);

Console.WriteLine(researchTeam.ToShortString());

WriteEnum(typeof(TimeFrame));

researchTeam.NameOfOrganisation = "ITER_";
researchTeam.Duration = TimeFrame.TwoYears;
researchTeam.NameOfResearch = "magnetism";
researchTeam.Papers = new Paper[] { new Paper(secondPerson, "10000 Ampers", fdate) };
researchTeam.RegistrationNumber = 194375;

researchTeam.AddPapers(new Paper(originalPerson, "100000 ampere", sdate));

Console.WriteLine(researchTeam);

Console.WriteLine(CheckArraysTimes<ResearchTeam>(1000, 100, nameof(researchTeam.NameOfResearch), "nonameres"));

// additional methods

void WriteEnum(Type enumType)
{
    var names = Enum.GetNames(enumType);
    var values = Enum.GetValues(enumType);

    Console.WriteLine(string.Join("\n", Enumerable.Range(0, values.Length).Select(x => names[x] + " " + ((int[])values)[x])));
}

string CheckArraysTimes<T>(int rows, int columns, string nameOfProperty, object valueToSet) where T : new()
{
    Type objType = typeof(T);
    PropertyInfo propInfo = objType.GetProperty(nameOfProperty);

    var oneDimension = new T[rows * columns].Select(x => new T()).ToArray();
    var twoDimension = new T[rows, columns];
    var ladder = new T[rows].Select(x => new T[columns].Select(x => new T()).ToArray()).ToArray();

    StringBuilder result = new StringBuilder();

    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < columns; j++)
        {
            twoDimension[i, j] = new T();
        }
    }
    DateTime startTime = DateTime.Now;

    for(int i = 0; i < rows * columns; i++)
    {
        propInfo.SetValue(oneDimension[i], valueToSet);
    }

    result.Append(nameof(oneDimension) + " time: " + (DateTime.Now - startTime) + "\n");

    startTime = DateTime.Now;

    for (int i = 0; i < rows; i++)    
    {
        for (int j = 0; j < columns; j++)
        {
            propInfo.SetValue(twoDimension[i, j], valueToSet);
        }
    }

    result.Append(nameof(twoDimension) + " time: " + (DateTime.Now - startTime) + "\n");

    startTime = DateTime.Now;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            propInfo.SetValue(ladder[i][j], valueToSet);
        }
    }

    result.Append(nameof(ladder) + " time: " + (DateTime.Now - startTime) + "\n");

    return result.ToString();
}



