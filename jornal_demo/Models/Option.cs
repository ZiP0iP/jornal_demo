using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jornal_demo.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public Option()
        {
            Cars = new List<Car>();
        }
    }
}