using Microsoft.ML.Data;

namespace EmailSpamAgent.Models
{
	public class EmailPrediction
	{
		[ColumnName("PredictedLabel")]
		public bool IsSpam { get; set; }

		public float Probability { get; set; }

		public float Score { get; set; }
	}
}