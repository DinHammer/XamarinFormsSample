using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Dlphn.Staff.Customs.Controls
{
    public class MgcFrame : Frame
    {
        public static new readonly BindableProperty CornerRadiusProperty = 
            BindableProperty.Create(
                nameof(MgcFrame), 
                typeof(CornerRadius), 
                typeof(MgcFrame));

        public MgcFrame()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
