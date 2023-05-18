﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.MeterHistory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellMeterHistoryItem : ContentView
    {
        public CellMeterHistoryItem(mdl.MdlMeterHistoryItem data)
        {
            InitializeComponent();
            lblValue.Text = data.StrValue;
            lblDate.Text = data.StrDateTime;
        }
    }
}