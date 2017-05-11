using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CoffeeDrinkCount.Data
{
    /// <summary>
    /// Todo Item business object
    /// </summary>
    public class CoffeeDrinker
    {
        public CoffeeDrinker()
        {

        }

        // SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ChipId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }

        public bool Active { get; set; }
    }
}
