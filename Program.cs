using System;

namespace рпм2
{
    interface IFio
    {
        string GetFio();
    }
    interface IDolsnoct : IFio
    {
        string GetDol();
    }
    interface IGropp : IFio
    {
        string GetGropp();
    }
    interface ICosdaet : IDolsnoct
    {
        Student GetCosdaetSt(string name, string grup);
        Propodavatel GetCosdaetPr(string name, string dolj);
    }
    interface ILekcee : IDolsnoct
    {
        string GetLekcee();
    }
    interface IZayavlen : IGropp
    {
        string GetZayavlen();
    }
    /// <summary>
    /// реализация интерфейса кадровка
    /// </summary>
    public class Kadrovik : ICosdaet
    {
        string name;
        public Kadrovik(string x)
        {
            this.name = x;
        }
        public string GetFio()
        {
            return name;
        }
        public string GetDol()
        {
            return "Кадровик";
        }
        public Student GetCosdaetSt(string nameS, string grup)
        {
            return new Student(nameS, grup);
        }
        public Propodavatel GetCosdaetPr(string namePr, string dolj)
        {
            return new Propodavatel(namePr, dolj);
        }
    }
    public class Propodavatel : ILekcee 
    {
        string name;
        string dolj;
        public Propodavatel(string x, string y)
        {
            this.name = x;
            this.dolj = y;
        }
        public string GetFio()
        {
            return name;
        }
        public string GetDol()
        {
            return dolj;
        }
        public string GetLekcee()
        {
            return "проводит лекции";
        }
        public override string ToString()
        {
            return name + " " + dolj;
        }
    }
    public class Student : IZayavlen 
    {
        string name;
        string grup;
        public Student(string x, string y)
        {
            this.name = x;
            this.grup = y;
        }
        public string GetFio()
        {
            return name;
        }
        public string GetGropp()
        {
            return grup;
        }
        public string GetZayavlen()
        {
            return "заявление на отчисление";
        }
        public override string ToString()
        {
            return name + " " + grup;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Kadrovik one = new Kadrovik("К.Е.В.");
            Console.WriteLine(one.GetFio());
            Console.WriteLine(one.GetDol());
            string nameS = "Н.З.Ш.";
            string grup = "3-1п9";
            Student four = one.GetCosdaetSt(nameS, grup);
            Console.WriteLine(four.GetFio());
            Console.WriteLine(four.GetGropp());
            string namePr = "Р.О.Г.";
            string dolj = "преподаватель";
            Propodavatel five = one.GetCosdaetPr(namePr, dolj);
            Console.WriteLine(five.GetFio());
            Console.WriteLine(five.GetDol());
            Propodavatel two = new Propodavatel("А.Х.Г.", "преподаватель");
            Console.WriteLine(two.GetFio());
            Console.WriteLine(two.GetDol());
            Console.WriteLine(two.GetLekcee() + "\n");
            Student three = new Student("П.Г.А.", "3-19");
            Console.WriteLine(three.GetFio());
            Console.WriteLine(three.GetGropp());
            Console.WriteLine(three.GetZayavlen());
        }
    }
}
