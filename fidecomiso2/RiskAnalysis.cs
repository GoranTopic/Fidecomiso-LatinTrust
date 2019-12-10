using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace fidecomiso2
{
    public class RiskAnalysis 
    {
        public string ClientName { get; set; }
        public bool IsJudicial { get; set; } // is a jusdicial or natual client

        public double TotalRisk1 { get; set; }
        public double TotalRisk2 { get; set; }



        //risk factor 1
        public List<RiskField> ClientRisks = new List<RiskField>();
        public List<RiskField> GeoLocRisks = new List<RiskField>();
        public List<RiskField> ProSerRisks = new List<RiskField>();
        public List<RiskField> VinChaRisks = new List<RiskField>();
        
        //risk Factor2
        public List<RiskField> TransacationalRisks = new List<RiskField>();

        //chart page object 
        public RiskChart Chart_Page = new RiskChart();


        private double CalcSumRisk(List<RiskField> ListofRisk, double Weight)
        {
            // get the sum of all the values of the risk variable in the risk field and divides it by the Weight
            double RiskSum = 0;
            foreach (RiskField risk in ListofRisk)
            {
                RiskSum += (double)risk.RiskVar;
            }
            return RiskSum * Weight;
        }

        public void UpdateRisks()
        {

            //Caculate First Risk Factor
            //caculate the clietn risk with a weight of 45%
            double ClientRisk = CalcSumRisk(ClientRisks, 0.45);
            //caculate the Geo Location risk with a weight of 10%
            double GeoLocRisk = CalcSumRisk(GeoLocRisks, 0.1);
            //caculate the Product and Service risk with a weight of 35%
            double ProSerRisk = CalcSumRisk(ProSerRisks, 0.35);
            //caculate the Vinculation Channels risk with a weight of 10%
            double VinChaRisk = CalcSumRisk(VinChaRisks, 0.1);


            
            /* DEBUGGING PORPUSES
            Debug.WriteLine("client:{0}", ClientRisk );
            foreach (RiskField risk in ClientRisks)
            {
                Debug.WriteLine("   " + risk.Name);
                Debug.WriteLine("   " + risk.RiskVar);
            }

            Debug.WriteLine("Geo:{0},", GeoLocRisk );
            foreach (RiskField risk in GeoLocRisks) {
                Debug.WriteLine("   " + risk.Name);
                Debug.WriteLine("   " + risk.RiskVar);
            }

            Debug.WriteLine("Proserv:{0},", ProSerRisk );
            foreach (RiskField risk in ProSerRisks) {
                Debug.WriteLine("   " + risk.Name);
                Debug.WriteLine("   " + risk.RiskVar);
            }

            Debug.WriteLine("VincChal:{0},", VinChaRisk );
            foreach (RiskField risk in VinChaRisks) {
                Debug.WriteLine("   " + risk.Name);
                Debug.WriteLine("   " + risk.RiskVar);
            }
            */


            //final risk factor 1
            TotalRisk1 = ClientRisk + GeoLocRisk + ProSerRisk + VinChaRisk;

            //calcualte the second risk factor
            //calculate the transactional risk with a weight of 100%
            double TransRisk = CalcSumRisk(TransacationalRisks, 1);

            //final risk factor 1
            TotalRisk2 = TransRisk;

            //update chart point 
            Chart_Page.UpdatePoint(TotalRisk1, TotalRisk2);
        }

   }


   
}
