using System;

namespace NotificationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationService service = new NotificationService();

            service.SendNotification("email", "Merhaba, sistem kaydınız oluşturuldu.", "bilal@soft.com");
         
            service.SendNotification("sms", "Doğrulama kodunuz: 1234", "05550000000");
            
            service.SendNotification("push", "Yeni bir bildiriminiz var.", "BilalCan");

            Console.ReadLine();
        }
    }

    class NotificationService
    {
        public void SendNotification(string type, string message, string receiver)
        {
            if (type == "email")
            {
                Console.WriteLine("E-posta bildirimi gönderiliyor...");
                Console.WriteLine("Alıcı e-posta: " + receiver);
              
                Console.WriteLine("Mesaj: " + message);
                Console.WriteLine("E-posta gönderildi.");
            }
            else if (type == "sms")
            {
                Console.WriteLine("SMS bildirimi gönderiliyor...");
            
                Console.WriteLine("Telefon numarası: " + receiver);
                Console.WriteLine("Mesaj: " + message);
                Console.WriteLine("SMS gönderildi.");
            }
            else if (type == "push")
            {
             
                
                Console.WriteLine("Push bildirimi gönderiliyor...");
                Console.WriteLine("Kullanıcı adı: " + receiver);
                Console.WriteLine("Mesaj: " + message);
                Console.WriteLine("Push bildirimi gönderildi.");
            }
            else
            {
            
                
                Console.WriteLine("Geçersiz bildirim türü.");
            }

            Console.WriteLine("-----------------------------");
        }
    }
}