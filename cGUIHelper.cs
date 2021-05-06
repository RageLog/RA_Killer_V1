using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutLook = NetOffice.OutlookApi;


namespace RA_Killer_V1
{
    abstract class cGUIHelper
    {
        public abstract object InitHelper();
        //public abstract void AccessToGuiObject(ref object obj);
    }
    class CMailGUIHelper : cGUIHelper
    {
        
        private cMailAccesser mailAccesser;
        private List<cMail> _mMails { get; set; }
        public List<cMail> getMailList() => _mMails;
        public override object InitHelper()
        {
            mailAccesser = new cMailAccesser();
            _mMails = new List<cMail>();
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
            mailAccesser.trevalMailItemsParallel(func);
            _mMails.Reverse();
            
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
            DataViewer.Columns[4].Name = "Attechment";
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
    
}
/*
 
            public static List<cMail> UpdateMailViewer(ref DataGridView DataViewer)
            {
                
                List<cMail> _mMails = new List<cMail>();
                DataViewer.Rows.Clear();
                void func(cMail mailItem, OutLook.MAPIFolder folder, OutLook.MAPIFolder subFolder)
                {

                    if (mailItem.UnRead)
                    {
                         _mMails.Add(mailItem);
                    }

                }
                mailAccesser.trevalMailItemsParallel(func);
                _mMails.Reverse();
                for (int i = 0; i < _mMails.Count; i++)
                {
                    DataViewer.Rows.Add();
                    DataViewer.Rows[i].Cells[0].Value = _mMails[i].UnRead;
                    DataViewer.Rows[i].Cells[1].Value = _mMails[i].SenderName;
                    //DataViewer.Rows[i].Cells[2].Value = _mMails[i].CC;
                    DataViewer.Rows[i].Cells[2].Value = _mMails[i].Subject;
                    _mMails[i].Classification();
                    //cMailLabels _mL = _mMails[i].getMailsLabels();
                    string temp = @"";
                    //foreach (var item in _mL)
                    //{
                    //    temp += item.name + ":" + item.value + " , "; 
                    //}
                    DataViewer.Rows[i].Cells[3].Value = _mMails[i].getMailType(); ;
                    //temp = @"";
                    foreach (var item in _mMails[i].Attachments)
                    {

                        temp += item.FileName + ", ";
                    }
                    if (temp.Length >0)
                    {
                        temp = temp.Remove(temp.Length - 2, 2);
                    }
                    DataViewer.Rows[i].Cells[4].Value = temp;
                    //DataViewer.Rows[i].Cells[6].Value = _mMails[i].Body;

                }

                return _mMails;
            }
        }*/