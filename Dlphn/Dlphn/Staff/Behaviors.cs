using Xamarin.Forms;

namespace Dlphn.Staff.Behaviors
{
    public class EntryPhone : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            long result;
            string str_text = args.NewTextValue;
            if (string.IsNullOrEmpty(str_text))
            {
                return;
            }
            int int_count = str_text.Length;
            if (int_count < 1)
            {
                ((Entry)sender).Text = "+";
            }

            //bool isValid = double.TryParse(args.NewTextValue, out result);
            bool isValid = long.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.FromHex("#c1b5a7") : Color.Red;
        }
    }
}
