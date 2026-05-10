\# Kullanılan Tasarım Örüntüleri



Bu dosyada projede kullanılan tasarım örüntüleri fazlara göre açıklanmıştır. Her örüntü için hangi problemden dolayı kullanıldığı, projede nerede uygulandığı ve koda ne kazandırdığı belirtilmiştir.





\## Faz 1 - Factory Method



\### Kullanıldığı Yer



Factory Method örüntüsü bildirim nesnelerinin oluşturulması için kullanılmıştır.



Projede aşağıdaki sınıflar bu yapıyı oluşturur:



\-  INotification

\-   EmailNotification

\- SmsNotification

\- PushNotification

\-   NotificationFactory

\- EmailNotificationFactory

\- SmsNotificationFactory

\- PushNotificationFactory



Başlangıç kodunda e-posta, SMS ve push bildirimleri NotificationService sınıfı içinde `if-else` bloklarıyla seçiliyordu. Faz 1'de bu yapı değiştirilerek bildirim nesnesi oluşturma sorumluluğu Factory sınıflarına taşındı.



\### Neden Kullanıldı?



Başlangıç kodunda NotificationService sınıfı hem bildirim türünü seçiyor hem de bildirimi gönderiyordu. Bu durum sınıfın fazla sorumluluk almasına neden oluyordu.

Yeni bir bildirim türü eklemek istediğimde NotificationService sınıfının içindeki if-else yapısını değiştirmem gerekiyordu. Bu da kodun genişletilmesini zorlaştırıyordu.



Factory Method kullanılarak nesne oluşturma işlemi ayrı bir yapıya taşındı. Böylece NotificationService sınıfı hangi bildirimin nasıl oluşturulacağını bilmek zorunda kalmadı.



\### Ne Kazandırdı?



Bu değişiklikten sonra kod daha düzenli hale geldi. NotificationService artık sadece kendisine verilen factory üzerinden bildirim nesnesini oluşturup gönderme işlemini başlatıyor.



Bu yapı sayesinde:



\- if-else kullanımı azaltıldı.

\- Nesne oluşturma sorumluluğu ayrıldı.

\- Kodun okunabilirliği arttı.

\- Yeni bildirim türü eklemek daha kolay hale geldi.

\- NotificationService sınıfının sorumluluğu azaldı.



Örneğin ileride WhatsApp bildirimi eklemek istersem yeni bir WhatsAppNotification ve WhatsAppNotificationFactory sınıfı oluşturarak sistemi genişletebilirim. Bu durumda mevcut servis sınıfını doğrudan değiştirmem gerekmez.

---

## Faz 2 - Adapter Pattern

### Kullanıldığı Yer

Adapter Pattern, dışarıdan gelen SMS sağlayıcısını sisteme uyumlu hale getirmek için kullanılmıştır.

Projede bu yapı şu sınıflar üzerinden uygulanmıştır:

- ExternalSmsProvider
- SmsProviderAdapter
- INotification

ExternalSmsProvider sınıfı, sistemde kullanılan INotification arayüzüne doğrudan uymamaktadır. Bu sınıfta SMS gönderimi SendSmsMessage(phoneNumber, text) metodu ile yapılmaktadır. Ancak sistemde bildirimler Send(message, receiver) metodu üzerinden çalışmaktadır.

Bu uyumsuzluğu çözmek için SmsProviderAdapter sınıfı oluşturulmuştur.

### Neden Kullanıldı?

Dış SMS sağlayıcısının metot yapısı mevcut bildirim sistemiyle uyumlu değildi. Bu sınıfı doğrudan kullanmak isteseydim mevcut sistem yapısını değiştirmem gerekebilirdi.

Adapter Pattern sayesinde dış servis, mevcut INotification yapısına uygun hale getirildi. Böylece sistemin genel yapısı bozulmadan yeni bir dış SMS sağlayıcısı eklenmiş oldu.

### Ne Kazandırdı?

Bu örüntü sayesinde dış servis sisteme uyarlanmış oldu. Mevcut bildirim yapısı korunurken, farklı bir SMS sağlayıcısı sisteme dahil edildi.

Bu yapı sayesinde:

- Dış servis sisteme uyumlu hale getirildi.
- Mevcut `INotification` yapısı bozulmadı.
- SMS gönderme işlemi daha esnek hale geldi.
- Yeni dış servislerin eklenmesi daha kolay hale geldi.

---

## Faz 2 - Facade Pattern

### Kullanıldığı Yer

Facade Pattern, bildirim gönderme sürecini daha sade hale getirmek için kullanılmıştır.

Projede bu yapı şu sınıf üzerinden uygulanmıştır:

- NotificationFacade

Başlangıçta Program.cs içinde e-posta, SMS ve push bildirimleri ayrı ayrı çağrılıyordu. Bu kullanım çalışsa da istemci tarafında fazla detay görünmesine neden oluyordu.

NotificationFacade sınıfı eklenerek bu işlemler tek bir metot altında toplandı.

### Neden Kullanıldı?

Bildirim gönderme süreci birden fazla adımdan oluşmaktadır. Kullanıcı kaydı gibi bir durumda e-posta, SMS ve push bildiriminin birlikte gönderilmesi gerekebilir.

Bu işlemleri Program.cs içinde tek tek yazmak yerine, NotificationFacade sınıfı ile daha sade bir kullanım sağlandı.

### Ne Kazandırdı?

Facade Pattern sayesinde istemci tarafındaki kod daha okunabilir hale geldi. `Program.cs`, artık hangi factory sınıfının nasıl çalıştığını bilmek zorunda kalmadı.

Bu yapı sayesinde:

- Kullanım daha sade hale geldi.
- Bildirim gönderme süreci tek bir sınıf üzerinden yönetildi.
- `Program.cs` içindeki karmaşıklık azaldı.
- Alt sistem detayları kullanıcıdan gizlendi.

Örneğin kullanıcı kaydı sonrası tüm bildirimler şu şekilde tek metotla gönderilebilir hale geldi:

```csharp
notificationFacade.SendUserRegistrationNotifications(
    "bilal@soft.com",
    "05550000000",
    "BilalCan"
);