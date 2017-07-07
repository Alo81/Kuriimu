﻿using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Kuriimu.Compression.Huffman;

namespace KuriimuTests
{
    [TestClass]
    public class HuffmanTests
    {
        static void Test(byte[] bytes)
        {
            var bytes2 = Decompress(new MemoryStream(Compress(new MemoryStream(bytes), 8)), 8);
            Assert.IsTrue(bytes.SequenceEqual(bytes2));
        }

        [TestMethod]
        public void AsciiCatTest() => Test(Encoding.ASCII.GetBytes("cat"));

        [TestMethod]
        public void AsciiHelloWorldTest() => Test(Encoding.ASCII.GetBytes("hello world"));

        [TestMethod]
        public void UnicodeCatTest() => Test(Encoding.Unicode.GetBytes("cat"));

        [TestMethod]
        public void UnicodeHelloWorldTest() => Test(Encoding.Unicode.GetBytes("hello world"));

        [TestMethod]
        public void HundredZeroesTest() => Test(new byte[100]);

        [TestMethod] // This test will be much much much more difficult to fix than the ones above
        public void AllBytesTest() => Test(Enumerable.Range(0, 256).Select(n => (byte)n).ToArray());
    }
}
