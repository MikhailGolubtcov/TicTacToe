USE [master]
GO


CREATE DATABASE [TicTacToe]
GO

USE [TicTacToe]
GO


CREATE TABLE [dbo].[Results](
	[PlayingPairId] [int] NULL,
	[PlayerId] [int] NULL,
	[ClassName] [nvarchar](100) NULL,
	[TeamName] [nvarchar](100) NULL,
	[IsHuman] [bit] NULL,
	[IsWinner] [bit] NULL,
	[RemainingTimeForGame] [time](7) NULL,
	[PlayerCellState] [nvarchar](2) NULL,
	[BattleResult] [nvarchar](100) NULL
) ON [PRIMARY]
GO



CREATE view [dbo].[TotalResults]
as

with cte as (
	select TeamName,
			count(cast(IsWinner as int)) as AmountOfVictories,
			sum(datediff(MILLISECOND, '0:00:00', RemainingTimeForGame)) as RemainingTimeForGame
	from dbo.Results
	where IsWinner = 1
	group by TeamName
),

cte_final as (
	select row_number() over(order by AmountOfVictories desc, RemainingTimeForGame desc) as OrderId,
			TeamName,
			AmountOfVictories,
			convert(time, dateadd(ms, RemainingTimeForGame, 0)) as RemainingTimeForGame
			
	from cte
)

select * 
from cte_final
GO


