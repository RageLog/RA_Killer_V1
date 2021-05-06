
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

        public MainWindow()
        {
            mailGUIHelper = new CMailGUIHelper();
            InitializeComponent();
        }
        ~MainWindow()
        {
            GC.Collect();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            mailGUIHelper.InitHelper();
            mailGUIHelper.InıtMailViewerHelper(ref MailViewerList);
            mailList = mailGUIHelper.UpdateMailViewer(ref MailViewerList);
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            mailList = mailGUIHelper.UpdateMailViewer(ref MailViewerList);
             
        }

        private void MailViewerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((MailViewerList.Columns[e.ColumnIndex].Name == "IsReaded") && (e.RowIndex != -1))
            {
               // MailViewerList.BeginEdit(true);
                mailList[e.RowIndex].setReaded();
                bool isChecked = (bool)MailViewerList[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                mailList[e.RowIndex].UnRead = isChecked;
                MailViewerList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
                MailViewerList.EndEdit();
            }

            
        }

        private void MailViewerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BodyViewer.DocumentText = mailList[MailViewerList.SelectedCells[0].RowIndex].HTMLBody;
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
    }
}

/*
 * 

        
        

        private void button1_Click(object sender, EventArgs e)
        {

            
            

           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dBName = textBox1.Text.Trim().Replace(@" ",@"_");
            cDbHelper db = new cDbHelper(dBName + ".db");
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                string _mPath = folderBrowserDialog1.SelectedPath + "\\";
                db.Create(_mPath);

            }
        }
 */