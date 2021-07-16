using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class City
    {
        public string ZipCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
