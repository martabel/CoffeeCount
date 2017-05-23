using System;
using System.Threading.Tasks;
using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.Business
{
    public interface ICoffeeRestService
    {
        Task SaveCoffeeListAsync(CoffeeList list);   
    }
}
