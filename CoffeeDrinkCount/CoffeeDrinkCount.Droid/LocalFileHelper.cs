using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using CoffeeDrinkCount;
using CoffeeDrinkCount.Droid;

using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]

namespace CoffeeDrinkCount.Droid
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}