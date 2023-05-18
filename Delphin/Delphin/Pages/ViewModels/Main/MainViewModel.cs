using DevDH.Magic.Abstractions.Magic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mdls = Delphin.Models;
using constEnum = Delphin.Constants.ConstantEnum;
using constText = Delphin.Constants.ConstantText;
using System.Windows.Input;
using dalSrvData = Delphin.DAL.ServiceData.SrvData;
using System.Linq;

namespace Delphin.Pages.ViewModels.Main
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.Main.MainPage"/>
    public class MainViewModel : BaseViewModel
    {
        public MgcObservableCollection<object> CollectionData { get; set; }
        ICommand cmd_cell_news_actial => MakeCommand(GoToCellNewsActual);
        ICommand cmd_cell_transfer_reading => MakeNavigateToCommand(constEnum.EnumClientMobile.Pages.TransferReading, constEnum.EnumClientMobile.NavigationMode.Modal);

        public MainViewModel()
        {
            CollectionData = new MgcObservableCollection<object>();
        }

        public async override Task OnPageAppearing()
        {
            DataSource.Clear();
            CollectionData.Clear();
            string token = "";
            var var_web_data = await dalSrvData.PageMain.GetInitData(token, CancellationToken);
            if (!var_web_data.IsValid)
            { 
            }

            //mdls.MdlCellNewsHot mdlCellNewsHot = new mdls.MdlCellNewsHot(var_web_data.Data.news_hot);
            DataSource.Add(new mdls.MdlCellNewsHot(var_web_data.Data.news_hot));

            int count_news_actual = var_web_data.Data.news_latest.latestnews.Count;
            if (count_news_actual > 0)
            {
                string str_actual_news = constText.PageText.Main.lbl_cell_actual_news;
                DataSource.Add(new mdls.MdlNewsActualTitle(str_actual_news));
                string str_actual_news_btn_text = constText.PageText.Main.btn_cell_news_all;

                for (int i = 0; i < count_news_actual; i++)
                {
                    var var_item = var_web_data.Data.news_latest.latestnews[i];
                    DataSource.Add(new mdls.MdlNewsActual(var_item));
                }

                DataSource.Add(new mdls.MdlNewsActualButton(str_actual_news_btn_text, cmd_cell_news_actial));
            }
            
            //models.MdlPersonalAccount mdlPersonalAccount = new models.MdlPersonalAccount();
            //mdlPersonalAccount.str_name = "Петров Иван Сергеевич";
            //mdlPersonalAccount.str_adress = "Московская обл., Подольский р-н., пос. Дубровцы, ул. Садово-Спасская, д. 201к2, кв. 154";
            //mdlPersonalAccount.str_personal_account_value = "№ 01234567";
            //mdlPersonalAccount.str_balance_value = "134.00 ₽";
            //mdlPersonalAccount.CmdGoTo = cmd_cell_transfer_reading;

            //models.MdlPokazaniyaSchetchika mdlPokazaniyaSchetchika = new models.MdlPokazaniyaSchetchika();
            //mdlPokazaniyaSchetchika.str_water_cold = "22.31";
            //mdlPokazaniyaSchetchika.str_water_hot = "4.26";
            //mdlPokazaniyaSchetchika.str_electro_energy_t1 = "51.390 кВт/ч";
            //mdlPokazaniyaSchetchika.str_electro_energy_t2 = "18.070 кВт/ч";

            //models.MdlNewsActual mdlNewsActual = new models.MdlNewsActual();
            //mdlNewsActual.CmdGoTo = cmd_cell_news_actial;

            //CollectionData.Add(mdlPersonalAccount);
            //CollectionData.Add(mdlPokazaniyaSchetchika);
            //CollectionData.Add(mdlNewsActual);

            CollectionData.MgcReplaceRange(DataSource);

            //PageState = constEnum.EnumClientMobile.PageState.Normal;
        }

        void GoToCellNewsActual()
        {
            string str_go_to = constEnum.EnumClientMobile.Pages.News.ToString();
            Action_function(str_go_to);

            constEnum.EnumClientMobile.Pages pageTo = constEnum.EnumClientMobile.Pages.News;
            int index = GetTabSelected(pageTo);
            NavigateTo(pageTo, NavigationParams, mode: constEnum.EnumClientMobile.NavigationMode.TabbedChange, ActiveTabIndex: index);
        }

        void GoToCellTransferReading()

        {
            string str_go_to = constEnum.EnumClientMobile.Pages.News.ToString();
            Action_function(str_go_to);
        }
    }
}
