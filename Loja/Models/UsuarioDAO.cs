using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Loja.Models
{
    public class UsuarioDAO
    {
        SqlConnection conn;

        public void Inserir(string nome, string funcao)
        {
            conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBLoja"].ConnectionString);

            SqlCommand cmd = new SqlCommand("insert into usuario values (@name, @funcao)");
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@name", nome);
            cmd.Parameters.AddWithValue("@funcao", funcao);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Usuario> Listar()
        {
            conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBLoja"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from usuario");
            conn.Open();
            // cmd.ExecuteNonQuery();
            cmd.Connection = conn;
            List<Usuario> usuarios = new List<Usuario>();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Usuario u = new Usuario();
                u.Nome = (string)reader["nome"];
                u.Funcao = (string)reader["funcao"];
                usuarios.Add(u);
            }
            return usuarios;
        }
    }
}