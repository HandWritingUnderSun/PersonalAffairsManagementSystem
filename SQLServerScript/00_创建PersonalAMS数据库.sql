SET NOCOUNT ON;
USE master
IF DB_ID('PersonalAMS') IS NULL 
    CREATE DATABASE PersonalAMS;
GO
USE PersonalAMS;
GO