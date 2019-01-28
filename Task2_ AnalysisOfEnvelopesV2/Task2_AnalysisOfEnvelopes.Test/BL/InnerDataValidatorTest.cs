using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_AnalysisOfEnvelopes.BL;

namespace Task2_AnalysisOfEnvelopes.Test.BL
{
    [TestClass]
    public class InnerDataValidatorTest
    {
        private InnerDataValidator _dataValidator;

        [TestInitialize]
        public void Initialize()
        {
            _dataValidator = new InnerDataValidator();
        }

        [TestMethod]
        public void ValidateInputArray_NullReferense_False()
        {
            string[] arr = null;

            bool result = _dataValidator.ValidateInputArray(arr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_OneElementNull_False()
        {
            string[] arr = { "12", "15", null, "30" };

            bool result = _dataValidator.ValidateInputArray(arr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_LenthIsNotFour_False()
        {
            string[] arr = { "12", "15", "30" };

            bool result = _dataValidator.ValidateInputArray(arr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_ValidTata_True()
        {
            string[] arr = { "12", "15", "30", "22" };

            bool result = _dataValidator.ValidateInputArray(arr);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertStringToParam_NullReferense_False()
        {
            string str = null;
            double side;

            bool result = _dataValidator.ConvertStringToParam(str, out side);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertStringToParam_EmptyString_False()
        {
            string str = " ";
            double side;

            bool result = _dataValidator.ConvertStringToParam(str, out side);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertStringToParam_MinusValue_False()
        {
            string str = "-99,3";
            double side;

            bool result = _dataValidator.ConvertStringToParam(str, out side);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertStringToParam_ValidData_True()
        {
            string str = "99,3";
            double side;

            bool result = _dataValidator.ConvertStringToParam(str, out side);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertArrayToParams_NullReferense_False()
        {
            string[] arr = null;

            double envelope1Side1;
            double envelope1Side2;
            double envelope2Side1;
            double envelope2Side2;

            bool result = _dataValidator.ConvertArrayToParams(arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertArrayToParams_OneElementNull_False()
        {
            string[] arr = { "12", "15", null, "30" };

            double envelope1Side1;
            double envelope1Side2;
            double envelope2Side1;
            double envelope2Side2;

            bool result = _dataValidator.ConvertArrayToParams(arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ConvertArrayToParams_LenthIsNotFour_False()
        {
            string[] arr = { "12", "15", "30" };

            double envelope1Side1;
            double envelope1Side2;
            double envelope2Side1;
            double envelope2Side2;

            bool result = _dataValidator.ConvertArrayToParams(arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertArrayToParams_OneElementMinus_False()
        {
            string[] arr = { "12", "15", "30", "-15" };

            double envelope1Side1;
            double envelope1Side2;
            double envelope2Side1;
            double envelope2Side2;

            bool result = _dataValidator.ConvertArrayToParams(arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertArrayToParams_OneElementZero_False()
        {
            string[] arr = { "12", "15", "30", "0" };

            double envelope1Side1;
            double envelope1Side2;
            double envelope2Side1;
            double envelope2Side2;

            bool result = _dataValidator.ConvertArrayToParams(arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConvertArrayToParams_ValidData_True()
        {
            string[] arr = { "12,7", "15,7", "30,7", "50,7" };

            double envelope1Side1;
            double envelope1Side2;
            double envelope2Side1;
            double envelope2Side2;
            double envelope1Side1Required = 12.7;
            double envelope1Side2Required = 15.7;
            double envelope2Side1Required = 30.7;
            double envelope2Side2Required = 50.7;


            bool result = _dataValidator.ConvertArrayToParams(arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2);

            Assert.IsTrue(result);
            Assert.AreEqual(envelope1Side1, envelope1Side1Required);
            Assert.AreEqual(envelope1Side2, envelope1Side2Required);
            Assert.AreEqual(envelope2Side1, envelope2Side1Required);
            Assert.AreEqual(envelope2Side2, envelope2Side2Required);
        }


    }
}
