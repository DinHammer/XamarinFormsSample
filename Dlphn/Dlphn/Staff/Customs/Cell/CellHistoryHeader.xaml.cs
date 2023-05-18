﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellHistoryHeader : ContentView
    {
        public CellHistoryHeader(mdl.MdlHistoryHeader data)
        {
            InitializeComponent();

            lblDate.Text = data.strText;
        }
    }
}