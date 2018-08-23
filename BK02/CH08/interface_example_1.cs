using System;

namespace SortInterface
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Get an unsorted array of students
            Console.WriteLine("Showing all students (in unsorted order)...");
            Student[] students = Student.CreateStudentList();

            // Use the IDisplayable interface to display the contents of the array
            DisplayArray(students);

            // Sort students by grade...
            Console.WriteLine("\nSorting the list of students...");

            // Use the IComparable interface to sort the array
            Array.Sort(students);

            // Use the IDisplayable interface to display the contents of the array
            DisplayArray(students);
        }

        // DisplayArray -- Display an array of objects that implement the IDisplayable interface
        public static void DisplayArray(IDisplayable[] displayables)
        {
            foreach (IDisplayable displayable in displayables)
            {
                Console.WriteLine(displayable.Display());
            }
        }
    }

    class Student : IComparable<Student>, IDisplayable
    {
        // Properties
        public string Name { get; private set; }
        public double Grade { get; private set; }

        // Constructor
        public Student(string name, double grade) { Name = name; Grade = grade; }

        // CreateStudentList -- Create a fixed list of students
        public static Student[] CreateStudentList()
        {
            string[] names = {"Homer", "Marge", "Bart", "Lisa", "Maggie"};

            double[] grades = {0, 85, 50, 100, 30};

            Student[] students = new Student[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                students[i] = new Student(names[i], grades[i]);
            }

            return students;
        }

        // Implement the IComparable interface
        public int CompareTo(Student other)
        {
            if (this.Grade < other.Grade)
                return -1;
            if (this.Grade > other.Grade)
                return 1;
            return 0;
        }

        // Implement the IDisplayable interface
        public string Display()
        {
            string padName = Name.PadRight(9);
            return String.Format("{0}: {1:N0}", padName, Grade);
        }
    }

    // IDisplayable -- Any object that implements the Display() method
    interface IDisplayable
    {
        string Display();
    }
}

