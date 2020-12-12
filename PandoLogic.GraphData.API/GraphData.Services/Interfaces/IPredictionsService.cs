using System;
using System.Collections.Generic;
using System.Text;

namespace GraphData.Services.Interfaces
{
    public interface IPredictionsService
    {
        int GetPrediction(int views, DateTime date);
    }
}
