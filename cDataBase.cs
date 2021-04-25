using System;
using System.IO;
using System.Collections.Generic;

//SQLite
using System.Data.SQLite;


namespace RA_Killer_V1
{
    class cDataBase
    {
        private SQLiteConnection _mConnection = null;
        private SQLiteCommand _mCommend;
        static private string _mDbName;
        private bool isOpened = false;
        public cDataBase() { }
        public cDataBase(string dbName)
        {
            Open(dbName);
        }
  

        public bool checkCalumnIsExistInTable(string tableName, string columnName)
        {
            if (!isOpened)
            {
                this.Open();
            }
            using (_mCommend = new SQLiteCommand(this._mConnection))
            {
                _mCommend.CommandText = string.Format("PRAGMA table_info({0})", tableName);

                var reader = _mCommend.ExecuteReader();
                int nameIndex = reader.GetOrdinal("Name");
                while (reader.Read())
                {
                    if (reader.GetString(nameIndex).Equals(columnName))
                    {
                        return true;
                    }
                }
            }
            return false;
 
        }
        public bool checkTableIsExist(string tableName) {
            if (!isOpened) 
            {
                this.Open();
            }
            using (_mCommend = new SQLiteCommand(this._mConnection))
            {
                _mCommend.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}';";
                object result = _mCommend.ExecuteScalar();
                int resultCount = Convert.ToInt32(result);
                if (resultCount > 0)
                    return true;

            }
            return false;
        }
        public void createTable(string tableName,string cloumnsAndTypes) 
        {
            if (!checkTableIsExist(tableName))
            {
                using (_mCommend = new SQLiteCommand(_mConnection)) 
                {
                    _mCommend.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({cloumnsAndTypes})";
                    _mCommend.ExecuteNonQuery();
                }
            }
        }
        static public void Create(string dbName = "DB") {
            _mDbName = dbName + ".sqlite";
            if (!File.Exists(_mDbName))
            {
                SQLiteConnection.CreateFile(_mDbName);
            }
        }
        private void Open() {

                if (_mConnection == null)
                {
                    this._mConnection = new SQLiteConnection("Data Source=" + _mDbName + "; Version=3;");
                }
                
                if (this._mConnection.State == System.Data.ConnectionState.Closed)
                {
                    this._mConnection.Open();
                    isOpened = true;
                }
                else
                {
                    throw new SQLiteException("Already opened.");

                } 
        }
        public void Open(string DBName = "DB")
        {
            _mDbName = DBName + ".sqlite";
            if (File.Exists(_mDbName))
            {
                Open();
            }
            else
            {
                Create(DBName);
                Open();
            }
        }
        public void Close()
        {
            if (File.Exists(_mDbName))
            {
                if(_mConnection.State == System.Data.ConnectionState.Open)
                {
                   _mConnection.Close();
                   isOpened = false;
                    _mConnection = null;
                }
                else
                {
                    throw new SQLiteException("Already closed.");
                }
            }

        }
        public void insertToTable(string tableName,string columns ,string values) 
        {
            if (!isOpened)
            {
                this.Open();
            }
            using (_mCommend = new SQLiteCommand(this._mConnection))
            {
                _mCommend.CommandText = $"insert into {tableName} ({columns}) values ({values})";
                _mCommend.ExecuteNonQuery();

            }
        }
        public SQLiteDataReader getReader(string sqlCommendText)
        {
            if (!isOpened)
            {
                this.Open();
            }
            using (_mCommend = new SQLiteCommand(this._mConnection))
            {
                _mCommend.CommandText = sqlCommendText;
                return _mCommend.ExecuteReader();
            }
        }
        public List<(string columnName, string type)> createDataBaseFromExcelFile(string filePath,string name) 
        {
            cExcelAccesser _mExcel = new cExcelAccesser();
            (int r, int c) tableSize;
            List<(string columnName, string type)> _mData = new List<(string columnName, string type)>();
            string cloumnsAndTypes =@"";

            _mExcel.openWorkBook(filePath);
            tableSize = _mExcel.getTableSize(name);
            Open(name);
            if (tableSize.r == 2)
            {
                for (int i = 1; i <= tableSize.c; i++)
                {
                    _mData.Add(((string columnName, string type))(_mExcel.getWorkSheets()[name].Cells[1, i].Value, _mExcel.getWorkSheets()[name].Cells[2, i].Value));
                }
                
            }
            else
            {
                return null;
            }
            for (int i = 0; i < _mData.Count; i++)
            {
                if (i != (_mData.Count-1))
                {
                    cloumnsAndTypes += _mData[i].columnName + @" " + _mData[i].type + @",";
                }
                else
                {
                    cloumnsAndTypes += _mData[i].columnName + @" " + _mData[i].type;
                }
            }
            createTable(name,cloumnsAndTypes);
            return _mData;
        }
        public void insertFromExcelFile(string filePath, string name) 
        {
            string columnName = @"";
            string dataInRow = @"";

            cExcelAccesser _mExcel = new cExcelAccesser();
            (int r, int c) tableSize;
            _mExcel.openWorkBook(filePath);
            tableSize = _mExcel.getTableSize(name);
            //for (int i = 1; i <= tableSize.c; i++)
            //{
            //    if (checkCalumnIsExistInTable(name, columnName = (string)_mExcel.getWorkSheets()[name].Cells[1, i].Value))
            //    {
            //        if (i != tableSize.c)
            //        {
            //            columnName += ",";
            //        }
            //    }
            //    else
            //    {
            //        //TO-DO:
            //    }
            //}
            bool tarih = checkCalumnIsExistInTable(name, "Date");
            //if (tarih)
            //{
            //    columnName += ",Date";
            //}
            for (int r = 1; r <= tableSize.r; r++)
            {
                for (int c = 1; c <= tableSize.c; c++) 
                {
                    if (r==1)
                    {

                        if (checkCalumnIsExistInTable(name,(string)_mExcel.getWorkSheets()[name].Cells[1, c].Value))
                        {
                            columnName += (string)_mExcel.getWorkSheets()[name].Cells[1, c].Value;
                            if (c == tableSize.c)
                            {
                                if (tarih)
                                {
                                    columnName += ",Date";
                                }
                                break;
                                
                            }
                            columnName += ",";

                        }
                    }
                    else
                    {
                        if (checkCalumnIsExistInTable(name,(string)_mExcel.getWorkSheets()[name].Cells[1, c].Value))
                        {
                            dataInRow += $"'{_mExcel.getWorkSheets()[name].Cells[r, c].Value}'";
                            if (c != tableSize.c)
                            {
                                dataInRow += ",";
                            }
                            else
                            {
                                if (tarih)
                                {
                                    dataInRow += @",datetime()";
                                }
                                insertToTable(name, columnName, dataInRow);
                                dataInRow = @"";

                            }

                        }
                    }
                    
                }
            }
        }



    }
}
