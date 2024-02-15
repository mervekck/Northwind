# Northwind Veritabanı Üzerinde CRUD İşlemleri: Product Tablosu

Bu proje, C# MVC (Model-View-Controller) mimarisi kullanılarak geliştirilmiş ve Microsoft SQL Server üzerinde bulunan Northwind veritabanındaki Product tablosu üzerinde CRUD (Create, Read, Update, Delete) ve Detay işlemlerinin gerçekleştirildiği bir örnektir.

# Fonksiyonlar:

- Create (Oluşturma): Yeni ürünler ekleyebilirsiniz.
- Read (Okuma): Mevcut ürünleri listeleyebilirsiniz.
- Update (Güncelleme): Varolan ürünlerin bilgilerini güncelleyebilirsiniz.
- Delete (Silme): Ürünleri veritabanından silebilirsiniz.

# Kullanım:

- Projeyi Visual Studio 2022 de C# IDE'sinde yaptım.
- appsettings.json dosyasında, SQL Server veritabanı bağlantı dizesini oluşturdum.
- Veritabanı bağlantısı ve tablo yapılandırmasını yaptım.
- İlgili Controller ve Views dosyalarını kullanarak CRUD işlemlerini gerçekleştirdim.

# Notlar:

- SQL Server veritabanı bağlantısını güncellemek için appsettings.json dosyasında ConnectionStrings bölümünü düzenleyin.
- Veritabanı işlemleri yapmadan önce, bağlantı ayarlarınızı doğru bir şekilde yapılandırdığınızdan emin olun.
- CRUD işlemlerini gerçekleştirmek için uygun yetkilere sahip olduğunuzdan emin olun.

# Gereksinimler:

- Visual Studio 2022
- .NET 7.0 SDK 
- Microsoft SQL Server
