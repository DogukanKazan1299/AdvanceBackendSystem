using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddTeam = "new team added";
        public static string DeleteTeam = "team deleted";
        public static string UpdateTeam = "team updated";

        public static string AddCountry = "new country added";
        public static string DeleteCountry = "country deleted";
        public static string UpdateCountry = "country updated";

        public static string UserNotFound = "Kullanici Bulunamadi";
        public static string PasswordError = "Şifre Hatali";
        public static string SuccessfulLogin = "Sisteme Giris Basarili";
        public static string UserAlreadyExists = "Kullanici Zaten Mevcut";
        public static string UserRegistered = "Kullanici Basariyla Kaydedildi";
        public static string AccessTokenCreated = "Access Token Basariyla Olusturuldu";
        public static string CountryNameAlreadyExists="Bu isimde zaten ülke var";
        public static string AuthorizationDenied="Yetkiniz yok! ";
    }
}
