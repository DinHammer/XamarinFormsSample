using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using constEnum = Dlphn.Constants.ConstEnums;
using srvAppCenter = Dlphn.Staff.Services.SrvAppCenter;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Dlphn.Pages.ViewModels.Tmp
{

    /// <see cref="Dlphn.Pages.Views.Tmp.TmpPage.TmpPage"/>
    public class TmpViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public TmpViewModel() : base(constEnum.Pages.TmpPage)
        {
            
        }
        #endregion

        #region Methods

        public ICommand CmdBtn1 => MakeCommand(async () =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            

            var vOut = await dalWebApi.Test.GetTestOut1(new dtObj.ObjTestIn(), cancellationToken);
            prtTrackError(
                nameof(CmdBtn1),
                nameof(dalWebApi.Test.GetTestOut1),
                vOut);
            

            //srvAppCenter.Instance.TrackEvent("ololoPishPish");

            //await srvNavigation.Instance.NavigateTwo(Constants.ConstEnums.Pages.SendMetersPage);

            IsBusy = false;
        });

        public ICommand CmdBtn2 => MakeCommand( async() =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            

            //srvAppCenter.Instance.TrackError("pishPish", "page", "tmpPage");
            var vOut = await dalWebApi.Test.GetTestOut2(new dtObj.ObjTestIn(), cancellationToken);
            prtTrackError(
                nameof(CmdBtn2),
                nameof(dalWebApi.Test.GetTestOut2),
                vOut);

            //await srvNavigation.Instance.NavigateTwo(Constants.ConstEnums.Pages.SendMetersPage);

            IsBusy = false;
        });

        #endregion
    }
}
