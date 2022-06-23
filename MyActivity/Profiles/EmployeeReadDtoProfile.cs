using AutoMapper;
using MyActivity.Dto;
using MyActivity.Models;

namespace MyActivity.Profiles
{
    public class EmployeeReadDtoProfile:Profile
    {
        public EmployeeReadDtoProfile()
        {
            CreateMap<Employee, EmployeeReadDto>();
        }
    }
}
