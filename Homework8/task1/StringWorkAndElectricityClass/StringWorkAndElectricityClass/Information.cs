using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringWorkAndElectricityClass
{
    internal class Information
    {
        private double inputIndecator;
        private double outputIndecator;
        private DateTime date;
        public double InputIndecator 
        {
            get
            { 
                if(!double.TryParse(inputIndecator.ToString(), out inputIndecator))
                {
                    throw new FormatException("inccorect input indecator");
                }
                if(inputIndecator < 0)
                {
                    throw new IndexOutOfRangeException("input date must be more than 0");
                }
                return inputIndecator;
            }
            set
            {
                if(!double.TryParse(inputIndecator.ToString(), out inputIndecator))
                {
                    throw new FormatException("inccorect input indecator");
                }
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("input date must be more than 0");
                }
                inputIndecator = value;
            }
        }
        public double OutputIndecator
        {
            get
            {
                if(!double.TryParse(outputIndecator.ToString(), out outputIndecator))
                {
                    throw new FormatException("inccorect output indecator");
                }
                if (outputIndecator < 0 /*|| outputIndecator<InputIndecator */)
                {
                    throw new IndexOutOfRangeException("output indecator must be more than 0");
                }
                return outputIndecator;
            }
            set
            {
                if (!double.TryParse(outputIndecator.ToString(), out outputIndecator))
                {
                    throw new FormatException("inccorect output indecator");
                }
                if (value < 0/* || value<InputIndecator*/)
                {
                    throw new IndexOutOfRangeException("output indecator must be more than 0");
                }
                outputIndecator = value;
            }
        }


        public DateTime Date 
        {
            get
            {
                if(date == null || !DateTime.TryParse(date.ToString(), out date))
                {
                    throw new InvalidTimeZoneException("inccorect date");
                }
                return date;
            }
        }

        public Information()
        {
            this.InputIndecator = 0;
            this.outputIndecator = 0;
            this.date = new DateTime();
        }
        public Information(double inputIndecator, double outputIndecator, DateTime date)
        {
            this.inputIndecator = inputIndecator;
            this.outputIndecator = outputIndecator;
            this.date = date;
        }

        public Information(double inputIndecator, double outputIndecator, string dateStr)
        {
            this.inputIndecator = inputIndecator;
            this.outputIndecator = outputIndecator;
            var cultureInfo = new CultureInfo("uk-UA");
            this.date = DateTime.Parse(dateStr.Trim(), cultureInfo);
        }

        public override string? ToString()
        {
            string res = String.Format("{0,10} || {1,10} || {2,6}", inputIndecator, outputIndecator, date.Date.ToString("d"));
            return res;
            //return String."{inputIndecator} || {outputIndecator} || {date.Date}";
        }
    }
}
