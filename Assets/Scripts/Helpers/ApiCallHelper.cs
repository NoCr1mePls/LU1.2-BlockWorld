using Dtos;
using Services;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
namespace Helpers
{
    public static class ApiCallHelper
    {
        /// <summary>
        /// Login with the given email and password via an API call
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public static async Task Login(string email, string password)
        {
            ApiService.Token = JsonConvert.DeserializeObject<PostLoginResponseDto>(await ApiService.PerformApiCall("post", ApiService.url + @"/account/login",
                    jsonData:
                    @$"{{""email"": ""{email}"", ""password"" : ""{password}""}}")).accessToken;
            Debug.Log("Api token set");
        }

        /// <summary>
        /// Register with the given email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public static async Task Register(string email, string password)
        {
            await ApiService.PerformApiCall("post", ApiService.url + @"/account/register",
                                jsonData:
                                @$"{{""email"": ""{email}"", ""password"" : ""{password}""}}");
        }

        /// <summary>
        /// Get the current user
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetLoggedInUserId()
        {
            Debug.Log(ApiService.Token);
            return await ApiService.PerformApiCall("get", ApiService.url + @"/UserInformation",token: ApiService.Token);
        }

        public static async Task<Environment2DDto[]> GetEnvironments()
        {
            return JsonConvert.DeserializeObject<Environment2DDto[]>(
                await ApiService.PerformApiCall("get", ApiService.url + @"/Data/Environments", token: ApiService.Token)
                );
        }
    }
}