using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSP1.DepartMent
{
    internal class DeptDbContext:DbContext
    {
        public DeptDbContext():base("name=DeptEntities")
        {
            Database.Log=Console.WriteLine;
        }
        
        public DbSet<DepartMentMaster> departMentMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartMentMaster>().MapToStoredProcedures
                (s => s.Insert(u => u.HasName("InsertEmployee", "dbo"))
                                            .Update(u => u.HasName("UpdateEmployee", "dbo"))
                                            .Delete(u => u.HasName("DeleteEmployee", "dbo"))
                                            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
