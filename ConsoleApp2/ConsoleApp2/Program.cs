using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> stu = new Dictionary<string, Student>();
            for (int i = 1; i < 5; i++)
            {
                Student a = new Student(2);
                a.Name = "S_" + i.ToString();
                a.Score = 100;
                stu.Add(a.Name, a);
            }
            Student kk = stu["S_3"];
            Console.WriteLine(kk.Name);
            int[] myarry = new int[] { 1, 2, 3, 4, 5 };
            CC c = new CC();
            Action myway = new Action(c.sayholle);
            myway();
            Console.WriteLine(myarry[3]);
            Type t = typeof(double);
            Console.WriteLine(t.Namespace);
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.Name);
            int len = t.GetMethods().Length;
            //foreach (var mi in t.GetMethods())
            //{
            //    Console.WriteLine(mi.Name);
            //}
            int x = default(int);
            Console.WriteLine(x);
            CC mycc = default(CC);
            Console.WriteLine(mycc == null);
            level l = default(level);
            Console.WriteLine(l);
            var p = 44.4;
            Console.WriteLine(p.GetType().Name);
            Form myform = new Form() { Text = "holle" };
            //myform.ShowDialog();
            var person = "hr";
            Console.WriteLine(person);
            kk.report();
            people kkk = new people();
            kkk.report();
            uint max = uint.MaxValue;
            Console.WriteLine(max);
            string binmax = Convert.ToString(max, 2);
            Console.WriteLine(binmax);
            try
            {
                uint y = checked(max + 1);
                Console.WriteLine(y);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            int o = int.MinValue;
            int o1 = -o;
            Console.WriteLine(o1);
            int n = 12345678;
            int m = -n;
            string nstr = Convert.ToString(n, 2).PadLeft(32, '0');
            string mstr = Convert.ToString(m, 2).PadLeft(32, '0');
            Console.WriteLine(nstr);
            Console.WriteLine(mstr);
            //string d = Console.ReadLine();
            //string e = Console.ReadLine();
            //Console.WriteLine(Convert.ToInt32(d)+Convert.ToInt32(e));
            //Console.WriteLine(Int32.Parse(d)+Int32.Parse(e));
            Console.WriteLine(56 is Int32);
            // Nullable<int> j = null;
            //j = 100;
            int? j = null;
            j = 100;
            Console.WriteLine(j.Value);
            Console.WriteLine(j.HasValue);
            int? h = null;
            h = 88;
            int g = h ?? 5;
            Console.WriteLine(g);
            //holle: Console.WriteLine("holle hr");
            //    goto holle;
            Calculator cc = new Calculator();
            int r = 0;
            try
            {
                r = cc.Add("abc", "100");
            }
            catch (Exception)
            {

                throw;
            }
            Console.WriteLine(r);
            Student stu2 = new Student(1);
            Console.WriteLine(stu2.id);
            //stu2.id = 2;
            try
            {
                Student stu3 = new Student(3);
                stu3.Age = 20;

                Student stu4 = new Student(4);
                stu4.Age = 20;

                Student stu5 = new Student(5);
                stu5.Age = 20;

                int avgAge = (stu3.Age + stu4.Age + stu5.Age) / 3;
                Console.WriteLine(avgAge);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            student stu1 = new student();
            stu1["math"] = 90;
            var mathscore = stu["math"];
            Console.WriteLine(mathscore==null);
        }
    }
    class CC
    {
        public double add(double a, double b)
        {
            return a + b;
        }
        public void sayholle()
        {
            Console.WriteLine("holle");
        }
    }
    class Student:people
    {
        public readonly int id;
        public string Name;
        public int Score;
        public Student(int id)
        {
            this.id = id;
        }
        private int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value>=0&&value<=120)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Age value has error");
                }
            }
        }

        public static int averageage;
        public static int averagescore;
        public static int amount = 100;
        public void report()
        {
            Console.WriteLine("I am a student");
        }
    }
    enum level
    {
        Low,
        Mid,
        High
    }
    class people
    {
        public void report()
        {
            Console.WriteLine("I am a person");            
        }
    }
    class Calculator
    {
        public int Add(string arg1,string arg2)
        {
            int a = 0;
            int b = 0;
            try
            {
                a = int.Parse(arg1);
                b = int.Parse(arg2);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            int result = a + b;
            return result;
        }
    }
    class teacher
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        //public int MyProperty { get; set; }
        public int Age { get => age; set => age = value; }

        private int age;

    }
    class student
    {
        private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();
        public int? this[string subject]
        {
            get
            {
                /* return the specified index here */
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    return this.scoreDictionary[subject];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                /* set the specified index to value here */
                if (value.HasValue==false)
                {
                    throw new Exception("score can not be null");
                }
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    this.scoreDictionary[subject] = value.Value;
                }
                else
                {
                    this.scoreDictionary.Add(subject, value.Value);
                }
            }
        }
    }
}
