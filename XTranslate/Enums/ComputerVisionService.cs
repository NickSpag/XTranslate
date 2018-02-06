using System;
namespace XTranslate
{
    public static partial class Help
    {
        public static string AsString(this ComputerVisionService type)
        {
            var stringResult = "";

            switch (type)
            {
                case ComputerVisionService.OCR:
                    stringResult = "ocr";
                    break;
                case ComputerVisionService.AnalyzeHandwriting:
                    stringResult = "recognizeText";
                    break;
                case ComputerVisionService.ReadHandwriting:
                    stringResult = "textOperations/";
                    break;
                default:
                    break;
            }

            return stringResult;
        }

    }

    public enum ComputerVisionService
    {
        OCR,
        AnalyzeHandwriting,
        ReadHandwriting
    }
}
