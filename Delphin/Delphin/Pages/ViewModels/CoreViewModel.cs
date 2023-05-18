using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials; //
using Plugin.Connectivity;

using constantText = Delphin.Constants.ConstantText;
using constMessageCenter = Delphin.Constants.ConstantText.ClientMessageCenter;
using ConstantEnums = Delphin.Constants.ConstantEnum;
using constEnumClient = Delphin.Constants.ConstantEnum.EnumClientMobile;
using services = Delphin.Staff.Services;

namespace Delphin.Pages.ViewModels
{
    public class CoreViewModel : BaseBindable
    {
        readonly CancellationTokenSource _networkTokenSource = new CancellationTokenSource();
        readonly ConcurrentDictionary<string, ICommand> _cachedCommands = new ConcurrentDictionary<string, ICommand>();

        public string str_page_name { get; set; }

        public CoreViewModel()
        {
            //if (NavigationParams == null)
            //{
            //    NavigationParams = new Dictionary<string, object>();
            //}
        }

        public Dictionary<string, object> NavigationParams
        {
            get => Get<Dictionary<string, object>>();
            private set
            {
                Set(value);
                OnSetNavigationParams(value ?? new Dictionary<string, object>());
            }
        }

        public constEnumClient.PageState State
        {
            get => Get(constEnumClient.PageState.Loading);
            set => Set(value);
        }

        public bool IsLoadDataStarted
        {
            get => Get<bool>();
            protected internal set => Set(value);
        }

        public bool IsConnected => !CrossConnectivity.IsSupported || CrossConnectivity.IsSupported && CrossConnectivity.Current.IsConnected;
        public CancellationToken CancellationToken => _networkTokenSource?.Token ?? CancellationToken.None;

        public ICommand GoBackCommand => MakeCommand(GoBackCommandExecute);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~CoreViewModel()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            ClearDialogs();
            CancelNetworkRequests();
        }

        public void SetNavigationParams(Dictionary<string, object> navParams)
        {
            NavigationParams = navParams;
        }

        public void CancelNetworkRequests()
        {
            _networkTokenSource.Cancel();
        }

        public virtual Task OnPageAppearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task OnPageDisappearing()
        {
            return Task.FromResult(0);
        }

        public void StartLoadData()
        {
            if (IsLoadDataStarted) return;
            IsLoadDataStarted = true;

            Task.Run(LoadDataAsync, CancellationToken);
        }

        //override this method for load data
        protected virtual Task LoadDataAsync()
        {
            return Task.FromResult(0);
        }

        //override this method for sets viewmodel properties before page appearing
        public virtual void OnSetNavigationParams(Dictionary<string, object> navigationParams)
        {
            // do nothing
        }

        protected static Task<bool> NavigateTo(object toName,
            object fromName = null,
            //constEnumClient.NavigationMode mode = constEnumClient.NavigationMode.Normal,
            constEnumClient.NavigationMode mode = constEnumClient.NavigationMode.Tabbed,
            string toTitle = null,
            Dictionary<string, object> navParams = null,
            bool newNavigationStack = false,
            bool withAnimation = true,
            bool withBackButton = false,
            int ActiveTabIndex = 0)
        {

            services.MessageBus.SendMessage(constMessageCenter.DialogHideLoadingMessage);

            var completedTask = new TaskCompletionSource<bool>();
            services.MessageBus.SendMessage(constMessageCenter.NavigationPushMessage,
                new services.NavigationPushInfo
                {
                    To = toName.ToString(),
                    From = fromName?.ToString(),
                    Mode = mode,
                    NavigationParams = navParams,
                    NewNavigationStack = newNavigationStack,
                    OnCompletedTask = completedTask,
                    ActivTabIndex=ActiveTabIndex
                });
            return completedTask.Task;
        }

        protected static ICommand MakeNavigateToCommand(object toName,
            constEnumClient.NavigationMode mode = constEnumClient.NavigationMode.Normal,
            string toTitle = null,
            bool newNavigationStack = false,
            bool withAnimation = true,
            bool withBackButton = true,
            Dictionary<string, object> navParams = null)
        {
            return new Command(() => NavigateTo(toName, null, mode, toTitle, navParams, newNavigationStack, withAnimation, withBackButton));
        }

        protected ICommand MakeCommand(Action commandAction, [CallerMemberName] string propertyName = null)
        {
            return GetCommand(propertyName) ?? SaveCommand(new Command(commandAction), propertyName);
        }

        protected ICommand MakeCommand(Action<object> commandAction, [CallerMemberName] string propertyName = null)
        {
            return GetCommand(propertyName) ?? SaveCommand(new Command(commandAction), propertyName);
        }

        protected Task<bool> NavigateBack(constEnumClient.NavigationMode mode = constEnumClient.NavigationMode.Normal, bool withAnimation = true, bool force = false)
        {
            ClearDialogs();
            var taskCompletionSource = new TaskCompletionSource<bool>();
            services.MessageBus.SendMessage(constMessageCenter.NavigationPopMessage, new services.NavigationPopInfo
            {
                Mode = mode,
                OnCompletedTask = taskCompletionSource
            });
            return taskCompletionSource.Task;
        }

        public void ClearDialogs()
        {
            HideLoading();
        }

        void GoBackCommandExecute(object mode)
        {
            if (mode is constEnumClient.NavigationMode navigationMode)
            {
                NavigateBack(navigationMode);
                return;
            }
            NavigateBack();
        }

        protected void ShowLoading(string message = null, bool useDelay = true)
        {
            services.MessageBus.SendMessage(constMessageCenter.DialogShowLoadingMessage, message);
        }

        protected void HideLoading()
        {
            services.MessageBus.SendMessage(constMessageCenter.DialogHideLoadingMessage);
        }

        protected static Task ShowAlert(string title, string message, string cancel)
        {
            var tcs = new TaskCompletionSource<bool>();
            services.MessageBus.SendMessage(constMessageCenter.DialogAlertMessage,
                new services.DialogAlertInfo
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
            services.MessageBus.SendMessage(constMessageCenter.DialogSheetMessage,
                new services.DialogSheetInfo
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
            services.MessageBus.SendMessage(constMessageCenter.DialogQuestionMessage,
                new services.DialogQuestionInfo
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
            services.MessageBus.SendMessage(constMessageCenter.DialogEntryMessage,
                new services.DialogEntryInfo
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
            services.MessageBus.SendMessage(constMessageCenter.DialogToastMessage,
                new services.DialogToastInfo
                {
                    Text = text,
                    IsCenter = isCenter,
                    IsLongTime = isLongTime
                });
        }

        ICommand SaveCommand(ICommand command, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            if (!_cachedCommands.ContainsKey(propertyName))
                _cachedCommands.TryAdd(propertyName, command);

            return command;
        }

        ICommand GetCommand(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            return _cachedCommands.TryGetValue(propertyName, out var cachedCommand)
                ? cachedCommand
                : null;
        }
    }
}
