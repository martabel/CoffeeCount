using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CoffeeDrinkCount.Data
{
    /// <summary>
    /// Dieses Objekt steht für einen getrunkenen Kaffee
    /// </summary>
    public class OneCoffee
    {
        public OneCoffee()
        {

        }

        // SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CoffeeCosumer_Id { get; set; }
        public string DateTime { get; set; }

        public bool Payed { get; set; }

    }
}
