using AutoMapper;
using EShopper.Comment.Dtos;
using EShopper.Comment.Entities;

namespace EShopper.Comment.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserComment,GetByIdCommentDto>().ReverseMap();
            CreateMap<UserComment,ResultCommentDto>().ReverseMap();
            CreateMap<UserComment,UpdateCommentDto>().ReverseMap();
            CreateMap<UserComment,CreateCommentDto>().ReverseMap();
        }
    }
}
