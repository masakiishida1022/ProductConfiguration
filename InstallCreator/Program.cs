using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InstallCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = @"""""/DSALES_REGION=KJ"" ActInstaller.nsi""";
            // 第1引数がコマンド、第2引数がコマンドの引数
            ProcessStartInfo processStartInfo = new ProcessStartInfo("makensis.exe", "\"/DSALES_REGION=KJ\"" "ActInstaller.nsi");
           

             // ウィンドウを表示しない
            processStartInfo.CreateNoWindow = false;
            processStartInfo.UseShellExecute = false; 
 
            // 標準出力、標準エラー出力を取得できるようにする
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true; 
 
            // コマンド実行
            Process process = Process.Start(processStartInfo); 
 
            // 標準出力・標準エラー出力・終了コードを取得する
            string standardOutput = process.StandardOutput.ReadToEnd();
            string standardError = process.StandardError.ReadToEnd();
            int exitCode = process.ExitCode; 
 
            process.Close(); 
 
            // MessageBoxに標準出力を表示
            MessageBox.Show(standardOutput);
            //makensis "/DSALES_REGION=KJ" ActInstaller.nsi
            //move TSPInst.exe ActKJ.exe 
            //makensis "/DSALES_REGION=KA" ActInstaller.nsi
            //move TSPInst.exe ActKA.exe
        }
    }
}
