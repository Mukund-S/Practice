// See https://aka.ms/new-console-template for more information

using Assignment3;

//Methods 

//Question 1
MethodQuestion1 question1 = new MethodQuestion1();

//Question 2
MethodQuestion2 question2 = new MethodQuestion2();

Designing_and_Building_Classes dbc = new Designing_and_Building_Classes();
dbc.ques();


Console.WriteLine("\nQ1-Q6");
// Create Courses
Course math = new Course("Math");
Course science = new Course("Science");

// Create Department
Department compSci = new Department("Computer Science", 1000000, new DateTime(2024, 1, 1), new DateTime(2024, 12, 31));
        
// Create Instructor
Instructor inst = new Instructor("Anjila Karki", new DateTime(1990, 5, 20), 70000, new DateTime(2010, 1, 1));
compSci.AssignHead(inst);
inst.AssignDepartment(compSci);

// Create Student
Student st = new Student("Mukund Sharma", new DateTime(1999, 06, 21));
st.EnrollCourse(math);
st.EnrollCourse(science);
st.SetGrade(math, 'A');
st.SetGrade(science, 'B');

// Print Details
Console.WriteLine($"Instructor: {inst.Name}, Age: {inst.CalculateAge()}, Salary: {inst.CalculateSalary()}, Head of Department: {inst.IsHeadOfDepartment()}");
Console.WriteLine($"Student: {st.Name}, Age: {st.CalculateAge()}, GPA: {st.CalculateGPA()}");


Console.WriteLine("\nQ7");
// Create colors
Color redColor = new Color(255, 0, 0);
Color blueColor = new Color(0, 0, 255);
Color greenColor = new Color(0, 255, 0, 128); // Semi-transparent green

// Create balls
Ball redBall = new Ball(10, redColor);
Ball blueBall = new Ball(15, blueColor);
Ball greenBall = new Ball(12, greenColor);

// Throw balls
redBall.Throw();
redBall.Throw();
blueBall.Throw();
greenBall.Throw();
greenBall.Throw();
greenBall.Throw();

// Pop the red ball
redBall.Pop();

// Attempt to throw the popped red ball
redBall.Throw();

// Print throw counts
Console.WriteLine($"Red ball throw count: {redBall.GetThrowCount()}");
Console.WriteLine($"Blue ball throw count: {blueBall.GetThrowCount()}");
Console.WriteLine($"Green ball throw count: {greenBall.GetThrowCount()}");