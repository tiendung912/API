using AutoMapper;
using dungDAL.Models;
using dungDDL.ViewModels;

namespace dungAPI.dungMapper
{
    public class dungMapper:Profile
    {
        public dungMapper()
        {
            CreateMap<Category,CategoryVM>().ReverseMap();
        }
    }
}