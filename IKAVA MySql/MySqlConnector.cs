using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;
using System.Data;


namespace IKAVA_Systembehandler.DB
{
    public class MySqlConnector
    {
        public static string Server { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string Table { get; set; }

        public static MySqlConnection connection;
        public MySqlCommand cmd;
        public MySqlDataReader reader;

        public class FieldInfo
        {
            public string FieldName = string.Empty;
            public string FieldType = string.Empty;
            public string RowCount = string.Empty;
        }
        public MySqlConnector()
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

        public MySqlConnector(string dbServer, string dbUsername, string dbPassword)
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

        public MySqlConnector(string dbServer, string dbUsername, string dbPassword, string dbDatabase)
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
            connection = new MySqlConnection(connectionString + ";Connect Timeout=300");
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
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
            string query = "SELECT k.column_name FROM information_schema.table_constraints t JOIN information_schema.key_column_usage k USING(constraint_name,table_schema,table_name) WHERE t.constraint_type='PRIMARY KEY' AND t.table_schema='" + Database + "' AND t.table_name='" + table + "'";
            cmd = new MySqlCommand(query, connection);
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
            string query = "ALTER TABLE " + table + " ADD PRIMARY KEY myKey (";
            for (int a = 0; a < ids.Count(); a++)
            {
                query += ids[a];
                if (a < ids.Count()-1)
                    query += ", ";
            }
            query += ");";
            cmd = new MySqlCommand(query, connection);
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

            cmd = new MySqlCommand("select SCHEMA_NAME from information_schema.SCHEMATA", connection);
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

            cmd = new MySqlCommand("SELECT table_name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '"+Database+"' and TABLE_TYPE = 'BASE TABLE'", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tableList.Add(reader.GetString(0));
            }
            reader.Close();

            return tableList;
        }

        public List<string> GetListOfLargeFieldTables()
        {
            List<string> tableList = new List<string>();
            // select * from information_schema.columns as c where c.table_schema = "bvpro_sogne" and c.CHARACTER_MAXIMUM_LENGTH > 65535 ORDER BY c.table_name ASC
            cmd = new MySqlCommand("SELECT table_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + Database + "' and CHARACTER_MAXIMUM_LENGTH > 65535", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tableList.Add(reader.GetString(0));
            }
            reader.Close();

            return tableList;
        }

        public FieldInfo GetFieldInfo(string table)
        {
            FieldInfo f = new FieldInfo();
            cmd = new MySqlCommand("SELECT column_name, column_type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + Database + "' and table_name = '" + table + "' and CHARACTER_MAXIMUM_LENGTH > 65535", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                f.FieldName = reader.GetString(0);
                f.FieldType = reader.GetString(1);
            }
            reader.Close();
            return f;
        }

        public string Unique_GetStringFromSequenceForDocId(string table, string id)
        {
            string retString = string.Empty;
            string query = "";
            MySqlDataReader reader = null;
            try
            {
                query = "SELECT * FROM " + Database + "." + table + " WHERE ID = " + id + " order by seq";
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
            }
            catch
            {
                Console.WriteLine("ver2");
                query = "SELECT * FROM `" + table + "` WHERE ID = " + id + " order by seq";
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
            }
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

            try
            {
                cmd = new MySqlCommand("SELECT distinct(id) FROM " + Database + "." + table, connection);
                reader = cmd.ExecuteReader();
            }
            catch {
                cmd = new MySqlCommand("SELECT distinct(id) FROM `" + table + "`", connection);
                reader = cmd.ExecuteReader();
            }

            while (reader.Read())
            {
                idList.Add(reader.GetDouble(0).ToString());
            }
            reader.Close();

            return idList;
        }

        public int GetRowCountOfTable(string table)
        {
            string query = "";
            try
            {
                query = "SELECT count(*) FROM " + Database + "." + table;
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
            }
            catch
            {
                query = "SELECT count(*) FROM `" + table + "`";
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
            }
            reader.Read();
            int cnt = reader.GetInt32(0);
            reader.Close();
            return cnt;
        }

        public void SaveBlobsFromTable(string table, string idcolumn, string datacolumn, string dataType, string savepath)
        {
            string query = "SELECT " + idcolumn + ", " + datacolumn + " FROM " + table;
            cmd = new MySqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    StreamWriter sw;
                    string doc = reader.GetString(1);
                    if (doc.Substring(0, 12) == @"{\rtf1\ansi\")
                    {
                        sw = new StreamWriter(savepath + @"\" + reader.GetInt32(0) + ".rtf", false);
                    }
                    else
                    {
                        sw = new StreamWriter(savepath + @"\" + reader.GetInt32(0) + ".txt", false);
                    }
                    sw.Write(doc);
                    sw.Close();
                    
                }
                catch { }
                Thread.Sleep(50);
            }
            reader.Close();

        }

        public bool CreateEmptyDatabase(string p)
        {
            string query = "CREATE DATABASE " + p;
            cmd = new MySqlCommand(query, connection);
            cmd.CommandTimeout = 3000;
            try
            {
                int b = cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DumpToCSVFile(string table, string filename, string separator)
        {
            string query = "SELECT * FROM " + table;
            cmd = new MySqlCommand(query, connection);
            if (!reader.IsClosed)
                reader.Close();
            reader = cmd.ExecuteReader();

            List<string> row = new List<string>();
            List<object> rows = new List<object>();

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                if (!reader.HasRows)
                {
                    writer.Write("Tabellen var tom ved eksport.");
                    writer.Close();
                    return false;
                }
                bool firstTime = true;
                while (reader.Read())
                {
                    if (firstTime)
                    {
                        for (int a = 0; a < reader.FieldCount; a++)
                        {
                            writer.Write(reader.GetName(a).ToString());
                            if (a + 1 < reader.FieldCount)
                                writer.Write(separator);
                        }
                        writer.Write(Environment.NewLine);
                        firstTime = false;
                    }

                    for (int a = 0; a < reader.FieldCount; a++)
                    {
                        try
                        {
                            writer.Write(reader.GetValue(a).ToString());
                        }
                        catch
                        {
                            writer.Write("null");
                        }
                        if (a + 1 < reader.FieldCount)
                            writer.Write(separator);
                    }
                    writer.WriteLine();
                }
            }
            return true;
        }

        public bool DropDatabase(string p)
        {
            string query = "DROP DATABASE " + p;
            cmd = new MySqlCommand(query, connection);
            cmd.CommandTimeout = 3000;
            try
            {
                int b = cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
