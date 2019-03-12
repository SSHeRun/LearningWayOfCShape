using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    //public delegate double Calc(double x, double y);

    class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(Action);
            //Console.WriteLine(t.IsClass);
            //Calculator calculator = new Calculator();
            //Calc calc1 = new Calc(calculator.Add);
            //Calc calc2 = new Calc(calculator.Sub);
            //Calc calc3 = new Calc(calculator.Mul);
            //Calc calc4 = new Calc(calculator.Div);

            //double a = 100;
            //double b = 200;
            //double c = 0;

            //c = calc1.Invoke(a, b);
            //Console.WriteLine(c);

            //c = calc2(a, b);
            //Console.WriteLine(c);
            //ProductFactory productFactory = new ProductFactory();
            //WrapFactory wrapFactory = new WrapFactory();

            //Func<Product> fun1 = new Func<Product>(productFactory.MakePizza);
            //Func<Product> fun2 = new Func<Product>(productFactory.MakeToy);

            //Logger logger = new Logger();
            //Action<Product> log = new Action<Product>(logger.log);

            //Box box1 = wrapFactory.WraProduct(fun1,log);
            //Box box2 = wrapFactory.WraProduct(fun2,log);

            //Console.WriteLine(box1.Pouduct.Name);
            //Console.WriteLine(box2.Pouduct.Name);

            //Student student1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            //Student student2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            //Student student3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            //Action action1 = new Action(student1.DoHomework);
            //Action action2 = new Action(student2.DoHomework);
            //Action action3 = new Action(student3.DoHomework);

            //action1 += action2;
            //action1 += action3;

            //action1();
            //action2();
            //action3();

            //action1.BeginInvoke(null,null);
            //action2.BeginInvoke(null, null);
            //action3.BeginInvoke(null, null);

            //Thread thread1 = new Thread(new ThreadStart(student1.DoHomework));
            //Thread thread2 = new Thread(new ThreadStart(student2.DoHomework));
            //Thread thread3 = new Thread(new ThreadStart(student3.DoHomework));

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //Task task1 = new Task(new Action(student1.DoHomework));
            //Task task2 = new Task(new Action(student2.DoHomework));
            //Task task3 = new Task(new Action(student3.DoHomework));

            //task1.Start();
            //task2.Start();
            //task3.Start();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.WriteLine("Main thread {0}",i);
            //    Thread.Sleep(1000);
            //}

        }
    }
    //class Calculator
    //{
    //    public double Add(double x,double y)
    //    {
    //        return x + y;
    //    }
    //    public double Sub(double x, double y)
    //    {
    //        return x - y;
    //    }
    //    public double Mul(double x, double y)
    //    {
    //        return x * y;
    //    }
    //    public double Div(double x, double y)
    //    {
    //        return x / y;
    //    }
    //}
    //class Logger
    //{
    //    public void log(Product product)
    //    {
    //        Console.WriteLine("Product '{0}' created at {1}.Price is {2}",product.Name,DateTime.UtcNow,product.Price);
    //    }
    //}
    //class Product
    //{
    //    public string Name { get; set; }
    //    public double Price { get; set; }
    //}
    //class Box
    //{
    //    public Product Pouduct { get; set; }
    //}
    //class WrapFactory
    //{
    //    public Box WraProduct(Func<Product> getProduct,Action<Product>logCallback)
    //    {
    //        Box box = new Box();
    //        Product product = getProduct.Invoke();
    //        if (product.Price>=50)
    //        {
    //            logCallback(product);
    //        }
    //        box.Pouduct = product;
    //        return box;
    //    }
    //}
    //class ProductFactory
    //{
    //    public Product MakePizza()
    //    {
    //        Product product = new Product();
    //        product.Name = "Pizza";
    //        product.Price = 12;
    //        return product;
    //    }
    //    public Product MakeToy()
    //    {
    //        Product product = new Product();
    //        product.Name = "Toy";
    //        product.Price = 200;
    //        return product;
    //    }
    //}
    //class Student
    //{
    //    public int ID { get; set; }
    //    public ConsoleColor PenColor { get; set; }

    //    public void DoHomework()
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.ForegroundColor = this.PenColor;
    //            Console.WriteLine("Student {0} doing homework {1} hour(s)",this.ID,i);
    //            Thread.Sleep(1000);       
    //        }
    //    }
    //}
}
