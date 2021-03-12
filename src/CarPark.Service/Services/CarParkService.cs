using CarPark.Common;
using CarPark.Common.Helper;
using CarPark.Service.Dto;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarPark.Service.Services
{
    public interface ICarParkService
    {
        Task<CarParkAvailabilityDto> GetCarParkAvailabilities();
    }

    public class CarParkService : ICarParkService
    {
        private readonly HttpHelper<CarParkAvailabilityDto> httpHelper;
        public CarParkService()
        {
            httpHelper = new HttpHelper<CarParkAvailabilityDto>();
        }

        public async Task<CarParkAvailabilityDto> GetCarParkAvailabilities() 
            => await httpHelper.SendGetRequestAsync($"{Constants.CarPark.CarParkAvailabilityAPI}?date_time={DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}");
    }
}
