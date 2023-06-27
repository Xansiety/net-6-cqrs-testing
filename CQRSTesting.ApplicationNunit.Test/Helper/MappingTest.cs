using AutoMapper;
using CQRSTesting.Application.DTOs;
using CQRSTesting.Domain.Entities;

namespace CQRSTesting.Application.Helper
{
    public class MappingTest : Profile
    {
        // Este constructor es el que se encarga de hacer el mapeo
        public MappingTest()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
