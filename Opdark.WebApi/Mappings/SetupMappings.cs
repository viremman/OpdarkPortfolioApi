using AutoMapper;
using Opdark.WebApi.DTOs.Bio;
using Opdark.WebApi.DTOs.Blog;
using Opdark.WebApi.DTOs.Comment;
using Opdark.WebApi.DTOs.Contact;
using Opdark.WebApi.DTOs.Project;
using Opdark.WebApi.DTOs.Quote;
using Opdark.WebApi.DTOs.Service;
using Opdark.WebApi.DTOs.Skill;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Mappings
{
    public class SetupMappings : Profile
    {
        public SetupMappings()
        {
            CreateMap<IncomingBioDto, Bio>().ReverseMap();
            CreateMap<OutgoingBioDto, Bio>().ReverseMap();

            CreateMap<IncomingProjectDto, Project>().ReverseMap();
            CreateMap<OutgoingProjectDto, Project>().ReverseMap();

            CreateMap<IncomingServiceDto, Service>().ReverseMap();
            CreateMap<OutgoingServiceDto, Service>().ReverseMap();

            CreateMap<IncomingSkillDto, Skill>().ReverseMap();
            CreateMap<OutgoingSkillDto, Skill>().ReverseMap();

            CreateMap<IncomingBlogDto, Blog>().ReverseMap();
            CreateMap<OutgoingBlogDto, Blog>().ReverseMap();

            CreateMap<IncomingContactDto, Contact>().ReverseMap();
            CreateMap<OutgoingContactDto, Contact>().ReverseMap();

            CreateMap<IncomingCommentDto, Comment>().ReverseMap();
            CreateMap<OutgoingCommentDto, Comment>().ReverseMap();

            CreateMap<IncomingQuoteDto, Quote>().ReverseMap();
            CreateMap<OutgoingQuoteDto, Quote>().ReverseMap();
        }
    }
}
