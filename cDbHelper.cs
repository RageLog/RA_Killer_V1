using System;
using System.IO;
using System.Collections.Generic;

//SQLite
using System.Data.SQLite;


namespace RA_Killer_V1
{
    class cDbHelper 
    {
        private string _mDbName;
        private string _mConString;
        public cDbHelper(string dbName = "DB.sqlite")
        {
            _mDbName = dbName;
            _mConString = "Data Source=" + _mDbName + "; Version=3;";
        }
        public void ExecuteNonQuery(string SQL)
        {
            using (SQLiteConnection c = new SQLiteConnection(_mConString))
            {
                c.Open();
                using (SQLiteCommand cmd =  new SQLiteCommand(SQL, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteReader(string SQL, Action<SQLiteDataReader> func)
        {
            using (SQLiteConnection c = new SQLiteConnection(_mConString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(SQL, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        func(rdr);
                    }
                }
            }
        }
        public bool CheckColumnIsExistInTable(string tableName, string columnName)
        {
            bool retVal = false;

            void func(SQLiteDataReader rdr) 
            {
                int nameIndex = rdr.GetOrdinal("Name");
                while (rdr.Read())
                {
                    if (rdr.GetString(nameIndex).Equals(columnName))
                    {
                        retVal = true;
                    }
                }
            }
            ExecuteReader($"PRAGMA table_info({tableName})", func);
            return retVal;
            
        }
        public bool CheckTableIsExist(string tableName)
        {
            bool retVal = false;

            using (SQLiteConnection c = new SQLiteConnection(_mConString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}';", c))
                {
                    object result = cmd.ExecuteScalar();
                    int resultCount = Convert.ToInt32(result);
                    if (resultCount > 0) retVal = true;
                }
            }
            return retVal;
        }
        public void Create(string path = @"")
        {
            
            if (!File.Exists(path+_mDbName))
            {
                SQLiteConnection.CreateFile(path + _mDbName);
            }
            else
            {
                throw new Exception("");
            }
        }
        public void CreateTable(string tableName, string cloumnsAndTypes)
        {
            if (!CheckTableIsExist(tableName))
            {
                ExecuteNonQuery($"CREATE TABLE IF NOT EXISTS {tableName} ({cloumnsAndTypes})");
            }
            else
            {
                throw new Exception($"{tableName} table is already exist");
            }
        }
        public void RemoveTable(string tableName)
        {
            if (CheckTableIsExist(tableName))
            {
                ExecuteNonQuery($"DROP TABLE IF EXISTS {tableName}");
            }
            else
            {
                throw new Exception($"{tableName} table is not exist");
            }
        }
        public void InsertToTable(string tableName, string columns, string values)
        {
            ExecuteNonQuery($"insert into {tableName} ({columns}) values ({values})");
        }
        public List<(string columnName, string type)> CreateTableFromExcelFile(string filePath, string name)
        {
            cExcelHelper _mExcel = new cExcelHelper();
            (int r, int c) tableSize;
            List<(string columnName, string type)> _mData = new List<(string columnName, string type)>();
            string cloumnsAndTypes = @"";

            _mExcel.openWorkBook(filePath);
            tableSize = _mExcel.getTableSize(name);
            Create();
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
                if (i != (_mData.Count - 1))
                {
                    cloumnsAndTypes += _mData[i].columnName + @" " + _mData[i].type + @",";
                }
                else
                {
                    cloumnsAndTypes += _mData[i].columnName + @" " + _mData[i].type;
                }
            }
            CreateTable(name, cloumnsAndTypes);
            return _mData;
        }
        public void InsertFromExcelFile(string filePath, string name)
        {
            string columnName = @"";
            string dataInRow = @"";

            cExcelHelper _mExcel = new cExcelHelper();
            (int r, int c) tableSize;
            _mExcel.openWorkBook(filePath);
            tableSize = _mExcel.getTableSize(name);
      
            for (int r = 1; r <= tableSize.r; r++)
            {
                for (int c = 1; c <= tableSize.c; c++)
                {
                    if (r == 1)
                    {

                        if (CheckColumnIsExistInTable(name, (string)_mExcel.getWorkSheets()[name].Cells[1, c].Value))
                        {
                            columnName += (string)_mExcel.getWorkSheets()[name].Cells[1, c].Value;
                            if (c != tableSize.c)
                            {
                                columnName += ",";

                            }
                        }
                    }
                    else
                    {
                        if (CheckColumnIsExistInTable(name, (string)_mExcel.getWorkSheets()[name].Cells[1, c].Value))
                        {
                            dataInRow += $"'{_mExcel.getWorkSheets()[name].Cells[r, c].Value}'";
                            if (c != tableSize.c)
                            {
                                dataInRow += ",";
                            }
                            else
                            {
                                InsertToTable(name, columnName, dataInRow);
                                dataInRow = @"";

                            }

                        }
                    }

                }
            }
        }
        public void AddColumnToTable(string tableName, string columnName, string columnType)
        {
            if (!CheckColumnIsExistInTable(tableName, columnName))
            {
                ExecuteNonQuery($"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnType}");
            }
            else
            {
                throw new Exception($"{columnName} {columnType} is alread exist in table {tableName}");
            }
        }
        public void ChangeColumnName(string tableName, string oldColumnName, string newColumnName)
        {
            ExecuteNonQuery($"ALTER TABLE {tableName} RENAME COLUMN {oldColumnName} TO {newColumnName};");
        }
        public void RemoveColumnToTable(string tableName, string columnName)
        {
            if (CheckColumnIsExistInTable(tableName, columnName))
            {
                string cols = @"";
                string colsType = @"";

                void func(SQLiteDataReader rdr)
                {
                    int nameIndex = rdr.GetOrdinal("Name");
                    int typeIndex = rdr.GetOrdinal("Type");
                    int notNull = rdr.GetOrdinal("notnull");
                    int primaryKey = rdr.GetOrdinal("pk");
                    while (rdr.Read())
                        if (!rdr.GetString(nameIndex).Equals(columnName))
                        {
                            cols += rdr.GetString(nameIndex) + @",";
                            colsType += rdr.GetString(nameIndex) + " " + rdr.GetString(typeIndex);
                            if (rdr.GetBoolean(notNull))
                            {
                                colsType += " NOT NULL";
                            }
                            if (rdr.GetBoolean(primaryKey))
                            {
                                bool isAutoInc = false;
                                void func2(SQLiteDataReader rdr2)//
                                {
                                    while (rdr2.Read())
                                    {
                                        
                                        isAutoInc = rdr2["COUNT(*)"].ToString().Equals("1");
                                    }
                                }
                                ExecuteReader($"SELECT COUNT(*) FROM sqlite_sequence WHERE name='{tableName}';", func2);
                                colsType += " PRIMARY KEY";
                                if (isAutoInc)
                                {
                                    colsType += " AUTOINCREMENT";
                                }

                            }
                            colsType += ",";
                        }
                    cols = cols.Remove(cols.Length - 1, 1);
                    colsType = colsType.Remove(colsType.Length - 1, 1);
                }
                ExecuteReader($"PRAGMA table_info({tableName})",func);

                ExecuteNonQuery(
                      $"PRAGMA foreign_keys=off;" +
                      $"BEGIN TRANSACTION;" +
                      $"CREATE TEMPORARY TABLE TEMP ({colsType});"+
                      $"INSERT INTO TEMP SELECT {cols} FROM {tableName};"+
                      $"DROP TABLE {tableName};"+
                      $"CREATE TABLE {tableName}({colsType});"+
                      $"INSERT INTO {tableName} SELECT {cols} FROM TEMP;"+
                      $"DROP TABLE TEMP;"+
                      $"COMMIT;" +
                      $"PRAGMA foreign_keys=on;");
            }
        }
        public List<(string columnName, string type)> GetColumnNames(string tableName)
        {
            List<(string columnName, string type)> _mData = new List<(string columnName, string type)>();
            void func(SQLiteDataReader rdr)
            {
                int nameIndex = rdr.GetOrdinal("Name");
                int typeIndex = rdr.GetOrdinal("Type");
                
                while (rdr.Read())
                {
                    _mData.Add((rdr.GetString(nameIndex), rdr.GetString(typeIndex)));
                }
            }
            ExecuteReader($"PRAGMA table_info({tableName})", func);
            return _mData;
        }
        public List<Dictionary<string,string>> SearchFor(string tableName, string columnName, string searchTerm) 
        {
            List<Dictionary<string, string>> _mData = new List<Dictionary<string, string>>();
            var colNamesAndType = GetColumnNames(tableName);
            void func(SQLiteDataReader rdr)
            {
                while (rdr.Read())
                {
                    Dictionary<string, string> _mDic = new Dictionary<string, string>();
                    foreach (var item in colNamesAndType)
                    {
                        _mDic.Add(item.columnName, rdr[item.columnName].ToString());
                    }
                    _mData.Add(_mDic);
                }
            }
            ExecuteReader($"SELECT * FROM {tableName} WHERE {columnName} LIKE '%{searchTerm}%'",func);
            return _mData;
        }
        public void UpdateData(string tableName, string columnAndvalue, string Condition, string orderingTerm = null, string limitTerm = null,string offsetTerm = null)
        {
            string SQL = $"UPDATE {tableName} SET {columnAndvalue} WHERE {Condition}";
            if (orderingTerm != null)
            {
                SQL += @" ORDER " + orderingTerm;
            }
            if (limitTerm != null)
            {
                SQL += @" LIMIT " + limitTerm;
            }
            if (offsetTerm != null)
            {
                SQL += @" OFFSET " + offsetTerm;
            }
            ExecuteNonQuery(SQL);
        }
        public void RemoveData(string tableName, string Condition = null, string orderingTerm = null, string limitTerm = null, string offsetTerm = null)
        {
            string SQL = $"DELETE FROM {tableName}";
            if (Condition != null)
            {
                SQL += @" WHERE " + Condition;
            }
            if (orderingTerm != null)
            {
                SQL += @" ORDER " + orderingTerm;
            }
            if (limitTerm != null)
            {
                SQL += @" LIMIT " + limitTerm;
            }
            if (offsetTerm != null)
            {
                SQL += @" OFFSET " + offsetTerm;
            }

            ExecuteNonQuery(SQL);
        }
        public List<Dictionary<string, string>> GetNonRepetitiveValue(string tableName, string columnsName)
        {
            List<Dictionary<string, string>> _mData = new List<Dictionary<string, string>>();
            string[] colNamesAndType = columnsName.Split(',');
            void func(SQLiteDataReader rdr)
            {
                while (rdr.Read())
                {
                    Dictionary<string, string> _mDic = new Dictionary<string, string>();
                    foreach (var item in colNamesAndType)
                    {
                        _mDic.Add(item.Trim(), rdr[item.Trim()].ToString());
                    }
                    _mData.Add(_mDic);
                }
            }
            ExecuteReader($"SELECT DISTINCT {columnsName} FROM {tableName}; ", func);
            return _mData;
        }
    }
}
