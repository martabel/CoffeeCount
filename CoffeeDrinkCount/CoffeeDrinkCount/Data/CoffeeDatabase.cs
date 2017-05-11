using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace CoffeeDrinkCount.Data
{
    /// <summary>
    /// TaskDatabase uses ADO.NET to create the [Items] table and create,read,update,delete data
    /// </summary>
    public class CoffeeDatabase
    {
        static object locker = new object();

        public SQLiteConnection database;

        public string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        public CoffeeDatabase(SQLiteConnection conn)
        {
            database = conn;
            // create the tables
            database.CreateTable<OneCoffee>();
            database.CreateTable<CoffeeDrinker>();
        }

        public IEnumerable<OneCoffee> GetCoffees()
        {
            lock (locker)
            {
                return (from i in database.Table<OneCoffee>() select i).ToList();
            }
        }

        public OneCoffee GetCofee(int id)
        {
            lock (locker)
            {
                return database.Table<OneCoffee>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
        }

        public int SaveCoffee(OneCoffee item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteCoffee(int id)
        {
            lock (locker)
            {
                return database.Delete<OneCoffee>(id);
            }
        }



        #region Methoden für Kaffetrinker

        public IEnumerable<CoffeeDrinker> GetCoffeeDrinkers()
        {
            lock (locker)
            {
                return (from i in database.Table<CoffeeDrinker>() select i).ToList();
            }
        }

        public CoffeeDrinker GetCoffeeDrinker(int id)
        {
            lock (locker)
            {
                return database.Table<CoffeeDrinker>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
        }

        public int SaveCoffeeDrinker(CoffeeDrinker item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteCoffeeDrinker(int id)
        {
            lock (locker)
            {
                return database.Delete<CoffeeDrinker>(id);
            }
        } 
        #endregion
    }
}
