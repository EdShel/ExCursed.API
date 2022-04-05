using AutoMapper;
using ExCursed.BLL.DTOs;
using ExCursed.BLL.DTOs.Auth;
using ExCursed.BLL.DTOs.Course;
using ExCursed.BLL.DTOs.Test;
using ExCursed.BLL.DTOs.Timetable;
using ExCursed.BLL.DTOs.University;
using ExCursed.BLL.DTOs.UniversityRequest;
using ExCursed.BLL.DTOs.Zoom;
using ExCursed.DAL.Entities;
using ExCursed.DAL.Entities.Tests;
using ExCursed.WebAPI.Models.Requests;
using ExCursed.WebAPI.Models.Responses.Course;
using ExCursed.WebAPI.Models.Responses.Lesson;
using ExCursed.WebAPI.Models.Test;
using ExCursed.WebAPI.Models.Timetable;
using ExCursed.WebAPI.Models.UniversityCreation;
using ExCursed.WebAPI.Models.Users;

namespace ExCursed.WebAPI.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap();

            CreateMap<CreateCourseRequest, CourseDTO>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Title));
            CreateMap<CreateLessonRequest, LessonDTO>();

            CreateMap<CourseDTO, CourseResponse>().ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Name));
            CreateMap<LessonDTO, LessonResponse>();
            CreateMap<Group, GroupDTO>();

            CreateMap<AdminRegistrationRequest, AdminRegistrationDTO>();
            CreateMap<UniversityAdminRegistrationRequest, UniversityAdminRegistrationDTO>();
            CreateMap<StudentRegistrationRequest, StudentRegistrationDTO>();
            CreateMap<TeacherRegistrationRequest, TeacherRegistrationDTO>();

            CreateMap<UniversityCreateRequestRequest, UniversityCreateRequestDTO>();
            CreateMap<UniversityCreateRequestDTO, UniversityCreateRequest>();
            CreateMap<UniversityCreateRequest, UniversityCreateRequestViewDTO>();
            CreateMap<UniversityCreateRequestViewDTO, University>()
                .ForMember(
                    university => university.Name,
                    opt => opt.MapFrom(request => request.UniversityName))
                .ForMember(
                    university => university.ShortName,
                    opt => opt.MapFrom(request => request.UniversityShortName));
            CreateMap<UniversityCreateRequestViewDTO, UniversityCreateRequestModel>();

            CreateMap<University, UniversityDTO>();

            CreateMap<TimetableEntryDTO, Timetable>()
                .ForMember(
                    tt => tt.Date,
                    opt => opt.MapFrom(dto => dto.DateTime)
                );
            CreateMap<ZoomMeetingDTO, ZoomMeeting>();
            CreateMap<TimetableCreateRequest, TimetableEntryDTO>();
            CreateMap<TimetableEditRequest, TimetableEntryDTO>();
            CreateMap<TimetableDeleteRequest, TimetableEntryDeleteDTO>();

            CreateMap<TestCreateDTO, Test>();
            CreateMap<TestQuestionCreateDTO, TestQuestion>();
            CreateMap<TestAnswerVariantCreateDTO, TestAnswerVariant>();
            CreateMap<TestScheduleCreateDTO, TestSchedule>();
            CreateMap<TestEditDTO, Test>();
            CreateMap<TestQuestionEditDTO, TestQuestion>();
            CreateMap<TestAnswerVariantEditDTO, TestAnswerVariant>();
            CreateMap<TestScheduleEditDTO, TestSchedule>();
            CreateMap<Test, TestDTO>();
            CreateMap<TestQuestion, TestQuestionDTO>();
            CreateMap<TestAnswerVariant, TestAnswerVariantDTO>();
            CreateMap<TestSchedule, TestScheduleDTO>();
            CreateMap<TestAnswerRequest, AnswerSubmitDTO>();
            CreateMap<TestQuestion, TestTakingDTO.QuestionDTO>();
            CreateMap<TestAnswerVariant, TestTakingDTO.AnswerDTO>();
            CreateMap<Test, TestFullDTO>();
            CreateMap<TestQuestion, TestFullDTO.QuestionDTO>();
            CreateMap<TestAnswerVariant, TestFullDTO.AnswerDTO>();
        }
    }
}
