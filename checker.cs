using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checker
{

    public class vitalcheck
    {
        internal void bpmchecker(float bpm)
        {
            if (bpm < 70)
                Console.WriteLine("bpm is low");
            if (bpm > 150)
                Console.WriteLine("bpm is high");
            else
                Console.WriteLine("bpm is normal");

        }


        internal void spo2checker(float spo2)
        {
            if (spo2 < 90)
                Console.WriteLine("spo2 level is low");
            else
                Console.WriteLine("spo2 level is normal");

        }

        internal void respratechecker(float respRate)
        {
            if (respRate < 30)
                Console.WriteLine("respiration rate is low");
            if (respRate > 95)
                Console.WriteLine("respiration rate is high");
            else
                Console.WriteLine("respiration rate is normal");
        }
    }
    
    public delegate void CheckVitals(float value);
    public class Checker
    {
        CheckVitals vitals;
        public Checker(CheckVitals vitals)
        {
            this.vitals = vitals;
        }
        public void CheckVital(float value)
        {
            this.vitals.Invoke(value);
        }
    }
    class Program
    {
        static vitalcheck checkBPM = new vitalcheck();
        static vitalcheck checkSpo2 = new vitalcheck();
        static vitalcheck checkRespRate = new vitalcheck();
        static void Main(string[] args)
        {
            Checker checkVitalBpm = new Checker(new CheckVitals(checkBPM.bpmchecker));
            checkVitalBpm.CheckVital(90);

            Checker checkVitalSpo2 = new Checker(new CheckVitals(checkSpo2.spo2checker));
            checkVitalSpo2.CheckVital(69);

            Checker checkVitalRespRate = new Checker(new CheckVitals(checkRespRate.respratechecker));
            checkVitalRespRate.CheckVital(52);
        }
    }



}


