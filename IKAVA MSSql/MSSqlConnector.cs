using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace IKAVA_Systembehandler.DB
{
    public class MSSqlConnector
    {
        public static string Server { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string Table { get; set; }

        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public MSSqlConnector()
        {
            try
            {
                if (!CreateConnection())
                {
                    throw new Exception("Feil ved tilkobling til database. Parameter brukt : Server=" + Server + ", Username=" + Username + ", Password=" + Password + ", Database=" + Database);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MSSqlConnector(string dbServer, string dbUsername, string dbPassword)
        {
            Server = dbServer;
            Username = dbUsername;
            Password = dbPassword;
            try
            {
                if (!CreateConnection())
                {
                    throw new Exception("Feil ved tilkobling til database. Parameter brukt : Server=" + Server + ", Username=" + Username + ", Password=" + Password + ", Database=" + Database);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MSSqlConnector(string dbServer, string dbUsername, string dbPassword, string dbDatabase)
        {
            Server = dbServer;
            Username = dbUsername;
            Password = dbPassword;
            Database = dbDatabase;
            try
            {
                if (!CreateConnection())
                {
                    throw new Exception("Feil ved tilkobling til database. Parameter brukt : Server=" + Server + ", Username=" + Username + ", Password=" + Password + ", Database=" + Database);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// CreateConnection
        /// Creates a connection, end connects to database. 
        /// Requires dbServer, dbDatabase, dbUsername and dbPassword set.
        /// </summary>
        /// <returns>true if ok, false if error</returns>
        public bool CreateConnection()
        {
            string connectionString;
            connectionString = "SERVER=" + Server + ";" + "DATABASE=" + (Database == null ? "" : Database).ToString() + ";" + "UID=" + Username + ";" + "PASSWORD=" + Password + ";";
            connection = new SqlConnection(connectionString + ";Connect Timeout=300");
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Kan ikke koble til server. Endre innstillinger og prøv igjen.");
                    case 1045:
                        throw new Exception("Feil brukernavn/passord-kombinasjon. Prøv igjen!");
                }
                return false;
            }
        }

        public bool HasPrimaryKeys(string table)
        {
            string query = "select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_CATALOG = '" + Database + "' and TABLE_NAME = '" + table + "';";
            cmd = new SqlCommand(query, connection);
            cmd.CommandTimeout = 3000;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
            }
            catch { }
            reader.Close();
            return false;
        }

        public bool CreatePrimaryKeys(string table, string[] ids)
        {
            string query = "ALTER TABLE " + table + " ADD CONSTRAINT pk_myKey PRIMARY KEY (";
            for (int a = 0; a < ids.Count(); a++)
            {
                query += ids[a];
                if (a < ids.Count() - 1)
                    query += ", ";
            }
            query += ");";
            cmd = new SqlCommand(query, connection);
            cmd.CommandTimeout = 3000;
            try
            {
                int b = cmd.ExecuteNonQuery();
                //reader.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<string> GetListOfDatabases()
        {
            List<string> dbList = new List<string>();

            cmd = new SqlCommand("select name from master.sys.databases", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dbList.Add(reader.GetString(0));
            }
            reader.Close();

            return dbList;
        }

        /// <summary>
        /// Lists tables 
        /// </summary>
        /// <returns>List of tables matching tablename-spec</returns>
        public List<string> GetListOfTables()
        {
            List<string> tableList = new List<string>();

            cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG = '" + Database + "' and TABLE_TYPE = 'BASE TABLE'", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tableList.Add(reader.GetString(0));
            }
            reader.Close();

            return tableList;
        }

        public string Unique_GetStringFromSequenceForDocId(string table, string id)
        {
            string retString = string.Empty;
            string query = "SELECT * FROM " + table + " WHERE ID = " + id + " order by seq";
            cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string Block1 = (reader.IsDBNull(2) ? "" : reader.GetString(2)); //BLOCK1
                string Block2 = (reader.IsDBNull(3) ? "" : reader.GetString(3)); //BLOCK2

                retString += Block1 + Block2;
            }
            reader.Close();
            return retString;
        }

        public List<string> Unique_GetListOfIds(string table)
        {
            List<string> idList = new List<string>();

            cmd = new SqlCommand("SELECT distinct(id) FROM " + table, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idList.Add(reader.GetInt32(0).ToString());
            }
            reader.Close();

            return idList;
        }

        public int GetRowCountOfTable(string table)
        {
            string query = "SELECT count(id) FROM " + table;
            cmd = new SqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            int cnt = reader.GetInt32(0);
            reader.Close();
            return cnt;
        }

        public List<string> GetListOfLargeFieldTables()
        {
            throw new NotImplementedException();
        }

        public void SaveBlobsFromTable(string table, string idcolumn, string datacolumn, string p, string savepath)
        {
            throw new NotImplementedException();
        }

        public bool CreateEmptyDatabase(string p)
        {
            throw new NotImplementedException();
        }
    }
}
