using AutoMapper;
using RandomUser.Domain.DTOs;
using RandomUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Application.Mapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<UserDTO, User>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.NameTitle, opt => opt.MapFrom(src => src.Name.Title))
                        .ForMember(dest => dest.NameFirst, opt => opt.MapFrom(src => src.Name.First))
                        .ForMember(dest => dest.NameLast, opt => opt.MapFrom(src => src.Name.Last))
                        .ForMember(dest => dest.DobDate, opt => opt.MapFrom(src => src.Dob.Date))
                        .ForMember(dest => dest.DobAge, opt => opt.MapFrom(src => src.Dob.Age))
                        .ForMember(dest => dest.RegisteredDate, opt => opt.MapFrom(src => src.Registered.Date))
                        .ForMember(dest => dest.RegisteredAge, opt => opt.MapFrom(src => src.Registered.Age))
                        .ForMember(dest => dest.IdName, opt => opt.MapFrom(src => src.Id.Name))
                        .ForMember(dest => dest.IdValue, opt => opt.MapFrom(src => src.Id.Value))
                        .ForPath(dest => dest.Location.City, opt => opt.MapFrom(src => src.Location.City))
                        .ForPath(dest => dest.Location.State, opt => opt.MapFrom(src => src.Location.State))
                        .ForPath(dest => dest.Location.Country, opt => opt.MapFrom(src => src.Location.Country))
                        .ForPath(dest => dest.Location.Postcode, opt => opt.MapFrom(src => src.Location.Postcode))
                        .ForPath(dest => dest.Location.StreetNumber, opt => opt.MapFrom(src => src.Location.Street.Number))
                        .ForPath(dest => dest.Location.StreetName, opt => opt.MapFrom(src => src.Location.Street.Name))
                        .ForPath(dest => dest.Location.CoordinatesLatitude, opt => opt.MapFrom(src => src.Location.Coordinates.Latitude))
                        .ForPath(dest => dest.Location.CoordinatesLongitude, opt => opt.MapFrom(src => src.Location.Coordinates.Longitude))
                        .ForPath(dest => dest.Location.TimezoneOffset, opt => opt.MapFrom(src => src.Location.Timezone.Offset))
                        .ForPath(dest => dest.Location.TimezoneDescription, opt => opt.MapFrom(src => src.Location.Timezone.Description))
                        .ForPath(dest => dest.Login.uuid, opt => opt.MapFrom(src => src.Login.Uuid))
                        .ForPath(dest => dest.Login.Username, opt => opt.MapFrom(src => src.Login.Username))
                        .ForPath(dest => dest.Login.Password, opt => opt.MapFrom(src => src.Login.Password))
                        .ForPath(dest => dest.Login.Salt, opt => opt.MapFrom(src => src.Login.Salt))
                        .ForPath(dest => dest.Login.Md5, opt => opt.MapFrom(src => src.Login.Md5))
                        .ForPath(dest => dest.Login.Sha1, opt => opt.MapFrom(src => src.Login.Sha1))
                        .ForPath(dest => dest.Login.Sha256, opt => opt.MapFrom(src => src.Login.Sha256))
                        .ForPath(dest => dest.Picture.Large, opt => opt.MapFrom(src => src.Picture.Large))
                        .ForPath(dest => dest.Picture.Medium, opt => opt.MapFrom(src => src.Picture.Medium))
                        .ForPath(dest => dest.Picture.Thumbnail, opt => opt.MapFrom(src => src.Picture.Thumbnail));

            CreateMap<User, UserDTO>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new NameDTO { Title = src.NameTitle, First = src.NameFirst, Last = src.NameLast }))
                        .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => new DobDTO { Date = src.DobDate, Age = src.DobAge }))
                        .ForMember(dest => dest.Registered, opt => opt.MapFrom(src => new RegisteredDTO { Date = src.RegisteredDate, Age = src.RegisteredAge }))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new IdDTO { Name = src.IdName, Value = src.IdValue }))
                        .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new LocationDTO {
                            City = src.Location.City,
                            State = src.Location.State,
                            Country = src.Location.Country,
                            Postcode = src.Location.Postcode,
                            Street = new StreetDTO { Number = src.Location.StreetNumber, Name = src.Location.StreetName },
                            Coordinates = new CoordinatesDTO { Latitude = src.Location.CoordinatesLatitude, Longitude = src.Location.CoordinatesLongitude },
                            Timezone = new TimezoneDTO { Offset = src.Location.TimezoneOffset, Description = src.Location.TimezoneDescription }
                        }))
                        .ForMember(dest => dest.Login, opt => opt.MapFrom(src => new LoginDTO {
                            Uuid = src.Login.uuid.ToString(),
                            Username = src.Login.Username,
                            Password = src.Login.Password,
                            Salt = src.Login.Salt,
                            Md5 = src.Login.Md5,
                            Sha1 = src.Login.Sha1,
                            Sha256 = src.Login.Sha256
                        }))
                        .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => new PictureDTO {
                            Large = src.Picture.Large,
                            Medium = src.Picture.Medium,
                            Thumbnail = src.Picture.Thumbnail
                        }));
        }
    }
}
