
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_Killer_V1
{
    public partial class MainWindow : Form
    {
        List<cMail> mailList;
        CMailGUIHelper mailGUIHelper;
        cDBGuiHelper DBHelper;

        public MainWindow()
        {
            mailGUIHelper = new CMailGUIHelper();
            mailGUIHelper.InitHelper();
            DBHelper = new cDBGuiHelper();

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.WindowState = FormWindowState.Maximized;
        }
        ~MainWindow()
        {
            GC.Collect();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            mailGUIHelper.InıtMailViewerHelper(ref MailViewerList);
            mailList = mailGUIHelper.UpdateMailViewer(ref MailViewerList);
            
        }
        private void Updater_Tick(object sender, EventArgs e)
        {
            mailList = mailGUIHelper.UpdateMailViewer(ref MailViewerList);
             BodyViewer.DocumentText = "";
        }
        private void MailViewerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((MailViewerList.Columns[e.ColumnIndex].Name == "IsReaded") && (e.RowIndex != -1) && (e.ColumnIndex != -1))
            {
                mailList[e.RowIndex].setReaded();
                bool isChecked = (bool)MailViewerList[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                mailList[e.RowIndex].UnRead = isChecked;
                MailViewerList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
                MailViewerList.EndEdit();
            }
        }
        private void MailViewerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != -1) && (e.ColumnIndex != -1))
            {
                BodyViewer.DocumentText = mailList[MailViewerList.SelectedCells[0].RowIndex].HTMLBody;
                if ((MailViewerList.Columns[e.ColumnIndex].Name == "Attachment"))
                {
                    ButSaveAtc.Visible = true;
                }
                else
                {
                    ButSaveAtc.Visible = false;

                }
            }
            
        }
        private void ButSaveAtc_Click(object sender, EventArgs e)
        {
            string _mPath;
            PathFinder.RootFolder = Environment.SpecialFolder.Desktop;
            PathFinder.Description = "File Location";
            PathFinder.ShowNewFolderButton = true;
            if (DialogResult.OK == PathFinder.ShowDialog())
            {
                _mPath = PathFinder.SelectedPath + "\\";

                for (int i = 0; i < MailViewerList.SelectedCells.Count; i++)
                {
                    if (MailViewerList.Columns[MailViewerList.SelectedCells[i].ColumnIndex].Name == "Attechment")
                    {
                        mailGUIHelper.GetAccesser().saveAllAttachment(_mPath, mailList[MailViewerList.SelectedCells[i].RowIndex]);
                    }
                }
            }
        }
        private void BDCreateBut_Click(object sender, EventArgs e)
        {
            string dBName = DBNameTB.Text.Trim().Replace(@" ", @"_");
            if (dBName.Length != 0)
            {
                if (!File.Exists(DataBasePathTB.Text+ dBName + ".db"))
                {
                    cDbHelper db = new cDbHelper(dBName + ".db", DataBasePathTB.Text);
                    db.Create();
                }
                else
                {
                    MessageBox.Show("DataBase already created!", "Warning!", MessageBoxButtons.OK);
                }
                
            }
            else
            {
                MessageBox.Show("Please type a DataBase name!","Warning!",MessageBoxButtons.OK);
            }
        }
        private void CreateDBFromExcelBut_Click(object sender, EventArgs e)
        {
            FileFinder.Filter = @"excel files (*.xlsx,*.xlsm)|*.xlsx;*.xlsm";
            FileFinder.Multiselect = false;
            if (DialogResult.OK == FileFinder.ShowDialog())
            {
                string dBName = DBNameTB.Text.Trim().Replace(@" ", @"_");
                if (dBName.Length != 0)
                {
                        cDbHelper db = new cDbHelper(dBName + ".db", DataBasePathTB.Text);
                        db.CreateTableFromExcelFile(FileFinder.FileName);//TO-DO create table for each sheet with that sheet names

                }
                else
                {
                    MessageBox.Show("Please type a DataBase name!", "Warning!", MessageBoxButtons.OK);
                }
            }
        }
        private void DBPathBut_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == PathFinder.ShowDialog())
            {
                DataBasePathTB.Text = PathFinder.SelectedPath + "\\";
                //TO-DO:When settings.ini file is implementing, save path to settings.ini file
            }
        }
        private void RefreshBut_Click(object sender, EventArgs e)
        {
            mailGUIHelper.GetAccesser().syncMails();
            mailList = mailGUIHelper.UpdateMailViewer(ref MailViewerList);
            BodyViewer.DocumentText = "";
        }
        private void OpenDBBut_Click(object sender, EventArgs e)
        {
            FileFinder.Filter = @"excel files (*.sqlite,*.db)|*.sqlite;*.db";
            FileFinder.Multiselect = false;
            if (DialogResult.OK == FileFinder.ShowDialog())
            {
                DBHelper.setDbHelper(FileFinder.FileName);
                DBHelper.InıtDBViewerHelper(ref DBViewer,ref DBListBox);
            }
        }

        private void AddDataBut_Click(object sender, EventArgs e)
        {

            FileFinder.Filter = @"excel files (*.xlsx,*.xlsm)|*.xlsx;*.xlsm";
            FileFinder.Multiselect = false;
            if (DialogResult.OK == FileFinder.ShowDialog())
            {
                DBHelper.AddDataFromExcel(FileFinder.FileName);
                DBHelper.InıtDBViewerHelper(ref DBViewer, ref DBListBox);
            }
           
        }

        private void DBViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DBListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DBHelper.UpdateDBViewer(ref DBViewer, ref DBListBox);
        }

     
    }
}
