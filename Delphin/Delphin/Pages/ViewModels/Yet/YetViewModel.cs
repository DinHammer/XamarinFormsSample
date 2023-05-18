using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using constEnum = Delphin.Constants.ConstantEnum;
using mdls = Delphin.Models;
using constTextPage = Delphin.Constants.ConstantText.PageText;
using srvImage = Delphin.Staff.Services.ServiceImage;

namespace Delphin.Pages.ViewModels.Yet
{
    /// <see cref="Delphin.Pages.Views.Yet.YetPage">
    public class YetViewModel : BaseViewModel
    {
        public YetViewModel()
        {
            PageDataCollection = new DevDH.Magic.Abstractions.Magic.MgcObservableCollection<object>();
        }
        public override async Task OnPageAppearing()
        {
            await Task.Run(() =>
            {
                DataSource.Clear();                
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_licevoi_schet, constEnum.EnumClientMobile.Pages.PersonalAccount, cmd_tap));
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_chetchiki, constEnum.EnumClientMobile.Pages.Counters, cmd_tap));
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_tarifi, constEnum.EnumClientMobile.Pages.Rates, cmd_tap));
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_lgoti, constEnum.EnumClientMobile.Pages.Privileges, cmd_tap));
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_statistics, constEnum.EnumClientMobile.Pages.Statistics, cmd_tap));
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_account, constEnum.EnumClientMobile.Pages.Account, cmd_tap));
                DataSource.Add(new mdls.MdlYetCell(constTextPage.Yet.lbl_contacts, constEnum.EnumClientMobile.Pages.Contacts, cmd_tap));

                PageDataCollection.MgcReplaceRange(DataSource);
                DataSource.Clear();
            });
        }

        ICommand cmd_tap => MakeCommand((item)=> 
        {
            var var_item = item as mdls.MdlYetCell;
            if (var_item == null)
            {
                return;
            }

            NavigateTo(
                toName: var_item.pages,
                mode: constEnum.EnumClientMobile.NavigationMode.Modal);                        
        });

        //void NavigateToTmp(constEnum.EnumClientMobile.Pages pages)
        //{
        //    NavigateTo(
        //        toName: pages,
        //        mode: constEnum.EnumClientMobile.NavigationMode.Modal);

        //    //ShowAlert(title: "Уважаемый", message: $"Хочешь перейти ты на страницу: {pages.ToString()}",cancel: "Нет");
        //    //NavigateTo(pages, mode: constEnum.EnumClientMobile.NavigationMode.Modal);
        //    //NavigateTo(pages);
        //}

        //public ICommand CmdGoToPersonalAccount => MakeMenuCommand(constEnum.EnumClientMobile.Pages.PersonalAccount);
        //public ICommand CmdGoToCounters => MakeMenuCommand(constEnum.EnumClientMobile.Pages.Counters);
        //public ICommand CmdGoToRates => MakeMenuCommand(constEnum.EnumClientMobile.Pages.Rates);
        //public ICommand CmdGoToPrivileges => MakeMenuCommand(constEnum.EnumClientMobile.Pages.Privileges);
        //public ICommand CmdGoToStatistics => MakeMenuCommand(constEnum.EnumClientMobile.Pages.Statistics);
        //public ICommand CmdGoToAccount => MakeMenuCommand(constEnum.EnumClientMobile.Pages.Account);
        //public ICommand CmdGoToContacs => MakeMenuCommand(constEnum.EnumClientMobile.Pages.Contacts);

        //static ICommand MakeMenuCommand(object page)
        //{
        //    return MakeNavigateToCommand(page, constEnum.EnumClientMobile.NavigationMode.Modal);
        //}
    }
}
