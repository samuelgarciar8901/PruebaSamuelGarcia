CREATE DATABASE DbDoubleVPartners;
GO

USE DbDoubleVPartners;
GO

CREATE TABLE Tickets(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Usuario VARCHAR(20) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaActualizacion DATETIME NULL,
    Estatus BIT NOT NULL
);
GO
