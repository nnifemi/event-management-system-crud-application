CREATE TABLE Events (
    EventID INT PRIMARY KEY,
    EventName VARCHAR(255),
    EventDate DATE,
    Location VARCHAR(255),
    Description TEXT
);


CREATE TABLE Registrations (
    RegistrationID INT PRIMARY KEY,
    EventID INT,
    ParticipantName VARCHAR(255),
    Email VARCHAR(255),
    RegistrationDate DATETIME,
    PaymentStatus VARCHAR(50),
    FOREIGN KEY (EventID) REFERENCES Events(EventID)
);
