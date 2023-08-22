
!include "Library.nsh"


Name "TSP Installer" 
OutFile "TSPInst.exe" 
InstallDir "$PROGRAMFILES\TSP"

RequestExecutionLevel admin

;Page license ; 
Page directory ; 
Page instfiles ;


UninstPage uninstConfirm ; 
UninstPage instfiles ; 



;
LoadLanguageFile "${NSISDIR}\Contrib\Language files\English.nlf"
;LoadLanguageFile "${NSISDIR}\Contrib\Language files\Japanese.nlf"



;LicenseLangString license ${LANG_ENGLISH} license-english.txt
;LicenseLangString license ${LANG_JAPANESE} license-japanese.txt
;LicenseData $(license)

LangString ShortcutDirectory ${LANG_ENGLISH} "Travelling Salesman Problem"
;LangString ShortcutDirectory ${LANG_JAPANESE} "Japanese Travelling salesman Problem"

Section "Install" ; 


SetOutPath $INSTDIR


!define ReleaseDirectory 

File ..\ProductConfiguration.exe
File ..\readme.txt

SetOutPath $INSTDIR\KJ"
File /nonfatal /a /r "KJ\" #note back slash at the end

;Var /GLOBAL SALES_REGION
${If} ${SALES_REGION} == "KJ"
    MessageBox MB_OK "SALES_REGION is ${SALES_REGION}"
${ElseIf} ${SALES_REGION} == "KA"
    SetOutPath $INSTDIR\KA"
    File /nonfatal /a /r "KA\" #note back slash at the end
${Else}    
    MessageBox MB_OK "SALES_REGION is None2"
${EndIf}

;;Var /GLOBAL ALREADY_INSTALLED
;IfFileExists "$INSTDIR\ProductConfiguration.exe.exe" 0 new_installation
;StrCpy $ALREADY_INSTALLED 1
;new_installation:

;WriteUninstaller $INSTDIR\uninstaller.exe

;CreateDirectory "$SMPROGRAMS\$(ShortcutDirectory)"
CreateShortCut "$SMPROGRAMS\$(ShortcutDirectory)\TSP.lnk" $INSTDIR\TSP.exe
;CreateShortCut "$SMPROGRAMS\$(ShortcutDirectory)\uninstaller.lnk" $INSTDIR\uninstaller.exe

 CreateDirectory "$DESKTOP\MyShortcutFolder"
 CreateShortCut "$DESKTOP\MyShortcutFolder\MyShortcut.lnk" "$INSTDIR\ProductConfiguration.exe" "" "$INSTDIR\ProductConfiguration.ico" 0



SectionEnd ; end the section


Section "Uninstall"


Delete $INSTDIR\TSP.exe
Delete $INSTDIR\readme.txt
Delete $INSTDIR\TSP_ja_JP.qm

!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\QtCore4.dll
!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\QtGui4.dll
!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\libgcc_s_dw2-1.dll
!insertmacro UnInstallLib DLL SHARED REBOOT_NOTPROTECTED $SYSDIR\mingwm10.dll


Delete $INSTDIR\uninstaller.exe

RMDir $INSTDIR

Delete "$SMPROGRAMS\$(ShortcutDirectory)\TSP.lnk"
Delete "$SMPROGRAMS\$(ShortcutDirectory)\uninstaller.lnk"
RMDir "$SMPROGRAMS\$(ShortcutDirectory)"

SectionEnd