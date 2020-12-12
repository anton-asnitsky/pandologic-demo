using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Helpers
{
    public static class EnvironmentTypeHelper
    {
        public static EnvironmentType GetEnvironmentType()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return env switch
            {
                "Production" => EnvironmentType.Production,
                "QA" => EnvironmentType.QA,
                _ => EnvironmentType.Development
            };
        }
    }
}