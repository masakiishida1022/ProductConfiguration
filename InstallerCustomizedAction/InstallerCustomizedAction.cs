[System.ComponentModel.RunInstaller(true)]
public class Installer1 : System.Configuration.Install.Installer
{
    private System.Windows.Forms.ComboBox comboBox1;

    public override void Install(System.Collections.IDictionary stateSaver)
    {
        base.Install(stateSaver);
        

        string val = this.Context.Parameters["name"];
        string targetdir = this.Context.Parameters["dir"];

    System.Windows.Forms.MessageBox.Show("name = " + val +
        "\nTARGETDIR = " + targetdir);
    }

    public override void Commit(System.Collections.IDictionary savedState)
    {
        base.Commit(savedState);
    }

    public override void Rollback(System.Collections.IDictionary savedState)
    {
        base.Rollback(savedState);
    }

    public override void Uninstall(System.Collections.IDictionary savedState)
    {
        base.Uninstall(savedState);
    }

    private void InitializeComponent()
    {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            //this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            //this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;

    }
}

