using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Models
{
    public class MouseData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //need to include ID Without ID can't search post, get or delete or update
        public int MouseDataId { get; set; }

        //Time variable type is wrong
        public DateTime rawTime { get; set; }

        //mousePositionX,Y can not be int type this cause error from Unity side because you are try to POST float type value and from webserver you set to integer.
        //That's why you get 500 error.
        public float mousePositionX { get; set; }
        public float mousePositionY { get; set; } 
    }
}
