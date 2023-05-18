using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Staff.Services
{
    public class ServiceTextTranslate
    {
        static readonly Lazy<ServiceTextTranslate> LazyInstance = new Lazy<ServiceTextTranslate>(() => new ServiceTextTranslate(), true);
        public static ServiceTextTranslate Instance => LazyInstance.Value;

        public RequestResult<string> GetTextByTextKey(string id_text)
        {
            return new RequestResult<string>(id_text, RequestStatus.Ok);
        }

    }
}
