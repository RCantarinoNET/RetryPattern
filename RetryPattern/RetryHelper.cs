using System;
using System.Threading.Tasks;

namespace RetryPattern
{
    public static class RetryHelper
    {
        //private static ILog logger = LogManager.GetLogger();

        public static void RetryOnException(int times, TimeSpan delay, Action operation)
        {
            var tentativa = 0;

            do
            {
                try
                {
                    tentativa++;
                    operation();
                    break;
                }
                catch (Exception)
                {
                    if (tentativa == times)  // fim da execucao baseada na quantidade de tentativas
                        throw;

                    //logger.Error($"tentativa numero {attempts} - tentaremos novamente em {delay}", ex);
                    Task.Delay(delay).Wait();
                }
            } while (true);
        }
    }
}