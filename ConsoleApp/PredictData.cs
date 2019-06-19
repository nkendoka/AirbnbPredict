using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBnbPredict
{
    public class PredictData
    {
        [ColumnName("Score")]
        public float price;
    }
}