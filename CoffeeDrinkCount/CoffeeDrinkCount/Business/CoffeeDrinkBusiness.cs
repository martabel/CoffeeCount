using System;
using System.Threading.Tasks;
using CoffeeDrinkCount.Data;
namespace CoffeeDrinkCount.Business
{
    public class CoffeeDrinkBusiness
    {
        ICoffeeRestService coffeeRestService;

        public CoffeeDrinkBusiness(ICoffeeRestService service)
        {
            this.coffeeRestService = service;
        }

        public Task SaveCoffeeList(CoffeeList list)
        {
            return coffeeRestService.SaveCoffeeListAsync(list);
        }
    }
}
