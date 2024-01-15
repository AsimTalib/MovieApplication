using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Entities
{
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = "System";
        public string UpdatedBy { get; set; } = "System";
        public DateTime CreatedAt { get; set;} = DateTime.Now;  
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    }
}
