using AutoMapper;
using Entities;
using ENTITIES;
using Epam.Library.Mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Library.Mvc.App_Start
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMaps()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<BookCreateFormVM, Book>()
                //.ForMember(dest => dest.ISBN, opt => opt.ResolveUsing(src => src.ISBN))
                //.ForMember(dest => dest.Authors, opt => opt.ResolveUsing(src => src.AuthorsId.Select(x => new Author { Id = x })))
                //.ForMember(dest => dest.Publisher, opt => opt.ResolveUsing(src => new Publisher { Id = src.PublisherId }))
                //.ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
                //.ForMember(dest => dest.Note, opt => opt.ResolveUsing(src => src.Note))
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                //.ForMember(dest => dest.NumberOfPages, opt => opt.ResolveUsing(src => src.NumberOfPages));
                
                //Create не нужен
                cfg.CreateMap<Book, BookEditFormVM>()
                .ForMember(dest => dest.ISBN, opt => opt.ResolveUsing(src => src.ISBN))
                .ForMember(dest => dest.AuthorsId, opt => opt.ResolveUsing(src => src.Authors.Select(x => x.Id)))
                .ForMember(dest => dest.PublisherId, opt => opt.ResolveUsing(src => src.Publisher.Id))
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
                .ForMember(dest => dest.Note, opt => opt.ResolveUsing(src => src.Note))
                .ForMember(dest => dest.Id, opt => opt.ResolveUsing(src => src.Id))
                .ForMember(dest => dest.YearOfPublishing, opt => opt.ResolveUsing(src => src.YearOfPublishing))
                .ForMember(dest => dest.CityOfPublishing, opt => opt.ResolveUsing(src => src.CityOfPublishing))
                .ForMember(dest => dest.NumberOfPages, opt => opt.ResolveUsing(src => src.NumberOfPages));


                //Create не нужен
                cfg.CreateMap<BookEditFormVM, Book>()
                .ForMember(dest => dest.ISBN, opt => opt.ResolveUsing(src => src.ISBN))
                .ForMember(dest => dest.Authors, opt => opt.ResolveUsing(src => src.AuthorsId.Select(x => new Author { Id = x})))
                .ForMember(dest => dest.Publisher, opt => opt.ResolveUsing(src => new Publisher { Id = src.PublisherId }))
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
                .ForMember(dest => dest.Note, opt => opt.ResolveUsing(src => src.Note))
                .ForMember(dest => dest.Id, opt => opt.ResolveUsing(src => src.Id))
                .ForMember(dest => dest.YearOfPublishing, opt => opt.ResolveUsing(src => src.YearOfPublishing))
                .ForMember(dest => dest.CityOfPublishing, opt => opt.ResolveUsing(src => src.CityOfPublishing))
                .ForMember(dest => dest.NumberOfPages, opt => opt.ResolveUsing(src => src.NumberOfPages));

                //Create не нужен
                cfg.CreateMap< PaperIssue, PaperIssueEditFormVM>()
                .ForMember(dest => dest.PublisherId, opt => opt.ResolveUsing(src => src.Publisher.Id ))
                .ForMember(dest => dest.CityOfPublishing, opt => opt.ResolveUsing(src => src.CityOfPublishing))
                .ForMember(dest => dest.PaperId, opt => opt.ResolveUsing(src => src.Paper.Id))
                .ForMember(dest => dest.IssueNumber, opt => opt.ResolveUsing(src => src.IssueNumber))
                .ForMember(dest => dest.DateOfIssue, opt => opt.ResolveUsing(src => src.DateOfIssue))
                .ForMember(dest => dest.Note, opt => opt.ResolveUsing(src => src.Note))
                .ForMember(dest => dest.Id, opt => opt.ResolveUsing(src => src.Id))
                .ForMember(dest => dest.IssueNumber, opt => opt.ResolveUsing(src => src.IssueNumber));


                //Поскольку Add принимает целую сущность, то он нужен
                cfg.CreateMap<PaperCreateFormVM, Paper>()
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
                .ForMember(dest => dest.Issn, opt => opt.ResolveUsing(src => src.Issn))
                .ForMember(dest => dest.Id, opt => opt.Ignore());


                //Для Create не нужно
                cfg.CreateMap<Patent, PatentEditFormVM>()
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
                .ForMember(dest => dest.AuthorsId, opt => opt.ResolveUsing(src => src.Authors.Select(x => x.Id)))
                .ForMember(dest => dest.Country, opt => opt.ResolveUsing(src => src.Country))
                .ForMember(dest => dest.RegNumber, opt => opt.ResolveUsing(src => src.RegNumber))
                .ForMember(dest => dest.SubmissionDocuments, opt => opt.ResolveUsing(src => src.SubmissionDocuments))
                .ForMember(dest => dest.DateOfPublication, opt => opt.ResolveUsing(src => src.DateOfPublication))
                .ForMember(dest => dest.NumberOfPages, opt => opt.ResolveUsing(src => src.NumberOfPages))
                .ForMember(dest => dest.Id, opt => opt.ResolveUsing(src => src.Id))
                .ForMember(dest => dest.Note, opt => opt.ResolveUsing(src => src.Note));

                cfg.CreateMap<UserEditVM, User>()
                .ForMember(dest => dest.Role, opt => opt.ResolveUsing(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.ResolveUsing(src => src.Login));

                cfg.CreateMap<User, UserEditVM>()
                .ForMember(dest => dest.Role, opt => opt.ResolveUsing(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.ResolveUsing(src => src.Login));

                cfg.CreateMap<Author, AuthorCreateVM>()
                .ForMember(dest => dest.FirstName, opt => opt.ResolveUsing(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.ResolveUsing(src => src.LastName));

                cfg.CreateMap<AuthorCreateVM, Author>()
                .ForMember(dest => dest.FirstName, opt => opt.ResolveUsing(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.ResolveUsing(src => src.LastName))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            });

            
            Mapper.AssertConfigurationIsValid();
        }
    }
}