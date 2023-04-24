using NaficebiLib.Models;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.ExcelLeyer
{
    public class ExcelManager
    {
        public void saveToExcel(List<PrincipalModel> list,string filepath)
        {
            using (SLDocument sl = new SLDocument())
            {
                SLStyle stl= new SLStyle();
                stl.SetFontBold(true);
                
                _ = sl.SetCellValue("A1", "#");
                _ = sl.SetCellStyle("A1", stl);
                _ = sl.SetCellValue("B1", "პირადი ნომერი");
                _ = sl.SetCellStyle("B1", stl);
                _ = sl.SetCellValue("C1", "სახელი და გვარი");
                _ = sl.SetCellValue("D1", "დაბადების თარიღი");
                _ = sl.SetCellValue("E1", "მისამართი");
                _ = sl.SetCellStyle("C1", stl);
                _ = sl.SetCellStyle("D1", stl);
                _ = sl.SetCellStyle("E1", stl);
                

                for (int i = 0;i<list.Count;i++)
                {
                    PrincipalModel pr = list[i];
                    sl.SetCellValue($"A{i + 2}", i+1);
                    sl.SetCellValue($"B{i + 2}", pr.PV_NUNMBER);
                    sl.SetCellValue($"C{i + 2}", pr.FullName);
                    sl.SetCellValue($"D{i + 2}", pr.BIRTH_DATE);
                    sl.SetCellValue($"E{i + 2}", pr.BP_FULL_ADDRESS);
                }

                sl.SaveAs(filepath);
            }
        }
    }
}
