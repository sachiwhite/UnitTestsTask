using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace UnitTestProject1
{
    public class SW_Person_Data    
    {
        public string name { get; set; } 
        public string homeworld { get; set; } 
    }

    public class SW_Planet_Data
    {
        public string Name { get; set; } 
    }
    [TestFixture]
    public class LukeSkywalkerTask
    {
        private HttpClient client;
        
        [SetUp]
        public void SetupTest()
        {
            client = new HttpClient();
        }

        [Test]
        public async Task IsLukeSkywalkerFromTatooineTest_ReturnsTrue()
        {
            
            var path = @"https://swapi.dev/api/people/1/";
            HttpResponseMessage response = await client.GetAsync(path);
            var person = await response.Content.ReadAsAsync<SW_Person_Data>();
            response = await client.GetAsync(person.homeworld);
            var planet = await response.Content.ReadAsAsync<SW_Planet_Data>();
            Assert.AreEqual(planet.Name, "Tatooine");
        }

        [TearDown]
        public void TearDown()
        {
            File.WriteAllLines($"LukeSkywalkerTests.txt", new String []{TestContext.CurrentContext.Test.FullName,
                TestContext.CurrentContext.Result.Outcome.ToString() });
        }
    }
}