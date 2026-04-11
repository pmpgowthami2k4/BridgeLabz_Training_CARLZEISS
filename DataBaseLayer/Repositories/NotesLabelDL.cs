using Dapper;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace DataBaseLayer.Repositories
{
    public class NotesLabelDL : INotesLabelDL
    {
        private readonly string connectionString;

        public NotesLabelDL(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool AddLabelToNote(int notesId, int labelId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NotesLabels (NotesId, LabelId) VALUES (@NotesId, @LabelId)";
                return con.Execute(query, new { notesId, labelId }) > 0;
            }
        }

        public bool RemoveLabelFromNote(int notesId, int labelId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM NotesLabels WHERE NotesId=@NotesId AND LabelId=@LabelId";
                return con.Execute(query, new { notesId, labelId }) > 0;
            }
        }

        public List<Label> GetLabelsByNote(int notesId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT l.* FROM Labels l
                JOIN NotesLabels nl ON l.LabelId = nl.LabelId
                WHERE nl.NotesId = @NotesId";

                return con.Query<Label>(query, new { notesId }).ToList();
            }
        }
    }
}
