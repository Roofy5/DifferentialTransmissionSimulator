using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DifferentialTransmissionSimulator.Model.BitsTranslator;
using System.Linq;

namespace Tests.ModelTests
{
    /// <summary>
    /// Summary description for SingleByteTranslator
    /// </summary>
    [TestClass]
    public class SingleByteTranslatorTests
    {
        private int[] _translatedA = { 0, 1, 0, 0, 0, 0, 0, 1 };
        private int[] _translatedA_pl = { 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 };
        private int[] _translatedm = { 0, 1, 1, 0, 1, 1, 0, 1 };
        public SingleByteTranslatorTests()
        {
        }


        [TestMethod]
        public void A_Translate_Should_Be_01000001()
        { 
            ITranslator sut = new AsciiTranslator();
            var test = sut.ToBits("A");
            Assert.IsTrue(test.SequenceEqual(_translatedA));
        }
        [TestMethod]
        public void A_Translate_Should_Be_01000001_Back()
        {
            ITranslator sut = new AsciiTranslator();
            var test = sut.FromBits(_translatedA);
            Assert.IsTrue(test.Equals("A"));
        }
        [TestMethod]
        public void A_pl_Translate_Should_Be_1100010010000100()
        {
            ITranslator sut = new Utf8Translator();
            var test = sut.ToBits("Ą");
            Assert.IsTrue(test.SequenceEqual(_translatedA_pl));
        }
        [TestMethod]
        public void m_Translate_Should_Be_01101101()
        {
            ITranslator sut = new AsciiTranslator();
            var test = sut.ToBits("m");
            Assert.IsTrue(test.SequenceEqual(_translatedm));
        }
        [TestMethod]
        public void m_Translate_Should_Be_01101101_Back()
        {
            ITranslator sut = new AsciiTranslator();
            var test = sut.FromBits(_translatedm);
            Assert.IsTrue(test.Equals("m"));
        }
    }
}
