using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using constString = Dlphn.Constants.ConstString;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Dlphn.Staff.Services
{
    public class SrvAuth: Delphin.Abstraction.Constants.BaseConstant
    {
        static readonly Lazy<SrvAuth> LazyInstance = new Lazy<SrvAuth>(()=> new SrvAuth(), true);
        public static SrvAuth Instance => LazyInstance.Value;

        public void SecureStorageTokensClear()
        {
            SecureStorage.Remove(constString.KeySecureStorage.str_token_access);
            SecureStorage.Remove(constString.KeySecureStorage.str_token_refresh);
        }

        public Task<RequestResult> SetTokens(dtObj.ObjRefreshTokenOut data)
            => SetTokens(data.access, data.refresh);

        public Task<RequestResult> SetTokens(dtObj.ObjTokenOut data)
            => SetTokens(data.access, data.refresh);
        async Task<RequestResult> SetTokens(string strAccess, string strRefresh)
        {
            var vAcces = await SetTokenAccess(strAccess);
            if (!vAcces.IsValid)
            {
                return new RequestResult(vAcces.Status, vAcces.Message);
            }

            var vRefresh = await SetTokenRefresh(strRefresh);
            if (!vRefresh.IsValid)
            {
                return new RequestResult(vRefresh.Status, vRefresh.Message);
            }

            return new RequestResult(RequestStatus.Ok);
        }
        Task<RequestResult> SetTokenAccess(string str) => SetSecureStorage(constString.KeySecureStorage.str_token_access, str);
        public Task<RequestResult<string>> GetTokenAccess() => GetSecureStorage(constString.KeySecureStorage.str_token_access);

        Task<RequestResult> SetTokenRefresh(string str) => SetSecureStorage(constString.KeySecureStorage.str_token_refresh, str);
        public Task<RequestResult<string>> GetTokenRefresh() => GetSecureStorage(constString.KeySecureStorage.str_token_refresh);


        public Task<RequestResult> SetUserId(string str) => SetSecureStorage(constString.KeySecureStorage.str_user_id, str);
        public Task<RequestResult<string>> GetUserId() => GetSecureStorage(constString.KeySecureStorage.str_user_id);

        public Task<RequestResult> SetAccountId(string str) => SetSecureStorage(constString.KeySecureStorage.str_account_id, str);
        public Task<RequestResult<string>> GetAccountId() => GetSecureStorage(constString.KeySecureStorage.str_account_id);


        async Task<RequestResult<string>> GetSecureStorage(string key)
        {
            try
            {
                var result = await SecureStorage.GetAsync(key);
                if (result != null)
                {
                    return new RequestResult<string>(result.ToString(), statusOk);
                }
                else
                {
                    return new RequestResult<string>(string.Empty, statusNotFound);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSomethingWrong, message: ex.Message);
            }
        }

        async Task<RequestResult> SetSecureStorage(string key, string str)
        {
            try
            {
                await SecureStorage.SetAsync(key, str);
                return new RequestResult(statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusSomethingWrong, message: ex.Message);
            }
        }


        RequestResult SecureStorageDelete(string key)
        {
            bool result = SecureStorage.Remove(key);
            return new RequestResult(statusOk, message: result.ToString());
        }

        public void ClearAll()
        {
            SecureStorage.RemoveAll();
        }
    }
}
