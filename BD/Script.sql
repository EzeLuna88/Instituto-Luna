USE [master]
GO
/****** Object:  Database [LugTp2]    Script Date: 11/11/2022 3:03:31 PM ******/
CREATE DATABASE [LugTp2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LugTp1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LugTp1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LugTp1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LugTp1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LugTp2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LugTp2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LugTp2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LugTp2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LugTp2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LugTp2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LugTp2] SET ARITHABORT OFF 
GO
ALTER DATABASE [LugTp2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LugTp2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LugTp2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LugTp2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LugTp2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LugTp2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LugTp2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LugTp2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LugTp2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LugTp2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LugTp2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LugTp2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LugTp2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LugTp2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LugTp2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LugTp2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LugTp2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LugTp2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LugTp2] SET  MULTI_USER 
GO
ALTER DATABASE [LugTp2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LugTp2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LugTp2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LugTp2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LugTp2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LugTp2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LugTp2] SET QUERY_STORE = OFF
GO
USE [LugTp2]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[FechaDeNacimiento] [date] NULL,
	[Direccion] [nvarchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dni] [int] NULL,
	[Becado] [bit] NULL,
	[Matricula_Pagada] [bit] NULL,
	[Cod_Carrera] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera_Alumno]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera_Alumno](
	[Cod_Carrera] [int] NULL,
	[Cod_Alumno] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera_Materia]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera_Materia](
	[Cod_Carrera] [int] NULL,
	[Cod_Materia] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Cod_Profesor] [int] NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Dni] [int] NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Contrasenia] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrera_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Alumno_Alumno] FOREIGN KEY([Cod_Alumno])
REFERENCES [dbo].[Alumno] ([Codigo])
GO
ALTER TABLE [dbo].[Carrera_Alumno] CHECK CONSTRAINT [FK_Carrera_Alumno_Alumno]
GO
ALTER TABLE [dbo].[Carrera_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Alumno_Carrera] FOREIGN KEY([Cod_Carrera])
REFERENCES [dbo].[Carrera] ([Codigo])
GO
ALTER TABLE [dbo].[Carrera_Alumno] CHECK CONSTRAINT [FK_Carrera_Alumno_Carrera]
GO
ALTER TABLE [dbo].[Carrera_Materia]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Materia_Carrera] FOREIGN KEY([Cod_Carrera])
REFERENCES [dbo].[Carrera] ([Codigo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carrera_Materia] CHECK CONSTRAINT [FK_Carrera_Materia_Carrera]
GO
ALTER TABLE [dbo].[Carrera_Materia]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Materia_Materia] FOREIGN KEY([Cod_Materia])
REFERENCES [dbo].[Materia] ([Codigo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carrera_Materia] CHECK CONSTRAINT [FK_Carrera_Materia_Materia]
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Profesor] FOREIGN KEY([Cod_Profesor])
REFERENCES [dbo].[Profesor] ([Codigo])
GO
ALTER TABLE [dbo].[Materia] CHECK CONSTRAINT [FK_Materia_Profesor]
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Baja]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Alumno_Baja]
	-- Add the parameters for the stored procedure here
	@Codigo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from Carrera_Alumno where [Cod_Alumno] = @Codigo
	DELETE from Alumno where [Codigo] = @Codigo
	
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Becado_Y_Regular]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Becado_Y_Regular]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
SUM (case when Becado = 1 THEN 1 ELSE 0 END) AS Becado,
SUM(CASE WHEN Becado = 0 then 1 else 0 end) AS Regular
from Alumno

END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Devolver]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Alumno_Devolver]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Alumno
	where Codigo = (Select MAX(Codigo) from Alumno)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Guardar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Alumno_Guardar]
	
	@Dni int,
	@Nombre nvarchar(50),
	@Apellido nvarchar (50),
	@FechaDeNacimiento date,
	@Email nvarchar(50),
	@Telefono int,
	@Direccion nvarchar(50),
	@Cod_Carrera int,
	@Becado bit

	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Alumno
				(Dni, Nombre, Apellido, FechaDeNacimiento, Email, Telefono, Direccion, Cod_Carrera, Becado)
				values
				(@Dni, @Nombre, @Apellido, @FechaDeNacimiento, @Email, @Telefono, @Direccion, @Cod_Carrera, @Becado)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Listar_Becados]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Listar_Becados]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT * 
	from Alumno
	where Becado = 'true'
	order by Apellido
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Listar_Matricula_No_Pagada]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Listar_Matricula_No_Pagada]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	from Alumno
	where Matricula_Pagada is NULL
	order by Apellido
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Listar_Matricula_Pagada]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Listar_Matricula_Pagada]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * 
	from Alumno
	where Matricula_Pagada = 'true'
	order by Apellido
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Listar_Por_Carrera]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Listar_Por_Carrera]

@Codigo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.Apellido, A.Nombre, A.FechaDeNacimiento, A.Email, A.Dni
	from Alumno A
	where A.Cod_Carrera = @Codigo

END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Listar_Regulares]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Listar_Regulares]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * 
	from Alumno
	where Becado = 'false'
	order by Apellido
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Listar_Todo]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[S_Alumno_Listar_Todo] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	from Alumno
	order by Apellido
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Modificar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Alumno_Modificar]
	
	@Dni int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@FechaDeNacimiento date,
	@Email nvarchar(50),
	@Telefono int, 
	@Direccion nvarchar (50),
	@MatriculaPagada bit,
	@Codigo int,
	@Becado bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Alumno
	set [Dni] = @Dni, 
		[Nombre] = @Nombre,
		[Apellido] = @Apellido,
		[FechaDeNacimiento] = @FechaDeNacimiento,
		[Email] = @Email,
		[Telefono] = @Telefono,
		[Direccion] = @Direccion,
		[Matricula_Pagada] = @MatriculaPagada,
		[Becado] = @Becado
	where Codigo = @Codigo

END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Rango_Edades]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Rango_Edades]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select 
SUM (CASE WHEN floor(
(cast(convert(varchar(8),getdate(),112) as int)-
cast(convert(varchar(8),Alumno.FechaDeNacimiento,112) as int) ) / 10000
) BETWEEN 18 AND 30 THEN 1 ELSE 0 END) AS [18-30],
SUM (CASE WHEN floor(
(cast(convert(varchar(8),getdate(),112) as int)-
cast(convert(varchar(8),Alumno.FechaDeNacimiento,112) as int) ) / 10000
) BETWEEN 31 AND 40 THEN 1 ELSE 0 END) AS [31-40],
SUM (CASE WHEN floor(
(cast(convert(varchar(8),getdate(),112) as int)-
cast(convert(varchar(8),Alumno.FechaDeNacimiento,112) as int) ) / 10000
) BETWEEN 41 AND 50 THEN 1 ELSE 0 END) AS [41-50],
SUM (CASE WHEN floor(
(cast(convert(varchar(8),getdate(),112) as int)-
cast(convert(varchar(8),Alumno.FechaDeNacimiento,112) as int) ) / 10000
) BETWEEN 51 AND 60 THEN 1 ELSE 0 END) AS [51-60],
SUM (CASE WHEN floor(
(cast(convert(varchar(8),getdate(),112) as int)-
cast(convert(varchar(8),Alumno.FechaDeNacimiento,112) as int) ) / 10000
) BETWEEN 61 AND 70 THEN 1 ELSE 0 END) AS [61-70]
from Alumno

Select floor(
(cast(convert(varchar(8),getdate(),112) as int)-
cast(convert(varchar(8),Alumno.FechaDeNacimiento,112) as int) ) / 10000
) as edad from Alumno



END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Total]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Alumno_Total]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT count (*)
	from Alumno
END
GO
/****** Object:  StoredProcedure [dbo].[S_Alumno_Totales_Matricula]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Alumno_Totales_Matricula]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
SUM (case when Matricula_Pagada = 1 THEN 1 ELSE 0 END) AS Pagada,
SUM(CASE WHEN Matricula_Pagada IS NULL then 1 else 0 end) AS "No Pagada"
from Alumno

END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Agregar_Alumno]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Agregar_Alumno]
	
	@CodigoCarrera int,
	@CodigoAlumno int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT into Carrera_Alumno
				(Cod_Carrera, Cod_Alumno)
				values
				(@CodigoCarrera, @CodigoAlumno)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Agregar_Materia]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Agregar_Materia]
	
	@CodigoCarrera int,
	@CodigoMateria int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT into Carrera_Materia
				(Cod_Carrera, Cod_Materia)
				values
				(@CodigoCarrera, @CodigoMateria)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Baja]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Baja]
	
	@Codigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from Carrera_Alumno where [Cod_Carrera] = @Codigo
	DELETE from Carrera where [Codigo] = @Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Borrar_Materia]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Borrar_Materia]
	
	@CodigoCarrera int,
	@CodigoMateria int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
   DELETE from Carrera_Materia
   where [Cod_Carrera] = @CodigoCarrera
   and [Cod_Materia] = @CodigoMateria
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Guardar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Guardar] 
	
	@Nombre nvarchar (50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT into Carrera
				(Nombre)
				values 
				(@Nombre)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Lista_Materias]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Lista_Materias]
	
	@Codigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT M.Codigo, M.Nombre, P.Codigo, P.Nombre, P.Apellido, P.Dni
	from Materia as M, Carrera_Materia as C, Profesor as P
	where M.Codigo = C.Cod_Materia and C.Cod_Carrera = @Codigo and M.Cod_Profesor = P.Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Listar_Todo]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Carrera_Listar_Todo] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Codigo, Nombre
	from Carrera
	order by Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Modificar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Modificar]
	
	@Nombre nvarchar(50),
	@Codigo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   UPDATE Carrera 
   set [Nombre] = @Nombre
   where [Codigo] = @Codigo
   
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Total]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Total]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT count (*) from Carrera
END
GO
/****** Object:  StoredProcedure [dbo].[S_Carrera_Totales_Alumnos]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Carrera_Totales_Alumnos]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT C.Nombre,
	count (Cod_Carrera) as Cantidad
	from Carrera_Alumno as CA 
	inner join Carrera as C
	on CA.Cod_Carrera = C.Codigo
	group by C.Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[S_Materia_Baja]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Materia_Baja]
	
	@Codigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE from Materia
	where [Codigo] = @Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[S_Materia_Guardar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Materia_Guardar]
	
	@Nombre nvarchar(50),
	@CodigoProfesor int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT into Materia
				(Nombre, Cod_Profesor)
				values
				(@Nombre, @CodigoProfesor)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Materia_Listar_Todo]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Materia_Listar_Todo]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT M.Codigo, M.Nombre, P.Codigo, P.Nombre, P.Apellido, P.Dni
	from Materia as M, Profesor as P
	where M.Cod_Profesor = P.Codigo
	order by M.Nombre asc
END
GO
/****** Object:  StoredProcedure [dbo].[S_Materia_Modificar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Materia_Modificar]
	
	@Nombre nvarchar(50),
	@CodigoProfesor int,
	@Codigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   UPDATE Materia
   set [Nombre] = @Nombre,
		[Cod_Profesor] = @CodigoProfesor
	where Codigo = @Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[S_Materia_Obtener_Codigo]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Materia_Obtener_Codigo] 
	
	@Nombre nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Codigo, Nombre, Cod_Profesor
	from Materia
	where [Nombre] = @Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[S_Profesor_Baja]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Profesor_Baja]

	@Codigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE from Profesor
	where [Codigo] = @Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[S_Profesor_Guardar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Profesor_Guardar]
	
	@Nombre nvarchar (50),
	@Apellido nvarchar (50),
	@Dni int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT into Profesor
				(Nombre, Apellido, Dni)
				values
				(@Nombre, @Apellido, @Dni)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Profesor_Listar_Todo]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Profesor_Listar_Todo]


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
	from Profesor
	order by Apellido
END
GO
/****** Object:  StoredProcedure [dbo].[S_Profesor_Modificar]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Profesor_Modificar]

	@Nombre nvarchar (50),
	@Apellido nvarchar (50),
	@Dni int,
	@Codigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Profesor 
	set [Nombre] = @Nombre,
		[Apellido] = @Apellido,
		[Dni] = @Dni
	where [Codigo] = @Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[S_Profesor_Total]    Script Date: 11/11/2022 3:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Profesor_Total]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT count (*) from Profesor
END
GO
USE [master]
GO
ALTER DATABASE [LugTp2] SET  READ_WRITE 
GO
