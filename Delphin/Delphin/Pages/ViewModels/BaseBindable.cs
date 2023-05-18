using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Delphin.Abstraction;

namespace Delphin.Pages.ViewModels
{    
    public class BaseBindable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        readonly ConcurrentDictionary<string, object> _properties = new ConcurrentDictionary<string, object>();

        protected bool CallPropertyChangeEvent { get; set; } = true;

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

                
        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region PropertyChanging

        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        #endregion

        /// <summary>
        /// Получение данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defValue"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T Get<T>(T defValue = default(T), [CallerMemberName] string name = null)
        {

            if (string.IsNullOrEmpty(name))
            {
                return defValue;
            }

            if (_properties.TryGetValue(name, out var value))
            {
                return (T)value;
            }

            _properties.AddOrUpdate(name, defValue, (s, o) => defValue);

            return defValue;

            //if (!string.IsNullOrEmpty(name) && _properties.TryGetValue(name, out var value))
            //{
            //    return (T)value;
            //}
            //else
            //{
            //    return defValue;
            //}
        }

        /// <summary>
        /// Присвоение данных
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected bool Set(object value, [CallerMemberName] string name = null)
        {
            if (string.IsNullOrEmpty(name)) { return false; }

            var isExists = _properties.TryGetValue(name, out var getValue);

            if (isExists && Equals(value, getValue)) { return false; }

            if (CallPropertyChangeEvent) { OnPropertyChanging(name); }

            _properties.AddOrUpdate(name, value, (s, o) => value);

            if (CallPropertyChangeEvent) { OnPropertyChanged(name); }

            return true;
        }
    }
}
