using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using adonet.Models;

namespace adonet.Service {
    public class Sqlhp {
        string st = @"server=192.168.1.1;database=teamdb;User ID=user;Password=1234;Trusted_Connection=false;";
        public List<Team> getreader () {
            List<Team> lr = new List<Team> ();
            using (SqlConnection con = new SqlConnection (st)) {
                SqlCommand cmd = new SqlCommand ("select * from team", con);

                con.Open ();
                SqlDataReader dr = cmd.ExecuteReader ();

                while (dr.Read ()) {
                    Team team = new Team ();
                    team.Team01 = Convert.ToInt32 (dr["team01"].ToString ());
                    team.Team02 = dr["team02"].ToString ();
                    team.Team03 = dr["team03"].ToString ();
                    DateTime dtnew = Convert.ToDateTime (dr["team04"].ToString ());
                    team.Team04 = dtnew;

                    lr.Add (team);

                }
                con.Close ();
            }
            return lr;

        }

        public List<Team> getreaderone (int? team01) {
            List<Team> lr = new List<Team> ();
            using (SqlConnection con = new SqlConnection (st)) {
                SqlCommand cmd = new SqlCommand ("select * from team where Team01 = @team01", con);
                cmd.Parameters.AddWithValue ("@team01", team01);

                con.Open ();
                SqlDataReader dr = cmd.ExecuteReader ();

                while (dr.Read ()) {
                    Team team = new Team ();
                    team.Team01 = Convert.ToInt32 (dr["team01"].ToString ());
                    team.Team02 = dr["team02"].ToString ();
                    team.Team03 = dr["team03"].ToString ();
                    DateTime dtnew = Convert.ToDateTime (dr["team04"].ToString ());
                    team.Team04 = dtnew;

                    lr.Add (team);

                }
                con.Close ();
            }
            return lr;
        }

        public void addteam (Team team) {
            using (SqlConnection con = new SqlConnection (st)) {
                con.Open ();
                SqlCommand cmd = new SqlCommand ("insert into team values(@team02, @team03, @team04)", con);
                DateTime date = DateTime.Now;
                string date2 = date.ToShortDateString ().ToString ();

                cmd.Parameters.AddWithValue ("@team02", team.Team02);
                cmd.Parameters.AddWithValue ("@team03", team.Team03);
                cmd.Parameters.AddWithValue ("@team04", date2);

                cmd.ExecuteNonQuery ();
                con.Close ();
            }
        }

        public void updateteam (int id, Team team) {
            using (SqlConnection con = new SqlConnection (st)) {
                con.Open ();
                SqlCommand cmd = new SqlCommand ("update team set team02 = @team02, team03 = @team03, team04 = @team04 where team01 = @team01", con);
                DateTime date = DateTime.Now;
                string date2 = date.ToShortDateString ().ToString ();

                cmd.Parameters.AddWithValue ("@team01", id);
                cmd.Parameters.AddWithValue ("@team02", team.Team02);
                cmd.Parameters.AddWithValue ("@team03", team.Team03);
                cmd.Parameters.AddWithValue ("@team04", date2);

                cmd.ExecuteNonQuery ();
                con.Close ();
            }
        }

        public void deleteteam (int id) {
            using (SqlConnection con = new SqlConnection (st)) {
                SqlCommand cmd = new SqlCommand ("delete from team where team01 = @id", con);

                cmd.Parameters.AddWithValue ("@id", id);

                con.Open ();
                cmd.ExecuteNonQuery ();
                con.Close ();
            }
        }

    }
}