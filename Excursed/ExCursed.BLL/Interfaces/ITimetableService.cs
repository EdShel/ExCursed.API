﻿using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Timetable;

namespace ExCursed.BLL.Interfaces
{
    public interface ITimetableService
    {
        Task CreateTimetableEntryAsync(TimetableEntryDTO timetableDto, string creatorEmail);

        Task DeleteTimetableEntryAsync(TimetableEntryDeleteDTO timetableDto, string userEmail);

        Task EditTimetableEntryAsync(TimetableEntryDTO newTimetableDto, string userEmail);

        Task<TimetableDTO> GetTimetableWithZoomLinkAsync(int groupId, int lessonId, string userEmail);

        Task<TimetableDTO> GetTimetableAsync(int groupId, int lessonId);
    }
}