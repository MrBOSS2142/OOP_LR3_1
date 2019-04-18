using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3_1
{
    public partial class Time
    {

        public int hours;//часы
        public int minutes;//минуты
        public int seconds;//секунды

        public static int count = 0;//количество объектов

        static int Cod=5;//статическое поле
        public readonly float ID;//поле только для чтения
        public const float idc = 86.4F;//поле константа

        private static int Hours2;
        private static int Minutes2;
        private static int Seconds2;


        public void TWrite()
        { Console.WriteLine("ID:{3:#.##}\n{0}.{1}.{2} ", Hours, Minutes, Seconds, ID); }

        public void TPWrite()
        { Console.WriteLine("Закрытый конструктор ID: " + Hours2 + Minutes2 + Seconds2 + ID); }

        public void TCount()
        { Console.WriteLine("Класс Time содержит " + count + " объектов."); }
    }

    public partial class Time
    {
        public int Hours
        {
            private set
            {
                if (value < 0 || value > 23)
                { Console.WriteLine("Часы заданы не верно!!!"); }
                else { hours = value; }
            }
            get { return hours; }
        }
        public int Minutes
        {
            set
            {
                if (value < 0 || value > 59)
                { Console.WriteLine("Минуты заданы не верно!!!"); }
                else { minutes = value; }
            }
            get { return minutes; }
        }
        public int Seconds
        {
            set
            {
                if (value < 0 || value > 59)
                { Console.WriteLine("Секунды заданы не верно!!!"); }
                else { seconds = value; }
            }
            get { return seconds; }
        }

        public Time(int hours = 23, int minutes = 59, int seconds = 59)
        {
            count++;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            float _id = idc / ((Hours * 3600 + Minutes * 60 + Seconds) / 1000);
            ID = _id;
        }
        public static string pr = "private";
        public static int sc;
        private Time(int hours, int minutes, out int seconds, ref string t)// закрытый конструктор
        {
            seconds = 10;
            count++;
            float _id = idc / ((hours * 3600 + minutes * 60 + this.seconds) / 1000);
            ID = _id;
            Hours2 = hours;
            Minutes2 = minutes;
            Seconds2 = seconds;
        }
        static Time()//статический конструктор
        {
            Time t4 = new Time(11, 36, out sc, ref pr);
            t4.TPWrite();
        }

        public override int GetHashCode()
        {
            int dop;
            if (Hours == 23)
                dop = 23;
            else dop = 15;
            Console.Write("Hash : ");
            return Minutes + Seconds + dop;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Time m = obj as Time;
            if (m as Time == null)
                return false;
            Console.Write(" Сравнение обьектов - ");
            return m.Hours == this.Hours && m.Minutes == this.Minutes && m.Seconds == this.Seconds;
        }
       
        public override string ToString()
        {
            return Hours + "." + Minutes + "." + Seconds;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var anon = new { hour1 = 12, min1 = 27, sec1 = 35 };
            Console.WriteLine("Аннонимный тип: " + anon.hour1 + "." + anon.min1 + "." + anon.sec1);
            Time[] time = new Time[7];
            time[0] = new Time(23, 25, 30);
            time[0].TWrite();
            Console.WriteLine(time[0].GetHashCode());
            time[1] = new Time(13, 27, 13);
            time[1].TWrite();
            Console.WriteLine(time[1].GetHashCode());

            time[2] = new Time();
            time[2].TWrite();
            Console.WriteLine(time[2].GetHashCode());

            time[3] = new Time(13, 27, 13);
            time[3].TWrite();
            Console.WriteLine(time[3].GetHashCode());

            time[4] = new Time(18, 39, 47);
            time[4].TWrite();
            Console.WriteLine(time[4].GetHashCode());

            time[5] = new Time(6, 34, 11);
            time[5].TWrite();
            Console.WriteLine(time[5].GetHashCode());

            time[6] = new Time(5, 22, 22);
            time[6].TWrite();
            Console.WriteLine(time[5].GetHashCode());

            bool m1 = time[0].Equals(time[2]);
            Console.WriteLine("Объекта time[0] и time[2] равны? {0}", m1);

            bool m2 = time[3].Equals(time[1]);
            Console.WriteLine("Объекта time[3] и time[1] равны? {0}", m2);
            time[2].TCount();
            Console.WriteLine("Массив объектов: ");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(time[i]);
            }

            Console.WriteLine("Задайте число часов для поиска: ");
            int hour = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Список времен по группам:");
            Console.WriteLine("_______________________");
            Console.WriteLine("Ночь: ");
            for (int i = 0; i < 7; i++)
                if (time[i].Hours > 20 && time[i].Hours < 5)
                {
                    Console.WriteLine(time[i]);
                }

            for (int i = 0; i < 7; i++)
                if (time[i].Hours == hour)
                {
                    Console.WriteLine(time[i]);
                }

            Console.WriteLine("_______________________");
            Console.WriteLine("Утро: ");
            for (int i = 0; i < 7; i++)
                if (time[i].Hours >= 5 && time[i].Hours < 12)
                {
                    Console.WriteLine(time[i]);
                }
            Console.WriteLine("_______________________");
            Console.WriteLine("День: ");
            for (int i = 0; i < 7; i++)
                if (time[i].Hours >= 12 && time[i].Hours < 16)
                {
                    Console.WriteLine(time[i]);
                }
            Console.WriteLine("_______________________");
            Console.WriteLine("Вечер: ");
            for (int i = 0; i < 7; i++)
                if (time[i].Hours >= 16 && time[i].Hours <= 20)
                {
                    Console.WriteLine(time[i]);
                }
           
        }
    }
}