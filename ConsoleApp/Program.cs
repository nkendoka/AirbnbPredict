using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML.Calibrators;
using Microsoft.ML.Runtime;
using System;
using Microsoft.ML;

namespace AirBnbPredict
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new LearningPipeline();
            pipeline.Add(new TextLoader("airbnb.csv").CreateFrom<InputData>(useHeader: true, separator: ','));
            pipeline.Add(new ColumnConcatenator("Features", "latitude", "longitude"));
            pipeline.Add(new GeneralizedAdditiveModelRegressor());

            var model = pipeline.Train<InputData, PredictData>();
            var testData = new TextLoader("airbnb-test.csv").CreateFrom<InputData>(useHeader: true, separator: ',');
            var evaluator = new RegressionEvaluator();

            var metrics = evaluator.Evaluate(model, testData);

            var prediction = model.Predict(new InputData() { latitude = 43.70318221f, longitude = -79.29790942f });//43.70318221,-79.29790942,125

            Console.WriteLine(metrics.RSquared);
            Console.WriteLine(prediction.price);

            Console.ReadLine();
        }
    }
}
