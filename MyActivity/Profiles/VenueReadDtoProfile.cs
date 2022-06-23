using AutoMapper;
using MyActivity.Dto;
using MyActivity.Models;

namespace MyActivity.Profiles
{
    public class VenueReadDtoProfile:Profile
    {
        public VenueReadDtoProfile()
        {
            CreateMap<Venue, VenueReadDto>();
        }
    }
}
