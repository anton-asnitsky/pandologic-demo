using GraphData.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphData.Services
{
    public class PredictionsService : IPredictionsService
    {
        // Of cause it should some AI or ML based saervice
        // with more intelligent and elegant logic but for 
        // demo assesment purpose I;ll use some fake data
        public int GetPrediction(int views, DateTime date) {
            return views + new Random().Next(0, 15);
        }
    }
}
