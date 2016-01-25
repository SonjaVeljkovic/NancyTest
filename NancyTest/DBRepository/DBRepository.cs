using Dapper;
using MySql.Data.MySqlClient;
using NancyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NancyTest.DBRepository
{
    public class DBRepository
    {
        #region Atributes

        private readonly MySqlConnection _dbConnection;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of data repository.
        /// </summary>
        /// <param name="dbConnection">An open connection to MySql server</param>
        public DBRepository(MySqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #endregion

        #region Database operations

        /// <summary>
        /// Creates specified location into the database.
        /// </summary>
        /// <param name="location">Location to be inserted</param>
        public void InsertLocation(Location location)
        {
            int id = _dbConnection.Query<int>(
                @"insert into location(Title, Latitude, Longitude)
				values (@Title, @Latitude, @Longitude);
                select cast(LAST_INSERT_ID() as unsigned)",
                param: location).Single();

            var rows = location.Keywords.Select(x => new { ID_location = id, Keyword = x });
            _dbConnection.Execute(
                @"insert into locationkeyword(ID_Location, Keyword)
            				values (@ID_location, @Keyword)",
                param: rows);
        }

        /// <summary>
        /// Gets location which have criteria as part of the title or as part of the keyword.
        /// </summary>
        /// <param name="criteria">Specified criteria</param>
        /// <returns>List of locations</returns>
        public List<Location> GetLocationsForAutocomplete(string criteria)
        {
            IEnumerable<Location> queryResult = _dbConnection.Query<Location>(
                string.Format(@"select distinct l.*
                from location l
                join locationkeyword lk on lk.ID_Location = l.ID
                where l.Title like '%{0}%'
                or lk.Keyword like '%{0}%'", criteria),
                param: null);

            return queryResult.ToList();
        }
        
        #endregion
    }
}