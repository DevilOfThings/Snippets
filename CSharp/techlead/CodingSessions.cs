using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace techlead
{
    
    [TestClass]
    public class CodingSessions
    {
        // use tuple to find an index using foreach
        //foreach(var (item, index) in magazine.Select((value, i) => (value, i)))
        

        [TestMethod]
        [DataRow("BED", "ABCDEF", true)]
        [DataRow("CAT", "ABCDEF", false)]
        public void RansomNoteTest(string word, string letters, bool isMatching)
        {
            var magazine = letters.ToCharArray().ToList(); 
            Assert.AreEqual(isMatching, magazine.CanSpell(word));            
        }
    }
}
