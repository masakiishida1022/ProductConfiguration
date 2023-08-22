
!include "Library.nsh"


Name "ACT Installer" 
OutFile "ActInst.exe" 
InstallDir "$PROGRAMFILES\ACT"



RequestExecutionLevel admin

;Page license ; 
Page directory ; 
Page instfiles ;


UninstPage uninstConfirm ; 
UninstPage instfiles ; 



;
LoadLanguageFile "${NSISDIR}\Contrib\Language files\English.nlf"
;LoadLanguageFile "${NSISDIR}\Contrib\Language files\Japanese.nlf"

LangString ShortcutDirectory ${LANG_ENGLISH} "Act 1.0.0"

;LicenseLangString license ${LANG_ENGLISH} license-english.txt
;LicenseLangString license ${LANG_JAPANESE} license-japanese.txt
;LicenseData $(license)

Section "Install" ; 


SetOutPath $INSTDIR


!define ReleaseDirectory 

File ..\ProductConfiguration.exe
File ..\readme.txt



;Var /GLOBAL SALES_REGION
${If} ${SALES_REGION} == "KJ"
    File .\CultureSettingInfo_KJ.json
    Rename ".\CultureSettingInfo_KJ.json" "$INSTDIR\CultureSettingInfo.json" ; ファイル名を変更
    SetOutPath $INSTDIR\KJ"
    File /nonfatal /a /r "../KJ\" #note back slash at the end
${ElseIf} ${SALES_REGION} == "KA"
    File .\CultureSettingInfo_KA.json
    Rename ".\CultureSettingInfo_KA.json" "$INSTDIR\CultureSettingInfo.json" ; ファイル名を変更

    SetOutPath $INSTDIR\KA"
    File /nonfatal /a /r "../KA\" #note back slash at the end

    SetOutPath $INSTDIR\report"
    File /nonfatal "../report\*.*" #note back slash at the end

    SetOutPath $INSTDIR\report\KA"
    File /nonfatal /a /r "../report/KA\" #note back slash at the end

${Else}    
    MessageBox MB_OK "SALES_REGION is None2"
${EndIf}

;;Var /GLOBAL ALREADY_INSTALLED
;IfFileExists "$INSTDIR\ProductConfiguration.exe.exe" 0 new_installation
;StrCpy $ALREADY_INSTALLED 1
;new_installation:

WriteUninstaller $INSTDIR\uninstaller.exe

;CreateDirectory "$SMPROGRAMS\$(ShortcutDirectory)"
;CreateShortCut "$SMPROGRAMS\$(ShortcutDirectory)\ProductConfiguration.lnk" $INSTDIR\ProductConfiguration.exe
;CreateShortCut "$SMPROGRAMS\$(ShortcutDirectory)\uninstaller.lnk" $INSTDIR\uninstaller.exe

CreateDirectory "$DESKTOP\MyShortcutFolder"
CreateShortCut "$DESKTOP\MyShortcutFolder\MyShortcut.lnk" "$INSTDIR\ProductConfiguration.exe" "" "$INSTDIR\test.ico" 0



SectionEnd ; end the section


Section "Uninstall"


Delete $INSTDIR\ProductConfiguration.exe
Delete $INSTDIR\readme.txt
Delete $INSTDIR\report

!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\QtCore4.dll
!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\QtGui4.dll
!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\libgcc_s_dw2-1.dll
!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\mingwm10.dll


Delete $INSTDIR\uninstaller.exe

RMDir /r $INSTDIR 

Delete "$SMPROGRAMS\$(ShortcutDirectory)\ProductConfiguration.lnk"
Delete "$SMPROGRAMS\$(ShortcutDirectory)\uninstaller.lnk"
RMDir "$SMPROGRAMS\$(ShortcutDirectory)"

SectionEnd
