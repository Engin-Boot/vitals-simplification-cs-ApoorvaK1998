using System;
using System.Diagnostics;

class Checker
{
    static bool bpmchecker(float bpm)
    {
        if (bpm < 70)
            Console.WriteLine("bpm is less");
        if(bpm>150)
            Console.WriteLine("bpm is high");
        else
            Console.WriteLine("bpm is normal");
    }
    static bool spo2checker(float spo2)
    {
        if(spo2<90)
            Console.WriteLine("spo2 level is low");
        else
            Console.WriteLine("spo2 level is normal");

    }
    static bool respratechecker(float respRate)
    {
        if (respRate < 30)
            Console.WriteLine("respiration rate is less");
        if (bpm > 95)
            Console.WriteLine("respiration rate is high");
        else
            Console.WriteLine("respiration rate is normal");
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
        static CheckBPM checkBPM = new CheckBPM();
        static CheckSpo2 checkSpo2 = new CheckSpo2();
        static CheckRespRate checkRespRate = new CheckRespRate();
        static void Main(string[] args)
        {
            Checker checkVitalBpm = new Checker(new CheckVitals(checkBPM.bpmchecker));
            checkVitalBpm.CheckVital(55);

            Checker checkVitalSpo2 = new Checker(new CheckVitals(checkSpo2.spo2checker));
            checkVitalSpo2.CheckVital(99);

            Checker checkVitalRespRate = new Checker(new CheckVitals(checkRespRate.respratechecker));
            checkVitalRespRate.CheckVital(62);
        }
    }


}