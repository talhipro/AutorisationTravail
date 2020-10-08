using Newtonsoft.Json;
using Shared;
using Shared.httpREST;
using Shared.Models;
using Shared.Models.Permis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AutorisationTravail.ApiCalls
{
    public static class ApiCalls
    {
        #region 1 - Login
        public static async Task<LoginResultModel> Login(LoginModel model)
        {
            var apiUrl = $"{AppUrls.Login}";
            return await RESTHelper.PostLoginRequest(apiUrl, model);
        }
        #endregion

        #region 2 - Get Permis List
        public static async Task<RESTServiceResponse<ObservableCollection<PermisListModel>>> GetPermisList()
        {
            try
            {
                return await RESTHelper.GetRequest<ObservableCollection<PermisListModel>> (url: AppUrls.PermisList, token: AppSettings.AccessToken, method: HttpVerbs.GET);
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<ObservableCollection<PermisListModel>>() { success = false, message = $"Erreur: {ex.Message}" };
            }
        }
        #endregion

        #region 3 - Get Permis List with Params
        public static async Task<RESTServiceResponse<ObservableCollection<PermisListModel>>> GetOrdersList(object param)
        {
            try
            {
                var postData = new GenericPostModel
                {
                    PostData = JsonConvert.SerializeObject(param),
                };

                return await RESTHelper.GetRequest<ObservableCollection<PermisListModel>>(url: AppUrls.PermisList, token: AppSettings.AccessToken, method: HttpVerbs.POST, postObject: postData);
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<ObservableCollection<PermisListModel>>() { success = false, message = $"Erreur: {ex.Message}" };
            }
        }
        #endregion
    }
}
