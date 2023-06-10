using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace SQLDemo.Util
{
    public class RepositoryDao
    {
        private MySqlConnection _connection;
        public RepositoryDao()
        {
            Init();
        }
        private void Init()
        {
            _connection = new MySqlConnection(GetConnectionString());

        }
        //public string GetConnectionString()
        //{
        //    string targetProjectPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));
        //    string appSettingsPath = Path.Combine(targetProjectPath, "appsettings.json");
        //    string json = File.ReadAllText(appSettingsPath);
        //    var jObject = JObject.Parse(json);
        //    string connectionString = jObject.GetValue("ConnectionStrings")["DefaultConnection"].ToString();
        //    return connectionString;
        //}
        public string GetConnectionString()
        {
            return "Server=localhost;Port=3306;Database=ecommerce_db;Uid=root;Pwd=;";
        }


        //public T LoadSPDataSingleWithParam<T>(string sql, DynamicParameters param)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        var result = cnn.Query<T>(sql, param, commandType: CommandType.StoredProcedure).SingleOrDefault();
        //        return result;
        //    }
        //}

        //public List<T> LoadSPDataListWithParam<T>(string sql, DynamicParameters param)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        var result = cnn.Query<T>(sql, param, commandType: CommandType.StoredProcedure).ToList();
        //        return result;
        //    }
        //}

        //Returns single data
        public T LoadSQLDataSingle<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).SingleOrDefault();
            }
        }
        //Returns multiple data
        public List<T> LoadSQLDataList<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                var result = cnn.Query<T>(sql).ToList();
                return result;
            }
        }

        //public List<T> LoadSQLDataListWithParam<T>(string sql, DynamicParameters p)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Query<T>(sql, p).ToList();
        //    }
        //}

        //public T LoadSQLDataSingleWithParam<T>(string sql, DynamicParameters p)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Query<T>(sql, p).SingleOrDefault();
        //    }
        //}

        //public System.Data.DataTable ExecuteDataTable(string sql)
        //{
        //    using (SqlConnection con = new SqlConnection(GetConnectionString()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sql, con))
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }
        //    }
        //}

        //same as to create row but the parameter is dynamic 
        public int RunSQLWithParam(string sql, DynamicParameters p)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, p);
            }
        }
        //Used to create new row
        public int RunSQL(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql);
            }
        }
    }
}