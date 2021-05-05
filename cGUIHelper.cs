using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutLook = NetOffice.OutlookApi;


namespace RA_Killer_V1
{
    namespace GuiHelper
    {
        static class cMailGUIHelper
        {
            public static cMailAccesser mailAccesser = new cMailAccesser();

            public static void InıtMailViewer(ref DataGridView DataViewer)
            {
                DataGridViewCheckBoxColumn isMailReaded = new DataGridViewCheckBoxColumn();
                
                isMailReaded.ValueType = typeof(bool);
                isMailReaded.Name = "IsReaded";
                isMailReaded.HeaderText = "IsReaded";
                
                DataViewer.ColumnCount = 4;
                DataViewer.Columns.Insert(0, isMailReaded); ;
                DataViewer.Columns[1].Name = "Sender";
                //DataViewer.Columns[2].Name = "CC";
                DataViewer.Columns[2].Name = "Subject";
                DataViewer.Columns[3].Name = "Tags";
                DataViewer.Columns[4].Name = "Attechment";
                //DataViewer.Columns[6].Name = "Body";
                foreach (DataGridViewColumn column in DataViewer.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
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
        }
    }
    
}
