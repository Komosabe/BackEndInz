using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Models.Board;
using BackEndInz.Models.Column;
using BackEndInz.Models.Label;
using BackEndInz.Models.Note;
using BackEndInz.Models.User;

namespace BackEndInz.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Board
            // CreateRequestBoard -> Board
            CreateMap<CreateRequestBoard, Board>();

            // UpdateRequestBoard -> Board
            CreateMap<UpdateRequestBoard, Board>();

            // Board -> GetModelBoard
            //CreateMap<Board, GetModelBoard>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => new UserOnly
            //    {
            //        Id = u.Id,
            //        Username = u.Username
            //    })))
            //    .ForMember(dest => dest.Columns, opt => opt.MapFrom(src => src.Columns.Select(c => new ColumnOnly
            //    {
            //        Id = c.Id,
            //        Title = c.Title
            //    })));
            CreateMap<Board, GetModelBoard>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
            .ForMember(dest => dest.Columns, opt => opt.MapFrom(src => src.Columns))
            .ForMember(dest => dest.LabelId, opt => opt.MapFrom(src => src.LabelId))
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Label))
            .ReverseMap(); 

            // Board -> BoardOnly
            CreateMap<Board, BoardOnly>();
            #endregion

            #region User
            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // User -> UserOnly
            CreateMap<User, UserOnly>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

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
            #endregion

            #region Column
            // Column -> ColumnyOnly
            CreateMap<Column, ColumnOnly>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            // CreateRequestColumn -> Column
            CreateMap<CreateRequestColumn, Column>();

            // UpdateRequestColumn -> Column
            CreateMap<UpdateRequestColumn, Column>();

            // Column -> GetModelColumn
            CreateMap<Column, GetModelColumn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes.Select(note => new NoteOnly
                {
                    Id = note.Id,
                    CreatedBy = note.CreatedBy,
                    Description = note.Description,
                    Title = note.Title,
                    CreatedDate = note.CreatedDate,
                    isDone = note.isDone,
                    isImportant = note.isImportant,
                    StartDate = note.StartDate,
                    EndDate = note.EndDate
                }))); ;
            #endregion

            #region Label
            // Label -> LabelOnly
            CreateMap<Label, LabelOnly>();

            // CreateRequestLabelToBoard -> Label 
            CreateMap<CreateRequestLabelToBoard, Label>();

            // CreateRequestLabelToNote -> Label
            CreateMap<CreateRequestLabelToNote, Label>();

            // UpdateRequestLabel -> Label 
            CreateMap<UpdateRequestLabel, Label>();

            // Label -> GetModelLabelToBoard
            CreateMap<Label, GetModelLabel>();
            #endregion

            #region Note
            // Note -> NoteOnly
            CreateMap<Note, NoteOnly>();

            // CreateRequestNote -> Note
            CreateMap<CreateRequestNote, Note>();

            // UpdateRequestNote -> Note
            CreateMap<UpdateRequestNote, Note>();

            // Note -> GetModelNote
            CreateMap<Note, GetModelNote>();
            #endregion
        }
    }
}
