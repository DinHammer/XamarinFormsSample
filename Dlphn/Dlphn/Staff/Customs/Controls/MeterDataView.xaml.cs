using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dlphn.Staff.Customs.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeterDataView : ContentView
    {
        public static readonly BindableProperty TextEntryProperty =
            BindableProperty.Create(nameof(TextEntry),
                returnType: typeof(string),
                declaringType: typeof(MeterDataView),
                defaultValue: default(string),
                defaultBindingMode: BindingMode.TwoWay);

        public string TextEntry
        {
            get => (string)GetValue(TextEntryProperty);
            set => SetValue(TextEntryProperty, value);
        }


        public MeterDataView()
        {
            InitializeComponent();

            entry.TextChanged += Entry_TextChanged;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextEntry = e.NewTextValue;
           
        }

        
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextEntryProperty.PropertyName)
            {
                entry.Text = TextEntry;
            }
        }

    }
}