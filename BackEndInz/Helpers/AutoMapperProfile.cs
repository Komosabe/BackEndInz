using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Models.Board;
using BackEndInz.Models.Column;
using BackEndInz.Models.Label;
using BackEndInz.Models.User;

namespace BackEndInz.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequestBoard -> Board
            CreateMap<CreateRequestBoard, Board>();

            // UpdateRequestBoard -> Board
            CreateMap<UpdateRequestBoard, Board>();


            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // User -> UserOnly
            CreateMap<User, UserOnly>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

            // Board -> GetModelBoard
            CreateMap<Board, GetModelBoard>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => new UserOnly
                {
                    Id = u.Id,
                    Username = u.Username
                })))
                .ForMember(dest => dest.Columns, opt => opt.MapFrom(src => src.Columns.Select(c => new ColumnOnly
                {
                    Id = c.Id,
                    Title = c.Title
                })));

            // Column -> ColumnyOnly
            CreateMap<Column, ColumnOnly>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            // Label -> LabelOnly
            CreateMap<Label, LabelOnly>();

            // Board -> BoardOnly
            CreateMap<Board, BoardOnly>();

            // User -> GetModelUser
            CreateMap<User, GetModelUser>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}
