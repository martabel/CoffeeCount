using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeDrinkCount
{
    public interface ILocalFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
