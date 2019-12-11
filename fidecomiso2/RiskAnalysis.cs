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


        private double ClientRisk;
        private double GeoLocRisk;
        private double ProSerRisk;
        private double VinChaRisk;
        private double TransRisk;

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


        private string ToString_Risks(List<RiskField> ListofRisks, double Weight)
        {
            string Str = "";
            double sum = 0;
            foreach (RiskField risk in ListofRisks)
            {
                Str +=  String.Format("   {0,-26}- {1}\n", risk.Name+":", risk.RiskVar);
                sum += (double)risk.RiskVar;
            }
            Str += String.Format("   {0,-26}- {1} ({2}%) = {3}\n\n", "suma:",  sum, (int)(Weight * 100) , sum * Weight) ;
            return Str;
        }

        public override string ToString()
        {
            string des = "";

            des += "---------------\n";
            /* for printing PORPUSES */
            des += "Client Risks:\n";
            des += ToString_Risks(ClientRisks, 0.45);

            des += "Geoloacation:\n";
            des += ToString_Risks(GeoLocRisks, 0.1);

            des += "Product and service:\n";
            des += ToString_Risks(ProSerRisks, 0.35);

            des += "Vinculation Channels:\n";
            des += ToString_Risks(VinChaRisks, 0.1);

            //calcualte the second risk factor
            //calculate the transactional risk with a weight of 100%

            des += "Trans Risk:\n";
            des += ToString_Risks(TransacationalRisks, 1);

            //Debug.WriteLine("X: {0}, y: {1}", TotalRisk1, TotalRisk2);
            return des;
        }
        public void UpdateRisks()
        {

            //Caculate First Risk Factor
            //caculate the clietn risk with a weight of 45%
            ClientRisk = CalcSumRisk(ClientRisks, 0.45);
            //caculate the Geo Location risk with a weight of 10%
            GeoLocRisk = CalcSumRisk(GeoLocRisks, 0.1);
            //caculate the Product and Service risk with a weight of 35%
            ProSerRisk = CalcSumRisk(ProSerRisks, 0.35);
            //caculate the Vinculation Channels risk with a weight of 10%
            VinChaRisk = CalcSumRisk(VinChaRisks, 0.1);





            Debug.WriteLine("-------------");
            Debug.WriteLine("-------------");
            /* DEBUGGING PORPUSES */
            Debug.WriteLine("Client Risks:");
            ToString_Risks(ClientRisks, 0.45);


            Debug.WriteLine("Geoloacation");
            ToString_Risks(GeoLocRisks, 0.1);

            Debug.WriteLine("Product and service");
            ToString_Risks(ProSerRisks, 0.35);

            Debug.WriteLine("Vinculation Channels");
            ToString_Risks(VinChaRisks, 0.1);

            //final risk factor 1
            TotalRisk1 = ClientRisk + GeoLocRisk + ProSerRisk + VinChaRisk;

            //calcualte the second risk factor
            //calculate the transactional risk with a weight of 100%
            TransRisk = CalcSumRisk(TransacationalRisks, 1);

            Debug.WriteLine("Trans Risk: ");
            ToString_Risks(TransacationalRisks, 1);
            //final risk factor 1
            TotalRisk2 = TransRisk;

            Debug.WriteLine("X: {0}, y: {1}", TotalRisk1, TotalRisk2);
            //update chart point 
            Chart_Page.UpdatePoint(TotalRisk1, TotalRisk2);
        }

   }


   
}
