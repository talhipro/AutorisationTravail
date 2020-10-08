namespace Shared.Models
{
    public class LoginResultModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        public string UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserRoles")]
        public string UserRoles { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "FullName")]
        public string FullName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "expires_in")]
        public double ExpiresIn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = ".issued")]
        public string Issued { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = ".expires")]
        public string Expires { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone")]
        public string phone { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string email { get; set; }
    }
}
