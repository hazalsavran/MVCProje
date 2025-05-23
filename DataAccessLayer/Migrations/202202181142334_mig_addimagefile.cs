﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addimagefile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        Imageid = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        Imagepath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Imageid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
