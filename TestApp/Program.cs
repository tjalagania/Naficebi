using NaficebiLib.DataBaseAccessLayer;
using NaficebiLib.DataBaseSqlLeyer;
using NaficebiLib.Models;

//MsAccessDb db = new MsAccessDb(@"C:\\Users\\tjalagania\\Documents\\SDA_KutaisiCourtData_210616.accdb");

//IEnumerable<PrincipalModel> list = await db.GetAccessTablesAsync();

//for(int i = 0; i < 10; i++)
//{
//    Console.WriteLine(list.ToList()[i].PV_NUNMBER);
//}
var db = new ApplicationDbContext();
Console.ReadLine();