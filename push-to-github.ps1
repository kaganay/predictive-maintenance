# GitHub'a Yükleme Scripti
# Kullanım: .\push-to-github.ps1 -GitHubUsername "KULLANICI_ADINIZ"

param(
    [Parameter(Mandatory=$true)]
    [string]$GitHubUsername,
    
    [string]$RepoName = "predictive-maintenance"
)

$RemoteUrl = "https://github.com/$GitHubUsername/$RepoName.git"

Write-Host "GitHub Repository URL: $RemoteUrl" -ForegroundColor Cyan
Write-Host ""

# Remote ekle
Write-Host "Remote repository ekleniyor..." -ForegroundColor Yellow
git remote add origin $RemoteUrl 2>$null
if ($LASTEXITCODE -ne 0) {
    Write-Host "Remote zaten var, güncelleniyor..." -ForegroundColor Yellow
    git remote set-url origin $RemoteUrl
}

# Main branch'e geç
Write-Host "Branch 'main' olarak ayarlanıyor..." -ForegroundColor Yellow
git branch -M main

# Push et
Write-Host "GitHub'a push ediliyor..." -ForegroundColor Yellow
git push -u origin main

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "✅ Başarılı! Proje GitHub'a yüklendi!" -ForegroundColor Green
    Write-Host "Repository: https://github.com/$GitHubUsername/$RepoName" -ForegroundColor Cyan
} else {
    Write-Host ""
    Write-Host "❌ Hata oluştu!" -ForegroundColor Red
    Write-Host "Lütfen GitHub'da repository oluşturduğunuzdan emin olun." -ForegroundColor Yellow
    Write-Host "Repository URL: $RemoteUrl" -ForegroundColor Yellow
}

