using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Models
{
    public class RRData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RRDataId { get; set; }        
        public DateTime RawTime { get; set; }
        public Double Timestamp { get; set; }
        public int RRInterval { get; set; }
        public double StressIndex { get; set; }
        public double hrv { get; set; }
        public double meanNN { get; set; }
        public double sd1 { get; set; }
        public double sd2 { get; set; }
        public double pnn50 { get; set; }
        public int UserId { get; set; }
    }
}
