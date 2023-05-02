using AutoMapper;

namespace Base.Application.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Dominio para ViewModel

            //CreateMap<Sample, SampleVm>();

            #endregion

            #region ViewModel para Dominio

            //CreateMap<SampleVm, Sample>();

            #endregion
        }
    }
}
