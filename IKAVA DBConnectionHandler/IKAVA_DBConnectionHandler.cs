using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IKAVA_Systembehandler.DB
{
    public class ConnectionHandler
    {
        public MySqlConnector mysqlConnector;
        public MSSqlConnector mssqlConnector;

        public static string Server { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string Table { get; set; }

        public enDatabaseType DatabaseType { get; set; }
        public enum enDatabaseType { MySql, MSSql }
        public enum enDataType { TXT, PDF, RTF, DOC }
        public bool IsConnected { get; set; }


        public ConnectionHandler(enDatabaseType dbType)
        {
            DatabaseType = dbType;
            switch (dbType)
            {
                case enDatabaseType.MySql:
                    mysqlConnector = new MySqlConnector(Server, Username, Password);
                    break;
                case enDatabaseType.MSSql:
                    mssqlConnector = new MSSqlConnector(Server, Username, Password);
                    break;
            }
        }

        public bool CreateConnection(string Server, string Database, string User, string Password)
        {
            IsConnected = false;
            try
            {
                switch (DatabaseType)
                {
                    case enDatabaseType.MySql:
                        MySqlConnector.Server = Server;
                        MySqlConnector.Username = User;
                        MySqlConnector.Password = Password;
                        MySqlConnector.Database = Database;
                        mysqlConnector.CreateConnection();
                        IsConnected = true;
                        return true;
                    case enDatabaseType.MSSql:
                        MSSqlConnector.Server = Server;
                        MSSqlConnector.Username = User;
                        MSSqlConnector.Password = Password;
                        MSSqlConnector.Database = Database;
                        mssqlConnector.CreateConnection();
                        IsConnected = true;
                        return true;
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                throw ex;
            }
            return false;
        }

        public bool HasPrimaryKeys(string p)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.HasPrimaryKeys(p);
                case enDatabaseType.MSSql:
                    return mssqlConnector.HasPrimaryKeys(p);
            }
            return false;
        }

        public List<string> GetListOfDatabases()
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.GetListOfDatabases();
                case enDatabaseType.MSSql:
                    return mssqlConnector.GetListOfDatabases();
            }
            return new List<string>();
        }

        public List<string> Unique_GetListOfIds()
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.Unique_GetListOfIds(Table);
                case enDatabaseType.MSSql:
                    return mssqlConnector.Unique_GetListOfIds(Table);
            }
            return new List<string>();
        }

        public bool CreatePrimaryKeys(string table, string[] p)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.CreatePrimaryKeys(table, p);
                case enDatabaseType.MSSql:
                    return mssqlConnector.CreatePrimaryKeys(table, p);
            }
            return false;
        }

        public int GetRowCountOfTable(string table)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.GetRowCountOfTable(table);
                case enDatabaseType.MSSql:
                    return mssqlConnector.GetRowCountOfTable(table);
            }
            return 0;
        }

        public void SaveBlobsFromTable(string table, string idcolumn, string datacolumn, enDataType datatype, string savepath)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    mysqlConnector.SaveBlobsFromTable(table, idcolumn, datacolumn, datatype.ToString(), savepath); break;
                case enDatabaseType.MSSql:
                    mssqlConnector.SaveBlobsFromTable(table, idcolumn, datacolumn, datatype.ToString(), savepath); break;
            }
        }

        public List<string> GetListOfTables()
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.GetListOfTables();
                case enDatabaseType.MSSql:
                    return mssqlConnector.GetListOfTables();
            }
            return new List<string>();
        }

        public List<string> GetListOfLargeFieldTables()
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.GetListOfLargeFieldTables();
                case enDatabaseType.MSSql:
                    return mssqlConnector.GetListOfLargeFieldTables();
            }
            return new List<string>();
        }

        public MySqlConnector.FieldInfo GetFieldInfo(string table)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.GetFieldInfo(table);
            }
            return new MySqlConnector.FieldInfo();
        }

        public string CreateConnector(enDatabaseType enDatabaseType)
        {
            try
            {
                switch (DatabaseType)
                {
                    case enDatabaseType.MySql:
                        mysqlConnector = new MySqlConnector(Server, Username, Password, Database);
                        break;
                    case enDatabaseType.MSSql:
                        mssqlConnector = new MSSqlConnector(Server, Username, Password, Database);
                        break;
                }
                return "";
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        public string Unique_GetStringFromSequenceForDocId(string id)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.Unique_GetStringFromSequenceForDocId(Table, id);
                case enDatabaseType.MSSql:
                    return mssqlConnector.Unique_GetStringFromSequenceForDocId(Table, id);
            }
            return string.Empty;
        }


        public bool CreateEmptyDatabase(string p)
        {
            switch (DatabaseType)
            {
                case enDatabaseType.MySql:
                    return mysqlConnector.CreateEmptyDatabase(p);
                case enDatabaseType.MSSql:
                    return mssqlConnector.CreateEmptyDatabase(p);
            }
            return false;
        }
    }

}
