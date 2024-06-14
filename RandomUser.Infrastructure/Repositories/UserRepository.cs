using Dapper;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Repositories;
using System.Data;


namespace RandomUser.Infrastructure.Repositories {
    public class UserRepository : IUserRepository {

        private readonly IDbConnection _dbConnection;
        public UserRepository(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
        }

        public void Insert(User user) {

            string query = "";
            query =   @"INSERT INTO randomUser (gender, 
                                                nameTitle, 
                                                nameFirst, 
                                                nameLast, 
                                                email, 
                                                dobDate, 
                                                dobAge, 
                                                registeredDate, 
                                                registeredAge, 
                                                phone, 
                                                cell, 
                                                idName, 
                                                idValue, 
                                                nat) 
                                VALUES (@gender, 
                                        @nameTitle, 
                                        @nameFirst, 
                                        @nameLast, 
                                        @email, 
                                        @dobDate, 
                                        @dobAge, 
                                        @registeredDate, 
                                        @registeredAge, 
                                        @phone, 
                                        @cell, 
                                        @idName, 
                                        @idValue, 
                                        @nat);";
            _dbConnection.Execute(query, user);

            query =   @"INSERT INTO userLocation (userId, 
                                                  city, 
                                                  state, 
                                                  country, 
                                                  postcode, 
                                                  streetNumber, 
                                                  streetName, 
                                                  coordinatesLatitude, 
                                                  coordinatesLongitude, 
                                                  timezoneOffset, 
                                                  timezoneDescription) 
                                    VALUES (@userId, 
                                            @city, 
                                            @state, 
                                            @country, 
                                            @postcode, 
                                            @streetNumber, 
                                            @streetName, 
                                            @coordinatesLatitude, 
                                            @coordinatesLongitude, 
                                            @timezoneOffset, 
                                            @timezoneDescription);";
            _dbConnection.Execute(query, user.Location);

            query =   @"INSERT INTO userLogin (userId, 
                                               uuid, 
                                               username, 
                                               password, 
                                               salt, 
                                               md5, 
                                               sha1, 
                                               sha256)
                               VALUES (@userId, 
                                       @uuid, 
                                       @username, 
                                       @password, 
                                       @salt, 
                                       @md5, 
                                       @sha1, 
                                       @sha256);";
            _dbConnection.Execute(query, user.Login);

            query =   @"INSERT INTO userPicture (userId, 
                                                 large, 
                                                 medium, 
                                                 thumbnail)
                                    VALUES (@userId, 
                                            @large, 
                                            @medium, 
                                            @thumbnail); ";
            _dbConnection.Execute(query, user.Picture);
        }            
    }
}
