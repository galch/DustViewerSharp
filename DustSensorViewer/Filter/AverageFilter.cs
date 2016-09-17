using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustSensorViewer.Filter
{
    class AverageFilter
    {
        private List<double> data;
        private int filterSize;
        private double currentAverage;

        public double CurrentAverage
        {
            get
            {
                return currentAverage;
            }
        }

        public AverageFilter(int size)
        {
            this.data = new List<double>(size);
            this.filterSize = size;
        }

        private bool isFirst = true;

        public void initialize(double input)
        {
            double temp = input / (double)filterSize;
            data.AddRange(Enumerable.Repeat(temp, filterSize).ToList());
            currentAverage = input;
        }

        public double insert(double input)
        {
            if(isFirst)
            {
                initialize(input);
                isFirst = false;
            }
            double temp = input / (double)filterSize;

            data.Add(temp);
            currentAverage += temp;
            currentAverage -= data.ElementAt(0);
            data.RemoveAt(0);

            return currentAverage;
        }
    }
}
