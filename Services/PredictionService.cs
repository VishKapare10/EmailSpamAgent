using Microsoft.ML;
using EmailSpamAgent.Models;

namespace EmailSpamAgent.Services
{
    public class PredictionService
    {
        private readonly PredictionEngine<EmailData, EmailPrediction> _predictionEngine;

        public PredictionService()
        {
            MLContext mlContext = new MLContext();

            ITransformer model = mlContext.Model.Load(
                "spamModel.zip",
                out _);

            _predictionEngine =
                mlContext.Model.CreatePredictionEngine
                <EmailData, EmailPrediction>(model);
        }


        public EmailPrediction Predict(string emailText)
        {
            var input = new EmailData
            {
                Text = emailText
            };

            return _predictionEngine.Predict(input);
        }
    }
}