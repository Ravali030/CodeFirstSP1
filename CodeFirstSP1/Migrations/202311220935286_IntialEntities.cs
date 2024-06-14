namespace CodeFirstSP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartMentMasters",
                c => new
                    {
                        Deptid = c.Int(nullable: false, identity: true),
                        deptCode = c.String(),
                        DepartName = c.String(),
                    })
                .PrimaryKey(t => t.Deptid);
            
            CreateStoredProcedure(
                "dbo.InsertEmployee",
                p => new
                    {
                        deptCode = p.String(),
                        DepartName = p.String(),
                    },
                body:
                    @"INSERT [dbo].[DepartMentMasters]([deptCode], [DepartName])
                      VALUES (@deptCode, @DepartName)
                      
                      DECLARE @Deptid int
                      SELECT @Deptid = [Deptid]
                      FROM [dbo].[DepartMentMasters]
                      WHERE @@ROWCOUNT > 0 AND [Deptid] = scope_identity()
                      
                      SELECT t0.[Deptid]
                      FROM [dbo].[DepartMentMasters] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Deptid] = @Deptid"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateEmployee",
                p => new
                    {
                        Deptid = p.Int(),
                        deptCode = p.String(),
                        DepartName = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[DepartMentMasters]
                      SET [deptCode] = @deptCode, [DepartName] = @DepartName
                      WHERE ([Deptid] = @Deptid)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteEmployee",
                p => new
                    {
                        Deptid = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[DepartMentMasters]
                      WHERE ([Deptid] = @Deptid)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteEmployee");
            DropStoredProcedure("dbo.UpdateEmployee");
            DropStoredProcedure("dbo.InsertEmployee");
            DropTable("dbo.DepartMentMasters");
        }
    }
}
