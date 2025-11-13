# 🚗 Predictive Maintenance System

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Python](https://img.shields.io/badge/Python-3.11-3776AB?style=for-the-badge&logo=python)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Endüstriyel IoT ve Makine Öğrenmesi Tabanlı Akıllı Bakım & Arıza Tahmin Sistemi**

[Özellikler](#-özellikler) • [Kurulum](#-kurulum) • [Kullanım](#-kullanım) • [API Dokümantasyonu](#-api-dokümantasyonu) • [Teknolojiler](#-teknoloji-stack)

</div>

---

## 📋 Proje Özeti

**Predictive Maintenance (Akıllı Bakım & Arıza Tahmin Sistemi)**, üretim ve dağıtım tesislerindeki pompa, vana, basınç sensörü, motor gibi ekipmanların arızalanmadan önce tespit edilmesini sağlayan endüstriyel IoT ve makine öğrenmesi tabanlı bir sistemdir.

### 🎯 Proje Amacı

IoT sensör verileri ve makine öğrenmesi (ML/DL) kullanarak ekipman arızalarını erken tahmin edip bakım maliyetini azaltmak, arıza kaynaklı duruş sürelerini minimize etmek ve dijital dönüşüm vizyonuna katkıda bulunmak.

### 💼 Katma Değer

- ✅ **Arıza kaynaklı duruş sürelerini %60-80 oranında azaltır**
- ✅ **Bakım planlamasını otomatikleştirir** ve maliyetleri düşürür
- ✅ **Öngörülebilir bakım** sayesinde işletme verimliliğini artırır
- ✅ **Endüstri 4.0** ve dijital dönüşüm vizyonuna uygundur
- ✅ **Gerçek zamanlı izleme ve alarm sistemi** ile anında müdahale imkanı

---

## 🏗️ Mimari Yapı

### Clean Architecture

Proje, **Clean Architecture** prensiplerine uygun olarak katmanlı bir yapıda geliştirilmiştir:

```
┌─────────────────────────────────────┐
│      Presentation Layer             │
│  (MVC, SignalR Hub, Controllers)    │
└─────────────────────────────────────┘
           ↓
┌─────────────────────────────────────┐
│      Application Layer              │
│  (Services, DTOs, Business Logic)   │
└─────────────────────────────────────┘
           ↓
┌─────────────────────────────────────┐
│      Domain Layer                   │
│  (Entities, Interfaces, Models)     │
└─────────────────────────────────────┘
           ↓
┌─────────────────────────────────────┐
│      Infrastructure Layer           │
│  (EF Core, SQL Server, RabbitMQ,    │
│   Redis, External APIs)             │
└─────────────────────────────────────┘
```

---

## ⚙️ Teknoloji Stack

### 💻 Full Stack (.NET)

| Teknoloji | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| **.NET Core** | 8.0 | Ana framework |
| **ASP.NET Core MVC** | 8.0 | Web uygulaması |
| **Web API** | 8.0 | RESTful API servisleri |
| **Entity Framework Core** | 8.0 | ORM ve veritabanı yönetimi |
| **SQL Server** | 2022 | Veritabanı |
| **SignalR** | 8.0 | Gerçek zamanlı bildirimler |
| **RabbitMQ** | 3.12 | Mesajlaşma kuyruğu |
| **Redis** | 7.0 | Cache ve session yönetimi |
| **AutoMapper** | 12.0 | Object mapping |
| **Swagger** | 6.5 | API dokümantasyonu |

### 🧠 ML & DL (Python)

| Teknoloji | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| **Python** | 3.11 | ML servisi |
| **TensorFlow** | 2.15 | Deep Learning framework |
| **Keras** | 2.15 | LSTM model geliştirme |
| **Scikit-learn** | 1.3 | Machine Learning algoritmaları |
| **Pandas** | 2.1 | Veri işleme |
| **NumPy** | 1.24 | Numerik hesaplamalar |
| **FastAPI** | 0.104 | Python Web API |
| **Anaconda** | 2023.09 | Virtual environment |

### 🎨 Frontend

| Teknoloji | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| **Bootstrap** | 5.3 | CSS framework |
| **Chart.js** | 4.4 | Grafik görselleştirme |
| **SignalR Client** | 8.0 | Gerçek zamanlı bağlantı |
| **jQuery** | 3.7 | DOM manipülasyonu |
| **AJAX** | - | Asenkron istekler |

### 🔧 DevOps & Tools

| Teknoloji | Kullanım Amacı |
|-----------|----------------|
| **Docker** | Containerization |
| **Docker Compose** | Multi-container orchestration |
| **Git** | Version control |

---

## 📊 Özellikler

### 1. Gerçek Zamanlı Sensör Takibi
- IoT sensörlerinden (basınç, sıcaklık, titreşim, akım) gelen verilerin anlık olarak işlenmesi
- Web API üzerinden veri alımı
- RabbitMQ ile asenkron veri işleme

### 2. Arıza Tahmini (ML/DL)
- LSTM (Long Short-Term Memory) modeli ile zaman serisi analizi
- Random Forest ile anomali tespiti
- Normal ve anormal (arıza öncesi) verilerin sınıflandırılması
- Arıza olasılık skoru hesaplama (0-100%)

### 3. Web Dashboard
- Gerçek zamanlı ekipman durumu görselleştirme
- Sensor verilerinin grafiklerle gösterilmesi
- Arıza tahmin sonuçları ve alarm sistemi
- Geçmiş analiz raporları

### 4. Alarm ve Bildirim Sistemi
- SignalR ile gerçek zamanlı "Bakım Uyarısı" bildirimleri
- Dashboard'da görsel alarm göstergeleri
- Kritik durumlar için otomatik uyarı

### 5. API Entegrasyonu
- RESTful API ile diğer sistemlere entegrasyon
- ML servisi ile Python API iletişimi
- IoT cihazlarından veri alımı

---

## 🗂️ Proje Yapısı

```
PredictiveMaintenance/
│
├── src/
│   ├── Domain/
│   │   └── PredictiveMaintenance.Domain/
│   │       ├── Entities/           # Domain entities
│   │       └── Interfaces/         # Repository ve service interfaces
│   │
│   ├── Application/
│   │   └── PredictiveMaintenance.Application/
│   │       ├── Services/           # Business logic services
│   │       ├── DTOs/               # Data Transfer Objects
│   │       └── Mappings/           # AutoMapper profiles
│   │
│   ├── Infrastructure/
│   │   └── PredictiveMaintenance.Infrastructure/
│   │       ├── Data/               # DbContext
│   │       ├── Repositories/       # Repository implementations
│   │       └── Services/           # RabbitMQ, Redis, ML Service
│   │
│   └── Presentation/
│       ├── PredictiveMaintenance.API/
│       │   ├── Controllers/        # REST API Controllers
│       │   └── Hubs/               # SignalR Hubs
│       │
│       └── PredictiveMaintenance.Web/
│           ├── Controllers/        # MVC Controllers
│           ├── Views/              # Razor views
│           └── wwwroot/            # Static files
│
├── ml-service/
│   ├── models/                     # ML models
│   ├── services/                   # ML services
│   ├── api/                        # FastAPI endpoints
│   ├── requirements.txt
│   └── main.py
│
├── docker/
│   ├── docker-compose.yml
│   ├── Dockerfile.web
│   └── Dockerfile.ml
│
├── docs/
│   ├── PROJECT_DOCUMENTATION.md
│   ├── API_DOCUMENTATION.md
│   └── ML_MODEL_DOCUMENTATION.md
│
└── README.md
```

---

## 🚀 Kurulum

### Gereksinimler

- .NET 8.0 SDK
- SQL Server 2022
- Redis 7.0
- RabbitMQ 3.12
- Python 3.11
- Anaconda (opsiyonel)
- Docker (opsiyonel)

### Adımlar

#### 1. Repository'yi Klonlayın

```bash
git clone https://github.com/kaganaydogan/predictive-maintenance.git
cd predictive-maintenance
```

#### 2. Veritabanını Yapılandırın

SQL Server'da veritabanı oluşturun ve `appsettings.json` dosyasında connection string'i güncelleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=PredictiveMaintenanceDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#### 3. .NET Bağımlılıklarını Yükleyin

```bash
dotnet restore
```

#### 4. Migration'ları Çalıştırın

```bash
dotnet ef migrations add InitialCreate --project src/Infrastructure/PredictiveMaintenance.Infrastructure
dotnet ef database update --project src/Infrastructure/PredictiveMaintenance.Infrastructure
```

#### 5. ML Servisini Kurun

```bash
cd ml-service
conda create -n predictive-maintenance python=3.11
conda activate predictive-maintenance
pip install -r requirements.txt
```

#### 6. Uygulamayı Çalıştırın

**Terminal 1 - Web Uygulaması:**
```bash
dotnet run --project src/Presentation/PredictiveMaintenance.Web
```

**Terminal 2 - API:**
```bash
dotnet run --project src/Presentation/PredictiveMaintenance.API
```

**Terminal 3 - ML Servisi:**
```bash
cd ml-service
python main.py
```

### Docker ile Çalıştırma

```bash
cd docker
docker-compose up -d
```

---

## 📖 Kullanım

### API Endpoints

#### Equipment (Ekipman)

```http
GET    /api/equipment              # Tüm ekipmanları listele
GET    /api/equipment/{id}         # Belirli bir ekipmanı getir
POST   /api/equipment              # Yeni ekipman ekle
PUT    /api/equipment/{id}         # Ekipman güncelle
DELETE /api/equipment/{id}         # Ekipman sil
GET    /api/equipment/status/{status}  # Duruma göre filtrele
```

#### Sensor Data (Sensör Verisi)

```http
GET    /api/sensordata/equipment/{equipmentId}              # Ekipman sensör verileri
GET    /api/sensordata/equipment/{equipmentId}/range        # Tarih aralığında veri
POST   /api/sensordata                                      # Yeni sensör verisi ekle
GET    /api/sensordata/equipment/{equipmentId}/anomalies    # Anomali tespiti
```

#### Prediction (Tahmin)

```http
POST   /api/prediction                         # Yeni tahmin oluştur
GET    /api/prediction/equipment/{equipmentId} # Ekipman tahminleri
GET    /api/prediction/equipment/{equipmentId}/latest  # Son tahmin
GET    /api/prediction/critical                # Kritik tahminler
```

#### Alert (Uyarı)

```http
GET    /api/alert/unread                       # Okunmamış uyarılar
GET    /api/alert/equipment/{equipmentId}      # Ekipman uyarıları
PUT    /api/alert/{id}/read                    # Uyarıyı okundu olarak işaretle
```

### Örnek API İstekleri

**Yeni Ekipman Ekleme:**
```bash
curl -X POST "https://localhost:5001/api/equipment" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Motor 1",
    "type": "Motor",
    "location": "Üretim Hattı A"
  }'
```

**Sensör Verisi Gönderme:**
```bash
curl -X POST "https://localhost:5001/api/sensordata" \
  -H "Content-Type: application/json" \
  -d '{
    "equipmentId": 1,
    "sensorType": "Temperature",
    "value": 75.5,
    "unit": "Celsius"
  }'
```

**Tahmin Oluşturma:**
```bash
curl -X POST "https://localhost:5001/api/prediction" \
  -H "Content-Type: application/json" \
  -d '{
    "equipmentId": 1,
    "modelType": "LSTM"
  }'
```

---

## 🧪 Test

```bash
# Tüm testleri çalıştır
dotnet test

# Belirli bir test projesi
dotnet test tests/UnitTests
```

---

## 📈 Proje Aşamaları

| Hafta | Yapılacak İş |
|-------|--------------|
| 1-2 | Sensör verisi toplama ve veritabanı entegrasyonu |
| 3-4 | ML modeli eğitimi ve testleri |
| 5-6 | ASP.NET Core API + Web dashboard geliştirme |
| 7 | SignalR bildirim entegrasyonu |
| 8 | Demo, test ve sunum hazırlığı |

---

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Push edin (`git push origin feature/AmazingFeature`)
5. Pull Request açın

---

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.

---

## 👨‍💻 Geliştirici

**Kağan Aydoğan**

- 🎓 Sakarya Üniversitesi Bilgisayar Mühendisliği
- 💻 Full Stack Developer
- 🤖 ML & DL Developer
- 📧 kagan.aydogan@example.com

---

## 📞 İletişim

Sorularınız veya önerileriniz için:

- 📧 Email: kagan.aydogan@example.com
- 💼 LinkedIn: [Kağan Aydoğan](https://linkedin.com/in/kaganaydogan)
- 🐙 GitHub: [@kaganaydogan](https://github.com/kaganaydogan)

---

## 🙏 Teşekkürler

- [.NET Foundation](https://dotnetfoundation.org/)
- [TensorFlow](https://www.tensorflow.org/)
- [FastAPI](https://fastapi.tiangolo.com/)
- Tüm açık kaynak topluluğuna katkılarından dolayı teşekkürler!

---

<div align="center">

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın! ⭐

Made with ❤️ by Kağan Aydoğan

</div>
