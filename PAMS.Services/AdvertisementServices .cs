using PAMS.IRepository;
using PAMS.IServices;
using PAMS.Repository;

namespace PAMS.Services
{
    public class AdvertisementServices:IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();


        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
