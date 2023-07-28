# Öğrenci Kayıt Yönetimi

Bu proje, öğrenci bilgileri, dersler ve başarı notları tutmak için kullanılan bir öğrenci kayıt yönetim sistemidir. Proje, öğrenci ekleme, silme, güncelleme ve listeleme işlemlerini sağlamaktadır.

## Kullanılan Teknolojiler

- SQL-Lite: Veritabanı olarak kullanılmıştır.
- .NET Core 7.0: Proje .NET Core 7.0 versiyonuyla geliştirilmiştir.
- EF Core Code First: Entity Framework Core Code First yöntemi ile veritabanı ve tablolar oluşturulmuştur.

## Kullanılan Mimari

Proje, N-Tier Architecture mimarisi kullanılarak 4 katmanda oluşturulmuştur:
- Business Logic Layer: Servislerin bulunduğu katmandır. (Projenin ileriki aşamalarında mapper kullanılabilmesi için temel oluşturulmuştur)
- Data Access Layer: DbContext ve Repositorilerin bulunduğu katmandır.
- Model Katmanı: Entitilerin bulunduğu katmandır.
- API Katmanı: RESTful API sağlayan katmandır.

## Ana Özellikler

Bu öğrenci kayıt yönetim sisteminde aşağıdaki işlemler yapılabilmektedir:

- Öğrenci Ekleme: Yeni bir öğrenci eklemek için kullanılır.
- Öğrenci Silme: Varolan bir öğrenciyi silmek için kullanılır.
- Öğrenci Bilgileri Güncelleme: Mevcut öğrenci bilgilerini güncellemek için kullanılır.
- Öğrencilerin Profil Doluluk Oranlarını Görebilme: Her öğrencinin profil doluluk oranını görmek için kullanılır.
- Öğrencilerin Profil Doluluk Oranlarına Göre Sıralama: Öğrencileri profil doluluk oranlarına göre en yüksekten en düşüğe sıralamak için kullanılır.

## Repository Pattern Kullanımı

Bu proje, veri erişim katmanında repository pattern kullanarak veritabanı işlemlerini yönetmektedir. Repository pattern, veri erişim katmanını soyutlamak ve veri tabanı işlemlerini daha düzenli ve kolay yönetilebilir hale getirmek amacıyla kullanılmaktadır.

Repository pattern ile oluşturulan veri erişim sınıfları (repository'ler) tüm CRUD işlemleri (Create, Read, Update, Delete) için asenkron metotları desteklemektedir. Asenkron metotlar, veritabanı işlemlerinin beklenmedik uzun sürelerde çalıştığı durumlarda, uygulamanın paralel olarak diğer işlemleri de yürütebilmesine olanak tanır ve performansı artırır.

Örneğin, "StudentRepository" sınıfı içindeki metotlar (AddAsync, DeleteAsync, UpdateAsync vb.), veritabanı işlemlerini asenkron olarak gerçekleştirir. Bu sayede, öğrenci ekleme, silme, güncelleme ve listeleme gibi işlemler paralel olarak yürütülerek uygulamanın daha hızlı ve etkin çalışmasına olanak sağlar.

Projemizde asenkron metotlar kullanarak veritabanı işlemlerini gerçekleştirdiğimiz için, kullanıcılar ve istemciler ile daha iyi bir kullanıcı deneyimi sunabiliyoruz. Bu sayede, veri tabanı işlemleri yoğun olduğunda bile uygulama performansının düşmemesi ve hızlı yanıtlar alınması sağlanmış oluyor.

Repository pattern kullanımı, kodun daha sürdürülebilir, test edilebilir ve değiştirilebilir olmasına yardımcı olmaktadır. Ayrıca, iş katmanını ve veri erişim katmanını daha iyi ayırmak ve gelecekte veritabanı teknolojilerini değiştirmek için kolaylık sağlamaktadır.

Bu proje, veri erişim katmanında repository pattern kullanarak veritabanı işlemlerini yönetmektedir. Repository pattern, veri tabanı işlemlerini daha düzenli ve kolay yönetilebilir hale getirmek amacıyla kullanılırken, asenkron metotlar kullanılarak veritabanı işlemleri daha verimli ve performanslı bir şekilde gerçekleştirilir.


