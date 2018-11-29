using System;
using Comply365.API.Samples.Models.Core;
using RestSharp;

namespace Comply365.API.Samples.Actions.Core
{
    public class Authentication
    {
        private readonly string _baseApiUrl;
        private readonly string _apiUsername;
        private readonly string _apiPassword;
        private AuthenticationToken _authenticationToken;

        public Authentication(string baseApiUrl1, string apiUsername, string apiPassword)
        {
            _baseApiUrl = baseApiUrl1;
            _apiUsername = apiUsername;
            _apiPassword = apiPassword;

            GetToken();
        }

        public AuthenticationToken GetToken()
        {
            var request = new RestRequest("/Token", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("userName", _apiUsername);
            request.AddParameter("password", _apiPassword);
            request.AddParameter("grant_type", "password");
            var client = GetClient();
            var authenticationResponse = client.Execute<AuthenticationToken>(request);

            // if we time out, try again just in case IIS was warming up
            if (!string.IsNullOrEmpty(authenticationResponse.ErrorMessage) && authenticationResponse.ErrorMessage.Contains("timed out"))
            {
                authenticationResponse = client.Execute<AuthenticationToken>(request);
            }

            if (string.IsNullOrEmpty(authenticationResponse.Data.Access_Token))
            {
                throw new Exception("No token was returned");
            }

            _authenticationToken = authenticationResponse.Data;

            return authenticationResponse.Data;
        }

        public RestClient GetClient()
        {
            return new RestClient(_baseApiUrl);
        }

        public RestRequest GetBaseRequest(string apiUrl, Method method)
        {
            var request = new RestRequest(apiUrl, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + _authenticationToken.Access_Token);

            if (method != Method.GET)
            {
                request.RequestFormat = DataFormat.Json;
            }

            return request;
        }
    }
}