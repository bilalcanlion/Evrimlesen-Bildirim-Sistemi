\# Başlangıç Kodundaki Tasarım Problemleri



Bu aşamada bildirim sistemi tasarım örüntüsü kullanılmadan, basit bir öğrenci projesi mantığıyla yazılmıştır. Kod çalışmaktadır ancak sistem büyüdükçe bakım ve geliştirme açısından bazı sorunlar oluşturabilecek bir yapıdadır.



\## Benim Gördüğüm Tasarım Sorunları



&#x20;1. Tüm bildirim işlemleri tek sınıfta toplanmış



`NotificationService` sınıfı hem e-posta, hem SMS, hem de push bildirimi göndermekten sorumludur. Bu durum sınıfın gereğinden fazla sorumluluk almasına neden olur.



&#x20;2. if-else yapısı fazla kullanılmış



Bildirim türü `if-else` bloklarıyla seçilmektedir. Bildirim türü arttıkça bu yapı daha da uzayacak ve kodun okunması zorlaşacaktır.



&#x20;3. Yeni bildirim türü eklemek mevcut kodu değiştirmeyi gerektiriyor



Örneğin sisteme WhatsApp bildirimi eklemek istersem `NotificationService` sınıfının içine yeni bir `else if` bloğu eklemem gerekir. Bu durum Açık/Kapalı Prensibine uygun değildir.



&#x20;4. Kod test etmeye uygun değil



Tüm bildirim türleri aynı metot içinde olduğu için sadece e-posta ya da sadece SMS davranışını ayrı ayrı test etmek zorlaşır. Kod küçükken sorun gibi görünmese de sistem büyüdükçe bu durum problem oluşturur.



5\. Sınıfın sorumluluğu net değil



`NotificationService` hem bildirim türünü kontrol ediyor hem de bildirim gönderme işlemini yapıyor. Bu yüzden sınıfın tek bir görevi yoktur.



&#x20;6. Kod tekrarına açık bir yapı var



Her bildirim türünde benzer şekilde alıcı ve mesaj bilgisi ekrana yazdırılıyor. Bu yapı ileride tekrar eden kodların artmasına neden olabilir.



\## AI Analizi



Bu bölüme Gemini'den alınan analiz özeti eklenecektir.



\## Benim Analizim ile AI Analizinin Karşılaştırması



Bu bölüme kendi gördüğüm problemler ile Gemini'nin gördüğü problemleri karşılaştırarak ekleyeceğim.

