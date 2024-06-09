using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Npgsql;
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
        public static void RunQuery(string query, string paramName, object paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue(paramName, paramValue);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void RunQuery(string query, string[] paramName, object[] paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                if (paramName.Count() != paramValue.Count())
                {
                    Debug.WriteLine("ParamName Count != ParamValue Count");
                }

                for (int i = 0; i < paramName.Count(); i++)
                {
                    cmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }

                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static DataTable SelectData(string query)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Prepare();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds);

                try
                {
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                connection.Close();
                return dt;
            }

        }

        public static DataTable SelectData(string query, string paramName, object paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue(paramName, paramValue);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds);

                try
                {
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                connection.Close();
                return dt;
            }
        }

        public static DataTable SelectData(string query, string[] paramName, object[] paramValue)
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                if (paramName.Count() != paramValue.Count())
                {
                    Debug.WriteLine("ParamName Count != ParamValue Count");
                    return null;
                }

                for (int i = 0; i < paramName.Count(); i++)
                {
                    cmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }


                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds);

                try
                {
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                connection.Close();
                return dt;
            }
        }

    }
}
