\# Phase 1 AI Log



\## Bu Fazda Ne Yapıldı?



Bu fazda başlangıç kodundaki bildirim oluşturma problemi ele alındı. İlk kodda e-posta, SMS ve push bildirimleri NotificationService sınıfı içinde if-else bloklarıyla seçiliyordu. Bu yapı küçük bir örnek için çalışsa da yeni bir bildirim türü eklendiğinde mevcut sınıfı değiştirmeyi gerektiriyordu.



Bu sorunu çözmek için Creational Design Pattern grubundan \*\*Factory Method\*\* kullanıldı. Bildirim nesnesi oluşturma sorumluluğu NotificationService sınıfından alınarak ayrı Factory sınıflarına taşındı.



\## AI'a Sorduğum Prompt



Factory Method uygulamasını yaptıktan sonra Gemini'den kod review istedim. Sorduğum prompt genel olarak şu şekildeydi:



> C# Console App ile Yazılım Tasarım Örüntüleri dersi için Bildirim Sistemi projesi yapıyorum. Faz 1'de Creational Design Pattern olarak Factory Method uyguladım. Başlangıçta NotificationService içinde if-else vardı. Şimdi bildirim nesnelerinin oluşturulmasını Factory sınıflarına ayırdım. Kodumu Factory Method kullanımı, sorumluluk ayrımı, sadelik ve öğrenci ödevi seviyesine uygunluk açısından inceleyebilir misin?



\## AI'ın Cevabının Özeti



Gemini, Factory Method kullanımının bu proje için uygun olduğunu belirtti. Kodda INotification arayüzünün Product rolünde,NotificationFactory yapısının ise Creator rolünde olduğunu söyledi. Ayrıca EmailNotificationFactory,SmsNotificationFactory ve PushNotificationFactory sınıflarının nesne oluşturma sorumluluğunu ayrı ayrı üstlendiğini ifade etti.



Gemini'ye göre bu değişiklikten sonra NotificationService sınıfının sorumluluğu azaldı. Önceki yapıda servis sınıfı hem bildirim türüne karar veriyor hem de bildirimi gönderiyordu. Yeni yapıda ise servis sınıfı sadece factory tarafından oluşturulan bildirimi çalıştırıyor.AI ayrıca kodun öğrenci ödevi seviyesinde sade ve anlaşılır olduğunu belirtti. Faz 1 için gereksiz karmaşık bir yapı kurulmadığını söyledi.



\## Benim Uyguladığım Kısım



Bu fazda aşağıdaki yapıları oluşturdum:



\- INotification arayüzü

\- EmailNotification, SmsNotification,PushNotification sınıfları

\- NotificationFactory soyut sınıfı

\- EmailNotificationFactory, SmsNotificationFactory,PushNotificationFactory sınıfları

\- Daha sade hale getirilmiş NotificationService sınıfı



Başlangıç kodunda NotificationService içinde yer alan if-else bloklarını kaldırdım. Bildirim nesnesinin nasıl oluşturulacağı artık servis sınıfının görevi değil. Bu sorumluluk Factory sınıflarına taşındı.



AI'dan Farklı Olarak Ne Yaptım?



Gemini genel olarak yapının doğru olduğunu söyledi. Ek olarak NotificationFactory sınıfının abstract class yerine interface olarak da tasarlanabileceğini belirtti. Ancak bu fazda Factory Method mantığını daha açık göstermek için abstract class NotificationFactory yapısını kullanmayı tercih ettim.Bunun nedeni, ödevde Creational Pattern kullanımının net görünmesini istememdir. Factory sınıflarının hangi bildirimi oluşturduğu daha anlaşılır şekilde ayrılmış oldu.



\*\*\*Bu Fazda Ne Kazanıldı?\*\*\*\*



Bu fazdan sonra kod daha düzenli hale geldi. Yeni bir bildirim türü eklemek istediğimde doğrudan NotificationService sınıfının içini değiştirmek yerine yeni bir bildirim sınıfı ve ona ait factory sınıfı ekleyebilirim.Bu yapı, başlangıç kodundaki nesne oluşturma karmaşasını azaltmıştır. Ayrıca kodun okunabilirliği artmış ve sorumluluklar daha net ayrılmıştır.

