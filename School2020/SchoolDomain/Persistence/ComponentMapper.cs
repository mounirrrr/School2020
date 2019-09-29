using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDomain.Business;
using MySql.Data.MySqlClient;

namespace SchoolDomain.Persistence
{
    internal class ComponentMapper
    {
        string _connectionString;
        internal ComponentMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        internal List<Component> GetComponentsFromDB()
        {
            List<Component> _componenten = new List<Component>();
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblcomponent", con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Component _component = new Component
                    (
                       Convert.ToInt32(dr["Id"]),
                       dr["Omschrijving"].ToString(),
                       Convert.ToInt32(dr["Gewicht"]),
                       dr["Afkorting"].ToString()
                    );
                _componenten.Add(_component);
            }
            con.Close();
            return _componenten;
        }

        internal void AddComponentToDB(Component component)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO tblComponent " +
                "(Id, Omschrijving, Gewicht, Afkorting) " +
                " VALUES(@id, @omschrijving, @gewicht, @afkorting)",
                con);
            cmd.Parameters.AddWithValue("id", component.Id);
            cmd.Parameters.AddWithValue("omschrijving", component.Naam);
            cmd.Parameters.AddWithValue("gewicht", component.Gewicht);
            cmd.Parameters.AddWithValue("afkorting", component.Afkorting);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException mse)
            {
                throw mse;
            }
            finally
            {
                con.Close();
            }
        }
        internal void DeleteComponentInDB(Int32 componentId)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tblComponent WHERE Id = @id");
            cmd.Parameters.AddWithValue("id", componentId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
