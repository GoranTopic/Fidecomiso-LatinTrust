using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fidecomiso2
{
    public class RiskAnalysis 
    {
        public string ClientName { get; set; }
        public bool IsJudicial { get; set; } // is a jusdicial or natual client

        double RiskFactorTotal1;
        double RiskFactorTotal2;


        List<RiskField> RiskFactors1 = new List<RiskField>();
        List<RiskField> RiskFactors2 = new List<RiskField>();


        //risk variabel 1
        public Dictionary<string, RiskField> ClienteRisks = new Dictionary<string, RiskField>(); 
        public Dictionary<string, RiskField> GeoLOcation = new Dictionary<string, RiskField>(); 
        public Dictionary<string, RiskField> ProductService = new Dictionary<string, RiskField>(); 
        public Dictionary<string, RiskField> VinculationChanels = new Dictionary<string, RiskField>(); 
        
        //risk variabel 2
        public Dictionary<string, RiskField> TransactionalRisk = new Dictionary<string, RiskField>();

        //chart page object 
        public RiskChart Chart_Page = new RiskChart();

        public void update()
        {
            foreach (var risk in RiskFactors1)
            {
                RiskFactorTotal1 += risk.Risk;
            }
            Chart_Page.RiskPoint.X = RiskFactorTotal1;

            foreach (var risk in RiskFactors2)
            {
                RiskFactorTotal2 += risk.Risk;
            }

            Chart_Page.RiskPoint.X = RiskFactorTotal1;
        }

        public void AddRiskFact1(RiskField field)
        {
            RiskFactors1.Add(field);
            //chart update
        }
        public void AddRiskFact2(RiskField field)
        {

            RiskFactors2.Add(field);
             //chart update 
        }
    }


   
}
