using Azure.AI.Vision.ImageAnalysis;
using Azure;

namespace ShuDu
{
    internal class AzureComputerVision
    {
        static string key = "07dd1bbd28b04e06b6504e0c183483cf";
        static string endpoint = "https://woasishen-cv.cognitiveservices.azure.com/";

        public static async Task<ReadResult> AnalyzeImageUrl(BinaryData data)
        {
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
            ImageAnalysisResult result = await client.AnalyzeAsync(data, VisualFeatures.Read);
            return result.Read;
        }
    }
}
