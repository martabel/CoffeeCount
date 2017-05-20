using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;
using CoffeeDrinkCount.Model;

namespace CoffeeDrinkCount.UI_Elements
{
    class MainMenu : ContentPage
    {
        private ModelCoffeeDatabase modelCoffeeDatabase;

        public MainMenu(ModelCoffeeDatabase pModelCoffeeDatabase)
        {
            modelCoffeeDatabase = pModelCoffeeDatabase;

            Title = "Kaffeeverwaltung";
            BackgroundColor = Color.FromHex("DDC9B2");
            Icon = "coffeemachine_2_comlete_white.png";

            ToolbarItem toolbarSettings = new ToolbarItem();
            toolbarSettings.Icon = "settings_white.png";
            toolbarSettings.Clicked += ToolbarSettings_Clicked;

            ToolbarItems.Add(toolbarSettings);

            ButtonNormalMenu buttonAddContentPageUserSetting = new ButtonNormalMenu("Benutzerverwaltung");
            buttonAddContentPageUserSetting.Clicked += OnAddContentPageAddUserClicked;

            ButtonNormalMenu buttonShowEntrys = new ButtonNormalMenu("Kaffee trinken");
            buttonShowEntrys.Clicked += OnButtonAddContentPageUserSetting_Clicked;

            ScrollView scrollViewMainMenu = new ScrollView();

            StackLayout listWithUser = new StackLayout();
            listWithUser.Margin = 10;
            listWithUser.VerticalOptions = LayoutOptions.StartAndExpand;
            listWithUser.BackgroundColor = Color.FromHex("DDC9B2");

            listWithUser.Children.Add(buttonShowEntrys);
            listWithUser.Children.Add(buttonAddContentPageUserSetting);
            //listWithUser.Children.Add(watingForOpenPage);

           scrollViewMainMenu.Content = listWithUser;

            this.Content = scrollViewMainMenu;

        }

        private void ToolbarSettings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentPageUserSetting(modelCoffeeDatabase));
        }


        #region OnButtonAddContentPageUserSetting_Clicked
        /// <summary>
        /// Wenn der Button geklickt wird, dann wir die Seite, mit den Button der Kaffetrinker aufgerufen
        /// </summary>
        /// <param name="sender">Auslöser des Events</param>
        /// <param name="e">Details zum ausgelösten Event</param>
        private void OnButtonAddContentPageUserSetting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentPageAddCoffeeForUser(modelCoffeeDatabase));
        }
        #endregion

        #region OnButtonAddContentPageUserSetting_Clicked
        /// <summary>
        /// Wenn der Button geklickt wird, dann wir die Benutzerverwaltung aufgerufen
        /// </summary>
        /// <param name="sender">Auslöser des Events</param>
        /// <param name="e">Details zum ausgelösten Event</param>
        private void OnAddContentPageAddUserClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentPageUserSetting(modelCoffeeDatabase));
        }
        #endregion

    }
}
