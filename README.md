# 👗 Kaira - AI Powered E-Commerce & Admin Platform

![NET 9.0](https://img.shields.io/badge/.NET%209.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-ORM-EA2839?style=for-the-badge&logo=nuget&logoColor=white)
![ViewComponent](https://img.shields.io/badge/ViewComponent-Modular-blue?style=for-the-badge&logo=dotnet&logoColor=white)
![OpenAI](https://img.shields.io/badge/OpenAI-GPT--3.5-412991?style=for-the-badge&logo=openai&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

**Kaira**, .NET 9.0 altyapısı kullanılarak geliştirilmiş, yüksek performanslı **Dapper ORM** ile veri işlemlerini yöneten ve **OpenAI** entegrasyonu ile kullanıcılara akıllı moda önerileri sunan modern bir E-Ticaret ve Yönetim Paneli projesidir.

## 🚀 Proje Hakkında

Bu proje, modern web geliştirme standartlarına uygun olarak **Repository Design Pattern** ve **DTO (Data Transfer Object)** mimarisi üzerine inşa edilmiştir. Arayüz tarafında **ViewComponent** yapısı kullanılarak modülerlik sağlanmış, veri tabanı işlemleri için ise **Raw SQL** performansını sunan Micro-ORM aracı **Dapper** tercih edilmiştir.

Ayrıca proje, sadece bir yönetim paneli olmanın ötesine geçerek, **Yapay Zeka (OpenAI API)** destekli bir "Moda Asistanı" modülü içermektedir.

## ✨ Öne Çıkan Özellikler

* **⚡ Yüksek Performanslı Veri Yönetimi:** Dapper ORM kullanılarak yazılan asenkron SQL sorguları ile maksimum hız.
* **🧩 Modüler UI Mimarisi:** **ViewComponent** teknolojisi kullanılarak parçalanmış, yönetilebilir ve tekrar kullanılabilir arayüz bileşenleri (Navbar, Sidebar, Footer vb.).
* **🤖 AI Moda Asistanı:** OpenAI GPT modelleri entegre edilerek, kullanıcının seçtiği kıyafete uygun kombin önerileri sunan akıllı modül.
* **🔒 Güvenli Yönetim Paneli:** Identity kütüphanesi kullanılmadan, özel olarak yazılmış **Cookie Based Authentication** mekanizması ile güvenli admin girişi.
* **🏗️ Katmanlı Mimari:** Repository Pattern ve DTO kullanımı ile temiz (clean) ve sürdürülebilir kod yapısı.
* **🎨 Modern Arayüz:** Sneat Admin Template ve Bootstrap 5 ile responsive tasarım.

## 🛠️ Teknolojiler ve Mimari

Bu projede kullanılan temel teknoloji ve kütüphaneler:

* **Framework:** ASP.NET Core 9.0 MVC
* **Veri Erişimi:** Dapper (Micro-ORM)
* **Frontend:** ViewComponents, Razor Views, Bootstrap 5
* **Veritabanı:** Microsoft SQL Server
* **DTO Yönetimi:** Data Transfer Objects (Manuel Mapping)
* **AI Entegrasyonu:** OpenAI API (ChatGPT)
* **Auth:** Cookie Authentication Scheme

## 📂 Proje Yapısı (Architecture)

Proje, **Separation of Concerns** (İlgi alanlarının ayrımı) prensibine uygun olarak yapılandırılmıştır:

```csharp
Kaira.WebUI
├── Context          # Dapper SQL Connection Ayarları
├── ViewComponents   # Modüler arayüz parçaları (Layout, Cart, CategoryList vb.)
├── Dtos             # Veri taşıma nesneleri (CreateCategoryDto, ResultProductDto vb.)
├── Repositories     # Veritabanı CRUD işlemleri (Dapper implementation)
├── Controllers      # İş mantığı ve API/View yönlendirmeleri
└── Views            # Razor arayüzleri
```
## 📷 Ekran Görüntüleri
### 🏠 Ana Sayfa ve Responsive Görünüm
<img width="1896" height="822" alt="Ekran görüntüsü 2025-12-14 052108" src="https://github.com/user-attachments/assets/836413fa-b666-4738-b74f-300ee5cf8cb2" />
<img width="1897" height="827" alt="Ekran görüntüsü 2025-12-14 051011" src="https://github.com/user-attachments/assets/27cdc716-33f3-4b14-ab26-c816c0b88daa" />
<img width="1901" height="826" alt="Ekran görüntüsü 2025-12-14 051031" src="https://github.com/user-attachments/assets/3b7ed35d-0b9b-42c2-933e-0cc350f7a445" />
<img width="1896" height="823" alt="Ekran görüntüsü 2025-12-14 051052" src="https://github.com/user-attachments/assets/31a2f213-d361-4dca-aed9-7ed1e29ac466" />
<img width="1894" height="820" alt="Ekran görüntüsü 2025-12-14 051104" src="https://github.com/user-attachments/assets/02db9073-46b7-41eb-ad56-6ca6f2239551" />
<img width="1896" height="829" alt="Ekran görüntüsü 2025-12-14 051127" src="https://github.com/user-attachments/assets/6ecde6cd-920a-45ac-afec-1427936c59e6" />
<img width="1894" height="824" alt="Ekran görüntüsü 2025-12-14 051138" src="https://github.com/user-attachments/assets/5396ac8e-4f5e-4be8-8d10-4daa57b83608" />
<img width="1896" height="825" alt="Ekran görüntüsü 2025-12-14 051209" src="https://github.com/user-attachments/assets/21c6e15a-807b-4184-9f5e-7dff0fab2de6" />

### 🤖 Yapay Zeka Entegrasyonu
<img width="1896" height="822" alt="Ekran görüntüsü 2025-12-14 051159" src="https://github.com/user-attachments/assets/eb0a2ed1-7151-4402-b362-d12b167893cd" />

## Giriş Ekranı
<img width="1918" height="825" alt="Ekran görüntüsü 2025-12-14 052121" src="https://github.com/user-attachments/assets/8716ba67-d693-4c1e-b947-17d4d8a2157f" />

### 📊 Admin Paneli
<img width="1919" height="823" alt="Ekran görüntüsü 2025-12-14 053215" src="https://github.com/user-attachments/assets/aada1f35-6a51-4c87-9a5c-300aa74e3063" />
<img width="1891" height="789" alt="Ekran görüntüsü 2025-12-14 053228" src="https://github.com/user-attachments/assets/6fe94c67-c84d-4735-8096-2183616edf07" />
<img width="1919" height="824" alt="Ekran görüntüsü 2025-12-14 053235" src="https://github.com/user-attachments/assets/429dc2eb-2353-48c0-ad57-0ab07d6149c7" />
<img width="1919" height="821" alt="Ekran görüntüsü 2025-12-14 053242" src="https://github.com/user-attachments/assets/46897abd-7b0a-487a-8c67-5a2818f93412" />
<img width="1919" height="826" alt="Ekran görüntüsü 2025-12-14 053248" src="https://github.com/user-attachments/assets/627c1691-ff28-4347-93bc-47fddc6c739a" />
<img width="1919" height="819" alt="Ekran görüntüsü 2025-12-14 053254" src="https://github.com/user-attachments/assets/40a55e17-77ee-44e8-9680-06b6d884b46b" />
