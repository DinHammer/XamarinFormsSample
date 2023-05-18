using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using constEnum = Delphin.Constants.ConstantEnum;
using srvImage = Delphin.Staff.Services.ServiceImage;
using dalDataObject = Delphin.Abstraction.DataObjects;
using System.Linq;

namespace Delphin.Models
{
    public class MdlNewsTitle
    {
        public MdlNewsTitle() { }
        public MdlNewsTitle(string str)
        {
            this.str = str;
        }
        public string str { get; set; }
    }
    public class MdlNewsHeader
    {
        dalDataObject.ObjectNews objectNews { get; set; }
        public MdlNewsHeader() { }
        public MdlNewsHeader(dalDataObject.ObjectNews objectNews)
        {
            this.objectNews = objectNews;
        }
        public MdlNewsHeader(dalDataObject.ObjectNews objectNews, ICommand cmd_go_to) : this(objectNews)
        {
            this.cmd_go_to = cmd_go_to;
        }
        public ICommand cmd_go_to { get; set; }
        public string str_title => objectNews.date_pub.ToString("dd MMMM yyyy");
        public string str_body => objectNews.body;

        public dalDataObject.ObjectNews GetContent()
        {
            return objectNews;
        }
    }

    public class MdlCellNewsHot
    {
        dalDataObject.ObjectNews objectNews { get; set; }
        public MdlCellNewsHot() { }        
        public MdlCellNewsHot(dalDataObject.ObjectNews objectNews)
        {
            this.objectNews = objectNews;
        }
        public MdlCellNewsHot(dalDataObject.ObjNewsHotOut objectNewsHotData) : this(objectNewsHotData.hotnews.First()) { }
        public string str => objectNews.body;
    }

    public class MdlYetCell
    {
        public MdlYetCell() { }
        public MdlYetCell(string str, constEnum.EnumClientMobile.Pages pages, ICommand cmd_tap)
        {
            this.str = str;
            this.cmd_tap = cmd_tap;
            this.pages = pages;
            this.imageSource = srvImage.Instance.GetYetIcon(pages);
        }
        public string str { get; set; }
        public ICommand cmd_tap { get; set; }
        public ImageSource imageSource { get; set; }
        public constEnum.EnumClientMobile.Pages pages { get; set; }
    }
    public class MdlPersonalAccount
    {
        public string str_name { get; set; }
        public string str_adress { get; set; }
        public string str_personal_account_value { get; set; }
        public string str_balance_value { get; set; }

        public ICommand CmdGoTo { get; set; }
    }

    public class MdlPokazaniyaSchetchika
    {
        public string str_data { get; set; }
        public string str_water_cold { get; set; }
        public string str_water_hot { get; set; }
        public string str_electro_energy_t1 { get; set; }
        public string str_electro_energy_t2 { get; set; }
    }

    public class MdlNewsActualTitle
    {
        public MdlNewsActualTitle() { }
        public MdlNewsActualTitle(string str_title) 
        {
            this.str_title = str_title;
        }
        public string str_title { get; set; }
    }
    
    public class MdlNewsActualButton
    {
        public MdlNewsActualButton() { }
        public MdlNewsActualButton(string str_btn_text, ICommand cmd_go_to) 
        {
            this.str_btn_text = str_btn_text;
            this.cmd_go_to = cmd_go_to;
        }
        public string str_btn_text { get; set; }
        public ICommand cmd_go_to { get; set; }
    }
    public class MdlNewsActual
    {
        dalDataObject.ObjectNews objectNews { get; set; }
        public MdlNewsActual() { }
        public MdlNewsActual(dalDataObject.ObjectNews objectNews)
        {
            this.objectNews = objectNews;
        }
        public string str_title => objectNews.date_pub.ToString("dd.MMMM.yyyy");
        public string str_body => objectNews.body;
    }

    public class MdlNews
    {
        public string str_text { get; set; }
        public string str_date { get; set; }
    }

    
}
