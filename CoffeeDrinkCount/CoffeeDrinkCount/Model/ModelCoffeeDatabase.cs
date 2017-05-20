using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;
using CoffeeDrinkCount;
using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.Model
{
    #region Wird später benötigt
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventCoffeeDrinkerArgs e);


    // The ModelEventArgs class which is derived from th EventArgs class to 
    // be passed on to the controller when the value is changed
    public class ModelEventCoffeeDrinkerArgs : EventArgs
    {
        public CoffeeDrinker coffeeDrinker;
        public ModelEventCoffeeDrinkerArgs(CoffeeDrinker cD)
        {
            coffeeDrinker = cD;
        }
    }



    // The interface which the form/view must implement so that, the event will be
    // fired when a value is changed in the model.
    public interface IModelObserver
    {
        void GetCoffeeDrinker(IModel model, ModelEventCoffeeDrinkerArgs e);
    }



    // The Model interface where we can attach the function to be notified when value
    // is changed. An actual data manipulation function increment which increments the value
    // A setvalue function which sets the value when users changes the textbox
    public interface IModel
    {
        void attach(IModelObserver imo);
        void increment();
        void setvalue(int v);
    } 
    #endregion

    public class ModelCoffeeDatabase //: IModel
    {
        public event ModelHandler<ModelCoffeeDatabase> changed;

        string path = "Fehler!";

        private CoffeeDatabase coffeeDatabase;

        public List<CoffeeDrinker> coffeeDrinkerList;
        public List<OneCoffee> coffeeList;


        #region ModelCoffeeDatabase  Standardkonstruktor
        /// <summary>
        /// Standard Konstruktor - Dateipfad der Datenbank ermitteln
        /// Daten initialisieren
        /// </summary>
        public ModelCoffeeDatabase()
        {
            path = DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("CoffeeDatabase.db3");
            coffeeDatabase = new CoffeeDatabase(new SQLiteConnection(path));

            updateCoffeeDrinkerList();
            updateCoffeeList();
        }
        #endregion


        public void addCoffeeDrinker(string firstname, string lastname, string chipId)
        {
            CoffeeDrinker newCoffeeDrinker = new CoffeeDrinker();
            newCoffeeDrinker.Firstname = firstname;
            newCoffeeDrinker.Name = lastname;
            newCoffeeDrinker.ChipId = chipId;
            newCoffeeDrinker.Email = "-";
            newCoffeeDrinker.Active = true;

            coffeeDatabase.SaveCoffeeDrinker(newCoffeeDrinker);

            updateCoffeeDrinkerList();
        }

        #region AddOneCoffeeForUserById
        /// <summary>
        /// Diese Methode fügt der Datenbank einen neuen Kaffee mit der Id des angegebenen User hinzu
        /// </summary>
        /// <param name="id">Die Id des User für den ein Kaffee zur Datenbank hinzugefügt werden soll</param>
        public void AddOneCoffeeForUserById(int id)
        {
            OneCoffee coffee = new OneCoffee(); // Neues Objekt erzeugen
            coffee.CoffeeCosumer_Id = id.ToString(); // Id des Nutzers eintragen
            coffee.Payed = false; // Nicht bazahlt als Standardwert
            coffee.DateTime = DateTime.Now.ToString(); // aktuelles Datum und Uhrzeit

            coffeeDatabase.SaveCoffee(coffee);

            // Liste mit Kaffee aktualisieren
            updateCoffeeList();
        }
        #endregion


        #region GetCoffeeDrinkerCount
        /// <summary>
        /// Gibt die Anzahl der Kaffeetrinker zurück
        /// </summary>
        /// <returns>Anzahl der Kaffeetrinker</returns>
        public int GetCoffeeDrinkerCount()
        {
            return coffeeDrinkerList.Count;
        } 
        #endregion





        //private Methoden

        #region updateCoffeeDrinkerList
        /// <summary>
        /// Die Liste der KaffeeTrinker wird aktualisiert
        /// </summary>
        /// <param name="coffeedatabase">Datenbank</param>
        /// <param name="coffeeList">Liste der Kaffeetrinker</param>
        private void updateCoffeeDrinkerList() //CoffeeDatabase coffeedatabase, List<CoffeeDrinker> coffeedrinkerList)
        {
            coffeeDrinkerList = coffeeDatabase.GetCoffeeDrinkers().ToList();
        }
        #endregion

        #region updateCoffeeList
        /// <summary>
        /// Die Liste der Kaffees wird aktualisiert
        /// </summary>
        /// <param name="coffeedatabase">Datenbank</param>
        /// <param name="coffeeList">Liste getrunkener Kaffee</param>
        private void updateCoffeeList() //CoffeeDatabase coffeedatabase, List<OneCoffee> coffeeList)
        {
            coffeeList = coffeeDatabase.GetCoffees().ToList();
        }
        #endregion


        #region Auskommentiert - Vorlage für spätere Erweiterung des Models
        //// Change the value and fire the event with the new value inside ModelEventArgs
        //// This will invoke the function valueIncremented in the model and will be displayed
        //// in the textbox subsequently
        //public void GetCoffeeDrinker(int Id)
        //{
        //    changed.Invoke(this, new ModelEventCoffeeDrinkerArgs(coffeeDrinkerList.Find(x => x.ID == Id)));
        //}



        //// Attach the function which is implementing the IModelObserver so that it can be
        //// notified when a value is changed
        //public void attach(IModelObserver imo)
        //{
        //    changed += new ModelHandler<ModelCoffeeDatabase>(imo.GetCoffeeDrinker);
        //} 
        #endregion


    }

}
