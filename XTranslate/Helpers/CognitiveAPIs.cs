using System;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
namespace XTranslate
{
    public static partial class Help
    {
        public static class CognitiveAPIs
        {
            private static readonly string version = "v1.0";

            private static readonly string locale = "westcentralus";


            public static string CognitiveServicesUrl(ComputerVisionService type)
            {
                var serviceType = type.AsString();

                if (!String.IsNullOrEmpty(serviceType))
                    return $"https://{locale}.api.cognitive.microsoft.com/vision/{version}/{serviceType}";
                else
                    return "";
            }

            public static string TranslateURL = "https://api.cognitive.microsoft.com/sts/v1.0";

            public static string TranslatorApi = "https://api.microsofttranslator.com/V2/Http.svc/Translate";


            private static HttpClient _analyzeAPIClient;
            public static HttpClient AnalyzeAPIClient
            {
                get
                {
                    if (_analyzeAPIClient == null)
                    {
                        _analyzeAPIClient = new HttpClient();
                        _analyzeAPIClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Help.PrivateKeys.AnalyzeKey);
                    }

                    return _analyzeAPIClient;
                }
            }

            private static HttpClient _translateAPIClient;
            public static HttpClient TranslateAPIClient
            {
                get
                {
                    if (_translateAPIClient == null)
                    {
                        _translateAPIClient = new HttpClient();
                        _translateAPIClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Help.PrivateKeys.TranslateKey);
                    }

                    return _analyzeAPIClient;
                }
            }
        }
    }
}