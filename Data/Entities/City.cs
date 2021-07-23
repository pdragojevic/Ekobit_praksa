using System.Collections.Generic;

namespace Data.Entities
{
    public class City
    {
        public string ZipCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
