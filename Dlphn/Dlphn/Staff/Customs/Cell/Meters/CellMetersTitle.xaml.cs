﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.Meters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellMetersTitle : ContentView
    {
        public CellMetersTitle(mdl.MdlMetersTitle data)
        {
            InitializeComponent();
        }
    }
}