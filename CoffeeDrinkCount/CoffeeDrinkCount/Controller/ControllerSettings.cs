using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeeDrinkCount.Model;
using CoffeeDrinkCount.UI_Elements;

namespace CoffeeDrinkCount.Controller
{
    // The Icontroller supports only one functionality that is to increment the value
    public interface IController
    {
        void openContentPageAddUser();
    }


    //public class ControllerSettings : IController
    //{
    //    IViewUserSetting view;
    //    IModel model;
    //    // The controller which implements the IController interface ties the view and model 
    //    // together and attaches the view via the IModelInterface and addes the event
    //    // handler to the view_changed function. The view ties the controller to itself.
    //    public ControllerSettings(IViewUserSetting v, IModel m)
    //    {
    //        view = v;
    //        model = m;
    //        view.setController(this);
    //        model.attach((IModelObserver)view);
    //        view.changed += new ViewUserSettingHandler<IViewUserSetting>(this.view_changed);
    //    }
    //    // event which gets fired from the view when the users changes the value
    //    public void view_changed(IViewUserSetting v, ViewEventUserSettingArgs e)
    //    {
    //        model.setvalue(e.value);
    //    }
    //    // This does the actual work of getting the model do the work
    //    public void openContentPageAddUser()
    //    {
    //        //Navigation.PushAsync(new ContentPageAddNewUser(coffeedatabase));
    //    }
    //}

}
