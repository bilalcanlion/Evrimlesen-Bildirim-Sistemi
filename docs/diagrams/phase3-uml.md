# Phase 3 UML / Mimari Diyagramı

Bu dosyada Faz 3 sonrasında sistemin güncellenmiş mimari yapısı gösterilmiştir. Bu fazda Behavioral Design Pattern grubundan **Strategy** ve **Observer** örüntüleri uygulanmıştır.

---

## Faz 3 Sonrası UML Diyagramı

```mermaid
classDiagram

    class Program {
        +Main()
    }

    class NotificationFacade {
        +SendUserRegistrationNotifications()
        +SendSilentSystemNotification()
    }

    class NotificationService {
        -observers
        +Attach()
        +Detach()
        +Notify()
        +SendNotification()
    }

    class INotification {
        <<interface>>
        +Send()
    }

    class EmailNotification {
        +Send()
    }

    class PushNotification {
        +Send()
    }

    class ExternalSmsProvider {
        +SendSmsMessage()
    }

    class SmsProviderAdapter {
        +Send()
    }

    class NotificationFactory {
        <<abstract>>
        +CreateNotification()
    }

    class EmailNotificationFactory {
        +CreateNotification()
    }

    class SmsNotificationFactory {
        +CreateNotification()
    }

    class PushNotificationFactory {
        +CreateNotification()
    }

    class INotificationSendStrategy {
        <<interface>>
        +Send()
    }

    class NormalSendStrategy {
        +Send()
    }

    class PrioritySendStrategy {
        +Send()
    }

    class SilentSendStrategy {
        +Send()
    }

    class NotificationEvent {
        +NotificationType
        +Message
        +Receiver
        +StrategyName
    }

    class INotificationObserver {
        <<interface>>
        +Update()
    }

    class LogObserver {
        +Update()
    }

    class ReportObserver {
        +Update()
    }

    class INotificationSubject {
        <<interface>>
        +Attach()
        +Detach()
        +Notify()
    }

    Program --> NotificationFacade
    NotificationFacade --> NotificationService

    NotificationService ..|> INotificationSubject
    NotificationService --> NotificationFactory
    NotificationService --> INotification
    NotificationService --> INotificationSendStrategy
    NotificationService --> NotificationEvent
    NotificationService --> INotificationObserver

    INotification <|.. EmailNotification
    INotification <|.. PushNotification
    INotification <|.. SmsProviderAdapter

    SmsProviderAdapter --> ExternalSmsProvider

    NotificationFactory <|-- EmailNotificationFactory
    NotificationFactory <|-- SmsNotificationFactory
    NotificationFactory <|-- PushNotificationFactory

    EmailNotificationFactory --> EmailNotification
    SmsNotificationFactory --> SmsProviderAdapter
    PushNotificationFactory --> PushNotification

    INotificationSendStrategy <|.. NormalSendStrategy
    INotificationSendStrategy <|.. PrioritySendStrategy
    INotificationSendStrategy <|.. SilentSendStrategy

    INotificationObserver <|.. LogObserver
    INotificationObserver <|.. ReportObserver

    LogObserver --> NotificationEvent
    ReportObserver --> NotificationEvent
```

---

## Kısa Açıklama

Faz 3'te sisteme iki Behavioral Pattern eklenmiştir.

İlk olarak **Strategy Pattern** kullanılmıştır. Bildirimlerin nasıl gönderileceği `INotificationSendStrategy` arayüzü ile soyutlanmıştır. `NormalSendStrategy`, `PrioritySendStrategy` ve `SilentSendStrategy` sınıfları farklı gönderim davranışlarını temsil etmektedir.

Bu yapı sayesinde yeni bir gönderim davranışı eklemek için mevcut servis sınıfını değiştirmek yerine yeni bir strategy sınıfı eklemek yeterli olur. Bu durum Açık/Kapalı Prensibini göstermektedir.

İkinci olarak **Observer Pattern** kullanılmıştır. `NotificationService` sınıfı bildirim gönderildikten sonra sisteme bağlı observer sınıflarını bilgilendirir. `LogObserver` ve `ReportObserver` sınıfları bildirim sonrası loglama ve raporlama işlemlerini otomatik olarak yürütür.

Bu faz sonunda sistem davranış açısından daha genişletilebilir hale gelmiştir.