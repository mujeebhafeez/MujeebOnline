using AutoMapper;

namespace MujeebOnline.AutoMapper
{
    public static class AutoMapperHelper
    {

        public static TDestination Parse<TSource, TDestination>(TSource model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(model);

        }

        public static List<TDestination> ParseCollection<TSource, TDestination>(List<TSource> sources)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<TSource>, List<TDestination>>(sources);

        }
    }
}
