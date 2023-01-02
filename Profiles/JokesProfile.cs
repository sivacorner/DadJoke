using AutoMapper;
using DadJokes.Models;

namespace DadJokes.Profiles
{
    public class JokesProfile : Profile
    {
        public JokesProfile()
        {
            CreateMap<Jokes, JokesViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src._Id))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.setup))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.punchline));
        }
            
                  
    }
}
