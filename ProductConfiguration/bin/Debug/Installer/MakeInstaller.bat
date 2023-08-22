
makensis "/DSALES_REGION=KJ" ActInstaller.nsi
move ActInst.exe ActKJ.exe 
makensis "/DSALES_REGION=KA" ActInstaller.nsi
move ActInst.exe ActKA.exe
