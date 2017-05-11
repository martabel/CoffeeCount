using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.Utility
{
    public static class CoffeeDrinkerUtility
    {

        public static int countCoffeeForCoffeeDrinkerAllTime(int coffeeDrinkerId, IEnumerable<OneCoffee> _listOfCoffee)
        {
            List<OneCoffee> listOfCoffee = _listOfCoffee.ToList();
            
            var listforuser = listOfCoffee.FindAll(x => x.CoffeeCosumer_Id == coffeeDrinkerId.ToString());

            return listforuser.Count();
        }


        public static int countCoffeeForCoffeeDrinkerPerActualMonth(int coffeeDrinkerId, IEnumerable<OneCoffee> _listOfCoffee)
        {
            List<OneCoffee> listOfCoffee = _listOfCoffee.ToList();

            var listforuser = listOfCoffee.FindAll(x => x.CoffeeCosumer_Id == coffeeDrinkerId.ToString()).Where(x => Convert.ToDateTime(x.DateTime).Month == DateTime.Now.Month);

            return listforuser.Count();


            //var listofCoffePerMonth = listOfCoffee.Where(x => Convert.ToDateTime(x.Time).Month == DateTime.Now.Month);
        }


    }
}
