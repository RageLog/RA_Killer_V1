using System;
using System.Collections.Generic;
using NetOffice;
using Excel = NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;


namespace RA_Killer_V1
{
    using Sheets_t = Dictionary<string, Excel.Worksheet>;
    class cExcelHelper
    {
        
        private Excel.Application _mApplication = new Excel.Application();
        private Excel.Workbook _mWorkBook;
        private Sheets_t _mSheets = new Sheets_t();
        ~cExcelHelper() 
        {
            
            //_mWorkBook.Save();
            _mWorkBook.Close();
            _mWorkBook.Dispose();
            _mApplication.Quit();
            _mApplication.Dispose();
            _mWorkBook = null;
            _mApplication = null;
        }
        public Excel.Application  getApplication() => _mApplication;
        public Excel.Workbook getWorkbook() => _mWorkBook;
        public Sheets_t getWorkSheets() => _mSheets;
        public void openWorkBook(string path) 
        {
            _mWorkBook = _mApplication.Workbooks.Open(path);
            updateWorkSheets();
        }
        public void createWorkSheet(string name) 
        {
            if (!_mSheets.ContainsKey(name))
            {
                _mSheets[name] = (Excel.Worksheet)_mWorkBook.Worksheets.Add();
                _mSheets[name].Name = name;
            }
            else
            {
                throw new ArgumentException(name + " worksheet already exist");
            }
        }
        public Excel.Workbook createWorkBook(string fileName,string sheetName = null) 
        {
            _mWorkBook = _mApplication.Workbooks.Add();
            if (!sheetName.Equals(null))
            {
                foreach (Excel.Worksheet item in _mWorkBook.Worksheets)
                {
                    item.Name = sheetName;
                }

            }
            _mWorkBook.SaveAs(fileName);
            updateWorkSheets();
            return _mWorkBook;
        }

        private void updateWorkSheets() 
        {
            _mSheets.Clear();
            foreach (Excel.Worksheet item in _mWorkBook.Worksheets)
            {
                
                _mSheets[item.Name] = item;
                
            }
        }
        
        public (int, int) getTableSize(string sheetName,int rowStartPoint = 1, int columnStartPoint = 1)//! change to default tulpe parameter
        {
            (int row, int column) size;
            if (_mSheets.ContainsKey(sheetName))
            {
                size.row =_mSheets[sheetName].Cells[_mSheets[sheetName].Rows.Count, columnStartPoint].End(XlDirection.xlUp).Row - rowStartPoint + 1;
                size.column = _mSheets[sheetName].Cells[rowStartPoint, _mSheets[sheetName].Columns.Count].End(XlDirection.xlToLeft).Column - columnStartPoint + 1;
                return size;
            }
            else
            {
                throw new ArgumentException("sheet does not exist!");
            }
        }
        

        



    }
}
