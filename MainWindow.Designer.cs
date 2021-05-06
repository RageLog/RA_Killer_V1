
namespace RA_Killer_V1
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MailViewer = new System.Windows.Forms.TabPage();
            this.ButonPanel = new System.Windows.Forms.Panel();
            this.ButSaveAtc = new System.Windows.Forms.Button();
            this.Hakediş = new System.Windows.Forms.TabPage();
            this.Option = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MailViewerList = new System.Windows.Forms.DataGridView();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.BodyViewer = new System.Windows.Forms.WebBrowser();
            this.PathFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.MailViewer.SuspendLayout();
            this.ButonPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MailViewerList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.MailViewer);
            this.tabControl1.Controls.Add(this.Hakediş);
            this.tabControl1.Controls.Add(this.Option);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // MailViewer
            // 
            resources.ApplyResources(this.MailViewer, "MailViewer");
            this.MailViewer.BackColor = System.Drawing.Color.Silver;
            this.MailViewer.Controls.Add(this.panel2);
            this.MailViewer.Controls.Add(this.ButonPanel);
            this.MailViewer.Name = "MailViewer";
            // 
            // ButonPanel
            // 
            resources.ApplyResources(this.ButonPanel, "ButonPanel");
            this.ButonPanel.BackColor = System.Drawing.Color.Gray;
            this.ButonPanel.Controls.Add(this.ButSaveAtc);
            this.ButonPanel.Name = "ButonPanel";
            // 
            // ButSaveAtc
            // 
            resources.ApplyResources(this.ButSaveAtc, "ButSaveAtc");
            this.ButSaveAtc.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ButSaveAtc.AutoEllipsis = true;
            this.ButSaveAtc.BackColor = System.Drawing.Color.LightGray;
            this.ButSaveAtc.Name = "ButSaveAtc";
            this.ButSaveAtc.UseCompatibleTextRendering = true;
            this.ButSaveAtc.UseVisualStyleBackColor = false;
            this.ButSaveAtc.Click += new System.EventHandler(this.ButSaveAtc_Click);
            // 
            // Hakediş
            // 
            resources.ApplyResources(this.Hakediş, "Hakediş");
            this.Hakediş.BackColor = System.Drawing.Color.Silver;
            this.Hakediş.Name = "Hakediş";
            // 
            // Option
            // 
            resources.ApplyResources(this.Option, "Option");
            this.Option.BackColor = System.Drawing.Color.Silver;
            this.Option.Name = "Option";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.BodyViewer);
            this.panel2.Controls.Add(this.MailViewerList);
            this.panel2.Name = "panel2";
            // 
            // MailViewerList
            // 
            resources.ApplyResources(this.MailViewerList, "MailViewerList");
            this.MailViewerList.AllowUserToAddRows = false;
            this.MailViewerList.AllowUserToDeleteRows = false;
            this.MailViewerList.AllowUserToOrderColumns = true;
            this.MailViewerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MailViewerList.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.MailViewerList.Name = "MailViewerList";
            this.MailViewerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MailViewerList_CellClick);
            this.MailViewerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MailViewerList_CellContentClick);
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 600000;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // BodyViewer
            // 
            resources.ApplyResources(this.BodyViewer, "BodyViewer");
            this.BodyViewer.Name = "BodyViewer";
            // 
            // PathFinder
            // 
            resources.ApplyResources(this.PathFinder, "PathFinder");
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Name = "MainWindow";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.MailViewer.ResumeLayout(false);
            this.ButonPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MailViewerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MailViewer;
        private System.Windows.Forms.TabPage Option;
        private System.Windows.Forms.Panel ButonPanel;
        private System.Windows.Forms.Button ButSaveAtc;
        private System.Windows.Forms.TabPage Hakediş;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView MailViewerList;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.WebBrowser BodyViewer;
        private System.Windows.Forms.FolderBrowserDialog PathFinder;
    }
}