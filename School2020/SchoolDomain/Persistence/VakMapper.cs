﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SchoolDomain.Business;

namespace SchoolDomain.Persistence
{
    internal class VakMapper
    {
        string _connectionString;
        internal VakMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        internal List<Vak> GetVakkenFromDB()
        {
            List<Vak> _vakken = new List<Vak>();
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblvak", con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Vak _vak = new Vak
                    (
                       Convert.ToInt32(dr["Id"]),
                       dr["Naam"].ToString()
                    );
                _vakken.Add(_vak);
            }
            con.Close();
            return _vakken;
        }
        internal void AddVakToDB(Vak vak)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO tblvak " +
                "(Id, naam) " +
                " VALUES(@id, @naam)",
                con);
            cmd.Parameters.AddWithValue("id", vak.Id);
            cmd.Parameters.AddWithValue("naam", vak.Naam);
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
        internal void DeleteVakFromDB(Int32 id)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM tblvak " +
                "WHERE Id = @id",
                con);
            cmd.Parameters.AddWithValue("id", id);
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

        internal void UpdateVakInDB(Vak vak)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(
                "UPDATE tblvak " +
                "SET naam = @naam " +
                "WHERE Id = @id",
                con);
            cmd.Parameters.AddWithValue("id", vak.Id);
            cmd.Parameters.AddWithValue("naam", vak.Naam);
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


    }
}
