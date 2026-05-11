\# Phase 3 AI Log



\## Bu Fazda Ne Yapıldı?



Bu fazda projeye iki tane Behavioral Design Pattern eklendi:



\- Strategy Pattern

\- Observer Pattern



Faz 3'te amaç sistemi gerçekten genişletilebilir hale getirmekti. Yani yeni bir davranış eklemek istediğimde mevcut kodu sürekli değiştirmek zorunda kalmamam gerekiyordu.

Bu nedenle Strategy Pattern ile bildirim gönderme davranışlarını ayrı sınıflara ayırdım. Observer Pattern ile de bildirim gönderildikten sonra loglama ve raporlama gibi işlemlerin otomatik çalışmasını sağladım.



\## AI ile Pair Programming Süreci



Bu fazda Gemini ile tek seferlik bir cevap almak yerine, birkaç aşamalı bir pair programming süreci yürüttüm. Önce hangi davranışsal örüntülerin projeye uygun olacağını tartıştım. Daha sonra yazdığım kodu gözden geçirttim, OCP kullanımını kontrol ettirdim ve son olarak README ile GitHub Actions kısmı için fikir aldım.



Bu süreçte AI bana özellikle Strategy, Observer ve OCP ilişkisini daha net kurmamda yardımcı oldu. Ancak bazı önerileri doğrudan uygulamadım; çünkü proje öğrenci ödevi seviyesinde kalmalıydı ve gereksiz karmaşıklıktan kaçınmak istedim.



\---



\## 1. Tur: Pattern Seçimi ve Planlama



İlk aşamada Gemini'ye mevcut proje yapısını gösterdim. Projede daha önce Factory Method, Adapter ve Facade patternlerinin kullanıldığını belirttim. Faz 3 için en az iki Behavioral Design Pattern uygulamam gerektiğini ve ayrıca OCP'yi göstermem gerektiğini söyledim.



AI'a genel olarak şu soruyu sordum:



\-Bu proje için Strategy Pattern ve Observer Pattern uygun olur mu? Strategy hangi problemi çözer, Observer hangi problemi çözer, OCP'yi hangi noktada gösterebilirim?



Gemini, Strategy ve Observer patternlerinin bildirim sistemi için uygun olduğunu belirtti. Strategy Pattern'in bildirimlerin nasıl gönderileceğini farklı davranışlara ayırmak için kullanılabileceğini söyledi. Örneğin normal gönderim, öncelikli gönderim ve sessiz gönderim gibi davranışların ayrı sınıflara alınabileceğini belirtti.

Observer Pattern için ise bildirim gönderildikten sonra loglama, raporlama veya başka sistemlerin otomatik çalıştırılabileceğini söyledi. Bu yaklaşımın bildirim sonrası olayları ana gönderim kodundan ayıracağını belirtti.



\---



\## 2. Tur: Kod Review



Strategy ve Observer kodunu yazdıktan sonra Gemini'den kod review istedim.



AI'a şu konularda değerlendirme yapmasını istedim:



\- Strategy Pattern doğru uygulanmış mı?

\- Observer Pattern doğru uygulanmış mı?

\- NotificationService sınıfının sorumluluğu fazla mı arttı?

\- Kod öğrenci ödevi seviyesinde sade mi?

\- Observer için C# event/delegate yerine interface tabanlı klasik yapı kullanmak doğru mu?

\- Gereksiz karmaşık veya eksik görünen yerler var mı?



Gemini, Strategy Pattern kullanımını doğru buldu. INotificationSendStrategy arayüzü ile gönderim davranışlarının ayrılmasının pattern mantığına uygun olduğunu söyledi. NormalSendStrategy, PrioritySendStrategy ve SilentSendStrategy sınıflarının bu yapı için doğru örnekler olduğunu belirtti.Observer Pattern için de NotificationService sınıfının subject,LogObserver ve ReportObserver sınıflarının observer rolünü üstlendiğini söyledi. Ayrıca NotificationEvent sınıfı ile olay bilgisinin ayrı bir nesne içinde taşınmasını olumlu buldu.Gemini, NotificationService sınıfının sorumluluğunun biraz arttığını söyledi. Çünkü bu sınıf hem bildirim gönderiyor hem de observer listesini yönetiyor. Ancak öğrenci projesi seviyesinde bunun kabul edilebilir olduğunu belirtti. Daha büyük projelerde bu yapının ayrı bir temel sınıfa veya yardımcı sınıfa taşınabileceğini söyledi.



\---



\## 3. Tur: OCP Kontrolü



Daha sonra Gemini'ye Açık/Kapalı Prensibini doğru gösterip göstermediğimi sordum. Özellikle SilentSendStrategy sınıfının OCP için yeterli bir örnek olup olmadığını kontrol ettirdim.



AI'a şu soruyu sordum:



\-SilentSendStrategy sınıfını yeni bir gönderim davranışı olarak ekledim. Bu davranış eklenirken mevcut bildirim sınıflarını değiştirmedim. Bu OCP için yeterli ve doğru bir örnek mi? Observer tarafında da OCP gösterilebilir mi?

Gemini, SilentSendStrategy örneğinin OCP için doğru ve yeterli olduğunu söyledi. Çünkü yeni bir gönderim davranışı eklenirken mevcut NotificationService yapısını if-else ile büyütmek yerine yeni bir strategy sınıfı eklenmiş oldu.



Bunu şu şekilde yorumladım:



\- Sistem yeni davranışlara açık, fakat mevcut çalışan kodu sürekli değiştirmeye kapalıdır.



Gemini ayrıca Observer tarafında da OCP'nin gösterilebileceğini söyledi. Örneğin sisteme ileride SlackObserver veya AdminObserver gibi yeni bir observer eklenirse, mevcut bildirim gönderme motorunu değiştirmeden yeni bir olay dinleyici eklenmiş olur.Bu bilgi mantıklıydı; ancak projede örnek olarak Strategy tarafındaki SilentSendStrategy üzerinden OCP'yi daha net göstermeyi tercih ettim.



\---



\## 4. Tur: README, CI ve Genel Değerlendirme



Son aşamada Gemini'ye README ve GitHub Actions kısmı için soru sordum.



AI'a şu konularda fikir istedim:



\- README'de kullanılan patternler nasıl kısa açıklanmalı?

\- GitHub Actions ile basit bir derleme pipeline yeterli olur mu?

\- AI olmadan bu faz ne kadar sürerdi?

\- AI beni nerede iyi yönlendirdi, nerede gereksiz bilgi verdi?



Gemini, README içinde her patternin hangi problemi çözdüğünü kısa şekilde yazmam gerektiğini söyledi. Factory Method, Adapter, Facade, Strategy ve Observer patternlerinin kısa açıklamalarını vermenin yeterli olacağını belirtti.



GitHub Actions için ise basit bir pipeline'ın öğrenci ödevi için yeterli olduğunu söyledi. dotnet restore ve dotnet build komutlarını çalıştıran bir CI yapısının, projenin derlenebilir olduğunu göstermek için yeterli olacağını belirtti.



AI, bu fazın AI olmadan daha uzun sürebileceğini söyledi. Özellikle patternlerin birbirine nasıl bağlanacağı, OCP'nin nerede gösterileceği ve README açıklamalarının nasıl yazılacağı konusunda AI'ın hız kazandırdığını belirtti.



\## Benim Uyguladığım Kısım



Bu fazda Strategy Pattern için aşağıdaki yapıları oluşturdum:



\- INotificationSendStrategy

\- NormalSendStrategy

\- PrioritySendStrategy

\- SilentSendStrategy



Bu sınıflar bildirimin nasıl gönderileceğini belirlemektedir. Örneğin bazı bildirimler normal gönderilirken, bazıları öncelikli veya sessiz şekilde gönderilebilmektedir.



Observer Pattern için ise şu yapıları oluşturdum:



\- NotificationEvent

\- INotificationObserver

\- LogObserver

\- ReportObserver

\- INotificationSubject



NotificationService sınıfı bildirim gönderildikten sonra observer sınıflarına haber vermektedir. Böylece loglama ve raporlama işlemleri otomatik çalışmaktadır.



\## Açık/Kapalı Prensibi Nasıl Gösterildi?



Açık/Kapalı Prensibini Strategy Pattern üzerinden gösterdim.



Projeye SilentSendStrategy adında yeni bir gönderim davranışı ekledim. Bu davranış eklenirken mevcut bildirim sınıflarını baştan yazmaya gerek kalmadı. Gönderim davranışı ayrı bir sınıf olarak eklendi.



Bu durum şunu gösterir:



\- Sistem yeni davranışlara açık, fakat mevcut kodu sürekli değiştirmeye kapalıdır.



Yani yeni bir gönderim yöntemi eklemek istediğimde mevcut yapıyı bozmak yerine yeni bir Strategy sınıfı ekleyebilirim.



Observer tarafında da benzer bir genişletilebilirlik vardır. İleride sisteme yeni bir observer eklemek istersem, örneğin AdminObserver ya da SlackObserver, mevcut bildirim gönderme mantığını değiştirmeden yeni bir gözlemci sınıfı ekleyebilirim.



\## AI'ın Yanılttığı veya Gereksiz Söylediği Kısım



Gemini genel olarak doğru yönlendirme yaptı. Ancak bazı yerlerde öğrenci projesi için fazla profesyonel sayılabilecek öneriler sundu. Örneğin Dependency Injection, C# event/delegate yapısı veya daha kurumsal mimari ayrımlarından bahsetti.Bu öneriler teknik olarak yanlış değildi, fakat bu ödevde tasarım örüntülerini açıkça göstermek daha önemliydi. Bu yüzden Observer Pattern'i C# event/delegate ile değil, klasik interface tabanlı yapı ile kurdum.Ayrıca Gemini bazı cevaplarında proje ile doğrudan ilgili olmayan kişisel veya konu dışı ifadeler kullandı. Bu kısımları ödev raporuna dahil etmedim ve sadece teknik olarak gerekli olan önerileri dikkate aldım.



\## AI Olmadan Bu Faz Ne Kadar Sürerdi?



AI olmadan bu fazın daha uzun süreceğini düşünüyorum. Özellikle Strategy ve Observer patternlerinin projedeki yerini belirlemek, OCP'yi nerede göstereceğimi netleştirmek ve kodu fazla karmaşıklaştırmadan ilerlemek daha fazla zaman alabilirdi.AI bu fazda bana özellikle fikirleri düzenleme, patternlerin görevlerini ayırma ve raporda neyi vurgulamam gerektiğini belirleme konusunda yardımcı oldu. Yine de kodu doğrudan kopyalamak yerine, kendi proje yapımıza göre sadeleştirerek uyguladım.



\## Bu Fazda Ne Kazanıldı?



Bu faz sonunda sistem daha genişletilebilir hale geldi.

Strategy Pattern sayesinde bildirim gönderme davranışları ayrı sınıflara ayrıldı. Observer Pattern sayesinde bildirim sonrası loglama ve raporlama işlemleri otomatik hale getirildi.



Bu yapı ile sistem yeni davranış eklemeye daha uygun hale geldi ve Açık/Kapalı Prensibi daha net şekilde gösterilmiş oldu.

