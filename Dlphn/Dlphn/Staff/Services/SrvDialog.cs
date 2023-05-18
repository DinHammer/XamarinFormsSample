using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Xamarin.Forms;
using constantTextMessageCenter = Delphin.Abstraction.Constants.ConstantText.ClientMessageCenter;
using mdls = Dlphn.Models;

namespace Dlphn.Staff.Services
{
    public class SrvDialog
    {
        static readonly Lazy<SrvDialog> LazyInstance = new Lazy<SrvDialog>(() => new SrvDialog(), true);
        Application _app;

        SrvDialog()
        {
            MessagingCenter.Subscribe<MessageBus, mdls.DialogAlertInfo>(this, constantTextMessageCenter.DialogAlertMessage, this.DialogAlertCallback);
            MessagingCenter.Subscribe<MessageBus, mdls.DialogSheetInfo>(this, constantTextMessageCenter.DialogSheetMessage, this.DialogSheetCallback);
            MessagingCenter.Subscribe<MessageBus, mdls.DialogQuestionInfo>(this, constantTextMessageCenter.DialogQuestionMessage, this.DialogQuestionCallback);
            MessagingCenter.Subscribe<MessageBus, mdls.DialogEntryInfo>(this, constantTextMessageCenter.DialogEntryMessage, this.DialogEntryCallback);

            MessagingCenter.Subscribe<MessageBus, string>(this, constantTextMessageCenter.DialogShowLoadingMessage, this.DialogShowLoadingCallback);
            MessagingCenter.Subscribe<MessageBus>(this, constantTextMessageCenter.DialogHideLoadingMessage, this.DialogHideLoadingCallback);

            MessagingCenter.Subscribe<MessageBus, mdls.DialogToastInfo>(this, constantTextMessageCenter.DialogToastMessage, this.DialogToastCallback);

            /*MessagingCenter.Subscribe<MessageBus, mdls.DialogCustomPopupHeader>(this, constantTextMessageCenter.DialogCustomPopupHeader, this.DialogCustomPopupHeaderCallback);
            MessagingCenter.Subscribe<MessageBus, mdls.DialogCustomPopupBody>(this, constantTextMessageCenter.DialogCustomPopupBody, this.DialogCustomPopupBodyCallback);
            MessagingCenter.Subscribe<MessageBus, mdls.DialogCustomWelcome>(this, constantTextMessageCenter.DialogCustomWelcome, this.DialogCustomPopupWelcomeCallback);
            MessagingCenter.Subscribe<MessageBus, mdls.DialogCustomMessage>(this, constantTextMessageCenter.DialogCustomMessage, this.DialogCustomPopupMessageCallback);*/
        }

        #region Инициализация приложения

        public static void Init(Application app)
        {
            LazyInstance.Value.SetApp(app);
        }

        void SetApp(Application app)
        {
            _app = app;
        }

        #endregion

        #region Описание действий

        #region Базовые
        
        void DialogEntryCallback(MessageBus bus, mdls.DialogEntryInfo entryInfo)
        {
            if (entryInfo == null)
            { throw new ArgumentNullException(nameof(entryInfo)); }

            Device.BeginInvokeOnMainThread(async () =>
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
        }

        void DialogToastCallback(MessageBus bus, mdls.DialogToastInfo toastInfo)
        {
            if (toastInfo == null)
            {
                throw new ArgumentNullException(nameof(toastInfo));
            }

            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.Toast(new ToastConfig(toastInfo.Text)
            {
                Duration = TimeSpan.FromSeconds(toastInfo.IsLongTime ? 2 : 1)
            }));

        }

        void DialogHideLoadingCallback(MessageBus bus)
        {
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
        }

        void DialogShowLoadingCallback(MessageBus bus, string message)
        {
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading(message, MaskType.Black));
        }

        void DialogQuestionCallback(MessageBus bus, mdls.DialogQuestionInfo questionInfo)
        {
            if (questionInfo == null)
            {
                throw new ArgumentNullException(nameof(questionInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await _app.MainPage.DisplayAlert(questionInfo.Title, questionInfo.Question, questionInfo.Positive, questionInfo.Negative);
                questionInfo.OnCompleted?.Invoke(result);
            });
        }

        void DialogSheetCallback(MessageBus bus, mdls.DialogSheetInfo sheetInfo)
        {
            if (sheetInfo == null)
            {
                throw new ArgumentNullException(nameof(sheetInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await _app.MainPage.DisplayActionSheet(sheetInfo.Title, sheetInfo.Cancel, sheetInfo.Destruction, sheetInfo.Items);
                sheetInfo.OnCompleted?.Invoke(result);
            });
        }

        void DialogAlertCallback(MessageBus bus, mdls.DialogAlertInfo alertInfo)
        {
            if (alertInfo == null)
            {
                throw new ArgumentNullException(nameof(alertInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                await _app.MainPage.DisplayAlert(alertInfo.Title, alertInfo.Message, alertInfo.Cancel);
                alertInfo.OnCompleted?.Invoke();
            });
        }

        #endregion

        #endregion
    }
}
