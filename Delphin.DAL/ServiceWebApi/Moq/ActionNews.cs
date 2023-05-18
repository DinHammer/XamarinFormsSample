using Delphin.Abstraction.DataObjects;
using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delphin.DAL.ServiceWebApi.Moq
{
    public class ActionNews : BaseMoqAction, IActionNews
    {
        public Task<RequestResult<ObjNewsOut>> GetNews(ObjNewsIn dtIn, CancellationToken cts)
        {
            return Task.Run(() => 
            {
                ObjNewsOut result = new ObjNewsOut();
                result.news.Add(
                    new ObjectNews
                    {
                        title = "Авария в Водоканале",
                        uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                        slug = "авария-в-водоканале-1594645338",
                        date_pub = Convert.ToDateTime("2020-07-13T13:02:18.711576Z"),
                        is_hot = true,
                        is_push = false,
                        body = "В связи с аварией в водоканеле, временно прекращена подача воды"
                    });
                result.news.Add(new ObjectNews
                {
                    title = "Ремонт колясочной",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "ремонт-колясочной-1594726627",
                    date_pub = Convert.ToDateTime("2020-07-14T11:37:07.876621Z"),
                    is_hot = false,
                    is_push = false,
                    body = "Начинается ремонт в колясочной, большая просьба забрать оттуда все свои вещи"
                });
                result.news.Add(new ObjectNews
                {
                    title = "Emergency",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "emergency-1594644987",
                    date_pub = Convert.ToDateTime("2020-06-13T12:56:27.919894Z"),
                    is_hot = false,
                    is_push = false,
                    body = "Утвержден график отключения горячей воды"
                });
                result.news.Add(new ObjectNews
                {
                    title = "Ежегодное собрание собственников",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "ежегодное-собрание-собственников-1594645211",
                    date_pub = Convert.ToDateTime("2020-06-13T13:00:11.660255Z"),
                    is_hot = false,
                    is_push = false,
                    body = "Ежегодное собрание собственников будет проведено 15 июля"
                });
                result.news.Add(new ObjectNews
                {
                    title = "Оплата коммунальных услуг",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "оплата-коммунальных-услуг-1594726768",
                    date_pub = Convert.ToDateTime("2020-07-14T11:39:28.864515Z"),
                    is_hot = false,
                    is_push = false,
                    body = "Напоминаем что коммунальные услуги необходимо оплатить до 10 июля. Спасибо."
                });
                return new RequestResult<ObjNewsOut>(result, statusOk);
            });
        }

        public Task<RequestResult<ObjNewsHotOut>> GetNewsHot(ObjNewsIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                ObjNewsHotOut result = new ObjNewsHotOut();
                result.hotnews.Add(new ObjectNews
                {
                    title = "Авария в Водоканале",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "авария-в-водоканале-1594645338",
                    date_pub = Convert.ToDateTime("2020-07-13T13:02:18.711576Z"),
                    is_hot = true,
                    is_push = false,
                    body = "В связи с аварией в водоканеле, временно прекращена подача воды"
                });
                return new RequestResult<ObjNewsHotOut>(result, statusOk);
            });
        }

        public Task<RequestResult<ObjNewsLatestOut>> GetNewsLatest(ObjNewsIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                ObjNewsLatestOut result = new ObjNewsLatestOut();
                result.latestnews.Add(
                    new ObjectNews
                    {
                        title = "Авария в Водоканале",
                        uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                        slug = "авария-в-водоканале-1594645338",
                        date_pub = Convert.ToDateTime("2020-07-13T13:02:18.711576Z"),
                        is_hot = true,
                        is_push = false,
                        body = "В связи с аварией в водоканеле, временно прекращена подача воды"
                    });
                result.latestnews.Add(new ObjectNews
                {
                    title = "Ремонт колясочной",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "ремонт-колясочной-1594726627",
                    date_pub = Convert.ToDateTime("2020-07-14T11:37:07.876621Z"),
                    is_hot = false,
                    is_push = false,
                    body = "Начинается ремонт в колясочной, большая просьба забрать оттуда все свои вещи"
                });
                result.latestnews.Add(new ObjectNews
                {
                    title = "Оплата коммунальных услуг",
                    uk_uuid = "892989a5-f53b-407a-9abd-34d176a2ee73",
                    slug = "оплата-коммунальных-услуг-1594726768",
                    date_pub = Convert.ToDateTime("2020-07-14T11:39:28.864515Z"),
                    is_hot = false,
                    is_push = false,
                    body = "Напоминаем что коммунальные услуги необходимо оплатить до 10 июля. Спасибо."
                });
                return new RequestResult<ObjNewsLatestOut>(result, statusOk);
            });
        }
    }
}
