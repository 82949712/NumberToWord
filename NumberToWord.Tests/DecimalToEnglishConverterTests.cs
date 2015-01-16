using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWord.Common;

namespace NumberToWord.Tests
{
    [TestClass]
    public class DecimalToEnglishConverterTests
    {
        [TestMethod]
        public void Convert_IntegerNumber_HundredMultiply()
        {
            var converter = new DecimalToEnglishConverter();
            string result = converter.Convert(200);
            Assert.AreEqual(result, "Two Hundred Dollars");
        }

        [TestMethod]
        public void Convert_IntegerNumber_Hundreds()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(234);
            Assert.AreEqual(result, "Two Hundred and Thirty Four Dollars");
        }

        [TestMethod]
        public void Convert_IntegerNumber_Thousands()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(5234);
            Assert.AreEqual(result, "Five Thousand Two Hundred and Thirty Four Dollars");
        }

        [TestMethod]
        public void Convert_IntegerNumber_OneMillion()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(1000000);
            Assert.AreEqual(result, "One Million Dollars");
        }

        [TestMethod]
        public void Convert_IntegerNumber_Million()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(2505234);
            Assert.AreEqual(result, "Two Million Five Hundred and Five Thousand Two Hundred and Thirty Four Dollars");
        }

        
        [TestMethod]
        public void Convert_IntegerNumber_HundredMillion()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(102505234);
            Assert.AreEqual(result, "One Hundred and Two Million Five Hundred and Five Thousand Two Hundred and Thirty Four Dollars");
        }

        [TestMethod]
        public void Convert_IntegerNumber_OneBillion()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(1000000000);
            Assert.AreEqual(result, "One Billion Dollars");
        }

        [TestMethod]
        public void Convert_IntegerNumber_Billion()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(1342505234);
            Assert.AreEqual(result, "One Billion Three Hundred and Forty Two Million Five Hundred and Five Thousand Two Hundred and Thirty Four Dollars");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Convert_Number_TooLarge()
        {
            var converter = new DecimalToEnglishConverter();
            converter.Convert(2000000001);
        }

        [TestMethod]
        public void Convert_LessThanOne_Cents()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(0.08m);
            Assert.AreEqual(result, "Eight Cents");
        }

        [TestMethod]
        public void Convert_LessThanOne_TenCents_SingleDigit()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(0.8m);
            Assert.AreEqual(result, "Eighty Cents");
        }

        [TestMethod]
        public void Convert_LessThanOne_TenCents_TwoDigits()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(0.85m);
            Assert.AreEqual(result, "Eighty Five Cents");
        }

        [TestMethod]
        public void Convert_LessThanOne_TenCents_ThreeDigits()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(0.825m);
            Assert.AreEqual(result, "Eighty Three Cents");
        }

        [TestMethod]
        public void Convert_Hundreds_WithDecimalPoints()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(234.83m);
            Assert.AreEqual(result, "Two Hundred and Thirty Four Dollars and Eighty Three Cents");
        }

        [TestMethod]
        public void Convert_Thousands_WithDecimalPoints()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(1234.83m);
            Assert.AreEqual(result, "One Thousand Two Hundred and Thirty Four Dollars and Eighty Three Cents");
        }

        [TestMethod]
        public void Convert_Million_WithDecimalPoints()
        {
            var converter = new DecimalToEnglishConverter();
            var result = converter.Convert(2501234.56m);
            Assert.AreEqual(result, "Two Million Five Hundred and One Thousand Two Hundred and Thirty Four Dollars and Fifty Six Cents");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Convert_NegativeNumber()
        {
            var converter = new DecimalToEnglishConverter();
            converter.Convert(-250);
        }

        
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Convert_Zero()
        {
            var converter = new DecimalToEnglishConverter();
            converter.Convert(0);
        }
    }
}
