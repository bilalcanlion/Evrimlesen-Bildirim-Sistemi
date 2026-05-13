# \# Evrimleşen Bildirim Sistemi

# 

# Bu proje, Yazılım Tasarım Örüntüleri dersi kapsamında geliştirilmiş bir C# Console App projesidir. Projede temel bir bildirim sistemi adım adım geliştirilmiş ve farklı tasarım örüntüleri kullanılarak daha esnek, genişletilebilir ve yönetilebilir hale getirilmiştir.

# 

# Sistem; e-posta, SMS ve push bildirimi gönderebilen basit bir yapıdan başlamış, daha sonra Factory Method, Adapter, Facade, Strategy ve Observer örüntüleriyle geliştirilmiştir.

# 

# \---

# 

# \## Projenin Amacı

# 

# Bu projenin amacı, bir bildirim sistemini tasarım örüntüleri kullanarak aşamalı şekilde geliştirmektir.

# 

# Başlangıçta bildirim gönderme işlemleri tek bir sınıf içinde ve daha basit bir yapıyla yönetiliyordu. Daha sonra her fazda farklı tasarım problemleri ele alınarak sistem iyileştirildi.

# 

# Proje sonunda sistem şu özelliklere sahip hale gelmiştir:

# 

# \- Bildirim nesneleri daha düzenli şekilde oluşturulmaktadır.

# \- Dış SMS servisi mevcut sisteme uyumlu hale getirilmiştir.

# \- Bildirim gönderme süreci daha sade bir arayüz üzerinden yönetilmektedir.

# \- Farklı gönderim davranışları ayrı sınıflar halinde uygulanmıştır.

# \- Bildirim gönderildikten sonra loglama ve raporlama işlemleri otomatik çalışmaktadır.

# \- Yeni davranış eklemek için mevcut kodu sürekli değiştirmeye gerek kalmamaktadır.

# 

# \---

# 

# \## Kullanılan Tasarım Örüntüleri

# 

# \### 1. Factory Method

# 

# Factory Method, bildirim nesnelerinin oluşturulmasını düzenlemek için kullanılmıştır.

# 

# Projede e-posta, SMS ve push bildirimleri için ayrı factory sınıfları oluşturulmuştur. Böylece `NotificationService` sınıfı hangi bildirimin nasıl oluşturulduğunu bilmek zorunda kalmamıştır.

# 

# Kullanılan yapılar:

# 

# \- `NotificationFactory`

# \- `EmailNotificationFactory`

# \- `SmsNotificationFactory`

# \- `PushNotificationFactory`

# 

# \---

# 

# \### 2. Adapter

# 

# Adapter Pattern, dışarıdan gelen SMS sağlayıcısını mevcut sisteme uyumlu hale getirmek için kullanılmıştır.

# 

# `ExternalSmsProvider` sınıfı sistemdeki `INotification` arayüzüne doğrudan uymadığı için `SmsProviderAdapter` sınıfı oluşturulmuştur.

# 

# Kullanılan yapılar:

# 

# \- `ExternalSmsProvider`

# \- `SmsProviderAdapter`

# \- `INotification`

# 

# \---

# 

# \### 3. Facade

# 

# Facade Pattern, bildirim gönderme sürecini daha sade hale getirmek için kullanılmıştır.

# 

# `NotificationFacade` sınıfı sayesinde `Program.cs` içinde e-posta, SMS ve push bildirimleri tek tek çağrılmak yerine daha sade bir metot üzerinden yönetilmiştir.

# 

# Kullanılan yapı:

# 

# \- `NotificationFacade`

# 

# \---

# 

# \### 4. Strategy

# 

# Strategy Pattern, bildirimlerin nasıl gönderileceğini ayrı davranış sınıflarına ayırmak için kullanılmıştır.

# 

# Bu sayede normal gönderim, öncelikli gönderim ve sessiz gönderim gibi davranışlar ayrı sınıflar halinde tanımlanmıştır.

# 

# Kullanılan yapılar:

# 

# \- `INotificationSendStrategy`

# \- `NormalSendStrategy`

# \- `PrioritySendStrategy`

# \- `SilentSendStrategy`

# 

# Bu yapı Açık/Kapalı Prensibine de örnek oluşturmaktadır. Yeni bir gönderim davranışı eklemek için mevcut servis sınıfını değiştirmek yerine yeni bir strategy sınıfı eklenebilir.

# 

# \---

# 

# \### 5. Observer

# 

# Observer Pattern, bildirim gönderildikten sonra otomatik çalışacak işlemleri yönetmek için kullanılmıştır.

# 

# Bildirim gönderildiğinde loglama ve raporlama işlemleri otomatik olarak tetiklenmektedir.

# 

# Kullanılan yapılar:

# 

# \- `NotificationEvent`

# \- `INotificationObserver`

# \- `LogObserver`

# \- `ReportObserver`

# \- `INotificationSubject`

# 

# \---

# 

# \## Mimari Diyagram

# 

# Aşağıdaki diyagram, projenin son mimari yapısını genel olarak göstermektedir.

# 

# ```mermaid

# flowchart TD

# &#x20;   Program --> NotificationFacade

# &#x20;   NotificationFacade --> NotificationService

# 

# &#x20;   NotificationService --> NotificationFactory

# &#x20;   NotificationFactory --> EmailNotificationFactory

# &#x20;   NotificationFactory --> SmsNotificationFactory

# &#x20;   NotificationFactory --> PushNotificationFactory

# 

# &#x20;   EmailNotificationFactory --> EmailNotification

# &#x20;   SmsNotificationFactory --> SmsProviderAdapter

# &#x20;   SmsProviderAdapter --> ExternalSmsProvider

# &#x20;   PushNotificationFactory --> PushNotification

# 

# &#x20;   NotificationService --> INotificationSendStrategy

# &#x20;   INotificationSendStrategy --> NormalSendStrategy

# &#x20;   INotificationSendStrategy --> PrioritySendStrategy

# &#x20;   INotificationSendStrategy --> SilentSendStrategy

# 

# &#x20;   NotificationService --> INotificationObserver

# &#x20;   INotificationObserver --> LogObserver

# &#x20;   INotificationObserver --> ReportObserver

# ```

# 

# Detaylı UML diyagramları için:

# 

# \- `docs/diagrams/phase1-uml.md`

# \- `docs/diagrams/phase2-uml.md`

# \- `docs/diagrams/phase3-uml.md`

# 

# \---

# 

# \## Proje Klasör Yapısı

# 

# ```text

# Evrimlesen-Bildirim-Sistemi

# ├── src

# │   └── NotificationSystem

# │       ├── Program.cs

# │       └── NotificationSystem.csproj

# ├── docs

# │   ├── ai-log

# │   │   ├── phase1.md

# │   │   ├── phase2.md

# │   │   └── phase3.md

# │   └── diagrams

# │       ├── phase1-uml.md

# │       ├── phase2-uml.md

# │       └── phase3-uml.md

# ├── PATTERNS.md

# ├── PROBLEMS.md

# ├── README.md

# └── .gitignore

# ```

# 

# \---

# 

# \## Nasıl Çalıştırılır?

# 

# Projeyi çalıştırmak için bilgisayarda .NET SDK kurulu olmalıdır.

# 

# Terminal veya Visual Studio Developer PowerShell üzerinden proje klasörüne girilir:

# 

# ```bash

# cd src/NotificationSystem

# ```

# 

# Ardından proje çalıştırılır:

# 

# ```bash

# dotnet run

# ```

# 

# Visual Studio üzerinden çalıştırmak için:

# 

# 1\. `NotificationSystem.sln` dosyası açılır.

# 2\. Üst menüden `Start` veya `Ctrl + F5` ile proje çalıştırılır.

# 3\. Konsol ekranında bildirim gönderme çıktıları görülür.

# 

# \---

# 

# \## Örnek Çıktı

# 

# Program çalıştırıldığında e-posta, SMS ve push bildirimleri gönderilir. Ayrıca Strategy ve Observer örüntüleri sayesinde gönderim davranışları ve bildirim sonrası işlemler konsolda görülür.

# 

# Örnek olarak:

# 

# ```text

# Normal gönderim stratejisi kullanılıyor.

# E-posta bildirimi gönderiliyor...

# E-posta gönderildi.

# \[LOG] Bildirim gönderildi.

# \[RAPOR] Bildirim rapor sistemine eklendi.

# 

# Öncelikli gönderim stratejisi kullanılıyor.

# Push bildirimi gönderiliyor...

# Push bildirimi gönderildi.

# \[LOG] Bildirim gönderildi.

# \[RAPOR] Bildirim rapor sistemine eklendi.

# ```

# 

# \---

# 

# \## Açık/Kapalı Prensibi

# 

# Projede Açık/Kapalı Prensibi özellikle Strategy Pattern üzerinden gösterilmiştir.

# 

# `SilentSendStrategy` sınıfı yeni bir gönderim davranışı olarak eklenmiştir. Bu davranış eklenirken mevcut bildirim sınıflarının veya genel servis mantığının baştan yazılmasına gerek kalmamıştır.

# 

# Bu durum sistemin yeni davranışlara açık, fakat mevcut çalışan kodu değiştirmeye kapalı olduğunu göstermektedir.

# 

# \---

# 

# \## Fazlara Göre Gelişim

# 

# \### Faz 0

# 

# Başlangıç kodundaki tasarım problemleri incelendi. `PROBLEMS.md` dosyasında mevcut kodun sorunları ve AI analizi karşılaştırıldı.

# 

# \### Faz 1

# 

# Factory Method uygulanarak bildirim nesnelerinin oluşturulması ayrı factory sınıflarına taşındı.

# 

# \### Faz 2

# 

# Adapter ve Facade örüntüleri uygulandı. Dış SMS servisi sisteme uyumlu hale getirildi ve bildirim gönderme süreci sadeleştirildi.

# 

# \### Faz 3

# 

# Strategy ve Observer örüntüleri uygulandı. Bildirim gönderme davranışları ayrıldı ve bildirim sonrası loglama/raporlama işlemleri otomatik hale getirildi.

# 

# \---

# 

# \## AI Kullanımı

# 

# Her fazda AI desteği alınmış, ancak AI cevapları doğrudan kopyalanmamıştır. AI önerileri incelenmiş, proje ihtiyaçlarına göre sadeleştirilmiş ve öğrenci ödevi seviyesine uygun şekilde uygulanmıştır.

# 

# AI kullanım kayıtları şu dosyalarda tutulmuştur:

# 

# \- `docs/ai-log/phase1.md`

# \- `docs/ai-log/phase2.md`

# \- `docs/ai-log/phase3.md`

