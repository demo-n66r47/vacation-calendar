namespace VacationCalendar.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class InitialCreate : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				 "Helper.Day",
				 c => new
				 {
					 ID = c.Int( nullable: false ),
				 } )
				 .PrimaryKey( t => t.ID, name: "PK_Day" );

			CreateTable(
				 "dbo.Employee",
				 c => new
				 {
					 ID = c.Int( nullable: false, identity: true ),
					 FirstName = c.String( nullable: false, maxLength: 50 ),
					 LastName = c.String( nullable: false, maxLength: 50 ),
					 RowVersion = c.Binary( nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion" ),
					 OwnerID = c.String( maxLength: 128 ),
				 } )
				 .PrimaryKey( t => t.ID, name: "PK_Employee" )
				 .Index( t => new { t.FirstName, t.LastName }, unique: true, name: "UX_Employee_FirstLastName" );

			CreateTable(
				 "dbo.Vacation",
				 c => new
				 {
					 ID = c.Int( nullable: false, identity: true ),
					 EmployeeID = c.Int( nullable: false ),
					 DateFrom = c.DateTime( nullable: false, storeType: "date" ),
					 DateTo = c.DateTime( nullable: false, storeType: "date" ),
					 VacationType = c.Byte( nullable: false ),
					 RowVersion = c.Binary( nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion" ),
				 } )
				 .PrimaryKey( t => t.ID, name: "PK_Vacation" )
				 .ForeignKey( "dbo.Employee", t => t.EmployeeID, cascadeDelete: true, name: "FK_Vacation_Employee" )
				 .Index( t => new { t.EmployeeID, t.DateFrom, t.DateTo }, name: "IX_Vacation_EmployeeIdDateFromTo" );

			Sql( SqlHelper.GetSql( "InitialCreate", true ) );
		}

		public override void Down()
		{
			Sql( SqlHelper.GetSql( "InitialCreate", false ) );

			DropForeignKey( "dbo.Vacation", "EmployeeID", "dbo.Employee" );
			DropIndex( "dbo.Vacation", "IX_Vacation_EmployeeIdDateFromTo" );
			DropIndex( "dbo.Employee", "UX_Employee_FirstLastName" );
			DropTable( "dbo.Vacation" );
			DropTable( "dbo.Employee" );
			DropTable( "Helper.Day" );
		}
	}
}
