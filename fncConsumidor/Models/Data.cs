using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fncConsumidor.Models
{
    class Data
    {


        [Key]
        public int aleatorio { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }


    }
}
