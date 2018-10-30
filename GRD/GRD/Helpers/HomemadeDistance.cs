using Accord.Math.Distances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRD.Helpers
{
    public class HomemadeDistance: IMetric<double[]>
    {
        public double Distance(double[] x, double[] y)
        {
            double distance = 0;
            
            for (int i = 0; i < x.Length; i++)
            {
                distance += Math.Pow((x[i] - y[i]), 2);
            }

            if (distance == 0) return 1 / 0.0001;
            return 1 / (Math.Sqrt(distance));
        }
    }
}
