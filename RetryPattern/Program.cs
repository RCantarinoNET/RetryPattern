using System;

namespace RetryPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tentativasMxima = 3;
            var delayOperacao = TimeSpan.FromSeconds(2);
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            RetryHelper.RetryOnException(tentativasMxima, delayOperacao, () =>
            {
                var x = client.GetAsync("XXXXXXXXXXXX");
            });
        }
    }
}