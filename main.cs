using System;
using System.Windows.Forms;

namespace RA_Killer_V1
{

    class main
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {


                Application.Run(new MainWindow());
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                //Console.ReadKey();
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}

 //cDbHelper _mDb = new cDbHelper("Hakediş.sqlite");
                ////_mDb.CreateTableFromExcelFile("C:\\Users\\cemal\\Desktop\\DataBase.xlsx", "Hakediş");
                ////_mDb.Create();//"C:\\Users\\cemal\\Desktop\\"
                ////_mDb.CreateTable("Hakediş", "No INTEGER PRIMARY KEY AUTOINCREMENT, Site_ID varchar(10), Customer_Site_ID varchar(10), Internal_Site_ID varchar(15),Date DATE");
                ////_mDb.InsertFromExcelFile("C:\\Users\\cemal\\Desktop\\Data.xlsx", "Hakediş");
                ////_mDb.AddColumnToTable("Hakediş", "Yeni_Col", "Text");
                ////_mDb.RemoveColumnToTable("Hakediş", "Yeni_Col");
                ////var v = _mDb.SearchFor("Hakediş", "Customer_Site_ID", "AN0001");
                ////_mDb.UpdateData(@"Hakediş", "Customer_Site_ID='AN9999'", "Site_ID ='AN0001'");
                //var v = _mDb.GetNonRepetitiveValue("Hakediş", "Site_ID,Customer_Site_ID");
                //foreach (var item in v)
                //{
                //    foreach (var i in item)
                //    {
                //        Console.WriteLine(i.Key + " : " + i.Value);
                //    }
                //}
                //System.Threading.Thread.Sleep(5000);
            



//////////////////////////////////////////////////////////////////
//cExcelAccesser _mEA = new cExcelAccesser();
//string path = "C:\\Users\\cemal\\Desktop\\a.xlsx";
//if (File.Exists(path))
//{
//    _mEA.openWorkBook(path);
//}
//else
//{
//    _mEA.createWorkBook(path,"deneme sayfa");
//}
//foreach (var item in _mEA.getWorkSheets())
//{
//    Console.WriteLine(item.Value.Name);
//}
//if (_mEA.getWorkSheets().ContainsKey("asd"))
//{
//    //_mEA.getWorkSheets()["asd"].Cells[1, 1].Value = "asd";
//}
//else
//{
//    _mEA.createWorkSheet("asd");
//   // _mEA.getWorkSheets()["asd"].Cells[1, 1].Value = "asd";
//   // _mEA.getWorkSheets()["asd"].Cells[1, 1].Font.Color = XlRgbColor.rgbBlueViolet;
//}
//foreach (var item in _mEA.getWorkSheets())
//{
//    Console.WriteLine(item.Value.Name);
//}
//Console.WriteLine(_mEA.getTableSize("asd").ToString());


//cMailAccesser mailAccesser = new cMailAccesser();
//mailAccesser.start();
//cDataBase _mDB = new cDataBase();
//_mDB.Create("_myDataBase");
//_mDB.Open();
//if (!_mDB.checkTableIsExist(@"Hakedis_Kayıt"))
//{
//    _mDB.createTable(@"Hakedis_Kayıt", @"No INTEGER PRIMARY KEY AUTOINCREMENT ,Site_ID varchar(10), Customer_Site_ID varchar(10), Internal_Site_ID varchar(15),Date DATE");

//}
//_mDB.insertToTable(@"Hakedis_Kayıt",
//                    @"Site_ID,    Customer_Site_ID,   Internal_Site_ID, Date",
//                    @"'AN0001','LAN0001','TAN0001',datetime()");
//SQLiteDataReader reader = _mDB.getReader("select * from Hakedis_Kayıt order by NO ASC");


//while (reader.Read())
//    Console.WriteLine("NO: " + reader["NO"] +
//                        "  Site_ID: " + reader["Site_ID"] +
//                        " Customer_Site_ID: " + reader["Customer_Site_ID"] +
//                        " Internal_Site_ID: " + reader["Internal_Site_ID"] +
//                        " Date: " + reader["Date"]);
//_mDB.Close();