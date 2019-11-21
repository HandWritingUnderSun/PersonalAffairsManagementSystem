using System;
using PAMS.IRepository;

namespace PAMS.Repository
{
    public class AdvertisementRepository:IAdvertisementRepository
    {
        public int Sum(int i,int j)
        {
            return i + j;
        }
    }
}
