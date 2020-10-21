using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Sqlhelper
{
    public class Sqlhelper
    {
        public IConfiguration Configuration { get; }

        Sqlhelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Execute store procedure return dataset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="commandType"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public static DataSet ExecDataSet(DbContext context, string procName, object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            DataSet dtSet = new DataSet();
            SqlConnection sqlConn = (SqlConnection)context.Database.GetDbConnection();

            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }

            using (SqlCommand command = new SqlCommand(procName, sqlConn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                command.CommandType = commandType;
                if (paramaters != null)
                {
                    foreach (var para in paramaters)
                    {
                        command.Parameters.Add(para);
                    }
                }
                adapter.Fill(dtSet);
            }
            return dtSet;
        }

        public static DataSet ExecDataSet(string connectStr, string procName, object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using(SqlConnection sqlConn = new SqlConnection(connectStr))
            {
                DataSet dtSet = new DataSet();

                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }

                using (SqlCommand command = new SqlCommand(procName, sqlConn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    command.CommandType = commandType;
                    if (paramaters != null)
                    {
                        foreach (var para in paramaters)
                        {
                            command.Parameters.Add(para);
                        }
                    }
                    adapter.Fill(dtSet);
                }
                return dtSet;

            }
           
        }


        public static object ExecuteScalar(DbContext context, string procName, object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            SqlConnection sqlConn = (SqlConnection)context.Database.GetDbConnection();

            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }

            using (SqlCommand command = new SqlCommand(procName, sqlConn))
            {
                command.CommandType = commandType;
                if (paramaters != null)
                {
                    foreach (var para in paramaters)
                    {
                        command.Parameters.Add(para);
                    }
                }
                return command.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string ConnectionStr, string procName, object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
        {    
            using(SqlConnection sqlConn = new SqlConnection(ConnectionStr))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }

                using (SqlCommand command = new SqlCommand(procName, sqlConn))
                {
                    command.CommandType = commandType;
                    if (paramaters != null)
                    {
                        foreach (var para in paramaters)
                        {
                            command.Parameters.Add(para);
                        }
                    }
                    return command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// exec nonquery using for insert, update, delete
        /// </summary>
        /// <typeparam name="T">db context</typeparam>
        /// <param name="sqlCommand"> </param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public static int ExecCommand(DbContext context, string sqlCommand, object[] paramaters = null)
        {
            SqlConnection sqlConn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand command = new SqlCommand(sqlCommand, sqlConn);

            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }

            using (command)
            {
                command.CommandType = CommandType.Text;
                if (paramaters != null)
                {
                    foreach (var para in paramaters)
                    {
                        command.Parameters.Add(para);
                    }
                }
                var result = command.ExecuteNonQuery();
                return result;

            }
        }


        /// <summary>
        /// Execute procedure return datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="commandType"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public static DataTable ExecDataTable(DbContext context, string procName, Object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                var dataSet = ExecDataSet(context, procName, paramaters, commandType);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExecDataTable(string connectStr, string procName, Object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                var dataSet = ExecDataSet(connectStr, procName, paramaters, commandType);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exec procedure return entity
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="commandType"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public static IList<T> ExecEntity<T>(DbContext context, string procName, Object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
            where T : new()
        {
            DataTable tb = ExecDataTable(context, procName, paramaters, commandType);
            return tb.ToList<T>();
        }

        public static IList<T> ExecEntity<T>(string connectStr, string procName, Object[] paramaters = null, CommandType commandType = CommandType.StoredProcedure)
            where T : new()
        {
            DataTable tb = ExecDataTable(connectStr, procName, paramaters, commandType);
            return tb.ToList<T>();
        }



        /// <summary>
        /// Method get call api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> ExecGetDataApi<T>(string url)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = new WebProxy(url),
                UseProxy = true,
            };
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(null);
                }
            }
        }
        /// <summary>
        /// Method post API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<IList<T>> ExcePostDataApi<T>(string url, T content)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(url.ToString(), CreateHttpContent<T>(content));
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IList<T>>(data);
                }
                else
                {
                    return JsonConvert.DeserializeObject<IList<T>>(null);
                }

            }
        }


        /// <summary>
        /// Insert list Row 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connect"></param>
        /// <param name="TableName"></param>
        /// <param name="lstItem"></param>
        public static void ExecAddList<T>(string connect, string TableName, List<T> lstItem)
        {
            using (var connection = new SqlConnection(connect))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = "dbo." + TableName;
                    try
                    {
                        bulkCopy.WriteToServer(lstItem.AsDataTable());
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        connection.Close();
                    }
                }

                transaction.Commit();
            }
        }

        public static void ExecAddListDataTable( DbContext context ,  string TableName, DataTable dt)
        {
                SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlTransaction transaction = connection.BeginTransaction();

                using (var bulkCopy = new SqlBulkCopy(connection, (SqlBulkCopyOptions.KeepNulls & SqlBulkCopyOptions.KeepIdentity), transaction))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = TableName;
                    try
                    {
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        connection.Close();
                    }
                }

                transaction.Commit();
        }

        public static void ExecAddListDataTable(string connectStr, string TableName, DataTable dt)
        {
            using(SqlConnection connection = new SqlConnection(connectStr))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlTransaction transaction = connection.BeginTransaction();

                using (var bulkCopy = new SqlBulkCopy(connection, (SqlBulkCopyOptions.KeepNulls & SqlBulkCopyOptions.KeepIdentity), transaction))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = TableName;
                    try
                    {
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        connection.Close();
                    }
                }

                transaction.Commit();
            }
        }

        private static HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
    }

}
