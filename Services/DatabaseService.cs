using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Npgsql;
using MongoDB.Driver.Core.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using NpgsqlTypes;

namespace BookReaderApp
{
    static internal class DatabaseService
    {
        static readonly string connectionString = "Host=localhost;Port=5432;Database=bookreaderapp;User Id=postgres;Password=postgres;";
        static readonly NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        public static NpgsqlDataReader SelectQuery(string query)
        {
            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        /// <summary>
		/// Runs a query on the database. Warning: Don't use for user direct inputs!
		/// </summary>
		/// <param name="query">Query to execute.</param>
		public static void RunQuery(string query)
        {
            connection.Open();

            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            connection.Close();
        }

        /// <summary>
        /// Get data from a simple query. No params needed.
        /// </summary>
        /// <param name="query">Query to execute. Example: select * from sales</param>
        /// <returns></returns>
        public static DataTable SelectData(string query)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Prepare();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Erro: ---> " + ex.Message);
                }

                connection.Close();
                return _dt;
            }

        }

        /// <summary>
        /// Get data a DataTable from a query with params.
        /// </summary>
        /// <param name="query">Query to execute. Example: select * from sales where product = @prodId</param>
        /// <param name="paramName">Param name. Example: "prodId"</param>
        /// <param name="paramValue">Param value. Example: (int)15</param>
        /// <returns></returns>
        public static DataTable SelectData(string query, string paramName, object paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue(paramName, paramValue);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: ---> " + ex.Message);
                }

                connection.Close();
                return _dt;
            }
        }

        /// <summary>
        /// Get a DataTable from a query with params.
        /// </summary>
        /// <param name="query">Query to execute. Example: select * from sales where product = @prodId</param>
        /// <param name="paramName">Param name. Example: "prodId"</param>
        /// <param name="paramType">Param type. Needed to enable prepare query.</param>
        /// <param name="paramValue">Param value. Example: (int)15</param>
        /// <returns></returns>
        public static DataTable SelectData(string query, string paramName, NpgsqlDbType paramType, object paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue(paramName, paramType, paramValue);

                //PREPARE creates a prepared statement. 
                //A prepared statement is a server-side object that can be used to optimize performance.
                cmd.Prepare();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: ---> " + ex.Message);
                }

                connection.Close();
                return _dt;
            }

        }


        /// <summary>
        /// Get data a DataTable from a query with multiple params.
        /// </summary>
        /// <param name="query">Query to execute. Example: select * from sales where product = @prodId and sale_date = @date</param>
        /// <param name="paramName">Param name. Example: []{"prodId". "qtd"}</param>
        /// <param name="paramValue">Param value. Example: []{(int)15,(DateTime)"2017-01-01"}</param>
        /// <returns></returns>
        public static DataTable SelectData(string query, string[] paramName, object[] paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                //Verify if the name's count equals the value's count
                if (paramName.Count() != paramValue.Count())
                {
                    Debug.WriteLine("ParamName Count != ParamValue Count");
                    return null;
                }

                //Add params in the arrays
                for (int i = 0; i < paramName.Count(); i++)
                {
                    cmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }


                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: ---> " + ex.Message);
                }

                connection.Close();
                return _dt;
            }
        }

        /// <summary>
        /// Get data a DataTable from a query with multiple params.
        /// </summary>
        /// <param name="query">Query to execute. Example: select * from sales where product = @prodId and sale_date = @date</param>
        /// <param name="paramName">Param name. Example: []{"prodId". "qtd"}</param>
        /// <param name = "paramType">Param type. Example: []{NpgsqlDbType.Integrer, NpgsqlDbType.Date}</param>
        /// <param name="paramValue">Param value. Example: []{(int)15,(DateTime)"2017-01-01"}</param>
        /// <returns></returns>
        public static DataTable SelectData(string query, string[] paramName, NpgsqlDbType[] paramType, object[] paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                if (paramName.Count() != paramValue.Count() || paramValue.Count() != paramType.Count())
                {
                    Debug.WriteLine("ParamName Count != ParamValue Count");
                    return null;
                }

                for (int i = 0; i < paramName.Count(); i++)
                {
                    cmd.Parameters.AddWithValue(paramName[i], paramType[i], paramValue[i]);
                }


                cmd.Prepare();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: ---> " + ex.Message);
                }

                connection.Close();
                return _dt;
            }

        }


    }
}
