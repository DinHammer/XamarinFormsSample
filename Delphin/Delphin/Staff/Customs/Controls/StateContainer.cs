﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Delphin.Staff.Customs.Controls
{
    [ContentProperty("Conditions")]
    public class StateContainer : ContentView
    {
        public List<StateCondition> Conditions { get; set; } = new List<StateCondition>();

        public static readonly BindableProperty PropertyState = BindableProperty.Create(nameof(State), typeof(object), typeof(StateContainer), null, BindingMode.Default, null, StateChanged);
        public object State
        {
            get { return GetValue(PropertyState); }
            set { SetValue(PropertyState, value); }
        }

        public static void Init()
        {
            //for linker
        }

        private static async void StateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as StateContainer;
            if (parent != null)
            {
                await parent.ChooseStateProperty(newValue);
            }
        }

        private async Task ChooseStateProperty(object newValue)
        {
            if (Conditions == null && Conditions?.Count == 0) return;

            try
            {
                foreach (var stateCondition in Conditions.Where(stateCondition => stateCondition.State != null && stateCondition.State.ToString().Equals(newValue.ToString())))
                {
                    if (Content != null)
                    {
                        await Content.FadeTo(0, 100U); //быстрая анимация скрытия
                        Content.IsVisible = false; //Полностью скрываем с экрана старое состояние
                        await Task.Delay(30); //Позволяем UI-потоку отработать свою очередь сообщений и гарантировано скрыть предыдущее состояние
                    }

                    // Плавно показываем новое состояние   
                    // Плавно показываем новое состояние   
                    stateCondition.Content.Opacity = 0;
                    Content = stateCondition.Content;
                    Content.IsVisible = true;
                    await Content.FadeTo(1);

                    break;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"StateContainer ChooseStateProperty {newValue} error: {e}");
            }
        }
    }

    [ContentProperty("Content")]
    public class StateCondition : View
    {
        public object State { get; set; }
        public View Content { get; set; }
    }
}
