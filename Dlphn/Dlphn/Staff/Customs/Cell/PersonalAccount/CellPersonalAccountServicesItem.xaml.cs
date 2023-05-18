﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.PersonalAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellPersonalAccountServicesItem : ContentView
    {
        public CellPersonalAccountServicesItem(mdl.MdlPersonalAccountServicesItem data)
        {
            InitializeComponent();

            lblServiceName.Text = data.StrServiceName;
            lblDateTime.Text = data.StrDateTime;
        }
    }
}