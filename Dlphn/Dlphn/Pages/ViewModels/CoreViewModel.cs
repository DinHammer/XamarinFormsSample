using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using mdls = Dlphn.Models;
using msgBus = Dlphn.Staff.MessageBus;
using constMessageCenter = Dlphn.Constants.ConstString.ClientMessageCenter;

namespace Dlphn.Pages.ViewModels
{
    public class CoreViewModel : BaseBindable
    {
        readonly CancellationTokenSource _networkTokenSource = new CancellationTokenSource();
        readonly ConcurrentDictionary<string, ICommand> _cachedCommands = new ConcurrentDictionary<string, ICommand>();
        protected readonly IList<object> dataSource;

        public CoreViewModel()
        {
            dataSource = new List<object>();
        }

        #region Commands
        protected ICommand MakeCommand(Action commandAction, [CallerMemberName] string propertyName = null)
        {
            return GetCommand(propertyName) ?? SaveCommand(new Command(commandAction), propertyName);
        }

        protected ICommand MakeCommand(Action<object> commandAction, [CallerMemberName] string propertyName = null)
        {
            return GetCommand(propertyName) ?? SaveCommand(new Command(commandAction), propertyName);
        }

        ICommand SaveCommand(ICommand command, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (!_cachedCommands.ContainsKey(propertyName))
            {
                _cachedCommands.TryAdd(propertyName, command);
            }

            return command;
        }

        ICommand GetCommand(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            return _cachedCommands.TryGetValue(propertyName, out var cachedCommand)
                ? cachedCommand
                : null;
        }

        #endregion

        public CancellationToken cancellationToken => _networkTokenSource?.Token ?? CancellationToken.None;

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => Get(_isBusy);
            set => Set(value);
        }

        public virtual Task OnPageAppearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task OnPageDisappearing()
        {
            return Task.FromResult(0);
        }

        #region ShowDialog                        

        protected static Task ShowAlert(string title, string message, string cancel)
        {
            var tcs = new TaskCompletionSource<bool>();
            msgBus.SendMessage(constMessageCenter.DialogAlertMessage,
                new mdls.DialogAlertInfo
                {
                    Title = title,
                    Message = message,
                    Cancel = cancel,
                    OnCompleted = () => tcs.SetResult(true)
                });
            return tcs.Task;
        }

        protected static Task<string> ShowSheet(string title, string cancel, string destruction, string[] items)
        {
            var tcs = new TaskCompletionSource<string>();
            msgBus.SendMessage(constMessageCenter.DialogSheetMessage,
                new mdls.DialogSheetInfo
                {
                    Title = title,
                    Cancel = cancel,
                    Destruction = destruction,
                    Items = items,
                    OnCompleted = s => tcs.SetResult(s)
                });
            return tcs.Task;
        }

        protected static Task<bool> ShowQuestion(string title, string question, string positive, string negative)
        {
            var tcs = new TaskCompletionSource<bool>();
            msgBus.SendMessage(constMessageCenter.DialogQuestionMessage,
                new mdls.DialogQuestionInfo
                {
                    Title = title,
                    Question = question,
                    Positive = positive,
                    Negative = negative,
                    OnCompleted = b => tcs.SetResult(b)
                });
            return tcs.Task;
        }

        protected static Task<string> ShowEntryAlert(string title, string message, string cancel, string ok, string placeholder)
        {
            var tcs = new TaskCompletionSource<string>();
            msgBus.SendMessage(constMessageCenter.DialogEntryMessage,
                new mdls.DialogEntryInfo
                {
                    Title = title,
                    Message = message,
                    Cancel = cancel,
                    Ok = ok,
                    Placeholder = placeholder,
                    OnCompleted = s => tcs.SetResult(s),
                    OnCancelled = () => tcs.SetResult(null)
                });
            return tcs.Task;
        }

        protected static void ShowToast(string text, bool isLongTime = false, bool isCenter = false)
        {
            msgBus.SendMessage(constMessageCenter.DialogToastMessage,
                new mdls.DialogToastInfo
                {
                    Text = text,
                    IsCenter = isCenter,
                    IsLongTime = isLongTime
                });
        }
        #endregion
    }
}
