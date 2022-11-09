using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Models
{
    public class MinusPoint
    {
        public int StudentId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public Student Student { get; set; }
    }
}
