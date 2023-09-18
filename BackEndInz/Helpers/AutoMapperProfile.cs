using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Models.Board;
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

            // User -> UserAddModel
            //CreateMap<User, UserAddModel>();

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
