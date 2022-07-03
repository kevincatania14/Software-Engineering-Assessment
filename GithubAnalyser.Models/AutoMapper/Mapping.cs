using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubAnalyser.Models.AutoMapper
{
    /// <summary>
    /// AutoMapper class is not in use
    /// Sample shows example of how AutoMapper could be used
    /// </summary>
    class Mapping
    {
        MapperConfiguration configuration { get; set; }
        Mapper mapper { get; set; }

        public Mapping()
        {
            configuration = new MapperConfiguration(cfg => cfg.CreateMap<GithubProfile, GithubProfileDTO>()
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.message)));

            mapper = new Mapper(configuration);
        }

        public GithubProfileDTO MapUser(GithubProfile user)
        {
            GithubProfileDTO userDTO = mapper.Map<GithubProfile, GithubProfileDTO>(user);
            return userDTO;
        }
    }
}
