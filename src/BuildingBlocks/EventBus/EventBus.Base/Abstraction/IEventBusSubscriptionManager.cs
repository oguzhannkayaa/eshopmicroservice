using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Abstraction
{
    public interface IEventBusSubscriptionManager
    {
        //herhangi bir subscription olduğunu dinliyor
        bool IsEmpty { get; }
        //event remove edilince event oluşucak
        event EventHandler<string> OnEventRemoved;  
        //subscriotion ekleniyor
        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        //subscriotion siliniyor
        void RemoveSubscription<T,TH>() where TH: IIntegrationEventHandler<T> where T : IntegrationEvent;
        //dışarıdan bir event gönderildiğinde dinlenip dinlenmediğini kontrol ediyor
        bool HasSubcriptionsForEvent<T>() where T : IntegrationEvent;
        //dışarıdan bir event gönderildiğinde dinlenip dinlenmediğini kontrol ediyor generic deği
        bool HasSubscriptionsForEvent(string eventName);
        //event ismi ordercreated ordercreatedHandler isminde evente oluşulucak
        Type GetEventTypeByName(string eventName);
        //liste clear
        void Clear();
        //event için dışarıdan gönderilen bir eventin bütün subscription handler geri dönücek
        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;
        //dışarıdan event isiölerini alınması
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        //eventlerin bir isimleri olucak ve unique olucak o integration için kullanılan bir key
        string GetEventKey<T>();
    }
}
