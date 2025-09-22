using EShopper.DtoLayer.IdentityDtos.LoginDtos;

namespace EShopper.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SingIn(SingInDto singInDto);
        Task<bool> GetRefreshToken();
    }
}
