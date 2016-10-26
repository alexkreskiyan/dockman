$cliPath = "src/Dockman.CLI/"

$config = (Get-Content "$cliPath/project.json" | ConvertFrom-Json)

$framework = $config.frameworks |
    Get-Member -MemberType NoteProperty |
    ForEach-Object { return $_.Name } |
    Select-Object -First 1

$runtimes = $config.runtimes |
    Get-Member -MemberType NoteProperty |
    ForEach-Object { return $_.Name }

foreach ($runtime in $runtimes) {
    dotnet publish $cliPath -r $runtime -c Release
    tar czf "$runtime.tar.gz" -C "$cliPath/bin/Release/$framework/$runtime/publish/" .
}