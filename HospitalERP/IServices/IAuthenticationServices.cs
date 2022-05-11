using HospitalERP.Models;

namespace HospitalERP.IServices
{
    public interface IAuthenticationServices
    {
        Login UserLogin(Login login);
    }
}
