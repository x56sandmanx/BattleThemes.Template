# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/BattleThemes.Template/*" -Force -Recurse
dotnet publish "./BattleThemes.Template.csproj" -c Release -o "$env:RELOADEDIIMODS/BattleThemes.Template" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location