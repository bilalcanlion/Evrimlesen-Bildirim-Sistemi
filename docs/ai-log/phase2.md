\* Phase 2 AI Log

\*--- Bu Fazda Ne Yapıldı?

Bu fazda projeye iki tane Structural Design Pattern eklendi:

\- Adapter Pattern

\- Facade Pattern


Faz 1'de Factory Method ile bildirim nesnelerinin oluşturulması ayrı bir yapıya taşınmıştı. Faz 2'de ise sisteme yeni özellikler eklerken mevcut kodu mümkün olduğunca bozmadan ilerlemeye çalıştım.Adapter Pattern ile dışarıdan gelen bir SMS sağlayıcısını kendi sistemimdeki `INotification` yapısına uyumlu hale getirdim. Facade Pattern ile de bildirim gönderme sürecini `Program.cs` tarafında daha sade ve anlaşılır hale getirdim.


\## AI'a Sorduğum Prompt

Faz 2 kodunu yazdıktan sonra Gemini'den kodu değerlendirmesini istedim. Sorduğum prompt genel olarak şu şekildeydi:

> C# Console App ile Yazılım Tasarım Örüntüleri dersi için Bildirim Sistemi projesi yapıyorum. Faz 1'de Factory Method kullandım. Faz 2'de Structural Design Pattern olarak Adapter ve Facade kullandım. Adapter kısmında dışarıdan gelen ExternalSmsProvider sınıfını kendi INotification yapımla uyumlu hale getirmek için SmsProviderAdapter sınıfını oluşturdum. Facade kısmında ise Program.cs tarafındaki bildirim gönderme sürecini sadeleştirmek için NotificationFacade sınıfını ekledim. Bu kullanım doğru mu? Adapter mı daha uygun, yoksa Facade mı? Aralarındaki farkı benim kodum üzerinden açıklar mısın? Eksik, yanlış veya fazla karmaşık gördüğün bir yer varsa belirt.


\## AI'ın Cevabının Özeti


Gemini, Adapter Pattern kullanımının bu proje için uygun olduğunu söyledi. Çünkü `ExternalSmsProvider` sınıfı benim sistemimdeki `INotification` arayüzüyle doğrudan uyumlu değildi. Dış SMS sağlayıcısında `SendSmsMessage(phoneNumber, text)` metodu varken, benim sistemimde bildirimler `Send(message, receiver)` metodu ile çalışıyordu. Bu uyumsuzluğu `SmsProviderAdapter` sınıfı çözdüğü için Adapter kullanımını doğru buldu.

Facade Pattern için de NotificationFacade sınıfının amacına uygun olduğunu belirtti. Çünkü Program.cs tarafında e-posta, SMS ve push bildirimlerini tek tek çağırmak yerine, kullanıcı kaydı bildirimlerini tek bir metot üzerinden yönetmek daha sade bir kullanım sağladı.
Gemini ayrıca Adapter ve Facade patternlerinin birbirinin alternatifi olmadığını söyledi. Adapter daha çok uyumsuz sistemleri birbirine uydurmak için kullanılırken, Facade karmaşık işlemleri daha basit bir arayüz arkasına almak için kullanılır. Bu yüzden bu projede ikisinin birlikte kullanılabileceğini belirtti.



\## Benim Uyguladığım Kısım

Bu fazda önce dış SMS sağlayıcısını temsil eden ExternalSmsProvider sınıfını oluşturdum. Bu sınıf, mevcut INotification arayüzüne uymadığı için doğrudan sistemde kullanılamıyordu.

Bu sorunu çözmek için SmsProviderAdapter sınıfını ekledim. Bu sınıf INotification arayüzünü uyguluyor ve içeride ExternalSmsProvider sınıfını kullanıyor. Böylece dış SMS sağlayıcısı, sistemdeki diğer bildirim türleriyle aynı yapı üzerinden çalışabilir hale geldi.

Daha sonra NotificationFacade sınıfını oluşturdum. Bu sınıf, kullanıcı kaydı gibi bir işlemde gönderilecek e-posta, SMS ve push bildirimlerini tek bir metot altında topladı. Böylece Program.cs tarafındaki kullanım daha sade hale geldi.

\## AI'ın Eksik veya Fazla Bulduğum Önerisi

Gemini genel olarak kodun doğru olduğunu söyledi. Ek olarak `NotificationFacade` içinde factory nesnelerinin doğrudan new ile oluşturulmasının ileride Dependency Injection ile daha esnek hale getirilebileceğini belirtti.


Bu öneri teknik olarak doğru olabilir; ancak bu fazın amacı Structural Pattern uygulamaktı. Projeyi öğrenci ödevi seviyesinde sade tutmak istediğim için Dependency Injection eklemedim. Çünkü bu aşamada fazla karmaşık bir yapı kurmak yerine Adapter ve Facade örüntülerinin net şekilde görünmesi daha önemliydi.


\## Bu Fazda Ne Kazanıldı?

Bu fazdan sonra sistem mevcut kodu çok fazla bozmadan yeni bir dış SMS sağlayıcısını kullanabilir hale geldi. Adapter Pattern sayesinde dış servis sisteme uyumlu hale getirildi.

Facade Pattern sayesinde ise bildirim gönderme süreci daha kolay kullanılabilir hale geldi. `Program.cs` artık alt sistemde hangi factory'nin nasıl çalıştığını bilmek zorunda kalmıyor. Bunun yerine `NotificationFacade` üzerinden daha sade bir kullanım sağlanıyor.Bu yüzden Faz 2 sonunda kod hem genişletilebilirlik hem de kullanım kolaylığı açısından daha iyi bir yapıya kavuştu.

