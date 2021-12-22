using Azure.Core;
using Azure.Identity;
using CsvHelper;
using Microsoft.Rest;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace APIMReporting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello API Management Reporting!");
            string tenantId = "ENTERTENANTID";
          
            var subscriptionId = "SUBSCRIPTIONID";
            var rgname = "RESOURCEGROUPNAME";
            var apiServiceName = "APISERVICENAME";
            var top = 20000;
            var skip = 0;
            var count = 20000;
            var start = "2017-06-01";
            var end = "2022-06-04";
            //   might need this for VS
            //   TokenCredential tokenCredential = new VisualStudioCredential(new VisualStudioCredentialOptions { TenantId = tenantId });
            TokenCredential tokenCredential = new DefaultAzureCredential();

            //  DefaultAzureCredential
            TokenRequestContext requestContext = new TokenRequestContext(new string[] { "https://management.azure.com" });
            CancellationTokenSource cts = new CancellationTokenSource();
            var accessToken = tokenCredential.GetToken(requestContext, cts.Token);
            Console.WriteLine("Token: " + accessToken.Token);


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
            using (var writer = new StreamWriter(@"c:\PlayArea\file3.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            { 
                while (count==20000)
            {



                string url = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{rgname}/providers/Microsoft.ApiManagement/service/{apiServiceName}/reports/byRequest?$filter=timestamp ge datetime'{start}' and timestamp le datetime'{end}'&api-version=2021-08-01&$top={top}&$skip={skip}";
//                    string url = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{rgname}/providers/Microsoft.ApiManagement/service/{apiServiceName}/reports/byRequest?$filter=timestamp ge datetime'2017-06-01' and timestamp le datetime'2022-06-04'&api-version=2021-08-01&$top={top}&$skip={skip}";

                Console.WriteLine(url);
                Console.WriteLine();

                string json = await client.GetStringAsync(url);

                Rootobject data = JsonSerializer.Deserialize<Rootobject>(json);
                count = data.count;
                Console.WriteLine("count:" + count);
                skip = skip + 20000;
                csv.WriteRecords(data.value);
    
                }
            }

        }
    }
}
