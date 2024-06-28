namespace Assignment3;

public class Designing_and_Building_Classes
{
    public void ques()
    {
        Console.WriteLine("\n\nDesigning and Building Classes");
    }
}

// Interfaces
public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
}

public interface IStudentService : IPersonService
{
    double CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    void AssignDepartment(Department department);
    bool IsHeadOfDepartment();
}

// Abstract Class - Person
public abstract class Person : IPersonService
{
    private List<string> addresses = new List<string>();
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; private set; }

    public Person(string name, DateTime dateOfBirth, decimal salary)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Salary = salary < 0 ? 0 : salary;
    }

    public void AddAddress(string address)
    {
        addresses.Add(address);
    }

    public IEnumerable<string> GetAddresses()
    {
        return addresses;
    }

    public int CalculateAge()
    {
        var age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
            age -= 1;

        return age;
    }

    public virtual decimal CalculateSalary()
    {
        return Salary;
    }
}

// Derived Class - Instructor
public class Instructor : Person, IInstructorService
{
    public Department Department { get; private set; }
    public DateTime JoinDate { get; set; }
    public bool IsHead { get; private set; }

    public Instructor(string name, DateTime dateOfBirth, decimal salary, DateTime joinDate, bool isHead = false)
        : base(name, dateOfBirth, salary)
    {
        JoinDate = joinDate;
        IsHead = isHead;
    }

    public void AssignDepartment(Department department)
    {
        Department = department;
    }

    public bool IsHeadOfDepartment()
    {
        return IsHead;
    }

    public int CalculateExperience()
    {
        return DateTime.Now.Year - JoinDate.Year;
    }

    public override decimal CalculateSalary()
    {
        var experienceBonus = 500 * CalculateExperience();
        return base.CalculateSalary() + experienceBonus;
    }
}

// Derived Class - Student
public class Student : Person, IStudentService
{
    private Dictionary<Course, char> coursesGrades = new Dictionary<Course, char>();

    public Student(string name, DateTime dateOfBirth)
        : base(name, dateOfBirth, 0) { }

    public void EnrollCourse(Course course)
    {
        coursesGrades[course] = 'F'; // Default grade
    }

    public void SetGrade(Course course, char grade)
    {
        if (coursesGrades.ContainsKey(course))
        {
            coursesGrades[course] = grade;
        }
    }

    public double CalculateGPA()
    {
        if (coursesGrades.Count == 0)
            return 0;

        double totalPoints = coursesGrades.Sum(courseGrade => GradeToPoint(courseGrade.Value));
        return totalPoints / coursesGrades.Count;
    }

    private double GradeToPoint(char grade)
    {
        switch (grade)
        {
            case 'A': return 4.0;
            case 'B': return 3.0;
            case 'C': return 2.0;
            case 'D': return 1.0;
            case 'F': return 0.0;
            default: return 0.0;
        }
    }
}

// Course Class
public class Course
{
    public string Name { get; set; }
    public List<Student> EnrolledStudents { get; private set; } = new List<Student>();

    public Course(string name)
    {
        Name = name;
    }

    public void EnrollStudent(Student student)
    {
        if (!EnrolledStudents.Contains(student))
        {
            EnrolledStudents.Add(student);
            student.EnrollCourse(this);
        }
    }
}

// Department Class
public class Department
{
    public string Name { get; set; }
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> OfferedCourses { get; private set; } = new List<Course>();

    public Department(string name, decimal budget, DateTime startDate, DateTime endDate)
    {
        Name = name;
        Budget = budget;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void AssignHead(Instructor instructor)
    {
        Head = instructor;
    }

    public void OfferCourse(Course course)
    {
        if (!OfferedCourses.Contains(course))
        {
            OfferedCourses.Add(course);
        }
    }
}

// Color Class
public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    // Constructor with red, green, blue, and alpha
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    // Constructor with red, green, blue (alpha defaults to 255)
    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    // Get and Set methods
    public int GetRed() { return red; }
    public void SetRed(int value) { red = value; }

    public int GetGreen() { return green; }
    public void SetGreen(int value) { green = value; }

    public int GetBlue() { return blue; }
    public void SetBlue(int value) { blue = value; }

    public int GetAlpha() { return alpha; }
    public void SetAlpha(int value) { alpha = value; }

    // Method to get grayscale value
    public int GetGrayscale()
    {
        return (red + green + blue) / 3;
    }
}

// Ball Class
public class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    // Constructor
    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    // Method to pop the ball
    public void Pop()
    {
        size = 0;
    }

    // Method to throw the ball
    public void Throw()
    {
        if (size > 0)
        {
            throwCount++;
        }
    }

    // Method to get throw count
    public int GetThrowCount()
    {
        return throwCount;
    }
}