using Gateway.Model.Dtos;

namespace Gateway.Api.Hubs
{
    public interface IParamHubContext
    {
        Task UpdateParam(List<ParameterDto> dto);
    }
}
