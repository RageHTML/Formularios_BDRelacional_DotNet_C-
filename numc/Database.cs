using MySql.Data.MySqlClient;

public class Database
{
    private String connectionString = "server=localhost;user=root;password=senha;database=name";

    public MySqlConnection GetConnection()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        return connection;
    }

    public List<string> LerDados(string nomeTabela)
    {
        List<string> dados = new List<string>();

        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();

            string query = $"SELECT * FROM {nomeTabela}";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String linha = "";

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    linha += reader.GetValue(i).ToString() + " | ";
                }

                dados.Add(linha);
            }
        }

        return dados;
    }
};