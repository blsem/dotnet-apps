using dotnet_apps.Models;

namespace dotnet_apps.Views;

partial class MainView
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.panel1 = new Panel();
        this.dataGridView1 = new DataGridView();
        this.button1 = new Button();
        this.label1 = new Label();
        this.bindingSource1 = new BindingSource();
        this.bindingSource2 = new BindingSource();
        //
        // panel1
        //
        this.panel1.BackColor = Color.AliceBlue;
        this.panel1.Dock = DockStyle.Top;
        this.panel1.Height = 29;
        //
        // dataGridView1
        //
        this.dataGridView1.Dock = DockStyle.Fill;
        this.dataGridView1.DataSource = bindingSource1;
        //
        // button1
        //
        this.button1.BackColor = SystemColors.Control;
        this.button1.Location = new Point(5, 3);
        this.button1.Text = "Sync";
        this.button1.Click += button1_Clicked;
        //
        // label1
        //
        this.label1.BackColor = Color.AliceBlue;
        this.label1.Location = new Point(100, 3);
        this.label1.TextAlign = ContentAlignment.MiddleCenter;
        this.label1.Text = "";
        this.label1.DataBindings.Add("Text", bindingSource2, "LabelText");
        this.label1.DataBindings.Add("BackColor", bindingSource2, "LabelBackColor");
        //
        // bindingSource1
        //
        bindingSource1.DataSource = typeof(User);
        //
        // bindingSource2
        //
        bindingSource2.DataSource = typeof(MainModel);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.panel1.Controls.Add(this.button1);
        this.panel1.Controls.Add(this.label1);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.panel1);
        this.Text = "Form1";
    }

    private Panel panel1;
    private Button button1;
    private Label label1;
    private DataGridView dataGridView1;
    private BindingSource bindingSource1;
    private BindingSource bindingSource2;

    #endregion
}
