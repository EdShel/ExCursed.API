﻿namespace UniAtHome.WebAPI.Models.Group
{
    public class AddStudentToGroupRequest
    {
        public int GroupId { get; set; }

        public string StudentEmail { get; set; }
    }
}
