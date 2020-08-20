$Time = [System.Diagnostics.Stopwatch]::StartNew()

function PrintElapsedTime {
    Log $([string]::Format("Elapsed time: {0}.{1}", $Time.Elapsed.Seconds, $Time.Elapsed.Milliseconds))
}

function Log {
    Param ([string] $s)
    Write-Output "###### $s"
}

function Check {
    Param ([string] $s)
    if ($LASTEXITCODE -ne 0) { 
        Log "Failed: $s"
        throw "Error case -- see failed step"
    }
}

 
$NUGET_DEVEXPRESS_COM = [System.Environment]::GetEnvironmentVariable('NUGET_DEVEXPRESS_COM','User')

if ($NUGET_DEVEXPRESS_COM -eq $null)
{
    Write-Host "NUGET_DEVEXPRESS_COM does not exist"
    throw "Error case -- see failed step"
}

$DockerOS = docker version -f "{{ .Server.Os }}"
$ImageName = "fluffybunny/inmemoryidentityappblazorbuild"
$Dockerfile = "Build-Dockerfile"

$Version = "0.0.3"

PrintElapsedTime

Log "Build application image"
docker build --no-cache --pull -t $ImageName -f $Dockerfile --build-arg Version=$Version --build-arg NUGET_DEVEXPRESS_COM=$NUGET_DEVEXPRESS_COM .
PrintElapsedTime
Check "docker build (application)"

docker build . --file ./App-Dockerfile   --tag fluffybunny/inmemoryidentityappblazor:latest

 