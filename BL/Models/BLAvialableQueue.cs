using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLAvialableQueue
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Hour { get; set; }

        public int Minute { get; set; }

        public string IdDoctor { get; set; } = null!;

        public int IdClinic { get; set; }
    }
}
