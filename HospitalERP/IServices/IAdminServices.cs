using HospitalERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalERP.IServices
{
    public interface IAdminServices
    {
        Task<IEnumerable<Doctor>> AllDoctors();
        Doctor AddDoctor(Doctor doctor);
        Doctor AddLoginDetails(Doctor doctor);
        Task<IEnumerable<Nurse>> AllNurse();
        Nurse AddNurse(Nurse nurse);
        Nurse AddLoginNurseDetails(Nurse nurse);
    }
}
