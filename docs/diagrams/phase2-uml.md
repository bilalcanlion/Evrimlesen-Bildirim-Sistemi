\# Phase 2 UML / Mimari Diyagramı



Bu dosyada Faz 2 sonrasında sistemin güncellenmiş mimari yapısı gösterilmiştir. Bu fazda Structural Design Pattern grubundan \*\*Adapter\*\* ve \*\*Facade\*\* örüntüleri uygulanmıştır.



\---



\## Faz 2 Sonrası UML Diyagramı



```mermaid

classDiagram

&#x20;   class Program {

&#x20;       +Main(string\[] args)

&#x20;   }



&#x20;   class NotificationFacade {

&#x20;       -NotificationService \_notificationService

&#x20;       +SendUserRegistrationNotifications(string email, string phoneNumber, string userName)

&#x20;   }



&#x20;   class NotificationService {

&#x20;       +SendNotification(NotificationFactory factory, string message, string receiver)

&#x20;   }



&#x20;   class INotification {

&#x20;       <<interface>>

&#x20;       +Send(string message, string receiver)

&#x20;   }



&#x20;   class EmailNotification {

&#x20;       +Send(string message, string receiver)

&#x20;   }



&#x20;   class PushNotification {

&#x20;       +Send(string message, string receiver)

&#x20;   }



&#x20;   class ExternalSmsProvider {

&#x20;       +SendSmsMessage(string phoneNumber, string text)

&#x20;   }



&#x20;   class SmsProviderAdapter {

&#x20;       -ExternalSmsProvider \_externalSmsProvider

&#x20;       +Send(string message, string receiver)

&#x20;   }



&#x20;   class NotificationFactory {

&#x20;       <<abstract>>

&#x20;       +CreateNotification() INotification

&#x20;   }



&#x20;   class EmailNotificationFactory {

&#x20;       +CreateNotification() INotification

&#x20;   }



&#x20;   class SmsNotificationFactory {

&#x20;       +CreateNotification() INotification

&#x20;   }



&#x20;   class PushNotificationFactory {

&#x20;       +CreateNotification() INotification

&#x20;   }



&#x20;   Program --> NotificationFacade

&#x20;   NotificationFacade --> NotificationService



&#x20;   NotificationService --> NotificationFactory

&#x20;   NotificationService --> INotification



&#x20;   INotification <|.. EmailNotification

&#x20;   INotification <|.. PushNotification

&#x20;   INotification <|.. SmsProviderAdapter



&#x20;   SmsProviderAdapter --> ExternalSmsProvider



&#x20;   NotificationFactory <|-- EmailNotificationFactory

&#x20;   NotificationFactory <|-- SmsNotificationFactory

&#x20;   NotificationFactory <|-- PushNotificationFactory



&#x20;   EmailNotificationFactory --> EmailNotification

&#x20;   SmsNotificationFactory --> SmsProviderAdapter

&#x20;   PushNotificationFactory --> PushNotification

```



\---



\## Kısa Açıklama



Faz 2'de sisteme iki Structural Pattern eklenmiştir.



İlk olarak \*\*Adapter Pattern\*\* kullanılmıştır. ExternalSmsProvider sınıfı sistemdeki INotification arayüzüne doğrudan uymadığı için SmsProviderAdapter sınıfı oluşturulmuştur. Bu adapter sınıfı, dış SMS sağlayıcısını mevcut bildirim sistemine uyumlu hale getirmiştir.



İkinci olarak \*\*Facade Pattern\*\* kullanılmıştır. `NotificationFacade` sınıfı, kullanıcı kaydı sonrası gönderilecek e-posta, SMS ve push bildirimlerini tek bir metot altında toplamıştır. Böylece `Program.cs` tarafında daha sade ve anlaşılır bir kullanım sağlanmıştır.

Bu faz sonunda sistem, mevcut yapıyı bozmadan dış servis entegrasyonu yapabilir hale gelmiş ve bildirim gönderme süreci daha kolay kullanılabilir duruma getirilmiştir.

