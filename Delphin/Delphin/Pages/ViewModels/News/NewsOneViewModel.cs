using DevDH.Magic.Abstractions.Magic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using constText = Delphin.Constants.ConstantText;
using mdls = Delphin.Models;

namespace Delphin.Pages.ViewModels.News
{
    /// <see cref="Delphin.Pages.Views.News.NewsOnePage">
    public class NewsOneViewModel: BaseViewModel
    {
        public MgcObservableCollection<object> CollectionData { get; set; }

        public NewsOneViewModel()
        {
            CollectionData = new MgcObservableCollection<object>();
        }
        public override async Task OnPageAppearing()
        {
            DataSource.Clear();
            var mdlNewsBody = NavigationParams[constText.KeyNavigation.keySelectedNews] as mdls.MdlNewsHeader;
            if (mdlNewsBody == null)
            {
                return;
            }

            mdls.MdlNewsHeader mdlNewsHeader = new mdls.MdlNewsHeader(mdlNewsBody.GetContent());

            DataSource.Add(mdlNewsHeader);

            CollectionData.MgcReplaceRange(DataSource);

        }

        public ICommand cmd_go_back => MakeCommand(() =>
          {
              NavigateBack(mode: Constants.ConstantEnum.EnumClientMobile.NavigationMode.Modal);
          });
    }
}
