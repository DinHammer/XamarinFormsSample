using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using constantTextMessageCenter = Delphin.Abstraction.Constants.ConstantText.ClientMessageCenter;
using keyMessageCenter = Delphin.Constants.ConstantText.KeyMessageCenter;
using mdls = Delphin.Models;
using customControls = Delphin.Staff.Customs.Popup;

namespace Delphin.Staff.Services
{
    public class ServiceDialog
    {
        static readonly Lazy<ServiceDialog> LazyInstance = new Lazy<ServiceDialog>(() => new ServiceDialog(), true);
        Xamarin.Forms.Application _app;

        /// <summary>
        /// Подписка действий на события для MessagingCenter
        /// </summary>
        ServiceDialog()
        {
            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, DialogAlertInfo>(this, constantTextMessageCenter.DialogAlertMessage, this.DialogAlertCallback);
            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, DialogSheetInfo>(this, constantTextMessageCenter.DialogSheetMessage, this.DialogSheetCallback);
            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, DialogQuestionInfo>(this, constantTextMessageCenter.DialogQuestionMessage, this.DialogQuestionCallback);
            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, DialogEntryInfo>(this, constantTextMessageCenter.DialogEntryMessage, this.DialogEntryCallback);

            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, string>(this, constantTextMessageCenter.DialogShowLoadingMessage, this.DialogShowLoadingCallback);
            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus>(this, constantTextMessageCenter.DialogHideLoadingMessage, this.DialogHideLoadingCallback);

            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, DialogToastInfo>(this, constantTextMessageCenter.DialogToastMessage, this.DialogToastCallback);


            Xamarin.Forms.MessagingCenter.Subscribe<MessageBus, DlgShowNewsOneInfo>(this, keyMessageCenter.str_news_one, this.DlgShowNewsOneCallback);
        }

        #region Инициализация приложения

        public static void Init(Xamarin.Forms.Application app)
        {
            LazyInstance.Value.SetApp(app);
        }

        void SetApp(Xamarin.Forms.Application app)
        {
            _app = app;
        }

        #endregion


        void DlgShowNewsOneCallback(MessageBus bus, DlgShowNewsOneInfo entryInfo)
        {
            if (entryInfo == null)
            { throw new ArgumentNullException(nameof(entryInfo)); }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new customControls.PopupNewsOne(entryInfo.mdlNewsHeader));                
            });
        }

        #region Описание действий

        void DialogEntryCallback(MessageBus bus, DialogEntryInfo entryInfo)
        {
            if (entryInfo == null)
            { throw new ArgumentNullException(nameof(entryInfo)); }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                {
                    Message = entryInfo.Message,
                    Title = entryInfo.Title,
                    OkText = entryInfo.Ok ?? PromptConfig.DefaultOkText,
                    CancelText = entryInfo.Cancel ?? PromptConfig.DefaultCancelText,
                    Placeholder = entryInfo.Placeholder,
                    Text = entryInfo.Text,
                    InputType = InputType.Name
                });
                if (result.Ok)
                {
                    entryInfo.OnCompleted?.Invoke(result.Text ?? string.Empty);
                }
                else
                {
                    entryInfo.OnCancelled?.Invoke();
                }
            });
        }//void DialogEntryCallback(MessageBus bus, DialogEntryInfo entryInfo)

        void DialogToastCallback(MessageBus bus, DialogToastInfo toastInfo)
        {
            if (toastInfo == null)
            {
                throw new ArgumentNullException(nameof(toastInfo));
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.Toast(new ToastConfig(toastInfo.Text)
            {
                Duration = TimeSpan.FromSeconds(toastInfo.IsLongTime ? 2 : 1)
            }));

        }//void DialogToastCallback(MessageBus bus, DialogToastInfo toastInfo)

        void DialogHideLoadingCallback(MessageBus bus)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
        }//void DialogHideLoadingCallback(MessageBus bus)

        void DialogShowLoadingCallback(MessageBus bus, string message)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading(message, MaskType.Black));
        }//void DialogShowLoadingCallback(MessageBus bus, string message)

        void DialogQuestionCallback(MessageBus bus, DialogQuestionInfo questionInfo)
        {
            if (questionInfo == null)
            {
                throw new ArgumentNullException(nameof(questionInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await _app.MainPage.DisplayAlert(questionInfo.Title, questionInfo.Question, questionInfo.Positive, questionInfo.Negative);
                questionInfo.OnCompleted?.Invoke(result);
            });
        }//void DialogQuestionCallback(MessageBus bus, DialogQuestionInfo questionInfo)

        void DialogSheetCallback(MessageBus bus, DialogSheetInfo sheetInfo)
        {
            if (sheetInfo == null)
            {
                throw new ArgumentNullException(nameof(sheetInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await _app.MainPage.DisplayActionSheet(sheetInfo.Title, sheetInfo.Cancel, sheetInfo.Destruction, sheetInfo.Items);
                sheetInfo.OnCompleted?.Invoke(result);
            });
        }//void DialogSheetCallback(MessageBus bus, DialogSheetInfo sheetInfo)

        void DialogAlertCallback(MessageBus bus, DialogAlertInfo alertInfo)
        {
            if (alertInfo == null)
            {
                throw new ArgumentNullException(nameof(alertInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                await _app.MainPage.DisplayAlert(alertInfo.Title, alertInfo.Message, alertInfo.Cancel);
                alertInfo.OnCompleted?.Invoke();
            });
        }//void DialogAlertCallback(MessageBus bus, DialogAlertInfo alertInfo)

        #endregion
    }

    #region Начальные данные для соответствующего события в MessagingCenter


    public class DlgShowNewsOneInfo
    {
        public mdls.MdlNewsHeader mdlNewsHeader { get; set; }
        public Action OnCompleted { get; set; }
    }

    public class DialogAlertInfo
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Cancel { get; set; }
        public Action OnCompleted { get; set; }
    }

    public class DialogEntryInfo
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Placeholder { get; set; }
        public string Cancel { get; set; }
        public string Ok { get; set; }
        public string Text { get; set; }
        public Action<string> OnCompleted { get; set; }
        public Action OnCancelled { get; set; }
    }

    public class DialogSheetInfo
    {
        public string Title { get; set; }
        public string Cancel { get; set; }
        public string Destruction { get; set; }
        public string[] Items { get; set; }
        public Action<string> OnCompleted { get; set; }
    }

    public class DialogQuestionInfo
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public string Positive { get; set; }
        public string Negative { get; set; }
        public Action<bool> OnCompleted { get; set; }
    }

    public class DialogToastInfo
    {
        public string Text { get; set; }
        public bool IsLongTime { get; set; }
        public bool IsCenter { get; set; }
    }

    #endregion
}
