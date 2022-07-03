using GithubAnalyser.Models;

namespace GithubAnalyser.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test method for correct intended input
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            GithubProfileCustomModel expected = new GithubProfileCustomModel()
            {
                login = "kevincatania14",
                bio = null,
                company = null,
                location = null,
                following = "0",
                public_repos = "0",
                message = null
            };

            GithubAnalyser.BusinessLogic.GithubAnalyser testMethod = new GithubAnalyser.BusinessLogic.GithubAnalyser();
            GithubProfileCustomModel actual = testMethod.Analyse("kevincatania14");
            Assert.AreEqual(actual.login, expected.login);
            Assert.AreEqual(actual.bio, expected.bio);
            Assert.AreEqual(actual.company, expected.company);
            Assert.AreEqual(actual.location, expected.location);
            Assert.AreEqual(actual.following, expected.following);
            Assert.AreEqual(actual.public_repos, expected.public_repos);
            Assert.AreEqual(actual.message, expected.message);
        }

        /// <summary>
        /// Test method for incorrect random input
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            string randomInput = "asdgasdgasdgsadgadsgadsgad";

            GithubProfileCustomModel expected = new GithubProfileCustomModel()
            {
                login = null,
                bio = null,
                company = null,
                location = null,
                following = null,
                public_repos = null,
                message = randomInput
            };

            GithubAnalyser.BusinessLogic.GithubAnalyser testMethod = new GithubAnalyser.BusinessLogic.GithubAnalyser();
            GithubProfileCustomModel actual = testMethod.Analyse(randomInput);
            Assert.AreEqual(actual.login, expected.login);
            Assert.AreEqual(actual.bio, expected.bio);
            Assert.AreEqual(actual.company, expected.company);
            Assert.AreEqual(actual.location, expected.location);
            Assert.AreEqual(actual.following, expected.following);
            Assert.AreEqual(actual.public_repos, expected.public_repos);
            Assert.AreEqual(actual.message, expected.message);
        }
    }
}