# GitHub'a Yükleme Talimatları

## 1. GitHub'da Repository Oluşturun

1. https://github.com adresine gidin
2. Sağ üstteki `+` simgesine tıklayın → `New repository`
3. Repository adı: `predictive-maintenance` (veya istediğiniz isim)
4. **Public** veya **Private** seçin
5. ⚠️ **Initialize with README** seçmeyin (zaten var)
6. **Create repository**'ye tıklayın

## 2. Remote Repository'yi Ekleyin

GitHub'da repo oluşturduktan sonra aşağıdaki komutları çalıştırın:

```bash
# GitHub'ın size verdiği URL'i kullanın (örnek)
git remote add origin https://github.com/KULLANICI_ADINIZ/predictive-maintenance.git

# Veya SSH kullanıyorsanız:
git remote add origin git@github.com:KULLANICI_ADINIZ/predictive-maintenance.git
```

## 3. GitHub'a Push Edin

```bash
# Ana branch'i main olarak ayarlayın (GitHub'ın yeni standartı)
git branch -M main

# GitHub'a push edin
git push -u origin main
```

## 4. Kontrol Edin

GitHub'da repository'nizi açın ve tüm dosyaların yüklendiğini kontrol edin!

---

## ✅ Hazır!

Artık projeniz GitHub'da! 🎉

### Sonraki Adımlar:
- GitHub Pages ile dokümantasyon yayınlayabilirsiniz
- Actions ile CI/CD pipeline kurabilirsiniz
- Issues ve Projects ile proje yönetimi yapabilirsiniz

