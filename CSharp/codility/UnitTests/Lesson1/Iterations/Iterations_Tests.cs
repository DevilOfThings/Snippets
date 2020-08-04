using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeExtensions;
using System;
using System.Diagnostics;
using System.Linq;


namespace codility
{
    // https://app.codility.com/programmers/lessons/1-iterations/binary_gap/
    [TestClass]
    public class IterationsTests
    {
        private static TestContext _testContext;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestMethod]
        [DataRow(9,2)]
        [DataRow(529,4)]
        [DataRow(20,1)]
        [DataRow(32,0)]
        public void BinaryGap_Test(int dec, int expected)
        {
            Console.WriteLine(
                $"TestContext.TestName='{TestContext.TestName}'  static _testContext.TestName='{_testContext.TestName}'");
            var binary = Convert.ToString(dec, 2);
            Assert.AreEqual(binary, dec.dot_ToBinary());

            Console.WriteLine(binary);

            Assert.AreEqual(expected, dec.dot_findMaxBinaryGapInNumber());

            var watch = new Stopwatch();
            watch.Start();
            foreach(var i in Enumerable.Range(1,100000).Select(x=>x))
            {
                var random = new Random().Next();
                //Console.WriteLine($"random: {random} ");
                random.dot_findMaxBinaryGapInNumber();
            }
            
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms with 1st method");

            Assert.AreEqual(expected, dec.dot_findMaxBinaryGapInNumber2());

            watch.Restart();
            foreach(var i in Enumerable.Range(1,100000).Select(x=>x))
            {
                var random = new Random().Next();
                //Console.WriteLine($"random: {random} ");
                random.dot_findMaxBinaryGapInNumber2();
            }
            
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms with 2nd method");


            
        }
    }
}
