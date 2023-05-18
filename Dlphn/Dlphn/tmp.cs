
#region Fields
#endregion

#region Properties
#endregion

#region Constructors
#endregion

#region Methods
#endregion

using dtTemplate = Dlphn.Staff.DataTemplates;
using viewModels = Dlphn.Pages.ViewModels;
using mdl = Dlphn.Models;
using constString = Dlphn.Constants.ConstString;
using constEnums = Dlphn.Constants.ConstEnums;

//xmlns:constString ="clr-namespace:Dlphn.Constants"

using srvAuth = Dlphn.Staff.Services.SrvAuth;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using srvImage = Dlphn.Staff.Services.SrvImage;

using smpTools = Dlphn.Staff.SimpleTools;



using Xamarin.Forms;

class TemplateSelector : DataTemplateSelector
{
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is mdl.MdlError mdlError)
        {
            return new dtTemplate.DtError(mdlError);
        }
        else
        {
            return new dtTemplate.DtEmpty();
        }
    }
}


/*#region OnPageAction

Dlphn.Pages.ViewModels.BaseViewModel baseViewModel => BindingContext as Dlphn.Pages.ViewModels.BaseViewModel;

protected override void OnAppearing()
{
    base.OnAppearing();
    Task.Run(async () =>
    {
        await Task.Delay(Dlphn.Constants.ConstNumeric.event_handler_loop);
        if (baseViewModel != null)
        {
            await baseViewModel.OnPageAppearing();
        }
    });
}

protected override void OnDisappearing()
{
    base.OnDisappearing();
    Task.Run(async () =>
    {
        await Task.Delay(Dlphn.Constants.ConstNumeric.event_handler_loop);
        if (baseViewModel != null)
        {
            await baseViewModel.OnPageDisappearing();
        }
    });
}

#endregion*/