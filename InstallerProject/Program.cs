using System.Diagnostics;
using System.Windows.Forms;

namespace InstallerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("MakeInstaller.bat");
            // ウィンドウを表示しない
            processStartInfo.CreateNoWindow = true;
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

            MessageBox.Show(standardError);
        }
    }
}
