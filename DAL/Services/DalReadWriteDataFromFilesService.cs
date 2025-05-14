using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Services
{
     public class DalReadWriteDataFromFilesService : IDalReadWriteDataFromFiles
    {
        public const string BASE_URL = "..\\..\\..\\..\\Dal\\Files\\";
        public DateTime GetLastDateFromDetermindQ()
        {
            XDocument xd = XDocument.Load(BASE_URL + "data.xml");
            string date =  xd.Root.Element("lastDateOfDetermindQ").Value;   
            return DateTime.Parse(date);

        }

        public DateTime GetLastDateThatAvialableQWasUpdated()
        {
            XDocument xd = XDocument.Load(BASE_URL + "data.xml");
            string date = xd.Root.Element("lastDateThatAvialableQWasUpdate").Value;
            return DateTime.Parse(date);
        }

        public void SetLastDateFromDetermindQ(DateTime date)
        {   
            XDocument xd = XDocument.Load(BASE_URL + "data.xml");
            xd.Root.Element("lastDateOfDetermindQ").SetValue(date.ToString());
            xd.Save(BASE_URL+"data.xml");
        }

        public void SetLastDateThatAvialableQWasUpdated(DateTime date)
        {
            XDocument xd = XDocument.Load(BASE_URL + "data.xml");
            xd.Root.Element("lastDateThatAvialableQWasUpdate").SetValue(date.ToString());
            xd.Save(BASE_URL + "data.xml");
        }

    }
}
