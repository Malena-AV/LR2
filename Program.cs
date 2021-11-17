using System;
using System.Collections.Generic;

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
        Propodavatel GetCosdaetPr(string name, Prepod dolj);
    }
    interface ILekcee : IDolsnoct
    {
        string GetLekcee();
    }
    interface IZayavlen : IGropp
    {
        string GetZayavlen();
    }
    public abstract class Person
    {
        string Name;
        public Person(string name)
        {
            this.Name = name;
        }
        public string GetFio()
        {
            return Name;
        }
    }
    public class Sotrudnik: Person
    {
        string dolj;
        public Sotrudnik (string name, string dolj): base (name)
        {
            this.dolj = dolj;
        }
        public string GetDol()
        {
            return dolj;
        }
    }
    public class Kadrovik : Sotrudnik, ICosdaet
    {
        public Kadrovik(string name): base(name, "кадровик")
        {
            
        }
        public Student GetCosdaetSt(string nameS, string grup)
        {
            return new Student(nameS, grup);
        }
        public Propodavatel GetCosdaetPr(string namePr, Prepod dolj)
        {
            return new Propodavatel(namePr, dolj);
        }
    }
    public enum Prepod
    {
        Assistant = 0,
        StLecturer = 1
    }

    public class Propodavatel: Sotrudnik, ILekcee 
    {
        static string[] dol = new string[] { "Ассистент" , "Старший преподаватель" };
        public Propodavatel(string Name, Prepod dolj) : base(Name, dol[(int)dolj])
        {
      
        }
        public string GetLekcee()
        {
            return "проводит лекции";
        }
    }
    public class Student : Person, IZayavlen 
    {
        string grup;
        public Student(string Name, string Grup): base (Name)
        {
            this.grup = Grup;
        }
        public string GetGropp()
        {
            return grup;
        }
        public string GetZayavlen()
        {
            return "заявление на отчисление";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

 
            Kadrovik one = new Kadrovik("К.Е.В.");
            Console.WriteLine(one.GetFio());
            Console.WriteLine(one.GetDol() + "\n");
            Student four = one.GetCosdaetSt("Н.З.Ш.", "3-1п9");
            Console.WriteLine(four.GetFio());
            Console.WriteLine(four.GetGropp() + "\n");
            Propodavatel five = one.GetCosdaetPr("Р.О.Г.", Prepod.Assistant);
            Console.WriteLine(five.GetFio());
            Console.WriteLine(five.GetDol() + "\n");
            Propodavatel two = new Propodavatel("А.Х.Г.", Prepod.StLecturer);
            Console.WriteLine(two.GetFio());
            Console.WriteLine(two.GetDol());
            Console.WriteLine(two.GetLekcee() + "\n");
        }
    }
}
