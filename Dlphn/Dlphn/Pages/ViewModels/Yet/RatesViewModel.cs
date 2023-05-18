using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using constEnums = Dlphn.Constants.ConstEnums;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.RatesPage.RatesPage"/>
    public class RatesViewModel : BaseViewModel 
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public RatesViewModel() : base(constEnums.Pages.RatesPage)
        { }

        #endregion

        #region Methods

        public override async Task OnPageAppearing()
        {
            dataSource.Clear();

            var vPersonalData = await prtGetPersonalData();
            if (!vPersonalData.IsValid)
            {
                return;
            }

            string strToken = vPersonalData.Data.StrToken;
            string strAccountId = vPersonalData.Data.StrAccountId;

            dtObj.ObjKvIn objKvIn = new dtObj.ObjKvIn(strToken, strAccountId);

            var vKvTarif = await dalWebApi.Kv.GetKvTarif(objKvIn, cancellationToken);
            if (!vKvTarif.IsValid)
            { }

            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlRatesTitle());
            dataSource.Add(new mdl.MdlRatesItem(CmdAction));
            dataSource.Add(new mdl.MdlRatesValue());

            dataCollection.MgcReplaceRange(dataSource);
        }

        public ICommand CmdAction => MakeCommand((item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            prtShowTbdMessage();

            IsBusy = false;
        });

        #endregion
    }
}
