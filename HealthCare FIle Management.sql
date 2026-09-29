CREATE DATABASE IF NOT EXISTS HealthCare_File_Management;
USE HealthCare_File_Management;

DROP TABLE IF EXISTS visit;
DROP TABLE IF EXISTS patient;

CREATE TABLE patient
(
	patientID INT UNIQUE NOT NULL PRIMARY KEY,
    patientName VARCHAR(50) NOT NULL,
    patientSurname VARCHAR(50) NOT NULL,
    address TEXT
);

CREATE TABLE visit
(
	visitID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    visitDate DATETIME NOT NULL,
    complaint TEXT NOT NULL,
    physicalExaminationNotes TEXT NOT NULL,
    prescribedMedication TEXT NOT NULL,
    patientID INT,
    FOREIGN KEY (patientID) REFERENCES patient(patientID)
);