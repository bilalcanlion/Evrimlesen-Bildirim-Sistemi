using System;

namespace NotificationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationService service = new NotificationService();

            service.SendNotification(new EmailNotificationFactory(),
                "Merhaba, sistem kaydınız oluşturuldu.",
                "bilal@soft.com");

            service.SendNotification(new SmsNotificationFactory(),
                "Doğrulama kodunuz: 1234",
                "05550000000");

            service.SendNotification(new PushNotificationFactory(),
                "Yeni bir bildiriminiz var.",
                "BilalCan");

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

    // Dışarıdan geldiğini düşündüğümüz SMS sağlayıcısı.
    // Bu sınıf bizim INotification yapımıza doğrudan uymuyor.
    
    
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
    // ExternalSmsProvider sınıfını INotification yapısına uyumlu hale getirir.
   
    
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

    class NotificationService
    {
        public void SendNotification(NotificationFactory factory, string message, string receiver)
        {

            INotification notification = factory.CreateNotification();
        
            notification.Send(message, receiver);

            Console.WriteLine("-----------------------------");
        }
    }
}