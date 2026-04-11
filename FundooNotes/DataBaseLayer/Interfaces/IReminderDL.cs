using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.Entities;
using ModelLayer.DTOs;

namespace DataBaseLayer.Interfaces
{
    public interface IReminderDL
    {
        bool AddReminder(ReminderDTO dto);
        List<Reminder> GetReminders(int notesId);
    }
}
