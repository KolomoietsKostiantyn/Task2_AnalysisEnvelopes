using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_AnalysisOfEnvelopes.BL;

namespace Task2_AnalysisOfEnvelopes.Test.BL
{
    [TestClass]
    public class EnvelopeComparerTest
    {
        [TestMethod]
        public void Compare_FirstBigget_1()
        {
            Envelope envelope1 = new Envelope(10.0, 15.0);
            Envelope envelope2 = new Envelope(14.0, 8.0);
            int expected = 1;

            EnvelopeComparer envelopeComparer = new EnvelopeComparer();
            int result = envelopeComparer.Compare(envelope1, envelope2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Compare_Equals_0()
        {
            Envelope envelope1 = new Envelope(10.5, 15.5);
            Envelope envelope2 = new Envelope(15.5, 10.5);
            int expected = 0;

            EnvelopeComparer envelopeComparer = new EnvelopeComparer();
            int result = envelopeComparer.Compare(envelope1, envelope2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Compare_CantBePutIn_Minus1()
        {
            Envelope envelope1 = new Envelope(20.0, 20.0);
            Envelope envelope2 = new Envelope(10.0, 30.0);
            int expected = -1;

            EnvelopeComparer envelopeComparer = new EnvelopeComparer();
            int result = envelopeComparer.Compare(envelope1, envelope2);

            Assert.AreEqual(expected, result);

        }
    }
}
