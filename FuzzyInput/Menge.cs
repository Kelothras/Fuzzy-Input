using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.Fuzzy;

namespace FuzzyInput
{
    public class Menge
    {
        public LinguisticVariable linguisticVariable { get; set; }
        public List<FuzzySet> fuzzySets { get; set; }

        public Menge()
        {

        }

        public Menge(LinguisticVariable linguisticVariable)
        {
            this.linguisticVariable = linguisticVariable;
        }

        public void neuesFuzzySet(FuzzySet fuzzySet)
        {
            this.fuzzySets.Add(fuzzySet);
        }

        public void LoeFuzzySet(FuzzySet fuzzySet)
        {
            this.fuzzySets.Remove(fuzzySet);   
        }


    }

    
}
