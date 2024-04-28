using AutoMapper;
using Learning.Data.UserEntity;
using Learning.Models.UserModels;
using System.Linq;

namespace Learning.Models.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
        
            CreateMap<UserCreateModel, User>().AutoMapAll();
        }
    }

    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> AutoMapAll<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties
                    .FirstOrDefault(p => p.Name == sourceProperty.Name);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    expression.ForMember(destinationProperty.Name, opt => opt.MapFrom(sourceProperty.Name));
                }
            }

            return expression;
        }
    }
}
