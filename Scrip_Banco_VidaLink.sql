Create database TesteVidaLink
Go
Use TesteVidaLink
Go
Create Table Tarefa
( 
	Id int not null primary key identity(1,1),
	nm_Titulo varchar(40),
	nm_descricao varchar(60),
	dt_Execucao date
)
