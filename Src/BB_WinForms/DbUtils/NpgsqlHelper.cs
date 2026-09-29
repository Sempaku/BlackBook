using Npgsql;
using System.Data;

namespace BB_WinForms.DbUtils
{
    public static class NpgsqlHelper
    {
        public static DataTable ExecuteNpgsqlTextCommand(string sql, string connString)
        {
            DataTable table = new DataTable();

            using (var npgsqlConnection = new NpgsqlConnection(connString))
            {
                npgsqlConnection.Open();
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
                npgsqlCommand.Connection = npgsqlConnection;
                npgsqlCommand.CommandText = sql;
                npgsqlCommand.CommandType = CommandType.Text;

                NpgsqlDataReader dReader = npgsqlCommand.ExecuteReader();
                if (dReader.HasRows)
                {
                    table = new DataTable();
                    table.Load(dReader);
                }
            }

            return table;
        }
    }
}