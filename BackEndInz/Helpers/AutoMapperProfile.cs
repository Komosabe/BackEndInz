using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Models.Board;

namespace BackEndInz.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequestBoard, Board>();
            CreateMap<UpdateRequestBoard, Board>();
            // to do
        }
    }
}
