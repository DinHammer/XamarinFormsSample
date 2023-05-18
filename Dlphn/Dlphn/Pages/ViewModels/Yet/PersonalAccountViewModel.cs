using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.PersonalAccountPage.PersonalAccountPage"/>
    public class PersonalAccountViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public PersonalAccountViewModel() : base(constEnum.Pages.PersonalAccountPage)
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

            var vKvLsDetail = await dalWebApi.Kv.GetKvLsDetail(objKvIn, cancellationToken);
            if (!vKvLsDetail.IsValid)
            {
            }

            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlPersonalAccountItem());
            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlPersonalAccountFlat());
            dataSource.Add(new mdl.MdlPersonalAccountRegisterResidentHeader());
            dataSource.Add(new mdl.MdlPersonalAccountRegisterResidentItem());
            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlPersonalAccountServicesHeader());
            dataSource.Add(new mdl.MdlPersonalAccountServicesItem());

            dataCollection.MgcReplaceRange(dataSource);
        }

        #endregion
    }
}
