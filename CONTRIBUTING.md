# Katkıda Bulunma Rehberi

Predictive Maintenance projesine katkıda bulunmak istediğiniz için teşekkürler! 🎉

## Nasıl Katkıda Bulunabilirsiniz?

### 1) Issue Açma
- Hata (bug) raporları için ayrıntılı açıklama ve tekrarlama adımlarını ekleyin
- Yeni özellik önerileri için beklenen davranışı ve gerekçeyi yazın
- Performans/Docs/Refactor gibi etiketleri kullanın

### 2) Branch Stratejisi
- `main`: her zaman üretime hazır (stable) kod
- `feature/<kısa-öz-isim>`: yeni özellikler (ör: `feature/signalr-dashboard`)
- `fix/<kısa-öz-isim>`: hata düzeltmeleri (ör: `fix/api-nullref`)
- `chore/<kısa-öz-isim>`: bakım/güncelleme (ör: `chore/update-deps`)

### 3) Commit Kuralları (Conventional Commits)
Aşağıdaki önekleri kullanın:
- `feat:` yeni özellik
- `fix:` hata düzeltmesi
- `docs:` dokümantasyon
- `style:` formatlama, noktalama vb. (mantıksal değişiklik yok)
- `refactor:` davranışı değiştirmeden kod düzenleme
- `perf:` performans iyileştirmesi
- `test:` test ekleme/düzeltme
- `chore:` araçlar/bağımlılıklar/CI

Örnek:
```
feat(api): add prediction controller with create/get endpoints
fix(web): handle null prediction status on dashboard
```

### 4) Pull Request (PR) Rehberi
- PR başlığı Conventional Commits formatında olsun
- Kapsam: mümkün olduğunca küçük ve odaklı
- PR açıklamasına şunları ekleyin:
  - Yapılan değişikliklerin özeti
  - İlgili issue numarası (örn. Closes #12)
  - Ekran görüntüsü/GIF (UI değişikliği varsa)
- PR kontrol listesi:
  - [ ] Build başarıyla çalışıyor (`dotnet build`)
  - [ ] Testler çalışıyor (varsa) (`dotnet test`)
  - [ ] Linter/format uygun (editör ayarları)
  - [ ] Dokümantasyon güncellendi (README/Docs)

### 5) Kod Standardı
- Clean Architecture & SOLID
- Anlamlı, açıklayıcı isimlendirme (kısaltmalardan kaçının)
- Gereksiz yorumlardan kaçının; gerekli yerlerde kısa ve net yorum
- Exception yakalama: amaçsız swallow yapmayın
- Controller’ları ince tutun; iş mantığı `Application` servislerinde olsun

### 6) Testler
- Mümkünse public business logic için unit test ekleyin
- Kritik edge-case’leri kapsayın
- Test isimleri: Anlamlı ve davranış odaklı (örn. `Should_ReturnCritical_When_ProbabilityAbove80`)

### 7) Çalıştırma (Yerel)
```bash
# API
dotnet run --project src/Presentation/AygazPredictiveMaintenance.API
# Web
dotnet run --project src/Presentation/AygazPredictiveMaintenance.Web
# Docker (opsiyonel)
cd docker && docker-compose up -d
```

### 8) Sürümleme ve Release
- Semantic Versioning: `vMAJOR.MINOR.PATCH` (örn. `v1.2.3`)
- Yeni sürüm yayınlamak için tag atın:
  ```bash
  git tag v1.0.0
  git push origin v1.0.0
  ```
- GitHub Actions otomatik olarak Release ve versiyonlu Docker imajlarını oluşturur
- Release Drafter PR’lardan otomatik değişiklik günlüğü hazırlar

### 9) Güvenlik
- Güvenlik açıkları için lütfen public issue yerine doğrudan iletişime geçin
- Secrets/connection string gibi gizli verileri repoya koymayın

---
Teşekkürler! Katkılarınız projeyi ileri taşıyor. 🙏

