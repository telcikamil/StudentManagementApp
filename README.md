Öğrenci Kayıt Yönetimi
Öğrenci Kayıt Yönetiminde öğrenci bilgileri, dersler ve başarı notları tutulur öğrenci ekleme, silme, güncelleme ve listeleme işlemleri yapılabilir.

Kullanılan Teknolojiler:
-SQL-Lite
-.Net Core 7.0
-Ef Core Code First

Kullanılan mimari
 N-Tier Architecture kullanılarak proje 4 katmanda oluşturuldu:
 -Business Logic Layer Katmanında Serviceler.(Projenin ilerki aşamalarında mapper kullanılabilmesi için temel oluşturuldu)
 -Data Access Layer Katmanında DbContext ve Repositoriler
 -Model katmanında Entitiler
 -API katmanı

Ana Özellikler
Sistemde:
-  Öğrenci ekleme işlemi
-  Öğrenci silme işlemi
-  Öğrenci bilgileri güncelleme işlemi
-  Öğrencilerin Profil Doluluk oranlarını görebilme
-  Öğrencilerin Profil doluluk oranlarına göre en yüksekten en düşüğe göre listeleme işlemi
Yapılabilir.

