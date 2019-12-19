
CREATE PROCEDURE spStaffSalary_Create
	
	@StoreId int,
	@StaffId int,
	@Date datetime,
	@Salary money,
	@Details nvarchar(500),
	@ToStaffId int,
	@Id int = 0 output

AS
BEGIN

	SET NOCOUNT ON;

	
	INSERT INTO StaffSalary(StoreId,StaffId,Date,Salary,Details,ToStaffId)
	VALUES (@StoreId,@StaffId,@Date,@Salary,@Details,@ToStaffId);

		SELECT @Id = SCOPE_IDENTITY();
    
END
GO
