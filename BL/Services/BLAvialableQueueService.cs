using BL.Api;
using BL.Models;
using DAL.Models;
using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services;
using Microsoft.IdentityModel.Tokens;

namespace BL.Services
{
    public class BLAvialableQueueService : IBLAvialableQueue
    {
        IDalAvialableQueue data;
        IBLWorkingTime workingTimes;
        IBLDoctor doctors;
        IBLClinic clinics;
        IBLPatient patients;
        IBLReadWriteDataFromFiles readWriteData;
     
        public BLAvialableQueueService(IDal dalMan , Lazy<IBLWorkingTime> workingTime, IBLDoctor doctors , IBLClinic clinics , IBLPatient patients , IBLReadWriteDataFromFiles readWriteData)
        {
            data = dalMan.AvagingQueues;
            this.workingTimes = workingTime.Value  ;
            this.doctors = doctors;
            this.clinics = clinics;
            this.patients = patients;
            this.readWriteData = readWriteData;
        }

        public void Add(BLAvialableQueue newAQueue)
        {
            data.Add(ConvertAvialableToDal(newAQueue));
        }

        public List<BLAvialableQueue> GetAll()
        {
            List<BLAvialableQueue> list =  data.GetAll().Select(aq => ConvertAvialableToBL(aq)).ToList();
            return list;
        }
        //קבלת כל התורים הפנויים לקביעת תור עבור אישה-שעה ועשר דקות
        private  List<BLAvialableQueue> GetAllForWoman()
        {
            List<BLAvialableQueue> kk = GetAll();
            List<BLAvialableQueue> l = GetAll().FindAll(q => IsStartTimeOfNewQueue(q , 1));
            l = l.OrderBy(a => DateOnly.FromDateTime(a.Date)).ThenBy(a => a.Hour).ThenBy(a => a.Minute).ToList();
            List<BLAvialableQueue> l1 = new List<BLAvialableQueue>();
            BLAvialableQueue last;
            if (l.Count == 0)
                return l;
            l1.Add(l[0]);
            last = l[0];
            foreach (var item in l)
            {
                if (DateOnly.FromDateTime( item.Date).CompareTo(DateOnly.FromDateTime(last.Date)) != 0 || item.Hour > last.Hour + 1 || item.Hour > last.Hour && item.Minute >= last.Minute)
                {
                    l1.Add(item);
                    last = item;
                }
            }
            return l1;
        }
        //קבלת כל התורים הפנויים לקביעת תור רגיל של שעה
        private List<BLAvialableQueue> GetAllForOrginal()
        {
            List<BLAvialableQueue> l = GetAll().FindAll(q => IsStartTimeOfNewQueue(q, 0));
            l = l.OrderBy(a => DateOnly.FromDateTime(a.Date)).ThenBy(a => a.Hour).ThenBy(a => a.Minute).ToList();
            List<BLAvialableQueue> l1 = new List<BLAvialableQueue>();
            BLAvialableQueue last;
            if (l.Count == 0) 
                return l;
            l1.Add(l[0]);
            last = l[0];
            foreach (var item in l)
            {
                if (DateOnly.FromDateTime(item.Date).CompareTo(DateOnly.FromDateTime(last.Date)) != 0 || item.Hour > last.Hour + 1 || item.Hour > last.Hour && item.Minute >= last.Minute)
                {
                    l1.Add(item);
                    last = item;
                }
            }
            return l1;
        }

        //קבלת כל התורים הפנויים לקביעת תור כפול
        private List<BLAvialableQueue> GetAllForDoubleQueue()
        {
            List<BLAvialableQueue> l = GetAll().FindAll(q => IsStartTimeOfNewQueue(q, 6));
            l = l.OrderBy(a => DateOnly.FromDateTime(a.Date)).ThenBy(a => a.Hour).ThenBy(a => a.Minute).ToList();
            if (l.Count == 0)
                return l;
            List<BLAvialableQueue> l1 = new List<BLAvialableQueue>();
            BLAvialableQueue last;
            l1.Add(l[0]);
            last = l[0];
            foreach (var item in l)
            {
                if (DateOnly.FromDateTime( item.Date).CompareTo(DateOnly.FromDateTime(last.Date)) != 0 || item.Hour > last.Hour + 1 || item.Hour > last.Hour && item.Minute >= last.Minute)
                {
                    l1.Add(item);
                    last = item;
                }
            }
            return l1;
        }
        //מיון התורים הפנויים
        private void Sort(List<BLAvialableQueue> list)
        {
            list = list.OrderBy(a => a.Date).ThenBy(a => a.Hour).ThenBy(a => a.Minute).ToList();
            //list.Sort((aq, other) => (aq.Date.CompareTo(other.Date)) * 1000 + (aq.Hour - other.Hour) * 60 + (aq.Minute - other.Minute));
        }
                                                
        //פונק' הבודקת האם תור יכול להוות התחלה של תור חדש
        private bool IsStartTimeOfNewQueue(BLAvialableQueue aq, int type)
        {
            int h = aq.Hour, m = aq.Minute;

            for (int i = 0; i < 5 + type; i++)
            {
                if (m < 50)
                    m += 10;
                else
                {
                    m = 0;
                    h++;
                }

                if (GetAll().Find(q => q.IdDoctor == aq.IdDoctor && DateOnly.FromDateTime(aq.Date).Equals(DateOnly.FromDateTime
                    (q.Date)) && q.Hour == h && q.Minute == m) == null)
                    return false;
            }
            return true;
        }
    
        //פונק' שמבטלת תור פנוי

        public void RemoveFullAvaialableQ( int startHour , int startMinute,DateTime date )
        {
            RemoveFromAvialableQueuesByRange(startHour,startMinute,startHour + 1,startMinute,date);
        }
        public void RemoveFromAvialableQueuesByRange(int startH , int startM , int endH , int endM , DateTime date)
        {
            List<BLAvialableQueue> list = GetAll();
            foreach (var aq in list)
            {
               if (DateOnly.FromDateTime(date).Equals(DateOnly.FromDateTime(aq.Date)) && IsInTimeRange(startH, startM, endH, endM, aq))
                    Remove(aq);
            }
        }

        public void Remove(BLAvialableQueue AQueue)
        {
            data.Remove(ConvertAvialableToDal(AQueue));  
        }

        //עדכון תורים פנויים בתווך תאריכים מסוים
        public void UpdateAllAvialableQueuesByRange(DateTime d1 , DateTime d2)
        {
            List<BLWorkingTime> s = workingTimes.GetAll();
            foreach (var workTime in s)
            {
                for(DateTime d = d1; d.CompareTo(d2) < 0; d = d.AddDays(1))
                {
                    String weekDay = d.DayOfWeek.ToString();  
                    if(weekDay == workTime.DayWeek)
                    {
                        for(int h = workTime.StartHour , m = workTime.StartMinute; h != workTime.EndHour || m != workTime.EndMinute;)
                        {
                            BLAvialableQueue aQ = new() { Date = d, Hour = h, Minute = m, IdDoctor = workTime.IdDoctor , IdClinic = workTime.IdClinic};
                            Add(aQ);
                            if (m < 50)
                                m += 10;
                            else
                            {
                                m = 0;
                                h++;
                            }
                        }                
                    }
                }
            }
            readWriteData.SetLastDateThatAvialableQWasUpdated(d2);

        }

        //פונק' הבודקת האם תור מסוים נמצא בטווח מסוים של שעות
        private bool IsInTimeRange(int startH, int startM, int endH, int endM,BLAvialableQueue aq)
        {
            if(startH < aq.Hour || startH == aq.Hour && startM <= aq.Minute)
            {
                if(endH > aq.Hour)
                {
                    return true;
                }
                else if(endH == aq.Hour)
                {
                     return  endM > aq.Minute;
                }
            }
            return false;
        }
        // פונקציה המוחקת מטבלת התורים הפנויים את כל התורים בטווח תאריכים מסויים
        
        public void DeleteAllAvialableQueuesByDateRange(DateTime d1 , DateTime d2)
        {
            GetAll().Where(aq => DateOnly.FromDateTime(aq.Date).CompareTo(DateOnly.FromDateTime(d1)) <= 0 &&  DateOnly.FromDateTime(aq.Date).CompareTo(DateOnly.FromDateTime(d2)) >= 0).ToList().ForEach(aq => Remove(aq));
        }
        public Object SearchAvialableQueueByConditiones(string id ,  string dayWeek , string doctorName , string city , int minHour , int maxHour , DateTime date , bool isDouble)
        {
            BLPatient p = patients.GetById(id);
            List<BLAvialableQueue> list ;
            if(isDouble)
                list = GetAllForDoubleQueue();
            else if (p.Gender.Equals("female"))
                list = GetAllForWoman();
            else 
                list = GetAllForOrginal();
            // עכשו יש רשיממת תורי בסיסית

            List<BLDoctor> docList = new List<BLDoctor>();
            List<BLClinic> cliList = new List<BLClinic>();
            if(doctorName != null)
               docList = doctors.GetBySubName(doctorName);
            if (city != null)
                cliList = clinics.GetByCity(city);
            List<BLAvialableQueue> res ;
            res = list.FindAll(aq => (dayWeek.IsNullOrEmpty() || aq.Date.DayOfWeek.ToString().Equals(dayWeek))
                            && (minHour == -1 || aq.Hour >= minHour)
                            && (maxHour == -1 || aq.Hour <= maxHour)
                            && (doctorName.IsNullOrEmpty() || docList.Find(d => d.Id.Equals(aq.IdDoctor)) != null)
                            && (city.IsNullOrEmpty() || cliList.Find(c => c.Id.Equals(aq.IdClinic)) != null)
                            && (date == null || DateOnly.FromDateTime(aq.Date).CompareTo(DateOnly.FromDateTime(date)) >= 0));
            return res.Select(q => new {id  = q.Id , date = q.Date.ToString("MM/dd/yyyy") , idClinic = q.IdClinic , idDoctor = q.IdDoctor , hour = q.Hour , minute = q.Minute}) ;
          
        }
        
        public Object GetAllStartQueues()
        {
            List<BLAvialableQueue> listOfWoman = GetAllForWoman();
            List<BLAvialableQueue> listOfDouble = GetAllForDoubleQueue();
            var res = GetAllForOrginal().Select(q => new { Queue = new {date = q.Date.ToString("MM/dd/yyyy"), id = q.Id , idClinic = q.IdClinic , idDoctor = q.IdDoctor , hour = q.Hour , minute = q.Minute}, flagWoman = listOfWoman.Exists(a => a.Id == q.Id), flagDouble = listOfDouble.Exists(a => a.Id == q.Id)}).ToList();
            return res;
        }
        
        public void BackQueueToBeAvialable(BLQueue queue)
        {
            for (int h = queue.StartHour, m = queue.StartMinute; h != queue.EndHour || m != queue.EndMinute;)
            {
                BLAvialableQueue aQ = new() { Date = queue.Date, Hour = h, Minute = m, IdDoctor = queue.IdDoctor, IdClinic = queue.IdClinic };
                Add(aQ);
                if (m < 50)
                    m += 10;
                else
                {
                    m = 0;
                    h++;
                }
            }
        }

        private BLAvialableQueue ConvertAvialableToBL(AvailableQueue aq) => new BLAvialableQueue() { Date = aq.Date, Id = aq.Id, IdDoctor = aq.IdDoctor, Hour = aq.Hour, Minute = aq.Minute, IdClinic = aq.IdClinic };

        private AvailableQueue ConvertAvialableToDal(BLAvialableQueue aq) => new AvailableQueue() { Date = aq.Date, Id = aq.Id, IdDoctor = aq.IdDoctor, Hour = aq.Hour, Minute = aq.Minute, IdClinic = aq.IdClinic };

      
    }
}
