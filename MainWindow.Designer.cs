
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MailViewer = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BodyViewer = new System.Windows.Forms.WebBrowser();
            this.MailViewerList = new System.Windows.Forms.DataGridView();
            this.ButonPanel = new System.Windows.Forms.Panel();
            this.RefreshBut = new System.Windows.Forms.Button();
            this.ButSaveAtc = new System.Windows.Forms.Button();
            this.Hakediş = new System.Windows.Forms.TabPage();
            this.DataBaseViewer = new System.Windows.Forms.TabPage();
            this.DBViewer = new System.Windows.Forms.DataGridView();
            this.DBViewerPanel = new System.Windows.Forms.Panel();
            this.AddDataBut = new System.Windows.Forms.Button();
            this.OpenDBBut = new System.Windows.Forms.Button();
            this.DBListBoxLabel = new System.Windows.Forms.Label();
            this.DBListBox = new System.Windows.Forms.ListBox();
            this.Options = new System.Windows.Forms.TabPage();
            this.DataBaseSettingPanel = new System.Windows.Forms.Panel();
            this.CreateDB = new System.Windows.Forms.Panel();
            this.DBPathBut = new System.Windows.Forms.Button();
            this.DataBasePathTB = new System.Windows.Forms.TextBox();
            this.DBPathLabel = new System.Windows.Forms.Label();
            this.CreateDBFromExcelBut = new System.Windows.Forms.Button();
            this.BDCreateBut = new System.Windows.Forms.Button();
            this.DBNameLabel = new System.Windows.Forms.Label();
            this.DBNameTB = new System.Windows.Forms.TextBox();
            this.DataBaseLabel = new System.Windows.Forms.Label();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.PathFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.FileFinder = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.MailViewer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MailViewerList)).BeginInit();
            this.ButonPanel.SuspendLayout();
            this.DataBaseViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBViewer)).BeginInit();
            this.DBViewerPanel.SuspendLayout();
            this.Options.SuspendLayout();
            this.DataBaseSettingPanel.SuspendLayout();
            this.CreateDB.SuspendLayout();
            this.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.DataBaseViewer);
            this.tabControl1.Controls.Add(this.Options);
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
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.BodyViewer);
            this.panel2.Controls.Add(this.MailViewerList);
            this.panel2.Name = "panel2";
            // 
            // BodyViewer
            // 
            resources.ApplyResources(this.BodyViewer, "BodyViewer");
            this.BodyViewer.Name = "BodyViewer";
            this.BodyViewer.WebBrowserShortcutsEnabled = false;
            // 
            // MailViewerList
            // 
            resources.ApplyResources(this.MailViewerList, "MailViewerList");
            this.MailViewerList.AllowUserToAddRows = false;
            this.MailViewerList.AllowUserToDeleteRows = false;
            this.MailViewerList.AllowUserToOrderColumns = true;
            this.MailViewerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MailViewerList.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MailViewerList.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.MailViewerList.Name = "MailViewerList";
            this.MailViewerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MailViewerList_CellClick);
            this.MailViewerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MailViewerList_CellContentClick);
            // 
            // ButonPanel
            // 
            resources.ApplyResources(this.ButonPanel, "ButonPanel");
            this.ButonPanel.BackColor = System.Drawing.Color.Gray;
            this.ButonPanel.Controls.Add(this.RefreshBut);
            this.ButonPanel.Controls.Add(this.ButSaveAtc);
            this.ButonPanel.Name = "ButonPanel";
            // 
            // RefreshBut
            // 
            resources.ApplyResources(this.RefreshBut, "RefreshBut");
            this.RefreshBut.Name = "RefreshBut";
            this.RefreshBut.UseVisualStyleBackColor = true;
            this.RefreshBut.Click += new System.EventHandler(this.RefreshBut_Click);
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
            // DataBaseViewer
            // 
            resources.ApplyResources(this.DataBaseViewer, "DataBaseViewer");
            this.DataBaseViewer.BackColor = System.Drawing.Color.Silver;
            this.DataBaseViewer.Controls.Add(this.DBViewer);
            this.DataBaseViewer.Controls.Add(this.DBViewerPanel);
            this.DataBaseViewer.Name = "DataBaseViewer";
            // 
            // DBViewer
            // 
            this.DBViewer.AllowUserToAddRows = false;
            this.DBViewer.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.DBViewer, "DBViewer");
            this.DBViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DBViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBViewer.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DBViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DBViewer.Name = "DBViewer";
            this.DBViewer.ReadOnly = true;
            this.DBViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DBViewer.TabStop = false;
            this.DBViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBViewer_CellContentClick);
            // 
            // DBViewerPanel
            // 
            resources.ApplyResources(this.DBViewerPanel, "DBViewerPanel");
            this.DBViewerPanel.BackColor = System.Drawing.Color.Gray;
            this.DBViewerPanel.Controls.Add(this.AddDataBut);
            this.DBViewerPanel.Controls.Add(this.OpenDBBut);
            this.DBViewerPanel.Controls.Add(this.DBListBoxLabel);
            this.DBViewerPanel.Controls.Add(this.DBListBox);
            this.DBViewerPanel.Name = "DBViewerPanel";
            // 
            // AddDataBut
            // 
            this.AddDataBut.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.AddDataBut, "AddDataBut");
            this.AddDataBut.Name = "AddDataBut";
            this.AddDataBut.UseVisualStyleBackColor = false;
            this.AddDataBut.Click += new System.EventHandler(this.AddDataBut_Click);
            // 
            // OpenDBBut
            // 
            this.OpenDBBut.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.OpenDBBut, "OpenDBBut");
            this.OpenDBBut.Name = "OpenDBBut";
            this.OpenDBBut.UseVisualStyleBackColor = false;
            this.OpenDBBut.Click += new System.EventHandler(this.OpenDBBut_Click);
            // 
            // DBListBoxLabel
            // 
            resources.ApplyResources(this.DBListBoxLabel, "DBListBoxLabel");
            this.DBListBoxLabel.Name = "DBListBoxLabel";
            // 
            // DBListBox
            // 
            resources.ApplyResources(this.DBListBox, "DBListBox");
            this.DBListBox.FormattingEnabled = true;
            this.DBListBox.Name = "DBListBox";
            this.DBListBox.Sorted = true;
            this.DBListBox.SelectedIndexChanged += new System.EventHandler(this.DBListBox_SelectedIndexChanged);
            // 
            // Options
            // 
            resources.ApplyResources(this.Options, "Options");
            this.Options.BackColor = System.Drawing.Color.Transparent;
            this.Options.Controls.Add(this.DataBaseSettingPanel);
            this.Options.Name = "Options";
            // 
            // DataBaseSettingPanel
            // 
            resources.ApplyResources(this.DataBaseSettingPanel, "DataBaseSettingPanel");
            this.DataBaseSettingPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.DataBaseSettingPanel.Controls.Add(this.CreateDB);
            this.DataBaseSettingPanel.Controls.Add(this.DataBaseLabel);
            this.DataBaseSettingPanel.Name = "DataBaseSettingPanel";
            // 
            // CreateDB
            // 
            this.CreateDB.BackColor = System.Drawing.Color.LightGray;
            this.CreateDB.Controls.Add(this.DBPathBut);
            this.CreateDB.Controls.Add(this.DataBasePathTB);
            this.CreateDB.Controls.Add(this.DBPathLabel);
            this.CreateDB.Controls.Add(this.CreateDBFromExcelBut);
            this.CreateDB.Controls.Add(this.BDCreateBut);
            this.CreateDB.Controls.Add(this.DBNameLabel);
            this.CreateDB.Controls.Add(this.DBNameTB);
            resources.ApplyResources(this.CreateDB, "CreateDB");
            this.CreateDB.Name = "CreateDB";
            // 
            // DBPathBut
            // 
            resources.ApplyResources(this.DBPathBut, "DBPathBut");
            this.DBPathBut.Name = "DBPathBut";
            this.DBPathBut.UseVisualStyleBackColor = true;
            this.DBPathBut.Click += new System.EventHandler(this.DBPathBut_Click);
            // 
            // DataBasePathTB
            // 
            resources.ApplyResources(this.DataBasePathTB, "DataBasePathTB");
            this.DataBasePathTB.Name = "DataBasePathTB";
            // 
            // DBPathLabel
            // 
            resources.ApplyResources(this.DBPathLabel, "DBPathLabel");
            this.DBPathLabel.Name = "DBPathLabel";
            // 
            // CreateDBFromExcelBut
            // 
            resources.ApplyResources(this.CreateDBFromExcelBut, "CreateDBFromExcelBut");
            this.CreateDBFromExcelBut.Name = "CreateDBFromExcelBut";
            this.CreateDBFromExcelBut.UseVisualStyleBackColor = true;
            this.CreateDBFromExcelBut.Click += new System.EventHandler(this.CreateDBFromExcelBut_Click);
            // 
            // BDCreateBut
            // 
            resources.ApplyResources(this.BDCreateBut, "BDCreateBut");
            this.BDCreateBut.Name = "BDCreateBut";
            this.BDCreateBut.UseVisualStyleBackColor = true;
            this.BDCreateBut.Click += new System.EventHandler(this.BDCreateBut_Click);
            // 
            // DBNameLabel
            // 
            resources.ApplyResources(this.DBNameLabel, "DBNameLabel");
            this.DBNameLabel.Name = "DBNameLabel";
            // 
            // DBNameTB
            // 
            resources.ApplyResources(this.DBNameTB, "DBNameTB");
            this.DBNameTB.Name = "DBNameTB";
            // 
            // DataBaseLabel
            // 
            resources.ApplyResources(this.DataBaseLabel, "DataBaseLabel");
            this.DataBaseLabel.Name = "DataBaseLabel";
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 600000;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MailViewerList)).EndInit();
            this.ButonPanel.ResumeLayout(false);
            this.DataBaseViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DBViewer)).EndInit();
            this.DBViewerPanel.ResumeLayout(false);
            this.DBViewerPanel.PerformLayout();
            this.Options.ResumeLayout(false);
            this.DataBaseSettingPanel.ResumeLayout(false);
            this.DataBaseSettingPanel.PerformLayout();
            this.CreateDB.ResumeLayout(false);
            this.CreateDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MailViewer;
        private System.Windows.Forms.TabPage Options;
        private System.Windows.Forms.Panel ButonPanel;
        private System.Windows.Forms.Button ButSaveAtc;
        private System.Windows.Forms.TabPage Hakediş;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView MailViewerList;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.WebBrowser BodyViewer;
        private System.Windows.Forms.FolderBrowserDialog PathFinder;
        private System.Windows.Forms.Panel DataBaseSettingPanel;
        private System.Windows.Forms.Label DataBaseLabel;
        private System.Windows.Forms.Panel CreateDB;
        private System.Windows.Forms.TextBox DBNameTB;
        private System.Windows.Forms.Label DBNameLabel;
        private System.Windows.Forms.Button CreateDBFromExcelBut;
        private System.Windows.Forms.OpenFileDialog FileFinder;
        private System.Windows.Forms.TextBox DataBasePathTB;
        private System.Windows.Forms.Label DBPathLabel;
        private System.Windows.Forms.Button DBPathBut;
        private System.Windows.Forms.Button BDCreateBut;
        private System.Windows.Forms.Button RefreshBut;
        private System.Windows.Forms.TabPage DataBaseViewer;
        private System.Windows.Forms.Panel DBViewerPanel;
        private System.Windows.Forms.DataGridView DBViewer;
        private System.Windows.Forms.ListBox DBListBox;
        private System.Windows.Forms.Button OpenDBBut;
        private System.Windows.Forms.Label DBListBoxLabel;
        private System.Windows.Forms.Button AddDataBut;
    }
}