using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Dlphn.Staff.Services
{
    public class SrvAppCenter
    {
        static readonly Lazy<SrvAppCenter> LazyInstance = new Lazy<SrvAppCenter>(() => new SrvAppCenter(), true);
        public static SrvAppCenter Instance => LazyInstance.Value;

        public static void Init(string key)
        {
            Instance.Initialize(key);
        }

        void Initialize(string key)
        {
            AppCenter.Start(key,
                   typeof(Analytics), 
                   typeof(Crashes));
        }

        #region TrackExceptions

        public void TrackError(string key, string parametr, string value)
        {            
            TrackError(new Exception(key), parametr, value);
        }

        public void TrackError(Exception ex, string key, string value)
        {
            IDictionary<string, string> table = new Dictionary<string, string> { { key, value } };

            if (string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value))
            {
                table = null;
            }

            TrackError(ex, table);
        }

        public void TrackError(string key, IDictionary<string, string> parameters)
        {
            TrackError(new Exception(key), parameters);
        }

        public void TrackError(Exception ex, IDictionary<string, string> parameters)
        {
            Crashes.TrackError(ex, parameters);    
                        
        }

        public void TrackTestException() => TrackError(new Exception("test_exseption"), "ololo", "pishPish");
        #endregion

        #region TrackEvent
        public void TrackEvent(string trackIdentifier, string key, string value)
        {
            IDictionary<string, string> table = new Dictionary<string, string> { { key, value } };

            if (string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value))
            {
                table = null;
            }

            TrackEvent(trackIdentifier, table);
        }

        public void TrackEvent(string trackIdentifier, IDictionary<string, string> table = null)
        {
            Analytics.TrackEvent(trackIdentifier, table); 
            
        }
        #endregion
    }
}
