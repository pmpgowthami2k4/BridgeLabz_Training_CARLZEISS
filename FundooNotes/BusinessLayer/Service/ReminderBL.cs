using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using DataBaseLayer.Repositories;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Service
{
    public class ReminderBL : IReminderBL
    {
        private readonly IReminderDL dl;

        public ReminderBL(IReminderDL dl)
        {
            this.dl = dl;
        }

        public bool Add(ReminderDTO dto) => dl.AddReminder(dto);

        public List<Reminder> Get(int notesId) => dl.GetReminders(notesId);
    }
}
