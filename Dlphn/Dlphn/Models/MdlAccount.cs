using System;
using System.Collections.Generic;
using System.Text;
using smpTools = Dlphn.Staff.SimpleTools;
using constString = Dlphn.Constants.ConstString;
using srvImage = Dlphn.Staff.Services.SrvImage;
using Xamarin.Forms;
using System.Windows.Input;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Dlphn.Models
{
    public class MdlAccountItem
    {
        public string StrNameFull { get; private set; }
        public string StrPhone { get; private set; }
        public string StrEmail { get; private set; }
        public string StrPasportNumber { get; private set; }
        public string StrSnils { get; private set; }
        public ICommand Cmd { get; private set; }

        public MdlAccountItem()
        {
            this.StrNameFull = "Петров Иван Сергеевич";
            this.StrPhone = "+7 (999) 123-45-67";
            this.StrEmail = "petrov@domain.com";
            this.StrPasportNumber = "Не указано";
            this.StrSnils= "Не указано";
        }
        public MdlAccountItem(ICommand cmd) : this()
        {
            this.Cmd = cmd;
        }
    }

    public class MdlAccountChangePassword
    {
        public ICommand Cmd { get; private set; }

        public MdlAccountChangePassword(ICommand cmd)
        {
            this.Cmd = cmd;
        }
    }
}
