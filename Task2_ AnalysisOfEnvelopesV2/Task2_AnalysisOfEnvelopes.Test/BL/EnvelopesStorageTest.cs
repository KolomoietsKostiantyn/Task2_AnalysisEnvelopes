using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task2_AnalysisOfEnvelopes.BL;
using Task2_AnalysisOfEnvelopes.Intermediate;

namespace Task2_AnalysisOfEnvelopes.Test.BL
{
    [TestClass]
    public class EnvelopesStorageTest
    {

        


        [TestMethod]
        public void AddEnvelope_AddЕhirdEnvelope_False()
        {
            double side1 = 22.5;
            double side2 = 22.5;

            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            eCreator.Setup(x => x.CreateEnvelope(It.IsAny<double>(), It.IsAny<double>())).Returns(() => It.IsAny<Envelope>());

            envelopesStorage.AddEnvelope(side1, side2);
            envelopesStorage.AddEnvelope(side1, side2);
            bool result = envelopesStorage.AddEnvelope(side1, side2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddEnvelope_AddFirstEnvelope_True()
        {
            double side1 = 22.5;
            double side2 = 22.5;

            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            eCreator.Setup(x => x.CreateEnvelope(It.IsAny<double>(), It.IsAny<double>())).Returns(new Envelope(1, 1));

            bool result = envelopesStorage.AddEnvelope(side1, side2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddEnvelope_AddSecondEnvelope_True()
        {
            double side1 = 22.5;
            double side2 = 22.5;

            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            eCreator.Setup(x => x.CreateEnvelope(It.IsAny<double>(), It.IsAny<double>())).Returns(new Envelope(1,1));

            envelopesStorage.AddEnvelope(side1, side2);
            bool result = envelopesStorage.AddEnvelope(side1, side2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanAddMore_OneEnvelopeAdded_True()
        {
            double side1 = 22.5;
            double side2 = 22.5;

            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            eCreator.Setup(x => x.CreateEnvelope(It.IsAny<double>(), It.IsAny<double>())).Returns(() => It.IsAny<Envelope>());
            envelopesStorage.AddEnvelope(side1, side2);

            bool result = envelopesStorage.CanAddMore();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanAddMore_TwoEnvelopeAdded_False()
        {
            double side1 = 22.5;
            double side2 = 22.5;

            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            eCreator.Setup(x => x.CreateEnvelope(It.IsAny<double>(), It.IsAny<double>())).Returns(new Envelope(1, 1));
            envelopesStorage.AddEnvelope(side1, side2);
            envelopesStorage.AddEnvelope(side1, side2);

            bool result = envelopesStorage.CanAddMore();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Result_NoTwoEnvelopesAdded_NotEnoughData()
        {
            CalculatingResult request = CalculatingResult.NotEnoughData;

            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            CalculatingResult result = envelopesStorage.Result();

            Assert.AreEqual(request, result);
        }

        [TestMethod]
        public void Result_FirstBiggerThanSecond_SecondToFirst()
        {

            CalculatingResult request = CalculatingResult.SecondToFirst;
            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            envelopesStorage.Envelope1 = new Envelope(10, 10);
            envelopesStorage.Envelope2 = new Envelope(1, 1);
  
            comparor.Setup(x => x.Compare(It.IsAny<Envelope>(), It.IsAny<Envelope>())).Returns(1);

            CalculatingResult result = envelopesStorage.Result();

            Assert.AreEqual(result, request);
        }

        [TestMethod]
        public void Result_EqualEnvelops_Equal()
        {


            CalculatingResult request = CalculatingResult.Equal;
            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            envelopesStorage.Envelope1 = new Envelope(1, 1);
            envelopesStorage.Envelope2 = new Envelope(1, 1);

            comparor.Setup(x => x.Compare(It.IsAny<Envelope>(), It.IsAny<Envelope>())).Returns(0);

            CalculatingResult result = envelopesStorage.Result();

            Assert.AreEqual(result, request);
        }

        [TestMethod]
        public void Result_SeconBiggerThanFirst_FirstToSecond()
        {

            CalculatingResult request = CalculatingResult.FirstToSecond;
            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            envelopesStorage.Envelope1 = new Envelope(1, 1);
            envelopesStorage.Envelope2 = new Envelope(10, 10);
 
            comparor.Setup(x => x.Compare(It.IsAny<Envelope>(), It.IsAny<Envelope>())).Returns(-1);
            comparor.Setup(x => x.Compare(It.Is<Envelope>(val => val.Equals(envelopesStorage.Envelope2)), It.Is<Envelope>(val => val.Equals(envelopesStorage.Envelope1)))).Returns(1);       

            CalculatingResult result = envelopesStorage.Result();

            Assert.AreEqual(result, request);
        }

        [TestMethod]
        public void Result_NoOneCanBePutToNoOne_NoOne()
        {

            CalculatingResult request = CalculatingResult.NoOne;
            Mock<IEnvelopeCreator> eCreator = new Mock<IEnvelopeCreator>();
            Mock<IComparer<Envelope>> comparor = new Mock<IComparer<Envelope>>();
            EnvelopesStorage envelopesStorage = new EnvelopesStorage(eCreator.Object, comparor.Object);

            envelopesStorage.Envelope1 = new Envelope(2, 2);
            envelopesStorage.Envelope2 = new Envelope(1, 3);

            comparor.Setup(x => x.Compare(It.IsAny<Envelope>(), It.IsAny<Envelope>())).Returns(-1);

            CalculatingResult result = envelopesStorage.Result();

            Assert.AreEqual(result, request);
        }


    }
}
