using MySql.Data.MySqlClient;

namespace NancyTest.DBRepository
{
    public class DBRepositoryProvider
    {
        #region Attributes

        private readonly string _connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of DBRepository and sets the connection string to the server.
        /// </summary>
        /// <param name="connectionString">Connection string to the server</param>
        public DBRepositoryProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        /// <summary>
        /// Provides an instance of data repository.
        /// </summary>
        /// <returns></returns>
        public DBRepository GetRepository()
        {
            var dbConnection = new MySqlConnection(_connectionString);
            dbConnection.Open();

            return new DBRepository(dbConnection);
        }

    }
}