using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_AnalysisOfEnvelopes.BL;

namespace Task2_AnalysisOfEnvelopes.Test.BL
{
    [TestClass]
    public class EnvelopeCreatorTest
    {

        [TestMethod]
        public void CreateEnvelope_MinusValue_Null()
        {
            double side1 = -1;
            double side2 = -2;

            EnvelopeCreator eCreator = new EnvelopeCreator();

            Envelope envelope = eCreator.CreateEnvelope(side1, side2);

            Assert.IsNull(envelope);
        }

        [TestMethod]
        public void CreateEnvelope_NullValue_Null()
        {
            double side1 = 22;
            double side2 = 0;

            EnvelopeCreator eCreator = new EnvelopeCreator();

            Envelope envelope = eCreator.CreateEnvelope(side1, side2);

            Assert.IsNull(envelope);
        }

        [TestMethod]
        public void CreateEnvelope_ValidData_OK()
        {
            double side1 = 25.5;
            double side2 = 22.5;

            EnvelopeCreator eCreator = new EnvelopeCreator();

            Envelope envelope = eCreator.CreateEnvelope(side1, side2);


            Assert.AreEqual(envelope.Height, side1);
            Assert.AreEqual(envelope.Width, side2);
        }

    }
}
