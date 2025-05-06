using BL;
using BL.Models;

namespace Try
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //int מספר = 5;
            //Console.WriteLine(מספר);
            //string שם_פרטי = "Racheli";
            //Console.WriteLine(שם_פרטי);
            //string שם_משפחה = "Brin";
            //Console.WriteLine(שם_משפחה);

            //DateTime d = DateTime.Now;
            //var a = d.DayOfWeek;
            //Console.WriteLine(a.ToString());

            DateTime d1 = DateTime.Now.AddDays(-3);
            DateTime d2 = DateTime.Now;
            //Console.WriteLine(d1.AddDays(4)<d2);
            BLManager b = new BLManager();
            // List<BLAvialableQueue> l = i.AvialableQueues.GetAll().OrderBy(a => a.Date).ThenBy(a => a.Hour).ThenBy(a => a.Minute).ToList();
            //foreach (var item in l)
            //{
            //    Console.WriteLine(item.Date + " " + item.Hour + " " + item.Minute);
            //}
            b.AvialableQueues.UpdateAllAvialableQueuesByRange(d1, d2);
            ////b.AvialableQueues.Remove(new BLAvialableQueue() { Id = 32304 , Date = DateTime.Now,Hour = 10,Minute = 30,IdDoctor = "202056478" });
            ////b.AvialableQueues.RemoveFromAvialableQueuesByRange(11,0,12,0,new DateTime(2025,3,10));
            ////b.AvialableQueues.RemoveFromAvialableQueuesByRange(12, 0, 13, 0, new DateTime(2025 , 3 , 9));
            //bool bb= b.Queues.DetermineNewQueue(new BLQueue() { Date = d1,StartHour = 10,StartMinute = 0,EndHour = 11,EndMinute = 10,IdDoctor = "202056478" ,IdPatient = "215555426" , IdClinic = 1});
            //Console.WriteLine(bb);
            ////Console.WriteLine(d1);
            //Console.WriteLine(d1.CompareTo(d2));
            //List<BLAvialableQueue> l = new List<BLAvialableQueue>();
            //b.AvialableQueues.Sort(l);
            //foreach (var item in l)
            //{
            //    Console.WriteLine(item.Date + " " + item.Hour + " " + +item.Minute);
            //}
            //Console.WriteLine("llllllllllllllllllllllllllll");
            //List<BLAvialableQueue> l1 = b.AvialableQueues.GetAll();
            //foreach (var item in l1)
            //{
            //    Console.WriteLine(item.Date + " " + item.Hour + " " + +item.Minute);
            //}
            //List<BLDoctor> li = b.Doctors.GetBySubName("E");
            //foreach (var item in li)
            //{
            //    Console.WriteLine(item.FirstName + " " + item.LastName);
            //}

            //List<BLClinic> c = new List<BLClinic>();
            //c = b.Clinics.GetAll();
            //c.ForEach(c => { Console.WriteLine(c.City); });
            //l = b.AvialableQueues.GetAllForWoman();
            //l = b.AvialableQueues.SearchAvialableQueueByConditiones(p, null, "e", "Jerusalem", -1, -1, DateTime.Now, false);
            //l.ForEach(a => { Console.WriteLine(a.Date + " " + a.Hour + " " + +a.Minute); });
            //Console.WriteLine((d1.DayOfWeek.ToString().Equals("Sunday")));
            //var q = new { id = 12, age = 12 };
            //Console.WriteLine(q.ToString());


        }
    }
}