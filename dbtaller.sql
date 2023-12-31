create database dbtaller

use dbtaller


CREATE TABLE [dbo].[Auto](
	[placa] [char](6) NOT NULL,
	[marca] [varchar](20) NULL,
	[modelo] [varchar](20) NULL,
	[color] [varchar](20) NULL,
	[año] [int] NULL,
	[combustible] [varchar](20) NULL,
 CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED 
(
	[placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'123ZQC', N'Peugeot', N'qqqqq', N'eeeeee', 2022, N'gnv')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'987GFA', N'Mitsubishi', N'ASDAD', N'DASDAS', 2022, N'gnv')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'ASDASD', N'Mazda', N'ASDASD', N'ASDASD', 2022, N'glp')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'ddd123', N'Toyota', N'ddddddd', N'ddddddddd', 2020, N'glp')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'JKL190', N'Mitsubishi', N'ASDAS', N'DASASD', 2020, N'gnv')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'MNB192', N'Toyota', N'asd', N'asd', 2022, N'gnv')
GO
USE [master]
GO
ALTER DATABASE [dbtaller] SET  READ_WRITE 
GO
