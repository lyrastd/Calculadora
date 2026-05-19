[Setup]
AppName=Calculadora Simples
AppVersion=1.0
DefaultDirName={autopf}\CalculadoraSimples
DefaultGroupName=Calculadora Simples
OutputDir=dist
OutputBaseFilename=setup_calculadora
SetupIconFile=app.ico
Compression=lzma
SolidCompression=yes

[Files]
Source: "bin\Release\net8.0-windows\win-x64\publish\CalculatorApp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "app.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Calculadora Simples"; Filename: "{app}\CalculatorApp.exe"; IconFilename: "{app}\app.ico"
Name: "{commondesktop}\Calculadora Simples"; Filename: "{app}\CalculatorApp.exe"; IconFilename: "{app}\app.ico"