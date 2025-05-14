using BL.Models;
using BL.Services;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLAvialableQueue
    {
        List<BLAvialableQueue> GetAll();
        void Add(BLAvialableQueue newAQueue);
        void Remove(BLAvialableQueue aq);
        void UpdateAllAvialableQueuesByRange(DateTime d1, DateTime d2);
        void RemoveFullAvaialableQ(int startH, int startM, DateTime date);
        void RemoveFromAvialableQueuesByRange(int startH, int startM, int endH, int endM, DateTime date);
        Object GetAllStartQueues();
        Object SearchAvialableQueueByConditiones(string id, string dayWeek, string doctorName, string city, int minHour, int maxHour, DateTime date , bool isDouble);
        void BackQueueToBeAvialable(BLQueue queue);
        void DeleteAllAvialableQueuesByDateRange(DateTime d1, DateTime d2);
    }
}
