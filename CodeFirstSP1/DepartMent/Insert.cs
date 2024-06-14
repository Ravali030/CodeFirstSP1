using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSP1.DepartMent
{
    internal class Insert
    {
        static void Main(string[] args)
        {
            DeptDbContext db = new DeptDbContext();
            DepartMentMaster dm=new DepartMentMaster();
            dm.Deptid = int.Parse(Console.ReadLine());
            dm.deptCode = Console.ReadLine();
            dm.DepartName = Console.ReadLine();
            db.departMentMasters.Add(dm);
            db.SaveChanges();
        }
       
    }
}
