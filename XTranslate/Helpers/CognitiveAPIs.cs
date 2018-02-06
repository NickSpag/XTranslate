using System;
using System.Security.Cryptography.X509Certificates;
namespace XTranslate
{
    public static class CognitiveAPIs
    {
        private static readonly string version = "v1.0";

        private static readonly string locale = "westcentralus";


        public static string CognitiveServicesUrl(ComputerVisionServiceType type)
        {
            var serviceType = type.AsString();

            if (!String.IsNullOrEmpty(serviceType))
                return $"https://{locale}.api.cognitive.microsoft.com/vision/{version}/{serviceType}";
            else
                return "";
        }

        public static string TranslateURL = "https://api.cognitive.microsoft.com/sts/v1.0";

        public static string TranslatorApi = "https://api.microsofttranslator.com/V2/Http.svc/Translate";

    }
}
