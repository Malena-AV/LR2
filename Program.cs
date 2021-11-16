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
    //interface IDolsnoct2 : IFio
    //{
    //    string GetDol();
    //}
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
        public string Name;
        public Person(string name)
        {
            this.Name = name;
        }
    }
    public class Kadrovik : Person, ICosdaet
    {
        public Kadrovik(string name) : base(name)
        {

        }
        public string GetFio()
        {
            return Name;
        }
        public string GetDol()
        {
            return "Кадровик";
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
        Assistant,
        StLecturer,
    }
    public class Propodavatel: Person, ILekcee 
    {
        Prepod dolj;
        public Propodavatel(string Name, Prepod dolj) : base(Name)
        {
            this.dolj = dolj;
        }
        public string GetFio()
        {
            return Name;
        }
        public string GetDol()
        {
            if (dolj == Prepod.Assistant)
            {
                return "Ассистент";
            }
            else
            {
                return "Старший преподаватель";
            }
        }
        public string GetLekcee()
        {
            return "проводит лекции";
        }
        public override string ToString()
        {
            return Name + " " + dolj;
        }
    }
    public class Student : Person, IZayavlen 
    {
        string grup;
        public Student(string Name, string Grup): base (Name)
        {
            this.grup = Grup;
        }
        public string GetFio()
        {
            return Name;
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
            return Name + " " + grup;
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
