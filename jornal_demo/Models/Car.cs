using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jornal_demo.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string Weburl { get; set; }
 //       public int OptionId { get; set; }
        
        public virtual ICollection<Option> Options { get; set; }
        public Car()
        {
            Options = new List<Option>();
        } 
    }
}