\# Phase 1 UML Diyagramları



Bu dosyada Faz 1 öncesi ve Faz 1 sonrası sınıf yapısı gösterilmiştir. Faz 1'de Factory Method örüntüsü uygulanarak bildirim nesnesi oluşturma sorumluluğu `NotificationService` sınıfından ayrılmıştır.



\---



\## Faz 1 Öncesi UML



Başlangıç kodunda tüm bildirim türleri tek bir `NotificationService` sınıfı içinde `if-else` bloklarıyla yönetiliyordu.



```mermaid

classDiagram

&#x20;   class Program {

&#x20;       +Main(string\[] args)

&#x20;   }



&#x20;   class NotificationService {

&#x20;       +SendNotification(string type, string message, string receiver)

&#x20;   }



&#x20;   Program --> NotificationService

```



\---



\## Faz 1 Sonrası UML



Faz 1 sonrasında bildirim nesnesi oluşturma sorumluluğu Factory sınıflarına taşındı. NotificationService artık hangi bildirimin nasıl oluşturulduğunu bilmek zorunda değildir.



```mermaid

classDiagram

&#x20;   class Program {

&#x20;       +Main(string\[] args)

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



&#x20;   class SmsNotification {

&#x20;       +Send(string message, string receiver)

&#x20;   }



&#x20;   class PushNotification {

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



&#x20;   Program --> NotificationService

&#x20;   NotificationService --> NotificationFactory

&#x20;   NotificationService --> INotification



&#x20;   INotification <|.. EmailNotification

&#x20;   INotification <|.. SmsNotification

&#x20;   INotification <|.. PushNotification



&#x20;   NotificationFactory <|-- EmailNotificationFactory

&#x20;   NotificationFactory <|-- SmsNotificationFactory

&#x20;   NotificationFactory <|-- PushNotificationFactory



&#x20;   EmailNotificationFactory --> EmailNotification

&#x20;   SmsNotificationFactory --> SmsNotification

&#x20;   PushNotificationFactory --> PushNotification

```



\## Kısa Açıklama



Başlangıç yapısında `NotificationService` sınıfı hem bildirim türünü seçiyor hem de gönderme işlemini yapıyordu. Bu yüzden sınıfın sorumluluğu fazlaydı.



Factory Method uygulandıktan sonra bildirim nesnesi oluşturma işlemi ayrı Factory sınıflarına taşındı. Böylece NotificationService sınıfı daha sade hale geldi ve yeni bildirim türü eklemek daha kolaylaştı.

