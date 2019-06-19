using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBnbPredict
{
    public class InputData
    {
        [Column("0")]
        public float latitude;
        [Column("1")]
        public float longitude;
        [Column("2", name:"Label")]
        public float price;
    }
}
