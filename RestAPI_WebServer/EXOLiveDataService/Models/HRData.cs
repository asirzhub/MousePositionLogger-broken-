using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Models
{
    public class HRData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HRDataId { get; set; }
        public DateTime RawTime { get; set; }
        public double Timestamp { get; set; }
        public int HeartRate { get; set; }        
        public int MaxHeartRate { get; set; }
        public int ExertionScore { get; set; }
        public string Intensity { get; set; }  
        public double meanHR { get; set; }  
        public double IBI { get; set; }
        public int UserId { get; set; }
    }
}
