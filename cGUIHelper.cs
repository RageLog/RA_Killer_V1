using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutLook = NetOffice.OutlookApi;


namespace RA_Killer_V1
{
    class CMailGUIHelper
    {

        private cMailAccesser mailAccesser;
        private List<cMail> _mMails { get; set; }
        public List<cMail> getMailList() => _mMails;
        public object InitHelper()
        {
            mailAccesser = new cMailAccesser();
            _mMails = new List<cMail>();
            //
            upDateMailList();
            return mailAccesser;
        }
        public cMailAccesser GetAccesser() => mailAccesser;
        private void upDateMailList()
        {
            _mMails.Clear();
            void func(cMail mailItem, OutLook.MAPIFolder folder, OutLook.MAPIFolder subFolder)
            {

                if (mailItem.UnRead)
                {
                    _mMails.Add(mailItem);
                }

            }
            mailAccesser.trevalMailItemsParallel(func, 20);

        }
        public void InıtMailViewerHelper(ref DataGridView DataViewer)
        {
            CMailGUIHelper _mgHelper = new CMailGUIHelper();

            DataGridViewCheckBoxColumn isMailReaded = new DataGridViewCheckBoxColumn();
            isMailReaded.ValueType = typeof(bool);
            isMailReaded.Name = "IsReaded";
            isMailReaded.HeaderText = "IsReaded";
            isMailReaded.DisplayIndex = 0;
            DataViewer.ColumnCount = 4;
            DataViewer.Columns.Insert(0, isMailReaded);
            DataViewer.Columns[1].Name = "Sender";
            DataViewer.Columns[2].Name = "Subject";
            DataViewer.Columns[3].Name = "Type";
            DataViewer.Columns[4].Name = "Attachment";
            foreach (DataGridViewColumn column in DataViewer.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            DataViewer.Columns[0].ReadOnly = false;
            DataViewer.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }
        public List<cMail> UpdateMailViewer(ref DataGridView DataViewer)
        {
            DataViewer.Rows.Clear();
            upDateMailList();
            for (int i = 0; i < _mMails.Count; i++)
            {

                DataViewer.Rows.Add();
                DataViewer.Rows[i].Cells[0].Value = _mMails[i].UnRead;
                DataViewer.Rows[i].Cells[1].Value = _mMails[i].SenderName;
                DataViewer.Rows[i].Cells[2].Value = _mMails[i].Subject;
                _mMails[i].Classification();
                DataViewer.Rows[i].Cells[3].Value = _mMails[i].getMailType(); ;
                string temp = @"";
                foreach (var item in _mMails[i].Attachments)
                {

                    temp += item.FileName + ", ";
                }
                if (temp.Length > 0)
                {
                    temp = temp.Remove(temp.Length - 2, 2);
                }
                DataViewer.Rows[i].Cells[4].Value = temp;

            }
            DataViewer.EndEdit();

            return _mMails;

        }

    }
    class cDBGuiHelper
    {
        private cDbHelper dbHelper;
        public cDBGuiHelper()
        {
            dbHelper = null;
        }
        public cDBGuiHelper(string dbName)
        {
            dbHelper = new cDbHelper(dbName);
        }
        public object setDbHelper(string dbName)
        {
            dbHelper = new cDbHelper(dbName);
            return dbHelper;
        }
        public cDbHelper getDbHelper() => dbHelper;
        public void InıtDBViewerHelper(ref DataGridView DataViewer, ref ListBox listBox)
        {

            listBox.Items.Clear();
            List<string> tables = dbHelper.GetTablesName();
            listBox.BeginUpdate();
            foreach (var item in tables)
            {
                listBox.Items.Add(item);
            }
            listBox.EndUpdate();

            listBox.SelectedIndex = 0;
            //MessageBox.Show(listBox.Items[listBox.SelectedIndex].ToString());
            DataViewer.EndEdit();


        }

        public void UpdateDBViewer(ref DataGridView DataViewer, ref ListBox listBox)
        {
            DataViewer.Columns.Clear();
            int i = 0;
            var colname = dbHelper.GetColumnNames(listBox.Items[listBox.SelectedIndex].ToString());
            DataViewer.ColumnCount = colname.Count;
            foreach (var item in colname)
            {
                DataViewer.Columns[i].Name = item.columnName;
                i++;
            }
            i = 0;
            var values = dbHelper.GetAllValue(listBox.Items[listBox.SelectedIndex].ToString());
            foreach (var item in values)
            {
                DataViewer.Rows.Add();
                int j = 0;
                foreach (var it in item)
                {
                    DataViewer.Rows[i].Cells[j].Value = it.Value;
                    j++;
                }
                i++;
            }
            //var itemList = dbHelper.
            DataViewer.EndEdit();

        }
        public void AddDataFromExcel(string filePath)
        {
            dbHelper.InsertFromExcelFile(filePath);
        }


    }

    //! This class must revise again
    /*class HakedisGuiHelper
    {
        private cDbHelper dbHelper;
        public object setDbHelper(string dbName)
        {
            dbHelper = new cDbHelper(dbName);
            return dbHelper;
        }
        public cDbHelper getDbHelper() => dbHelper;
        public void InıtMailViewerHelper(ref DataGridView DataViewer)
        {
            CMailGUIHelper _mgHelper = new CMailGUIHelper();

            DataGridViewCheckBoxColumn isMailReaded = new DataGridViewCheckBoxColumn();
            isMailReaded.ValueType = typeof(bool);
            isMailReaded.Name = "IsReaded";
            isMailReaded.HeaderText = "IsReaded";
            isMailReaded.DisplayIndex = 0;
            DataViewer.ColumnCount = 4;
            DataViewer.Columns.Insert(0, isMailReaded);
            DataViewer.Columns[1].Name = "Sender";
            DataViewer.Columns[2].Name = "Subject";
            DataViewer.Columns[3].Name = "Type";
            DataViewer.Columns[4].Name = "Attachment";
            foreach (DataGridViewColumn column in DataViewer.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            DataViewer.Columns[0].ReadOnly = false;
            DataViewer.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }
        public List<cMail> UpdateMailViewer(ref DataGridView DataViewer,ref List<cMail> _mMails)
        {
            DataViewer.Rows.Clear();
            for (int i = 0; i < _mMails.Count; i++)
            {

                DataViewer.Rows.Add();
                DataViewer.Rows[i].Cells[0].Value = _mMails[i].UnRead;
                DataViewer.Rows[i].Cells[1].Value = _mMails[i].SenderName;
                DataViewer.Rows[i].Cells[2].Value = _mMails[i].Subject;
                _mMails[i].Classification();
                DataViewer.Rows[i].Cells[3].Value = _mMails[i].getMailType(); ;
                string temp = @"";
                foreach (var item in _mMails[i].Attachments)
                {

                    temp += item.FileName + ", ";
                }
                if (temp.Length > 0)
                {
                    temp = temp.Remove(temp.Length - 2, 2);
                }
                DataViewer.Rows[i].Cells[4].Value = temp;

            }
            DataViewer.EndEdit();

            return _mMails;

        }
        public void InıtDBViewerHelper(ref DataGridView DataViewer)
        {

            listBox.Items.Clear();
            List<string> tables = dbHelper.GetTablesName();
            listBox.BeginUpdate();
            foreach (var item in tables)
            {
                listBox.Items.Add(item);
            }
            listBox.EndUpdate();

            listBox.SelectedIndex = 0;
            //MessageBox.Show(listBox.Items[listBox.SelectedIndex].ToString());
            DataViewer.EndEdit();


        }
    }*/
}
