using System;
using System.Data.SQLite;
using System.IO;

using NetOffice.ExcelApi.Enums;
using NetOffice.ExcelApi.Tools.Contribution;

namespace RA_Killer_V1
{
   
    class main
    {
        static void Main(string[] args)
        {
            cDataBase _mDB = new cDataBase();
            _mDB.createDataBaseFromExcelFile("C:\\Users\\cemal\\Desktop\\DataBase.xlsx", "Hakediş");
            _mDB.insertFromExcelFile("C:\\Users\\cemal\\Desktop\\Data.xlsx", "Hakediş");
            SQLiteDataReader reader = _mDB.getReader("select * from Hakediş order by NO ASC");
            while (reader.Read())
                Console.WriteLine("No: " + reader["No"] +
                                    "  Site_ID: " + reader["Site_ID"] +
                                    " Customer_Site_ID: " + reader["Customer_Site_ID"] +
                                    " Internal_Site_ID: " + reader["Internal_Site_ID"] +
                                    " Date: " + reader["Date"]);

            System.Console.ReadLine();
        }
    }
}






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