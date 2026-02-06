# 1. Levantar el contenedor
Write-Host "Iniciando contenedor de SQL Server..." -ForegroundColor Cyan
docker-compose up -d

# 2. Esperar a que SQL Server esté listo
Write-Host "Esperando a que SQL Server inicie (esto puede tardar unos segundos)..." -ForegroundColor Yellow
$ready = $false
$retryCount = 0
$maxRetries = 15
$password = "BG_1NVTAR10@26!"
$containerName = "bg_inventario_db"
$sqlcmd = "/opt/mssql-tools18/bin/sqlcmd"

while (-not $ready -and $retryCount -lt $maxRetries) {
    # Intentamos una conexión simple
    $check = docker exec $containerName $sqlcmd -S localhost -U sa -P $password -C -Q "SELECT 1" 2>$null
    
    if ($LASTEXITCODE -eq 0 -and $check -match "1") {
        $ready = $true
        Write-Host "¡SQL Server está listo!" -ForegroundColor Green
    } else {
        $retryCount++
        Write-Host "Aun no responde... reintentando ($retryCount/$maxRetries)"
        Start-Sleep -Seconds 5
    }
}

if ($ready) {
    # 3. Ejecutar el script init_db.sql (copiamos al contenedor y usamos -i para evitar problemas de encoding/pipe en PowerShell)
    Write-Host "Ejecutando init_db.sql..." -ForegroundColor Cyan
    $scriptPath = Join-Path $PSScriptRoot "init_db.sql"
    docker cp $scriptPath "${containerName}:/tmp/init_db.sql"
    docker exec $containerName $sqlcmd -S localhost -U sa -P $password -C -i /tmp/init_db.sql
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Proceso finalizado con éxito." -ForegroundColor Green
    } else {
        Write-Host "Error al ejecutar init_db.sql" -ForegroundColor Red
    }
} else {
    Write-Host "Error: SQL Server no inició a tiempo." -ForegroundColor Red
}