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

