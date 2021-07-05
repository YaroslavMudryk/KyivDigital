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
        private string GetRandomPhone()
        {
            return "Samsung A30";
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
            return "1.1.1";
        }
        #endregion
    }
}