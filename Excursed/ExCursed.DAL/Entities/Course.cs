using System.Collections.Generic;

namespace ExCursed.DAL.Entities
{
    public class Publication : BaseAuditableEntity
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<PublicationMaterial> Materials { get; set; }

        public List<PublicationGroup> PublicationGroups { get; set; }

        public Course Course { get; set; }
    }

    public class PublicationGroup
    {
        public int PublicationId { get; set; }

        public int GroupId { get; set; }

        public Publication Publication { get; set; }

        public Group Group { get; set; }

    }

    public class PublicationMaterial : BaseEntity
    {
        public int PublicationId { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }

        public Publication Publication { get; set; }
    }

    public class Course : BaseAuditableEntity
    {
        public Course()
        {
            CourseMembers = new List<CourseMember>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int UniversityId { get; set; }

        public University University { get; set; }

        public List<CourseMember> CourseMembers { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<Tests.Test> Tests { get; set; }

        public List<Publication> Publications { get; set; }
    }
}
