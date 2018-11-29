namespace Comply365.API.Samples.Models.Core
{
    public class AuthenticationToken
    {
        /// <summary>
        /// This is the bearer token you use after authenticating
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// For now, this is always Bearer
        /// </summary>
        public string Token_Type { get; set; }
        /// <summary>
        /// The number of seconds until the token expires from last API call
        /// </summary>
        public int Expires_In { get; set; }
    }
}