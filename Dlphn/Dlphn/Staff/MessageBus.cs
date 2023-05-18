using System;
using System.Collections.Generic;
using System.Text;

namespace Dlphn.Staff
{
    /// <summary>
    /// Класс осуществляющий отправку сообщений через MessageCentr
    /// </summary>
    public class MessageBus
    {
        static readonly Lazy<MessageBus> LazyInstance = new Lazy<MessageBus>(() => new MessageBus(), true);
        static MessageBus Instance => LazyInstance.Value;

        MessageBus() { }

        #region Отправка событий

        /// <summary>
        /// Посыл простого сообщения на простое действие
        /// </summary>
        /// <param name="message">Имя команды</param>
        public static void SendMessage(string message)
        {
            Xamarin.Forms.MessagingCenter.Send(Instance, message);
        }

        /// <summary>
        /// Посыл сложного сообщения на сложное действие
        /// </summary>
        /// <typeparam name="TArgs"></typeparam>
        /// <param name="message">Имя команды</param>
        /// <param name="args">Входные параметры для действия</param>
        public static void SendMessage<TArgs>(string message, TArgs args)
        {
            Xamarin.Forms.MessagingCenter.Send(Instance, message, args);
        }

        #endregion
    }
}
