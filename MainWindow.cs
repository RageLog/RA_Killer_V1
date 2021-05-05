using RA_Killer_V1.GuiHelper;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        ~MainWindow()
        {
            GC.Collect();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            cMailGUIHelper.InıtMailViewer(ref dataGridView1);
            mailList = cMailGUIHelper.UpdateMailViewer(ref dataGridView1);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mailList = cMailGUIHelper.UpdateMailViewer(ref dataGridView1);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView1.Columns[e.ColumnIndex].Name == "IsReaded") && (e.RowIndex!=-1))
            {
                mailList[e.RowIndex].setReaded();
                bool isChecked = (bool)dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                mailList[e.RowIndex].UnRead = isChecked;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
                dataGridView1.EndEdit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            string _mPath;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.Description = "File Location";
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                _mPath = folderBrowserDialog1.SelectedPath + "\\";
              
                Console.WriteLine(dataGridView1.SelectedCells.Count);
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    if (dataGridView1.Columns[dataGridView1.SelectedCells[i].ColumnIndex].Name == "Attechment")
                    {
                        cMailGUIHelper.mailAccesser.saveAllAttachment(_mPath, mailList[dataGridView1.SelectedCells[i].RowIndex]);
                    }
                }
            }

           
            
        }

        
    }
}