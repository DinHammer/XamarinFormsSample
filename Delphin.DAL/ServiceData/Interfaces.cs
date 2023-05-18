using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dalDataObjects = Delphin.Abstraction.DataObjects;
using srvWebApi = Delphin.DAL.ServiceWebApi;

namespace Delphin.DAL.ServiceData
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.DAL.ServiceData.Action.ActionPageMain">
    public interface IActionPageMain
    {
        Task<RequestResult<dalDataObjects.ObjPageMain>> GetInitData(string token, CancellationToken cts);
    }
    /// <see cref="Delphin.DAL.ServiceData.Action.ActionPageNews">
    public interface IActionPageNews
    {
        Task<RequestResult<dalDataObjects.ObjPageNews>> GetInitData(string token, CancellationToken cts);
    }


    public interface IActionUsers : srvWebApi.IActionUsers
    { }
}
