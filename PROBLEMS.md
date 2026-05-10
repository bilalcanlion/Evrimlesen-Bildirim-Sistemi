# Başlangıç Kodundaki Tasarım Problemleri



Bu aşamada bildirim sistemi tasarım örüntüsü kullanılmadan, basit bir öğrenci projesi mantığıyla yazılmıştır. Kod çalışmaktadır ancak sistem büyüdükçe bakım ve geliştirme açısından bazı sorunlar oluşturabilecek bir yapıdadır.



## Benim Gördüğüm Tasarım Sorunları



1. Tüm bildirim işlemleri tek sınıfta toplanmış



`NotificationService` sınıfı hem e-posta, hem SMS, hem de push bildirimi göndermekten sorumludur. Bu durum sınıfın gereğinden fazla sorumluluk almasına neden olur.



2. if-else yapısı fazla kullanılmış



Bildirim türü `if-else` bloklarıyla seçilmektedir. Bildirim türü arttıkça bu yapı daha da uzayacak ve kodun okunması zorlaşacaktır.



3. Yeni bildirim türü eklemek mevcut kodu değiştirmeyi gerektiriyor



Örneğin sisteme WhatsApp bildirimi eklemek istersem `NotificationService` sınıfının içine yeni bir `else if` bloğu eklemem gerekir. Bu durum Açık/Kapalı Prensibine uygun değildir.



4. Kod test etmeye uygun değil



Tüm bildirim türleri aynı metot içinde olduğu için sadece e-posta ya da sadece SMS davranışını ayrı ayrı test etmek zorlaşır. Kod küçükken sorun gibi görünmese de sistem büyüdükçe bu durum problem oluşturur.



5\. Sınıfın sorumluluğu net değil



`NotificationService` hem bildirim türünü kontrol ediyor hem de bildirim gönderme işlemini yapıyor. Bu yüzden sınıfın tek bir görevi yoktur.



6. Kod tekrarına açık bir yapı var



Her bildirim türünde benzer şekilde alıcı ve mesaj bilgisi ekrana yazdırılıyor. Bu yapı ileride tekrar eden kodların artmasına neden olabilir.



## AI Analizi

Başlangıç kodunu Gemini'ye gösterdiğimde, kodda özellikle bazı temel tasarım problemleri olduğunu belirtti. Gemini'nin en çok üzerinde durduğu nokta, `NotificationService` sınıfının çok fazla sorumluluk almasıydı. Bu sınıf hem bildirim türünü seçiyor hem de e-posta, SMS ve push bildiriminin nasıl gönderileceğini kendi içinde yönetiyor.

Gemini ayrıca kodda Açık/Kapalı Prensibinin ihlal edildiğini söyledi. Çünkü sisteme yeni bir bildirim türü eklemek istediğimde mevcut `NotificationService` sınıfının içindeki `if-else` yapısını değiştirmem gerekiyor. Bu da kodun büyüdükçe bakımını zorlaştırabilecek bir durumdur.

AI'ın dikkat çektiği diğer bir nokta da `email`, `sms`, `push` gibi string değerlerin doğrudan kullanılmasıydı. Bu tarz kullanımlar yazım hatalarına açık olduğu için ileride hata çıkarabilir. Ayrıca her bildirim türü için ayrı bir sınıf ya da ortak bir arayüz olmadığı için kodun nesne yönelimli yapısı zayıf kalmaktadır.
Gemini bu sorunları çözmek için Factory Method, Strategy, Adapter, Facade ve Observer gibi tasarım örüntülerinin kullanılabileceğini önerdi. Factory Method ile nesne oluşturma işleminin ayrılabileceğini, Strategy ile farklı bildirim davranışlarının ayrı sınıflara bölünebileceğini, Adapter ile dış servislerin sisteme uyarlanabileceğini, Facade ile karmaşık işlemlerin sadeleştirilebileceğini ve Observer ile olay gerçekleştiğinde bildirimlerin otomatik tetiklenebileceğini açıkladı.

## Benim Analizim ile AI Analizinin Karşılaştırması

Benim analizimde daha çok kodun okunabilirliği, `if-else` yapısının artması ve tek sınıfın fazla sorumluluk alması gibi sorunlara odaklandım. Gemini ise bu sorunları daha teknik kavramlarla açıkladı ve SOLID prensipleriyle ilişkilendirdi.
Ben başlangıçta kodun büyüdükçe karışacağını ve yeni bildirim türü eklemenin zorlaşacağını fark ettim. Gemini de aynı noktayı Açık/Kapalı Prensibi üzerinden açıkladı. Bu açıdan benim gördüğüm sorunlarla AI'ın gördüğü sorunlar genel olarak benzerdi.
Fark olarak Gemini, bu problemlerin hangi tasarım örüntüleriyle çözülebileceğini daha net şekilde sınıflandırdı. Örneğin ben `if-else` yapısının sorun olduğunu yazdım, Gemini ise bunun Strategy veya Factory Method ile daha düzenli hale getirilebileceğini belirtti. Ayrıca dış servis entegrasyonu için Adapter, karmaşık işlemleri sadeleştirmek için Facade ve olay bazlı bildirimler için Observer pattern önerdi.
Bu karşılaştırma sonucunda başlangıç kodundaki problemlerin sadece çalışırlıkla ilgili olmadığını, aslında kodun gelecekte nasıl genişletileceğiyle ilgili olduğunu daha net gördüm. Bu yüzden sonraki fazlarda tasarım örüntülerini doğrudan kodu süslemek için değil, başlangıçta tespit edilen gerçek sorunları çözmek için kullanacağım.