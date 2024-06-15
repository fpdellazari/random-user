CREATE TABLE randomUser (
    id SERIAL PRIMARY KEY,
    gender VARCHAR(10),
    nameTitle VARCHAR(10),
    nameFirst VARCHAR(50),
    nameLast VARCHAR(50),
    email VARCHAR(100),
    dobDate TIMESTAMP,
    dobAge INT,
    registeredDate TIMESTAMP,
    registeredAge INT,
    phone VARCHAR(20),
    cell VARCHAR(20),
    idName VARCHAR(50),
    idValue VARCHAR(50),
    nat VARCHAR(10)
);

CREATE TABLE userLocation (
    userId INT REFERENCES randomUser(id),
    city VARCHAR(50),
    state VARCHAR(50),
    country VARCHAR(50),
    postcode VARCHAR(50),
    streetNumber INT,
    streetName VARCHAR(100),
    coordinatesLatitude VARCHAR(20),
    coordinatesLongitude VARCHAR(20),
    timezoneOffset VARCHAR(20),
    timezoneDescription VARCHAR(100)
);

CREATE TABLE userLogin (
    userId INT REFERENCES randomUser(id),
    uuid UUID,
    username VARCHAR(50),
    password VARCHAR(50),
    salt VARCHAR(50),
    md5 VARCHAR(100),
    sha1 VARCHAR(100),
    sha256 VARCHAR(100)
);

CREATE TABLE userPicture (
    userId INT REFERENCES randomUser(id),
    large TEXT,
    medium TEXT,
    thumbnail TEXT
);

