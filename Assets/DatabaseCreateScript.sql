use dmab0914_2Sem_3

create table Player
(
	PlayerID	int Not NULL Identity(1,1),
	Username	varchar(20) Not NULL,
	Password	varchar(MAX) Not NULL,
	Email		varchar(40) Not NULL,
	primary key(PlayerID)
)

Create table Gamemodes
(
	GamemodeID	int Not NULL,
	GamemodeName varchar(max) Not NULL,
	primary key(GamemodeID)
)

create table Score
(
	PLayerID	int Not NULL,	
	GamemodeID	int Not NULL,
	Score		int,
	primary key(PlayerID, GamemodeID),
	foreign key(PlayerID) references Player(PlayerID),
	foreign key(GamemodeID) references Gamemodes(GamemodeID)
)
