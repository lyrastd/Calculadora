[Setup]
AppName=Calculadora Simples
AppVersion=1.0
DefaultDirName={autopf}\CalculadoraSimples
DefaultGroupName=Calculadora Simples
OutputDir=.
OutputBaseFilename=Setup_Calculadora
SetupIconFile=app.ico
Compression=lzma
SolidCompression=yes

[Files]
Source: "bin\Release\net8.0-windows\win-x64\publish\CalculadoraApp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "app.ico"; DestDir: "{app}"

[Icons]
Name: "{group}\Calculadora Simples"; Filename: "{app}\CalculadoraApp.exe"; IconFilename: "{app}\app.ico"
Name: "{commondesktop}\Calculadora Simples"; Filename: "{app}\CalculadoraApp.exe"; IconFilename: "{app}\app.ico"