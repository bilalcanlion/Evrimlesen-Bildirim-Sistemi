# Phase 2 UML / Mimari Diyagramı

Bu dosyada Faz 2 sonrasında sistemin güncellenmiş mimari yapısı gösterilmiştir. Bu fazda Structural Design Pattern grubundan **Adapter** ve **Facade** örüntüleri uygulanmıştır.

---

## Faz 2 Sonrası UML Diyagramı

```mermaid
classDiagram
    class Program {
        +Main(string[] args)
    }

    class NotificationFacade {
        -NotificationService _notificationService
        +SendUserRegistrationNotifications(string email, string phoneNumber, string userName)
    }

    class NotificationService {
        +SendNotification(NotificationFactory factory, string message, string receiver)
    }

    class INotification {
        <<interface>>
        +Send(string message, string receiver)
    }

    class EmailNotification {
        +Send(string message, string receiver)
    }

    class PushNotification {
        +Send(string message, string receiver)
    }

    class ExternalSmsProvider {
        +SendSmsMessage(string phoneNumber, string text)
    }

    class SmsProviderAdapter {
        -ExternalSmsProvider _externalSmsProvider
        +Send(string message, string receiver)
    }

    class NotificationFactory {
        <<abstract>>
        +CreateNotification() INotification
    }

    class EmailNotificationFactory {
        +CreateNotification() INotification
    }

    class SmsNotificationFactory {
        +CreateNotification() INotification
    }

    class PushNotificationFactory {
        +CreateNotification() INotification
    }

    Program --> NotificationFacade
    NotificationFacade --> NotificationService

    NotificationService --> NotificationFactory
    NotificationService --> INotification

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