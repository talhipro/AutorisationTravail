using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shared.httpREST
{
    public class RESTHelper
    {
        #region Login Method
        public static async Task<LoginResultModel> PostLoginRequest(string loginUrl, LoginModel loginModel, string acceptMediaType = "application/json", string fromKey = "")
        {
            try
            {
                #region Is valid model
                if (loginModel == null || string.IsNullOrWhiteSpace(loginModel?.Username) || string.IsNullOrWhiteSpace(loginModel?.Password))
                    return new LoginResultModel() { Error = "Invalid input", ErrorDescription = "Invalid username/ password" };
                #endregion

                #region IsConnected
                if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                    return new LoginResultModel() { Error = "Connection problem", ErrorDescription = "No connection available!" };
                #endregion

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(loginUrl);
                    client.DefaultRequestHeaders.Accept.Clear();

                    if (!string.IsNullOrWhiteSpace(acceptMediaType))
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptMediaType));

                    if (!string.IsNullOrWhiteSpace(fromKey))
                        client.DefaultRequestHeaders.TryAddWithoutValidation("From", fromKey);

                    var formEncodedContent = new FormUrlEncodedContent(new[]
                    {
                     new KeyValuePair<string, string>("grant_type", "password"),
                     new KeyValuePair<string, string>("username", loginModel.Username),
                     new KeyValuePair<string, string>("password", loginModel.Password),
                 });

                    var responseMessage = await client.PostAsync(string.Empty,formEncodedContent);

                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    LoginResultModel result = JsonConvert.DeserializeObject<LoginResultModel>(jsonResponse);

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new LoginResultModel() { Error = "Error", ErrorDescription = ex.Message };
            }
        }
        #endregion

        #region GetRequest GetParams as NameValueCollection
        public static async Task<RESTServiceResponse<T>> GetRequest<T>(string token, string url, HttpVerbs method = HttpVerbs.GET, NameValueCollection getParams = null, object postObject = null, string contentType = "application/json")
        {
            try
            {
                #region IsConnected

                bool IsConnected = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
                if (!IsConnected)
                {
                    return new RESTServiceResponse<T>(false, "Vous n'êtes pas connéctés !");
                }
                #endregion


                using (var client = new HttpClient())
                {
                    //setup client
                    Uri uri = new Uri(url);
                    #region Setting Attachements

                    if (method == HttpVerbs.GET && getParams != null)
                    {
                        uri = uri.AttachParameters(getParams);
                    }

                    #endregion
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    //make request
                    HttpResponseMessage response = new HttpResponseMessage();
                    switch (method)
                    {
                        case HttpVerbs.GET:
                            try
                            {
                                response = await client.GetAsync(uri);
                            }
                            catch (Exception)
                            {
                            }
                            break;
                        case HttpVerbs.POST:
                            try
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(postObject).ToString(), Encoding.UTF8, "application/json");
                                response = await client.PostAsync(uri, content);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                            break;
                        default:
                            break;
                    }

                    var stringResponseJson = await response.Content?.ReadAsStringAsync();

                    RESTServiceResponse<T> result = JsonConvert.DeserializeObject<RESTServiceResponse<T>>(stringResponseJson);

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<T>(false, ex.Message);
            }
        }
        #endregion
    }

    public static class RESTExtensions
    {
        #region Attach "NameValueCollection" Parameters
        public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";
            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }
        #endregion
    }
}
