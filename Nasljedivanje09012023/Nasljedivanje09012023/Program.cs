using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasljedivanje09012023
{
    internal class Program
    {

        class Dessert
        {
            private String name;
            private double weight;
            private int calories;

            public Dessert(String name, double weight, int calories)
            {
                this.name = name;
                this.weight = weight;
                this.calories = calories;
            }

            public String Name { get => name; set => name = value; }
            public double Weight { get => weight; set => weight = value; }
            public int Calories { get => calories; set => calories = value; }


            public override String ToString()
            {
                String ispis = Name + " weight=" + Weight + ", calories=" + Calories;
                return ispis;
            }

            public String getDessertType()
            {
                return "dessert";
            }
        }

        class Cake : Dessert
        {
            bool containsGluten;
            String cakeType;
            public Cake(String name, double weight, int calories, bool containsGluten, String cakeType) : base(name, weight, calories)
            {
                this.containsGluten = containsGluten;
                this.cakeType = cakeType;
            }

            public bool ContainsGluten { get => this.containsGluten; set => this.containsGluten = value; }
            public String CakeType { get => this.cakeType; set => this.cakeType = value; }

            public override String ToString()
            {
                String ispis = " " + this.ContainsGluten + " " + this.cakeType;
                return ispis;
            }

            public new String getDessertType()
            {
                return "cake";
            }

        }

        class IceCream : Dessert
        {
            String flavour;
            String color;

            public IceCream(String name, double weight, int calories, String flavour, String color) : base(name, weight, calories)
            {
                this.flavour = flavour;
                this.color = color;
            }

            public String Flavour { get => this.flavour; set => this.flavour = value; }
            public String Color { get => this.color; set => this.color = value; }

            public override String ToString()
            {
                return base.ToString() + " " + this.flavour + " " + this.color;
            }

            public new String getDessertType()
            {
                return "ice cream";
            }

        }




        ////////////////////////////////////////////////////////////////////////

        class Person
        {
            String name;
            String surname;
            int age;


            public Person(String name, String surname, int age)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
            }

            public String Name { get => this.name; set => this.name = value; }
            public int Age { get => this.age; set => this.age = value; }
            public String Surname { get => this.surname; set => this.surname = value; }

            public override bool Equals(object obj)
            {
                return obj is Person person &&
                       name == person.name &&
                       surname == person.surname &&
                       age == person.age;
            }


            public override String ToString()
            {
                String ispis = this.name + " " + this.surname + " " + this.age;
                return ispis;
            }

        }


        class Student : Person
        {
            String studentid;
            int academicYear;

            public Student(String name, String surname, int age, String studentid, int academicYear) : base(name, surname, age)
            {
                this.studentid = studentid;
                this.academicYear = academicYear;
            }

            public String Studentid { get => this.studentid; set => this.studentid = value; }
            public int AcademicYear { get => this.academicYear; set => this.academicYear = value; }

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       base.Equals(obj) &&
                       studentid == student.studentid;
            }

            public override int GetHashCode()
            {
                int ispis = -1980727003 + EqualityComparer<String>.Default.GetHashCode(studentid);
                return ispis;
            }

            public override String ToString()
            {
                String ispis = " " + this.studentid + " " + this.academicYear;
                return ispis;
            }



        }

        class Teacher : Person
        {
            String email;
            String subject;
            double salary;
            public Teacher(String name, String surname, int age, String email, String subject, double salary) : base(name, surname, age)
            {
                this.email = email;
                this.subject = subject;
                this.salary = salary;
            }

            public String Email { get => this.email; set => this.email = value; }
            public String Subject { get => this.subject; set => this.subject = value; }
            public double Salary { get => this.salary; set => this.salary = value; }

            public override bool Equals(object obj)
            {
                return obj is Teacher teacher &&
                       base.Equals(obj) &&
                       email == teacher.email;
            }

            public override int GetHashCode()
            {
                int ispis = 848330207 + EqualityComparer<String>.Default.GetHashCode(email);
                return ispis;
            }


            public override String ToString()
            {
                return base.ToString() + " " + this.email + " " + this.subject + " " + this.salary;
            }

            public void increaseSalary(int postotak)
            {
                this.salary = this.salary * (1 + (postotak / 100.0));
            }
            static public void increaseSalary(int postotak, params Teacher[] list)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].increaseSalary(postotak);
                }
            }




        }

        
        /////////////////////////////////////////////////////////////////////////////////////////
        

        class CompetitionEntry
        {
            Teacher teacher;
            Dessert dessert;
            private Student[] students;
            private int[] ratings;
            private int idx;
            public CompetitionEntry(Teacher teacher, Dessert dessert)
            {
                this.teacher = teacher;
                this.dessert = dessert;
            }

            public bool addEntry(Student student, int number)
            {
                if (idx == 3)
                {
                    return false;
                }
                foreach (Student s in students)
                {
                    if (s != null && s.Equals(student))
                        return false;
                }
                Students[idx] = student;
                ratings[idx] = number;
                idx++;
                return true;


            }
            public double getRating()
            {
                if (idx == 0) return 0;

                double sum = 0;
                for (int i = 0; i < idx; i++)
                    sum += ratings[i];

                return sum / idx;
            }

            internal Teacher Teacher { get => teacher; set => teacher = value; }
            internal Dessert Dessert { get => dessert; set => dessert = value; }
            public int[] Ratings { get => ratings; set => ratings = value; }
            public int Idx { get => idx; set => idx = value; }
            public Student[] Students { get => students; set => students = value; }

        }


        //////////////////////////////////////////////////////////////////


        class UniMastersChef
        {
            private CompetitionEntry[] entries;

            private int idx = 0;

            public UniMastersChef(int noOfEntries)
            {
                this.entries = new CompetitionEntry[noOfEntries];
            }
            public bool addEntry(CompetitionEntry entry)
            {
                if (idx == this.entries.Length) return false;

                foreach (CompetitionEntry e in entries)
                {
                    if (e != null && e.Equals(entry))
                        return false;
                }
                entries[idx++] = entry;
                return true;
            }
            public Dessert getBestDessert()
            {
                if (idx == 0) return null;

                double max = entries[0].getRating();
                int maxIdx = 0;

                for (int i = 0; i < idx; i++)
                {
                    if (entries[i].getRating() > max)
                    {
                        max = entries[i].getRating();
                        maxIdx = i;
                    }
                }

                return entries[maxIdx].Dessert;
            }
            public static Person[] getInvolvedPeople(CompetitionEntry entry)
            {

                Person[] retVal = new Person[4];

                int idx = 0;

                retVal[idx++] = entry.Teacher;

                foreach (Student s in entry.Students)
                {
                    retVal[idx++] = s;
                }

                return retVal;
            }
        }



        static void Main(string[] args)
        {
            Dessert genericDessert = new Dessert("Cheessecake", 500, 1200);
            Cake cake = new Cake("Red velvet", 600, 1000, false, "formal");
            IceCream icecream = new IceCream("Strawberry punch", 100, 200, "light pink", "jagoda punč");

            Teacher t1 = new Teacher("Ivo ", "Ivić", 40, "ivo.ivic@skole.hr", "Napredno i objektno programiranje", 10000);
            Teacher t2 = new Teacher("Ana", "Anić", 36, "ana.anic@skole.hr", "Programiranje mobilnih uređaja", 10000);

            Student s1 = new Student("Jana", "Janjić", 19, "0036312123", (short)2);
            Student s2 = new Student("Karla", "Karlić", 19, "0036387656", (short)1);
            Student s3 = new Student("Ivan", "Ivanović", 20, "0036392357", (short)3);

            UniMastersChef competition = new UniMastersChef(2);

            CompetitionEntry e1 = new CompetitionEntry(t1, genericDessert);
            competition.addEntry(e1);

            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            e1.addEntry(s1, 4);
            e1.addEntry(s2, 5);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());

            CompetitionEntry e2 = new CompetitionEntry(t2, cake);
            e2.addEntry(s1, 2);
            e2.addEntry(s3, 3);
            e2.addEntry(s2, 4);
            competition.addEntry(e2);

            Console.WriteLine("Entry 2 rating: " + e2.getRating());
            Console.WriteLine("Best dessert is: " + competition.getBestDessert().Name);

            Console.ReadKey();
        }
    }
}
