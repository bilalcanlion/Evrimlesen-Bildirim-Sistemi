using System;
using System.Collections.Generic;

namespace NotificationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationFacade notificationFacade = new NotificationFacade();

            notificationFacade.SendUserRegistrationNotifications(
                "bilal@soft.com",
                "05550000000",
                "BilalCan"
            );

            notificationFacade.SendSilentSystemNotification("BilalCan");

            Console.ReadLine();
        }
    }

    interface INotification
    {
        void Send(string message, string receiver);
    }

    class EmailNotification : INotification
    {
        public void Send(string message, string receiver)
        {
            Console.WriteLine("E-posta bildirimi gönderiliyor...");
            Console.WriteLine("Alıcı e-posta: " + receiver);
            Console.WriteLine("Mesaj: " + message);
            Console.WriteLine("E-posta gönderildi.");
        }
    }

    class PushNotification : INotification
    {
        public void Send(string message, string receiver)
        {
            Console.WriteLine("Push bildirimi gönderiliyor...");
            Console.WriteLine("Kullanıcı adı: " + receiver);
            Console.WriteLine("Mesaj: " + message);
            Console.WriteLine("Push bildirimi gönderildi.");
        }
    }

    class ExternalSmsProvider
    {
        public void SendSmsMessage(string phoneNumber, string text)
        {
            Console.WriteLine("Harici SMS sağlayıcısı kullanılıyor...");
            Console.WriteLine("Telefon numarası: " + phoneNumber);
            Console.WriteLine("SMS içeriği: " + text);
            Console.WriteLine("Harici servis üzerinden SMS gönderildi.");
        }
    }

    // Adapter Pattern
    class SmsProviderAdapter : INotification
    {
        private readonly ExternalSmsProvider _externalSmsProvider;

        public SmsProviderAdapter(ExternalSmsProvider externalSmsProvider)
        {
            _externalSmsProvider = externalSmsProvider;
        }

        public void Send(string message, string receiver)
        {
            _externalSmsProvider.SendSmsMessage(receiver, message);
        }
    }

    abstract class NotificationFactory
    {
        public abstract INotification CreateNotification();
    }

    class EmailNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new EmailNotification();
        }
    }

    class SmsNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            ExternalSmsProvider externalSmsProvider = new ExternalSmsProvider();
            return new SmsProviderAdapter(externalSmsProvider);
        }
    }

    class PushNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new PushNotification();
        }
    }

    // Strategy Pattern
    interface INotificationSendStrategy
    {
        void Send(INotification notification, string message, string receiver);
    }

    class NormalSendStrategy : INotificationSendStrategy
    {
        public void Send(INotification notification, string message, string receiver)
        {
            Console.WriteLine("Normal gönderim stratejisi kullanılıyor.");
            notification.Send(message, receiver);
        }
    }

    class PrioritySendStrategy : INotificationSendStrategy
    {
        public void Send(INotification notification, string message, string receiver)
        {
            Console.WriteLine("Öncelikli gönderim stratejisi kullanılıyor.");
            Console.WriteLine("Bildirim öncelikli olarak işleme alındı.");
            notification.Send(message, receiver);
        }
    }

    // OCP örneği:
    // Yeni bir gönderim davranışı eklemek için NotificationService sınıfını değiştirmeye gerek kalmadan
    // yeni bir strategy sınıfı eklenebilir.
    class SilentSendStrategy : INotificationSendStrategy
    {
        public void Send(INotification notification, string message, string receiver)
        {
            Console.WriteLine("Sessiz gönderim stratejisi kullanılıyor.");
            Console.WriteLine("Kullanıcıya rahatsız edici sesli uyarı gösterilmeden bildirim gönderiliyor.");
            notification.Send(message, receiver);
        }
    }

    // Observer Pattern için olay bilgisi
    class NotificationEvent
    {
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public string Receiver { get; set; }
        public string StrategyName { get; set; }

        public NotificationEvent(string notificationType, string message, string receiver, string strategyName)
        {
            NotificationType = notificationType;
            Message = message;
            Receiver = receiver;
            StrategyName = strategyName;
        }
    }

    interface INotificationObserver
    {
        void Update(NotificationEvent notificationEvent);
    }

    class LogObserver : INotificationObserver
    {
        public void Update(NotificationEvent notificationEvent)
        {
            Console.WriteLine("[LOG] Bildirim gönderildi.");
            Console.WriteLine("[LOG] Tür: " + notificationEvent.NotificationType);
            Console.WriteLine("[LOG] Alıcı: " + notificationEvent.Receiver);
        }
    }

    class ReportObserver : INotificationObserver
    {
        public void Update(NotificationEvent notificationEvent)
        {
            Console.WriteLine("[RAPOR] Bildirim rapor sistemine eklendi.");
            Console.WriteLine("[RAPOR] Kullanılan strateji: " + notificationEvent.StrategyName);
        }
    }

    interface INotificationSubject
    {
        void Attach(INotificationObserver observer);
        void Detach(INotificationObserver observer);
        void Notify(NotificationEvent notificationEvent);
    }

    class NotificationService : INotificationSubject
    {
        private readonly List<INotificationObserver> _observers;

        public NotificationService()
        {
            _observers = new List<INotificationObserver>();
        }

        public void Attach(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(NotificationEvent notificationEvent)
        {
            foreach (INotificationObserver observer in _observers)
            {
                observer.Update(notificationEvent);
            }
        }

        public void SendNotification(
            NotificationFactory factory,
            string message,
            string receiver,
            INotificationSendStrategy sendStrategy)
        {
            INotification notification = factory.CreateNotification();

            sendStrategy.Send(notification, message, receiver);

            NotificationEvent notificationEvent = new NotificationEvent(
                notification.GetType().Name,
                message,
                receiver,
                sendStrategy.GetType().Name
            );

            Notify(notificationEvent);

            Console.WriteLine("-----------------------------");
        }
    }

    // Facade Pattern
    class NotificationFacade
    {
        private readonly NotificationService _notificationService;

        public NotificationFacade()
        {
            _notificationService = new NotificationService();

            // Observer Pattern
            // Bildirim gönderildikten sonra loglama ve raporlama otomatik çalışır.
            _notificationService.Attach(new LogObserver());
            _notificationService.Attach(new ReportObserver());
        }

        public void SendUserRegistrationNotifications(string email, string phoneNumber, string userName)
        {
            _notificationService.SendNotification(
                new EmailNotificationFactory(),
                "Merhaba, sistem kaydınız oluşturuldu.",
                email,
                new NormalSendStrategy()
            );

            _notificationService.SendNotification(
                new SmsNotificationFactory(),
                "Doğrulama kodunuz: 1234",
                phoneNumber,
                new NormalSendStrategy()
            );

            _notificationService.SendNotification(
                new PushNotificationFactory(),
                "Yeni bir bildiriminiz var.",
                userName,
                new PrioritySendStrategy()
            );
        }

        public void SendSilentSystemNotification(string userName)
        {
            _notificationService.SendNotification(
                new PushNotificationFactory(),
                "Sistem bakım bildirimi: Bu gece kısa süreli bakım yapılacaktır.",
                userName,
                new SilentSendStrategy()
            );
        }
    }
}