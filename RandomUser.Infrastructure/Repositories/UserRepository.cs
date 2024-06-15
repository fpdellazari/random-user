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

        public IEnumerable<User> Get() {

            string query = @"    SELECT a.id,
		                                a.gender, 
		                                a.nameTitle, 
		                                a.nameFirst, 
		                                a.nameLast, 
		                                a.email, 
		                                a.dobDate, 
		                                a.dobAge, 
		                                a.registeredDate, 
		                                a.registeredAge, 
		                                a.phone, 
		                                a.cell, 
		                                a.idName, 
		                                a.idValue, 
		                                a.nat,
		                                b.userId, 
	  	                                b.city, 
	  	                                b.state, 
	  	                                b.country, 
	  	                                b.postcode, 
	  	                                b.streetNumber, 
	  	                                b.streetName, 
	  	                                b.coordinatesLatitude, 
	  	                                b.coordinatesLongitude, 
	  	                                b.timezoneOffset, 
	  	                                b.timezoneDescription,
		                                c.userId, 
		                                c.uuid, 
		                                c.username, 
		                                c.password, 
		                                c.salt, 
		                                c.md5, 
		                                c.sha1, 
		                                c.sha256,
		                                d.userId, 
		                                d.large, 
		                                d.medium, 
		                                d.thumbnail
	                                FROM randomUser a
	                                LEFT JOIN userLocation b ON a.id = b.userId
	                                LEFT JOIN userLogin c ON a.id = c.userId
	                                LEFT JOIN userPicture d ON a.id = d.userId;";

            var users = _dbConnection.Query<User, UserLocation, UserLogin, UserPicture, User>(query,
                map: (user, userLocation, userLogin, userPicture) => {
                    user.Location = userLocation;
                    user.Login = userLogin;
                    user.Picture = userPicture;
                    return user;
                }, splitOn: "userId, userId, userId"); 

            return users;
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
                                        @nat) RETURNING id;";
            int userId = _dbConnection.Query(query, user).Single().id;
            user.Location.UserId = userId;
            user.Login.UserId = userId;
            user.Picture.UserId = userId;

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
