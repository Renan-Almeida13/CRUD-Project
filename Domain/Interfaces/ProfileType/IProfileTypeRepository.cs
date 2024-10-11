using Domain.Entities.ProfileType.Responses;

namespace Domain.Interfaces.ProfileType
{
    public interface IProfileTypeRepository
    {
        IEnumerable<ProfileTypeListResponse> List();
    }
}
