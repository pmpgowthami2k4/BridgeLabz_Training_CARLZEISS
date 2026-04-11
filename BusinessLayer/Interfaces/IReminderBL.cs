using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Repositories;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReminderBL
    {
        bool Add(ReminderDTO dto);
        List<Reminder> Get(int notesId);
    }
}
