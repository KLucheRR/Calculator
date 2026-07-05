using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Calculator.Tests
{
    [TestClass]
    public class WebTests
    {
        const string SERVER_URL = "https://localhost:7183";
        [TestMethod]
        [DataRow(new double[2] { 5, 6 }, 0, 11)]
        [DataRow(new double[2] { 5, 6 }, 1, -1)]
        [DataRow(new double[2] { 2, 2 }, 2, 4)]
        [DataRow(new double[2] { 12, 4 }, 3, 3)]
        public async Task WebSumTest(double[] args, int type, double expectedResult)
        {            
            var client = new HttpClient();
            var requestData = new { Args = args, Type = type };
            var json = System.Text.Json.JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");                     
            var result = await client.PostAsync($"{SERVER_URL}/Calculator/Calculate", content);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var responseJson = await result.Content.ReadAsStringAsync();
            var result2 = System.Text.Json.JsonSerializer.Deserialize<double>(responseJson);
            Assert.AreEqual(expectedResult, result2);  
            client.Dispose();
        }
    }
}
