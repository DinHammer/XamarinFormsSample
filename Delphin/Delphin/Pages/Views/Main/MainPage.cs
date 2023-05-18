using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using viewModel = Delphin.Pages.ViewModels.Main;
using customControls = Delphin.Staff.Customs.Controls;
using customView = Delphin.Staff.Customs.Views;
using customCell = Delphin.Staff.Customs.Cells;
using constEnum = Delphin.Constants.ConstantEnum;
using constText = Delphin.Constants.ConstantText;
using mdls = Delphin.Models;
using stylePage = Delphin.Staff.Styles.StylePage;

namespace Delphin.Pages.Views.Main
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.ViewModels.Main.MainViewModel"/>
    public class MainPage : BasePage
    {
        viewModel.MainViewModel viewModel;
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //var tabbedpage = Application.Current.MainPage as customControls.MagicTabbedPage;
            //tabbedpage?.eventTabChange
            //if (tabbedpage != null)
            //{
            //    tabbedpage.CurrentPageChanged += Tabbedpage_CurrentPageChanged;
            //}

            //Application.Current.MainPage.SetBinding(customControls.MagicTabbedPage.PropertyCommandTabChange, nameof(viewModel.CommndChangedTab));
            //this.SetBinding(customControls.MagicTabbedPage.PropertyCommandTabChange, nameof(viewModel.CommndChangedTab));

            viewModel = this.BindingContext as viewModel.MainViewModel;

            double myWidth = prtcGetWidth();
            double myHeight = prtcGetHeight();

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(viewModel.CollectionData));
            collectionView.ItemTemplate = new TemplateSelector(myWidth, myHeight);
            collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
            collectionView.EmptyView = constText.PageText.lbl_text_downloading;
            collectionView.Style = stylePage.stcCollectionView;

            //customControls.StateContainer stateContainer = new customControls.StateContainer();
            //stateContainer.SetBinding(customControls.StateContainer.PropertyState, nameof(viewModel.PageState));
            //stateContainer.Conditions.Add(new customControls.StateCondition { State = constEnum.EnumClientMobile.PageState.Loading, Content = new customView.MagicLoading() });
            //stateContainer.Conditions.Add(new customControls.StateCondition { State = constEnum.EnumClientMobile.PageState.Normal, Content = collectionView });
            //stateContainer.Conditions.Add(new customControls.StateCondition { State = constEnum.EnumClientMobile.PageState.Error, Content = new customView.MagicError() });

            this.Content = collectionView;
            //this.BackgroundColor = Color.FromHex("#E5E5E5");
            this.Style = stylePage.stlView;
        }
        

        class TemplateSelector : DataTemplateSelector
        {
            double width { get; set; }
            double height { get; set; }            
            public TemplateSelector(double width, double height)
            {
                this.width = width;
                this.height = height;
            }
            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {

                if (item is mdls.MdlNewsActualTitle mdlNewsActualTitle)
                {
                    return new DtNewsActualTitle(width, height, mdlNewsActualTitle);
                }
                else if (item is mdls.MdlNewsActual mdlNewsActual)
                {
                    return new DtNewsActual(width, height, mdlNewsActual);
                }
                else if (item is mdls.MdlNewsActualButton mdlNewsActualButton)
                {
                    return new DtNewsActualButton(width, height, mdlNewsActualButton);
                }
                else if (item is mdls.MdlCellNewsHot mdlCellNewsHot)
                {
                    return new DtNewsHot(width, height, mdlCellNewsHot);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
                
            }

            class DtNewsHot : DataTemplate
            {
                public DtNewsHot(double width, double height, mdls.MdlCellNewsHot data)
                    : base(() => CreateView(width, height, data)) { }
                static View CreateView(double width, double height, mdls.MdlCellNewsHot data)
                {
                    double my_width = width;
                    double my_height = height;                    
                    customCell.CellNewsHot cell =  new customCell.CellNewsHot(my_width, my_height);
                    cell.lbl.Text = data.str;
                    return cell;
                }
            }

            //class DtPersonalAccount : DataTemplate
            //{
            //    public DtPersonalAccount(double width, double height, mdls.MdlPersonalAccount data)
            //        : base(() => CreateView(width, height, data)) { }

            //    static View CreateView(double width, double height, mdls.MdlPersonalAccount data)
            //    {
            //        double my_height = height * 1 / 3;

            //        customCell.CellPersonalAccount cell = new customCell.CellPersonalAccount(width, my_height);
            //        cell.btnTrnasferEvedance.Command = data.CmdGoTo;
            //        cell.BindingContext = data;
            //        return cell;
            //    }
            //}

            //class DtPokazaniyaSchetchika : DataTemplate
            //{
            //    public DtPokazaniyaSchetchika(double width, double height, mdls.MdlPokazaniyaSchetchika data)
            //        : base(() => CreateView(width, height, data)) { }
            //    static View CreateView(double width, double height, mdls.MdlPokazaniyaSchetchika data)
            //    {
            //        double my_height = height * 1 / 3;
            //        customCell.CellPokazaniyaSchetchika cell = new customCell.CellPokazaniyaSchetchika(width, my_height);
            //        cell.lblData.Text = data.str_data;
            //        cell.lblValueWaterHot.Text = data.str_water_hot;
            //        cell.lblValueWaterCold.Text = data.str_water_cold;
            //        cell.lblValueElectroEnergyT1.Text = data.str_electro_energy_t1;
            //        cell.lblValueElectroEnergyT2.Text = data.str_electro_energy_t2;

            //        return cell;
            //    }
            //}
            class DtNewsActualTitle : DataTemplate
            {
                public DtNewsActualTitle(double width, double height, mdls.MdlNewsActualTitle data)
                    : base(() => CreateView(width, height, data)) { }

                static View CreateView(double width, double height, mdls.MdlNewsActualTitle data)
                {
                    double my_width = width;
                    double my_height = height;

                    customCell.CellActialNewsTitle cell = new customCell.CellActialNewsTitle(my_width, my_height);
                    cell.lbl.Text = data.str_title;                    

                    return cell;
                }
            }
            class DtNewsActual : DataTemplate
            {
                public DtNewsActual(double width, double height, mdls.MdlNewsActual data)
                    : base(() => CreateView(width, height, data)){}

                static View CreateView(double width, double height, mdls.MdlNewsActual data)
                {
                    double my_width = width;
                    double my_height = height;
                    customCell.CellActualNews cell = new customCell.CellActualNews(my_width, my_height);
                    cell.lblTitle.Text = data.str_title;
                    cell.lblBody.Text = data.str_body;

                    return cell;
                }
            }
            class DtNewsActualButton : DataTemplate
            {
                public DtNewsActualButton(double width, double height, mdls.MdlNewsActualButton data)
                    : base(() => CreateView(width, height, data)) { }

                static View CreateView(double width, double height, mdls.MdlNewsActualButton data)
                {
                    double my_width = width;
                    double my_height = height;
                    customCell.CellActualButton cell = new customCell.CellActualButton(my_width, my_height);
                    cell.btn.Command = data.cmd_go_to;
                    cell.btn.Text = data.str_btn_text;
                    //cell.btnGoTo.Command = data.CmdGoTo;

                    return cell;
                }
            }
        }
    }
}
