using EmailSpamAgent.Models;
using EmailSpamAgent.Services;

Console.WriteLine("Email Spam Detection Agent");
Console.WriteLine("--------------------------");

PredictionService predictionService = new PredictionService();

Console.Write("Enter an email: ");

string email = Console.ReadLine() ?? "";

EmailPrediction result = predictionService.Predict(email);

Console.WriteLine();

if (result.IsSpam)
{
    Console.WriteLine("Result: SPAM");
}
else
{
    Console.WriteLine("Result: NOT SPAM");
}

Console.WriteLine($"Confidence: {result.Probability:P}");