using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelLayer.DTOs;
using Dapper;
using ModelLayer.Entities;

namespace DataBaseLayer.Repositories
{
    public class ReminderDL : IReminderDL
    {
        private readonly string connectionString;

        public ReminderDL(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool AddReminder(ReminderDTO dto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reminders (DateTime, Status, NotesId) VALUES (@DateTime, @Status, @NotesId)";
                return con.Execute(query, dto) > 0;
            }
        }

        public List<Reminder> GetReminders(int notesId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reminders WHERE NotesId=@NotesId";
                return con.Query<Reminder>(query, new { notesId }).ToList();
            }
        }
    }
}
