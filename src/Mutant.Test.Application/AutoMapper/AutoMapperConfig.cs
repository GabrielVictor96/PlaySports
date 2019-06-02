using AutoMapper;

namespace PlaySports.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x => { });
        }
    }
}