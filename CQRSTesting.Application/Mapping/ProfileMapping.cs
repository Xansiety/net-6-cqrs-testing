using AutoMapper;
using CQRSTesting.Application.DTOs;
using CQRSTesting.Domain.Entities;

namespace CQRSTesting.Application.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
