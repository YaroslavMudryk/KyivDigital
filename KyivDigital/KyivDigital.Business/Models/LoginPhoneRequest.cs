using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class LoginPhoneRequest
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("device")]
        public Dictionary<string, string> Device { get; set; }
        public LoginPhoneRequest(string phone) : this()
        {
            Phone = phone;
        }
        public LoginPhoneRequest(string phone, string code) : this()
        {
            Phone = phone;
            Code = code;
        }
        public LoginPhoneRequest()
        {
            Device = new Dictionary<string, string>();
            Device.Add("app_ver", GetAppVersion());
            Device.Add("fcm_token", "");
            Device.Add("name", GetRandomPhone());
            Device.Add("os_ver", GetRandomOSVersion());
            Device.Add("platform", GetPlatform());
            Device.Add("UUID", GetRandomUUID());
        }

        #region Private

        private string[] _phones = new string[]
        {
            "Samsung A30",
            "Samsung A32",
            "Samsung A31",
            "Xiaomi Note 5",
            "Xiaomi Note 11 Pro",
            "Asus Rog 2",
            "Asus Rog Pro",
            "HUAWEI P20 Pro",
            "HUAWEI P40",
            "Sony Xperia 5",
            "Sony Xperia 4 Pro",
            "OnePlus 9 Pro",
            "OnePlus 8",
            "Google Pixel 3 Pro",
            "Google Pixel 5",
            "HTC U11",
            "Lenovo A328",
            "Lenovo S660",
            "Meizu M3 Note",
            "Meizu M5",
            "Nomi i5071"
        };

        private string GetRandomPhone()
        {
            var rnd = new Random();
            var randomIndex = rnd.Next(0, _phones.Length);
            return _phones[randomIndex];
        }

        private string GetRandomOSVersion(int minVersion = 7, int maxVersion = 12)
        {
            var rnd = new Random();
            return rnd.Next(minVersion, maxVersion).ToString();
        }

        private string GetRandomUUID()
        {
            return Guid.NewGuid().ToString();
        }

        private string GetPlatform()
        {
            return "0";
        }

        private string GetAppVersion()
        {
            return "1.2.1";
        }
        #endregion
    }
}