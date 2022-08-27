CREATE TABLE [dbo].[JA_ProcessCodeDataT](
	[ProcessCodeData_UID] [nvarchar](50) NULL,
	[SizingWeek] [nvarchar](50) NULL,
	[PersonnelArea] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedName] [nvarchar](50) NULL,
	[CreatedTime] [nvarchar](50) NULL,
	[Building] [nvarchar](50) NULL,
	[SiteProcess] [nvarchar](50) NULL,
	[SingleMultiple] [nvarchar](50) NULL,
	[Line] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Workstation] [nvarchar](50) NULL,
	[ProcessDescription] [nvarchar](50) NULL,
	[StandardHeadcount] [nvarchar](50) NULL

) ON [PRIMARY]

go
Create PROCEDURE [dbo].[JA_InsProcessCodeDataP]
@ProcessCodeData_UID [nvarchar](50)= NULL,
@SizingWeek [nvarchar](50)= NULL,
@PersonnelArea [nvarchar](50)= NULL,
@CreatedBy [nvarchar](50)= NULL,
@CreatedName [nvarchar](50)= NULL,
@CreatedTime [nvarchar](50)= NULL,
@Building [nvarchar](50)= NULL,
@SiteProcess [nvarchar](50)= NULL,
@SingleMultiple [nvarchar](50)= NULL,
@Line [nvarchar](50)= NULL,
@Department [nvarchar](50)= NULL,
@Workstation [nvarchar](50)= NULL,
@ProcessDescription [nvarchar](50)= NULL,
@StandardHeadcount [nvarchar](50)=NULL

AS
BEGIN
	--SET NOCOUNT ON;
	IF NOT EXISTS(SELECT TOP 1 1 FROM JA_ProcessCodeDataT WHERE 	ProcessCodeData_UID = @ProcessCodeData_UID AND	SizingWeek = @SizingWeek AND	PersonnelArea = @PersonnelArea AND	CreatedBy = @CreatedBy AND	CreatedName = @CreatedName AND	CreatedTime = @CreatedTime AND	Building = @Building AND	SiteProcess = @SiteProcess AND	SingleMultiple = @SingleMultiple AND	Line = @Line AND	Department = @Department AND	Workstation = @Workstation AND	ProcessDescription = @ProcessDescription AND	StandardHeadcount = @StandardHeadcount )
		INSERT INTO JA_ProcessCodeDataT (	ProcessCodeData_UID,	SizingWeek,	PersonnelArea,	CreatedBy,	CreatedName,	CreatedTime,	Building,	SiteProcess,	SingleMultiple,	Line,	Department,	Workstation,	ProcessDescription,	StandardHeadcount)
		VALUES (	@ProcessCodeData_UID,	@SizingWeek,	@PersonnelArea,	@CreatedBy,	@CreatedName,	@CreatedTime,	@Building,	@SiteProcess,	@SingleMultiple,	@Line,	@Department,	@Workstation,	@ProcessDescription,	@StandardHeadcount)
	ELSE
		RAISERROR('The mapping data already exist in the system',16,1)
END

go
Create PROCEDURE [dbo].[JA_UpdProcessCodeDataP]
@ProcessCodeData_UID [nvarchar](50)= NULL,
@SizingWeek [nvarchar](50)= NULL,
@PersonnelArea [nvarchar](50)= NULL,
@CreatedBy [nvarchar](50)= NULL,
@CreatedName [nvarchar](50)= NULL,
@CreatedTime [nvarchar](50)= NULL,
@Building [nvarchar](50)= NULL,
@SiteProcess [nvarchar](50)= NULL,
@SingleMultiple [nvarchar](50)= NULL,
@Line [nvarchar](50)= NULL,
@Department [nvarchar](50)= NULL,
@Workstation [nvarchar](50)= NULL,
@ProcessDescription [nvarchar](50)= NULL,
@StandardHeadcount [nvarchar](50)=NULL

AS
BEGIN
	--SET NOCOUNT ON;
	IF NOT EXISTS(SELECT TOP 1 1 FROM [JA_ProcessCodeDataT] WHERE 	ProcessCodeData_UID = @ProcessCodeData_UID AND	SizingWeek = @SizingWeek AND	PersonnelArea = @PersonnelArea AND	CreatedBy = @CreatedBy AND	CreatedName = @CreatedName AND	CreatedTime = @CreatedTime AND	Building = @Building AND	SiteProcess = @SiteProcess AND	SingleMultiple = @SingleMultiple AND	Line = @Line AND	Department = @Department AND	Workstation = @Workstation AND	ProcessDescription = @ProcessDescription AND	StandardHeadcount = @StandardHeadcount )
		UPDATE [JA_ProcessCodeDataT]
			SET 
				 	ProcessCodeData_UID = @ProcessCodeData_UID,	SizingWeek = @SizingWeek,	PersonnelArea = @PersonnelArea,	CreatedBy = @CreatedBy,	CreatedName = @CreatedName,	CreatedTime = @CreatedTime,	Building = @Building,	SiteProcess = @SiteProcess,	SingleMultiple = @SingleMultiple,	Line = @Line,	Department = @Department,	Workstation = @Workstation,	ProcessDescription = @ProcessDescription,	StandardHeadcount = @StandardHeadcount 
		WHERE 	ProcessCodeData_UID = @ProcessCodeData_UID;
	ELSE
		RAISERROR('The mapping data already exist in the system',16,1)
END

go
 
Create PROCEDURE [dbo].[JA_GetProcessCodeDataP]
	@page	INT = 1,
	@limit	INT = 20,
@ProcessCodeDataName	NVARCHAR(200) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	DECLARE @RecCount	INT = 0
	SELECT COUNT(*) AS [Count]
	FROM JA_ProcessCodeDataT
	WHERE (@ProcessCodeDataName IS NULL OR ProcessCodeDataName LIKE '%' + @ProcessCodeDataName + '%')
	;
	WITH cte (
		[index],
	ProcessCodeData_UID,	SizingWeek,	PersonnelArea,	CreatedBy,	CreatedName,	CreatedTime,	Building,	SiteProcess,	SingleMultiple,	Line,	Department,	Workstation,	ProcessDescription,	StandardHeadcount
	)
	AS (
		SELECT ROW_NUMBER() OVER(ORDER BY getdate()) AS [index],
	ProcessCodeData_UID,	SizingWeek,	PersonnelArea,	CreatedBy,	CreatedName,	CreatedTime,	Building,	SiteProcess,	SingleMultiple,	Line,	Department,	Workstation,	ProcessDescription,	StandardHeadcount
		FROM JA_ProcessCodeDataT
		WHERE (@ProcessCodeDataName IS NULL OR ProcessCodeDataName LIKE '%' + @ProcessCodeDataName + '%')
	) 
	SELECT [index],
	ProcessCodeData_UID,	SizingWeek,	PersonnelArea,	CreatedBy,	CreatedName,	CreatedTime,	Building,	SiteProcess,	SingleMultiple,	Line,	Department,	Workstation,	ProcessDescription,	StandardHeadcount
	FROM cte
	ORDER BY ProcessCodeDataName
	OFFSET @limit * (@page - 1) ROWS
	FETCH NEXT @limit ROWS ONLY OPTION (RECOMPILE);
END

go
Create PROCEDURE [dbo].[JA_DelProcessCodeDataP]
	@ProcessCodeData_UID varchar(50)
AS
BEGIN
	DELETE FROM JA_ProcessCodeDataT 
 where		ProcessCodeData_UID = @ProcessCodeData_UID
END

