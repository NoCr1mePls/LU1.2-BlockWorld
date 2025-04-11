using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    /// <summary>
    /// This class functions as a service for the API calls
    /// </summary>
    public class ApiService : MonoBehaviour
    {
        //This is the standard url, use this as a base and add the endpoint
        public static readonly string url = "https://localhost:7227";

        //Use this Token for authorisation, it gets set by the login method
        public static string Token { get; set; }

        /// <summary>
        /// This method performs an API call
        /// </summary>
        /// <param name="method">Method of the API-call (POST, GET, etc.)</param>
        /// <param name="url">The url of the endpoint, use <see cref="url"/>for the base string.</param>
        /// <param name="jsonData">The json data to be sent</param>
        /// <param name="token">The token to be used with the request, use <see cref="Token"/>.</param>
        /// <returns></returns>
        public static async Task<string> PerformApiCall(string method, string url, string jsonData = null, string token = null)
        {
            using (UnityWebRequest request = new(url, method))
            {
                if (!string.IsNullOrEmpty(jsonData))
                {
                    byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
                    request.uploadHandler = new UploadHandlerRaw(jsonToSend);
                }

                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                if (!string.IsNullOrEmpty(token))
                {
                    request.SetRequestHeader("Authorization", "Bearer " + token);
                }
                
                await request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("API-call succes: " + request.downloadHandler.text);

                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.Log("API-call error: " + request.error);
                    return null;
                }
            }
        }
    }
}