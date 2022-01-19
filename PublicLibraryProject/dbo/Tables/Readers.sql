CREATE TABLE Readers 
(
    ReaderId       BIGINT     IDENTITY (1, 1) NOT NULL,
    FirstName       NCHAR (20) NOT NULL,
    LastName        NCHAR (20) NOT NULL,
    MiddleName      NCHAR (20) NULL,
    SubscribeDate   DATE       NOT NULL,
    UnsubscribeDate DATE       NULL,
    CONSTRAINT PK_Readers PRIMARY KEY CLUSTERED (ReaderId ASC)
);

