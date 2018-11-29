using Comply365.API.Samples.Actions.Core;
using Comply365.API.Samples.Actions.SYS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comply365.API.Samples.Tests.SYS
{
    [TestClass]
    public class UsersTest
    {
        /// <summary>
        /// Fill out the API settings below.  In production, these values should obviously be stored securely in a database or config file according to your company's security
        /// policy.
        /// </summary>
        private readonly string _baseApiUrl = "base api url goes here";
        private readonly string _baseApiUsername = "api username goes here";
        private readonly string _baseApiPassword = "api password goes here";

        [TestMethod]
        public void GetAllUsers()
        {
            var authentication = new Authentication(_baseApiUrl, _baseApiUsername, _baseApiPassword);

            var users = new Users(authentication);

            var allUsers = users.GetUsers();

            Assert.IsTrue(allUsers.IsSuccess);
            Assert.AreEqual(allUsers.TotalRecords, allUsers.Data.Count);
        }

        [TestMethod]
        public void CreateAndUpdateUser()
        {
            var authentication = new Authentication(_baseApiUrl, _baseApiUsername, _baseApiPassword);

            var users = new Users(authentication);

            var username = Guid.NewGuid().ToString();

            var userToCreate = new UserPutRequest
            {
                Username = username,
                FirstName = "Test",
                LastName = "User",
                Email = "nobody@comply365.com",
                StartDateTimeUtc = DateTime.UtcNow.AddDays(-10)
            };

            // The comply365 API only takes in a list for all requests to speed up processing, so we need a new list here even though there is only one object in it
            var userPutRequest = new List<UserPutRequest>();
            userPutRequest.Add(userToCreate);

            var usersPutResponse = users.PutUsers(userPutRequest);

            // let's make sure the request was a success
            Assert.IsTrue(usersPutResponse.Where(x=> x.Data.Username.Equals(username)).Select(x=> x.IsSuccess).Single());
        }
    }
}
