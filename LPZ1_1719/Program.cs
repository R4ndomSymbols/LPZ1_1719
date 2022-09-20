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

var testP1 = new Person("Erick", "Evans", new DateTime(1970, 10, 12));
var testP2 = new Person("Erick", "Evans", new DateTime(1970, 10, 12));

Console.WriteLine($"{nameof(testP1)} и {nameof(testP2)} " + (testP2.Equals(testP1) ? "равны" : "не равны"));
Console.WriteLine($"{nameof(testP1)} hash: {testP1.GetHashCode()}\n{nameof(testP2)} hash: {testP2.GetHashCode()}" );

var student = new Student(testP1, Education.Specialist, 100);

student.Exams = new System.Collections.ArrayList() {
    new Exam("math", 5, new DateTime(1985, 12, 26)),
    new Exam("russian", 4, new DateTime(1985, 12, 27)),
    new Exam("geography", 5, new DateTime(1985, 12, 28)),
    new Exam("chinese", 3, new DateTime(1985, 12, 28))
};

student.Tests = new System.Collections.ArrayList() {
new Test("euler_theory", true),
new Test("advanced_russian", false),
new Test("country_acknowledge_test", true)
};

Console.WriteLine(student.AboutIndividual.ToString());

var secondStudent = student.DeepCopy();

student.Name = "NonErick";
student.Tests.Add(new Test("DoesNotExist", true));

Console.WriteLine(student);
Console.WriteLine(secondStudent);
try
{
    student.GroupNumber = int.MaxValue;
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("\n" + e.Message);
}

foreach (var obj in student.EnumerateExamsAndTests())
{
    Console.WriteLine("\n" + obj.ToString());
}

foreach (var exam in student.EnumerateExams(3))
{
    Console.WriteLine("\n" + exam.ToString());
}

//Console.WriteLine(student);

//Console.WriteLine(CheckArraysTimes<Student>(1000, 100, nameof(student.GroupNumber), 1000));

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



