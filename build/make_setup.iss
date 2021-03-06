[Setup]
AppId={{E6136546-41EA-47FD-A62B-E487DB236052}
AppName=CodeGreen
AppVerName=CodeGreen
AppVersion=1.5.1
VersionInfoVersion=1.5.1.0
AppPublisherURL=http://code.google.com/p/codegreen/
AppSupportURL=http://code.google.com/p/codegreen/w/list
DefaultDirName={pf}\CodeGreen
DefaultGroupName=CodeGreen
AllowNoIcons=yes
WizardImageFile=setupbanner_codegreen.bmp
WizardImageBackColor=clBlack
WizardSmallImageFile=setupicon_codegreen.bmp
WizardSmallImageBackColor=clWhite
; license.txt en changelog.txt worden in de setup gecompiled.
LicenseFile=license.txt
;AppReadmeFile=changelog.txt
OutputDir=..\build
OutputBaseFilename=CodeGreen_setup_v1.5.1
Compression=lzma
SolidCompression=yes
; zorgt voor voldoen rechten onder win. vista/7 >.
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
Source: "..\bin\Debug\CodeGreen.exe"; DestDir: "{app}"; Flags: touch
Source: "..\bin\Debug\soundhelper.exe"; DestDir: "{app}"; Flags: touch
Source: "..\bin\Debug\SQLite3.dll"; DestDir: "{app}"; Flags: touch
Source: "..\bin\Debug\SQLite.NET.dll"; DestDir: "{app}"; Flags: touch
Source: "..\bin\Debug\UsbLibrary.dll"; DestDir: "{app}"; Flags: touch
Source: "..\bin\Debug\highscoren"; DestDir: "{app}"; Flags: touch
; external soundfiles not compiled in exe.
Source: "..\bin\Debug\sounds\*"; DestDir: "{app}\sounds";

[Icons]
Name: "{group}\CodeGreen"; WorkingDir: "{app}"; Filename: "{app}\CodeGreen.exe";
Name: "{group}\{cm:UninstallProgram,CodeGreen}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\CodeGreen"; WorkingDir: "{app}"; Filename: "{app}\CodeGreen.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\CodeGreen.exe"; Description: "{cm:LaunchProgram,CodeGreen}"; Flags: nowait postinstall skipifsilent runascurrentuser

[CustomMessages]
english.dotnetmissing=This setup requires the .NET Framework v3.0 SP1. Please download and install the .NET Framework v3.0 SP1 and run this setup again. Do you want to download the framework now?
dutch.dotnetmissing=Dit programma vereist .NET framework 3.0 SP1 en dat is niet op uw computer gevonden. Wilt u .NET framework 3.0 SP1 nu downloaden?

[code]
function InitializeSetup(): Boolean;
var
    ErrorCode: Integer;
    NetFrameWorkInstalled : Boolean;
    Result1 : Boolean;
begin

	NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\v3.0');
	if NetFrameWorkInstalled =true then
	begin
		Result := true;
	end;

	if NetFrameWorkInstalled = false then
	begin
		NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\v3.0');
		if NetFrameWorkInstalled =true then
		begin
			Result := true;
		end;

		if NetFrameWorkInstalled =false then
			begin
				//Result1 := (ExpandConstant('{cm:dotnetmissing}'), mbConfirmation, MB_YESNO) = idYes;
				Result1 := MsgBox(ExpandConstant('{cm:dotnetmissing}'),
						mbConfirmation, MB_YESNO) = idYes;
				if Result1 =false then
				begin
					Result:=false;
				end
				else
				begin
					Result:=false;
					ShellExec('open',
					'http://www.microsoft.com/downloads/details.aspx?familyid=EC2CA85D-B255-4425-9E65-1E88A0BDB72A&displaylang=en',
					'','',SW_SHOWNORMAL,ewNoWait,ErrorCode);
                end;
            end;
	end;
end;












