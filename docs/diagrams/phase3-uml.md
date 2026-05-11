\# Phase 3 UML / Mimari Diyagramı



Bu dosyada Faz 3 sonrasında sistemin güncellenmiş mimari yapısı gösterilmiştir. Bu fazda Behavioral Design Pattern grubundan \*\*Strategy\*\* ve \*\*Observer\*\* örüntüleri uygulanmıştır.



\---



\## Faz 3 Sonrası UML Diyagramı



```mermaid

classDiagram

&#x20;   class Program {

&#x20;       +Main()

&#x20;   }



&#x20;   class NotificationFacade {

&#x20;       +SendUserRegistrationNotifications()

&#x20;       +SendSilentSystemNotification()

&#x20;   }



&#x20;   class NotificationService {

&#x20;       -List observers

&#x20;       +Attach()

&#x20;       +Detach()

&#x20;       +Notify()

&#x20;       +SendNotification()

&#x20;   }



&#x20;   class INotification {

&#x20;       <<interface>>

&#x20;       +Send()

&#x20;   }



&#x20;   class EmailNotification {

&#x20;       +Send()

&#x20;   }



&#x20;   class PushNotification {

&#x20;       +Send()

&#x20;   }



&#x20;   class ExternalSmsProvider {

&#x20;       +SendSmsMessage()

&#x20;   }



&#x20;   class SmsProviderAdapter {

&#x20;       +Send()

&#x20;   }



&#x20;   class NotificationFactory {

&#x20;       <<abstract>>

&#x20;       +CreateNotification()

&#x20;   }



&#x20;   class EmailNotificationFactory {

&#x20;       +CreateNotification()

&#x20;   }



&#x20;   class SmsNotificationFactory {

&#x20;       +CreateNotification()

&#x20;   }



&#x20;   class PushNotificationFactory {

&#x20;       +CreateNotification()

&#x20;   }



&#x20;   class INotificationSendStrategy {

&#x20;       <<interface>>

&#x20;       +Send()

&#x20;   }



&#x20;   class NormalSendStrategy {

&#x20;       +Send()

&#x20;   }



&#x20;   class PrioritySendStrategy {

&#x20;       +Send()

&#x20;   }



&#x20;   class SilentSendStrategy {

&#x20;       +Send()

&#x20;   }



&#x20;   class NotificationEvent {

&#x20;       +NotificationType

&#x20;       +Message

&#x20;       +Receiver

&#x20;       +StrategyName

&#x20;   }



&#x20;   class INotificationObserver {

&#x20;       <<interface>>

&#x20;       +Update()

&#x20;   }



&#x20;   class LogObserver {

&#x20;       +Update()

&#x20;   }



&#x20;   class ReportObserver {

&#x20;       +Update()

&#x20;   }



&#x20;   class INotificationSubject {

&#x20;       <<interface>>

&#x20;       +Attach()

&#x20;       +Detach()

&#x20;       +Notify()

&#x20;   }



&#x20;   Program --> NotificationFacade

&#x20;   NotificationFacade --> NotificationService



&#x20;   NotificationService ..|> INotificationSubject

&#x20;   NotificationService --> NotificationFactory

&#x20;   NotificationService --> INotification

&#x20;   NotificationService --> INotificationSendStrategy

&#x20;   NotificationService --> NotificationEvent

&#x20;   NotificationService --> INotificationObserver



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



&#x20;   INotificationSendStrategy <|.. NormalSendStrategy

&#x20;   INotificationSendStrategy <|.. PrioritySendStrategy

&#x20;   INotificationSendStrategy <|.. SilentSendStrategy



&#x20;   INotificationObserver <|.. LogObserver

&#x20;   INotificationObserver <|.. ReportObserver



&#x20;   LogObserver --> NotificationEvent

&#x20;   ReportObserver --> NotificationEvent

```



\---



\## Kısa Açıklama



Faz 3'te sisteme iki Behavioral Pattern eklenmiştir.



İlk olarak \*\*Strategy Pattern\*\* kullanılmıştır. Bildirimlerin nasıl gönderileceği INotificationSendStrategy arayüzü ile soyutlanmıştır. NormalSendStrategy, PrioritySendStrategy ve SilentSendStrategy sınıfları farklı gönderim davranışlarını temsil etmektedir.



Bu yapı sayesinde yeni bir gönderim davranışı eklemek için mevcut servis sınıfını değiştirmek yerine yeni bir strategy sınıfı eklemek yeterli olur. Bu durum Açık/Kapalı Prensibini göstermektedir.



İkinci olarak \*\*Observer Pattern\*\* kullanılmıştır. NotificationService sınıfı bildirim gönderildikten sonra sisteme bağlı observer sınıflarını bilgilendirir. LogObserver ve ReportObserver sınıfları bildirim sonrası loglama ve raporlama işlemlerini otomatik olarak yürütür.



Bu faz sonunda sistem davranış açısından daha genişletilebilir hale gelmiştir.

