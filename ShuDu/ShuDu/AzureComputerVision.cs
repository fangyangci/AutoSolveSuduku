using Azure.AI.Vision.ImageAnalysis;
using Azure;

namespace ShuDu
{
    internal class AzureComputerVision
    {
        static string key = "";
        static string endpoint = "";

        public static async Task<ReadResult> AnalyzeImageUrl(BinaryData data)
        {
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
            ImageAnalysisResult result = await client.AnalyzeAsync(data, VisualFeatures.Read);
            return result.Read;
        }
    }
}
