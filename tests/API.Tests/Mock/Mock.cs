using AutoMapper;
using CarPark.Service.Mapper;

namespace Application.Tests.Mock
{
    public class Mock
    {
        public static IMapper Mapper
        {
            get
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ServiceProfile());
                });

                return mapper.CreateMapper();
            }
        }
    }
}
