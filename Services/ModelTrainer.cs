using Microsoft.ML;
using EmailSpamAgent.Models;

namespace EmailSpamAgent.Services
{
    public class ModelTrainer
    {
        private readonly MLContext _mlContext;

        public ModelTrainer()
        {
            _mlContext = new MLContext(seed: 1);
        }

        public void TrainModel()
        {
            Console.WriteLine("Loading training data...");

            IDataView data = _mlContext.Data.LoadFromTextFile<EmailData>(
                path: "Data/emails.csv",
                hasHeader: true,
                separatorChar: ',');

            Console.WriteLine("Creating ML pipeline...");

            var pipeline =
                _mlContext.Transforms.Text.FeaturizeText(
                    outputColumnName: "Features",
                    inputColumnName: nameof(EmailData.Text))
                .Append(
                    _mlContext.BinaryClassification.Trainers
                    .SdcaLogisticRegression(
                        labelColumnName: nameof(EmailData.Label),
                        featureColumnName: "Features"));

            Console.WriteLine("Training model...");

            var model = pipeline.Fit(data);

            Console.WriteLine("Saving model...");

            _mlContext.Model.Save(
                model,
                data.Schema,
                "spamModel.zip");

            Console.WriteLine("Model training completed.");
        }
    }
}