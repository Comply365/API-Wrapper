using System;
using System.Collections.Generic;
using Comply365.API.Samples.Actions.Core;
using Comply365.API.Samples.Models.Core;
using Comply365.API.Samples.Models.SYS;
using RestSharp;
using System.Linq;
using MoreLinq;

namespace Comply365.API.Samples.Actions.SYS
{
    public class Users
    {
        private readonly Authentication _authentication;

        public Users(Authentication authentication)
        {
            _authentication = authentication;
        }

        public PagedListWithStatusResponse<List<User>> GetUsers()
        {
            var response = new PagedListWithStatusResponse<List<User>>
            {
                IsSuccess = true,
                Data = new List<User>(),
                TotalRecords = 0
            };

            var client = _authentication.GetClient();

            // Here we set the page size.  We recommend starting at 5000, but this can be higher or lower depending on your server and network speed.  The larger
            // the page, the fewer requests you'll have (so it speeds up the job), but slower networks may time out.
            var page = 1;
            var pageSize = 5000;
            while (((page - 1) * pageSize < response.TotalRecords) || page == 1)
            {
                var request = _authentication.GetBaseRequest("api/SYS/v1/Users", Method.GET);
                request.AddParameter("pageSize", pageSize);
                request.AddParameter("page", page);
                var apiResponse = client.Execute<PagedListWithStatusResponse<List<User>>>(request);

                if (apiResponse.Data.IsSuccess && apiResponse.Data.Data.Any())
                {
                    response.Data.AddRange(apiResponse.Data.Data);

                    if (page == 1)
                    {
                        response.TotalRecords = apiResponse.Data.TotalRecords;
                    }
                }
                else
                {
                    throw new Exception($"The following error occurred when getting a list of users: {apiResponse.Data.ErrorMessage}");
                }
                page++;
            }

            return response;
        }

        public List<StatusResponseWithData<UserPutResponse>> PutUsers(List<UserPutRequest> usersToPut)
        {
            var returnValue = new List<StatusResponseWithData<UserPutResponse>>();

            //here we use a NuGet package to batch the user put requests so that we don't get timeout errors if we have large data sets.
            // in production you may very well find that batches larger than 50 are okay depending on your server and network speed.  Generally
            // we recommend testing around 200 at a time.
            foreach (var usersToPutBatch in usersToPut.Batch(50))
            {
                var client = _authentication.GetClient();

                var request = _authentication.GetBaseRequest("api/SYS/v1/Users", Method.PUT);
                request.AddBody(usersToPutBatch);
                var apiResponse = client.Execute<List<StatusResponseWithData<UserPutResponse>>>(request);

                returnValue.AddRange(apiResponse.Data);
            }

            return returnValue;
        }
    }
}