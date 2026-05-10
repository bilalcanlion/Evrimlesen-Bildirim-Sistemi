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
                "bilal@example.com");

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

    class SmsNotification : INotification
    {
        public void Send(string message, string receiver)
        {
            Console.WriteLine("SMS bildirimi gönderiliyor...");
            Console.WriteLine("Telefon numarası: " + receiver);
            Console.WriteLine("Mesaj: " + message);
            Console.WriteLine("SMS gönderildi.");
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
            return new SmsNotification();
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