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
        
        //risk variabel 1
        public Dictionary<string, RiskField> ClienteRisks = new Dictionary<string, RiskField>(); 
        public Dictionary<string, RiskField> GeoLOcation = new Dictionary<string, RiskField>(); 
        public Dictionary<string, RiskField> ProductService = new Dictionary<string, RiskField>(); 
        public Dictionary<string, RiskField> VinculationChanels = new Dictionary<string, RiskField>(); 
        
        //risk variabel 2
        public Dictionary<string, RiskField> TransactionalRisk = new Dictionary<string, RiskField>();





    }
}
