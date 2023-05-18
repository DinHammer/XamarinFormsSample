using System;
using System.Collections.Generic;
using System.Text;

namespace Dlphn.Models
{
    #region Начальные данные для соответствующего события в MessagingCenter

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

    /*public class DialogCustomPopupHeader
    {
        public ObjectText objectText { get; set; }
    }
    public class DialogCustomPopupBody
    {
        public ObjectText objectText { get; set; }
        public bool is_payd { get; set; }
    }*/

    public class DialogCustomWelcome
    {
        public string str_text { get; set; }
        public string strLblClickText { get; set; }
        public string str_axept { get; set; }
        public Action<bool> OnCompleted { get; set; }
    }

    public class DialogCustomMessage
    {
        public string str_title { get; set; }
        public string str_text { get; set; }
        public string str_axept { get; set; }
        public Action<bool> OnCompleted { get; set; }
    }


    #endregion
}
