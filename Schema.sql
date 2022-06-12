use futebol

CREATE TABLE Usuario(
	Id_Usuario INT NOT NULL IDENTITY(1,1),
	Login VARCHAR(100) NOT NULL,
	Senha VARCHAR(60) NOT NULL,
	Nome VARCHAR(30) NOT NULL,
	Sobrenome VARCHAR(30) NOT NULL,
	PRIMARY KEY(Id_Usuario)
)

CREATE TABLE Usuario_Agendamento(
	Id_Usuario_Agendamento INT NOT NULL IDENTITY(1,1),
	Id_Quadra INT NOT NULL,
	Horario DATETIME NULL,
	Jogadores TINYINT NOT NULL,
	Incluir_Bola Bit NOT NULL,
	Incluir_Colete Bit NOT NULL,
	Usuario_Id_Usuario INT NOT NULL,
	PRIMARY KEY(Id_Usuario_Agendamento),
	CONSTRAINT FK_Usuario_Usuario_Agendamento FOREIGN KEY(Usuario_Id_Usuario) REFERENCES Usuario(Id_Usuario)
)

CREATE TABLE Usuario_Plano(
	Id_Usuario_Plano INT NOT NULL IDENTITY(1,1),
	Id_Plano INT NOT NULL,
	Usuario_Id_Usuario INT NOT NULL,
	PRIMARY KEY(Id_Usuario_Plano),
	CONSTRAINT FK_Usuario_Usuario_Plano FOREIGN KEY(Usuario_Id_Usuario) REFERENCES Usuario(Id_Usuario)
)

CREATE TABLE Usuario_Equipe(
	Id_Usuario_Equipe INT NOT NULL IDENTITY(1,1),
	Nome Varchar(45) NOT NULL,
	Usuario_Id_Usuario INT NOT NULL,
	PRIMARY KEY(Id_Usuario_Equipe),
	CONSTRAINT FK_Usuario_Usuario_Equipe FOREIGN KEY(Usuario_Id_Usuario) REFERENCES Usuario(Id_Usuario)
)

CREATE TABLE Equipe_Integrante(
	Id_Equipe_Integrante INT NOT NULL IDENTITY(1,1),
	Nome_Integrante Varchar(45) NOT NULL,
	Posicao Varchar(10) NOT NULL,
	Usuario_Equipe_Id_Usuario_Equipe INT NOT NULL,
	PRIMARY KEY(Id_Equipe_Integrante),
	CONSTRAINT FK_Equipe_Equipe_Integrante FOREIGN KEY(Usuario_Equipe_Id_Usuario_Equipe) REFERENCES Usuario_Equipe(Id_Usuario_Equipe)
)
