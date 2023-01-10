using AutoMapper;
using Models.Data;
using Models.View;
namespace web_pairing_kit_dot_net.MapperProfile
{
    public class TourProfile : Profile
    {
        public TourProfile()
        {
            CreateMap<Tour, VmTour>();
        }
    }
}
