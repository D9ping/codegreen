; Script generated by the Inno Setup Script Wizard.
[Setup]
AppId={{E6136546-41EA-47FD-A62B-E487DB236052}
AppName=CodeGreen
AppVerName=CodeGreen - DEVELOPMENT VERSION
AppVersion=0.6 Alpha
AppPublisherURL=http://code.google.com/p/codegreen/
AppSupportURL=http://code.google.com/p/codegreen/w/list
DefaultDirName={pf}\CodeGreen
DefaultGroupName=CodeGreen
AllowNoIcons=yes
WizardImageFile=setupbanner_codegreen.bmp
WizardSmallImageFile=setupicon_codegreen.bmp
WizardSmallImageBackColor=Green
; license.txt en changelog.txt worden in de setup gecompiled.
LicenseFile=license.txt
AppReadmeFile=changelog.txt
OutputDir=..\build
OutputBaseFilename=CodeGreen_setup
Compression=lzma
SolidCompression=yes
; zorgt voor voldoen rechten onder vista.
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
; Visual Studio debug conf.
Source: "..\bin\Debug\CodeGreen.exe"; DestDir: "{app}";
;Source: "..\bin\Debug\CodeGreen.vshost.exe"; DestDir: "{app}\bin\Debug";
;Source: "..\bin\Debug\CodeGreen.vshost.exe.manifest"; DestDir: "{app}\bin\Debug";
Source: "..\bin\Debug\UsbLibrary.dll"; DestDir: "{app}"; Flags: touch

; externe afbeeldingen, niet gebruiken want alle afbeeldingen zijn nu in exe compiled.
;Source: "..\afb\*"; DestDir: "{app}\afb"; Flags: ignoreversion touch

; externe geluid bestanden, deze zijn NIET in executable compiled.
Source: "..\sounds\*"; DestDir: "{app}\sounds"; Flags: ignoreversion touch

[Icons]
; Visual Studio debug conf.
Name: "{group}\CodeGreen"; WorkingDir: "{app}"; Filename: "{app}\CodeGreen.exe";
Name: "{group}\{cm:UninstallProgram,CodeGreen}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\CodeGreen"; WorkingDir: "{app}"; Filename: "{app}\CodeGreen.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\CodeGreen.exe"; Description: "{cm:LaunchProgram,CodeGreen}"; Flags: nowait postinstall skipifsilent

