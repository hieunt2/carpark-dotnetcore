using System;

namespace CarPark.Common
{
    public static class Constants
    {
        public static class Users
        {
            public const string UserExisted = "User already existed.";
            public const string RegisterAccountSuccess = "Register account successfully!";
            public const string RegisterAccountFail = "Register account failed!";
            public const string LoginAccountSuccess = "Login successfully!";
            public const string LoginAccountFail = "Login failed!";
        }

        public static class CarPark
        {
            public const string CarParkAvailabilityAPI = "https://api.data.gov.sg/v1/transport/carpark-availability";
        }
    }
}
