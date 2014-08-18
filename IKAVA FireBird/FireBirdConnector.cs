using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace IKAVA_Systembehandler.DB
{
    public class FireBirdConnector
    {
        public static string Server { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string Table { get; set; }

        public static FbConnection connection;
        public FbCommand cmd;
        public FbDataReader reader;

        public class FieldInfo
        {
            public string FieldName = string.Empty;
            public string FieldType = string.Empty;
            public string RowCount = string.Empty;
        }
        public FireBirdConnector()
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

        public FireBirdConnector(string dbServer, string dbUsername, string dbPassword)
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

        public FireBirdConnector(string dbServer, string dbUsername, string dbPassword, string dbDatabase)
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
            FbConnectionStringBuilder connectionString = new FbConnectionStringBuilder();
            connectionString.UserID = Username;
            connectionString.Password = Password;
            connectionString.Database = Server;
            connectionString.ServerType = FbServerType.Default;
            connection = new FbConnection(connectionString.ConnectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (FbException ex)
            {
                throw ex;
                //return false;
            }
        }

        public bool HasPrimaryKeys(string table)
        {
            throw new NotImplementedException();
            /*
            string query = "SELECT k.column_name FROM information_schema.table_constraints t JOIN information_schema.key_column_usage k USING(constraint_name,table_schema,table_name) WHERE t.constraint_type='PRIMARY KEY' AND t.table_schema='" + Database + "' AND t.table_name='" + table + "'";
            cmd = new FbCommand(query, connection);
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
            */
        }

        public bool CreatePrimaryKeys(string table, string[] ids)
        {
            throw new NotImplementedException();
            /*
            string query = "ALTER TABLE " + table + " ADD PRIMARY KEY myKey (";
            for (int a = 0; a < ids.Count(); a++)
            {
                query += ids[a];
                if (a < ids.Count() - 1)
                    query += ", ";
            }
            query += ");";
            cmd = new FbCommand(query, connection);
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
            */
        }

        public List<string> GetListOfDatabases()
        {
            throw new NotImplementedException();
            /*
            List<string> dbList = new List<string>();

            cmd = new FbCommand("select SCHEMA_NAME from information_schema.SCHEMATA", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dbList.Add(reader.GetString(0));
            }
            reader.Close();

            return dbList;
            */
        }

        /// <summary>
        /// Lists tables 
        /// </summary>
        /// <returns>List of tables matching tablename-spec</returns>
        public List<string> GetListOfTables()
        {
            List<string> tableList = new List<string>();

            cmd = new FbCommand("select rdb$relation_name from rdb$relations where rdb$view_blr is null and (rdb$system_flag is null or rdb$system_flag = 0);", connection);
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
            throw new NotImplementedException();
            /*
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
            */
        }

        public FieldInfo GetFieldInfo(string table)
        {
            throw new NotImplementedException();
            /*
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
            */
        }

        public string Unique_GetStringFromSequenceForDocId(string table, string id)
        {
            throw new NotImplementedException();
            /*
            string retString = string.Empty;
            string query = "SELECT * FROM " + Database + "." + table + " WHERE ID = " + id + " order by seq";
            cmd = new FbCommand(query, connection);
            FbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string Block1 = (reader.IsDBNull(2) ? "" : reader.GetString(2)); //BLOCK1
                string Block2 = (reader.IsDBNull(3) ? "" : reader.GetString(3)); //BLOCK2

                retString += Block1 + Block2;
            }
            reader.Close();
            return retString;
             */
        }

        public List<string> Unique_GetListOfIds(string table)
        {
            throw new NotImplementedException();
            /*
            List<string> idList = new List<string>();

            cmd = new MySqlCommand("SELECT distinct(id) FROM " + Database + "." + table, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idList.Add(reader.GetDouble(0).ToString());
            }
            reader.Close();

            return idList;
             */
        }

        public int GetRowCountOfTable(string table)
        {
            string query = "SELECT count(*) FROM " + Database + "." + table;
            cmd = new FbCommand(query, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            int cnt = reader.GetInt32(0);
            reader.Close();
            return cnt;
        }

        public void SaveBlobsFromTable(string table, string idcolumn, string datacolumn, string dataType, string savepath)
        {
            throw new NotImplementedException();
            /*
            string query = "SELECT " + idcolumn + ", " + datacolumn + " FROM " + table;
            cmd = new FbCommand(query, connection);
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
            */
        }

        public bool CreateEmptyDatabase(string p)
        {
            throw new NotImplementedException();
            /*
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
            */
        }

        public void RunSql(string sql)
        {
            cmd = new FbCommand(sql, connection);
            int t = cmd.ExecuteNonQuery();
        }

        public bool DumpToCSVFile(string table, string filename, string separator)
        {
            string query = "SELECT * FROM " + table;
            cmd = new FbCommand(query, connection);
            reader = cmd.ExecuteReader();
            
            List<string> row = new List<string>();
            List<object> rows = new List<object>();

            using(StreamWriter writer = new StreamWriter(filename,false))
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
                        try { 
                            writer.Write(reader.GetValue(a).ToString()); 
                        }
                        catch {
                            writer.Write("null");
                        }
                        if (a+1<reader.FieldCount)
                            writer.Write(separator);
                    }
                    writer.WriteLine();
                }
            }
            return true;
        }
    }
}
