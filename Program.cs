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
        Student GetCosdaetSt(string name, string dolj);
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
    public class Kadrovik : ICosdaet // реализация интерфейса кадровка
    {
        string name;
        string dolj;
        public Kadrovik(string x, string y)
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
        public Student GetCosdaetSt(string name, string dolj)
        {
            return new Student(name, dolj);
        }
        public Propodavatel GetCosdaetPr(string name, string dolj)
        {
            return new Propodavatel(name, dolj);
        }
    }
    public class Propodavatel : ILekcee // реализация интерфейса преподавателя
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
    }
    public class Student : IZayavlen // реализация интерфейса студента
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
            Kadrovik one = new Kadrovik("К.Е.В.", "кадровик");
            Console.WriteLine(one.GetFio());
            Console.WriteLine(one.GetDol());
            Console.WriteLine(one.GetCosdaetSt("rtfer", "dcjs"));
            Console.WriteLine(one.GetCosdaetPr("rfr", "geg"));
            Console.WriteLine("    ");
            Propodavatel two = new Propodavatel("Н.М.Х.", "преподаватель");
            Console.WriteLine(two.GetFio());
            Console.WriteLine(two.GetDol());
            Console.WriteLine(two.GetLekcee());
            Console.WriteLine("    ");
            Student three = new Student("Р.З.А.", "3-1п9");
            Console.WriteLine(three.GetFio());
            Console.WriteLine(three.GetGropp());
            Console.WriteLine(three.GetZayavlen());
        }
    }
}
