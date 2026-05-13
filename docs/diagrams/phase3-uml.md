# Phase 3 UML / Mimari Diyagramı

Bu dosyada Faz 3 sonrasında sistemin güncellenmiş mimari yapısı gösterilmiştir.  
Bu fazda Behavioral Design Pattern grubundan **Strategy** ve **Observer** örüntüleri uygulanmıştır.

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

class NotificationEvent {
    +NotificationType
    +Receiver
    +StrategyName
}

Program --> NotificationFacade
NotificationFacade --> NotificationService

NotificationService --> NotificationFactory
NotificationFactory <|-- EmailNotificationFactory
NotificationFactory <|-- SmsNotificationFactory
NotificationFactory <|-- PushNotificationFactory

EmailNotificationFactory --> EmailNotification
SmsNotificationFactory --> SmsProviderAdapter
PushNotificationFactory --> PushNotification

INotification <|.. EmailNotification
INotification <|.. PushNotification
INotification <|.. SmsProviderAdapter

SmsProviderAdapter --> ExternalSmsProvider

NotificationService --> INotificationSendStrategy
INotificationSendStrategy <|.. NormalSendStrategy
INotificationSendStrategy <|.. PrioritySendStrategy
INotificationSendStrategy <|.. SilentSendStrategy

NotificationService --> INotificationObserver
INotificationObserver <|.. LogObserver
INotificationObserver <|.. ReportObserver

NotificationService --> NotificationEvent
```

## Kısa Açıklama

Faz 3'te sisteme iki Behavioral Pattern eklenmiştir.

İlk olarak **Strategy Pattern** kullanılmıştır. Bildirimlerin nasıl gönderileceği `INotificationSendStrategy` arayüzü ile soyutlanmıştır. `NormalSendStrategy`, `PrioritySendStrategy` ve `SilentSendStrategy` sınıfları farklı gönderim davranışlarını temsil etmektedir.

İkinci olarak **Observer Pattern** kullanılmıştır. `NotificationService` sınıfı bildirim gönderildikten sonra observer sınıflarına haber verir. `LogObserver` ve `ReportObserver` sınıfları bildirim sonrası loglama ve raporlama işlemlerini otomatik olarak yürütür.

Bu faz sonunda sistem davranış açısından daha genişletilebilir hale gelmiştir.