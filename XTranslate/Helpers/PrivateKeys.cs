using System;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Dynamic;

namespace XTranslate
{
    public enum ComputerVisionServiceType
    {
        OCR,
        AnalyzeHandwriting,
        ReadHandwriting
    }

    public static partial class Help
    {
        public static class PrivateKeys
        {

            public static readonly string TranslateKey = "880bdd19d8064f40b18ab8067978508b";

            public static readonly string AnalyzeKey = "01371aef575f45bfbe395bccc84d339b";

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
}