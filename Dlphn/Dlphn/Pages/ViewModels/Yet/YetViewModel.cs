using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using mdl = Dlphn.Models;

using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using srvImage = Dlphn.Staff.Services.SrvImage;
using constString = Dlphn.Constants.ConstString;
using constEnums = Dlphn.Constants.ConstEnums;
using constYet = Dlphn.Constants.Yet;
using Xamarin.Forms;
using DevDH.Magic.Abstractions;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.YetPage.YetPage"/>
    public class YetViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public YetViewModel() : base(constEnums.Pages.YetPage)
        { }

        #endregion

        #region Methods

        public override async Task OnPageAppearing()
        {
            await Task.Run(() => 
            {
                dataSource.Clear();

                dataSource.Add(new mdl.MdlYetCell(constYet.str_licevoi_schet, constEnums.Pages.PersonalAccountPage, CmdGoTo));
                dataSource.Add(new mdl.MdlYetCell(constYet.str_schetchiki, constEnums.Pages.MetersPage, CmdGoTo));
                dataSource.Add(new mdl.MdlYetCell(constYet.str_tarifi, constEnums.Pages.RatesPage, CmdGoTo));
                dataSource.Add(new mdl.MdlYetCell(constYet.str_lgoti, constEnums.Pages.PrivilegesPage, CmdGoTo));
                dataSource.Add(new mdl.MdlYetCell(constYet.str_statistic, constEnums.Pages.StatisticPage, CmdGoTo));
                dataSource.Add(new mdl.MdlYetCell(constYet.str_account, constEnums.Pages.AccountPage, CmdGoTo));
                dataSource.Add(new mdl.MdlYetCell(constYet.str_contacts, constEnums.Pages.ContactsPage, CmdGoTo));                

                prtAdd2DataCollection(dataSource);
            });
        }

        public ICommand CmdGoTo => MakeCommand(async (item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            if (item is mdl.MdlYetCell data)
            {
                constEnums.Pages pages = data.Page;
                switch (pages)
                {

                    case constEnums.Pages.PersonalAccountPage:
                    case constEnums.Pages.MetersPage:
                    case constEnums.Pages.RatesPage:
                    case constEnums.Pages.AccountPage:
                        await srvNavigation.Instance.NavigateTwo(pages);
                        break;
                    default:
                        await prtShowTbdMessage();
                        break;
                }
                
            }

            IsBusy = false;
        });

        #endregion
    }
}
