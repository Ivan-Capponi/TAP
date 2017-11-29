using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using static Lab05.Lab05;

namespace Lab05Tests
{
    [TestClass]
    public class Lab05Tests
    {
        [TestMethod]
        public void MacroExpansion_Null_Params_OrignalSequence()
        {
            Assert.That(() => MacroExpansion(null, 3, new [] {1,2,3}), Throws.TypeOf<ArgumentNullException>());
        }

        [TestMethod]
        public void MacroExpansion_Null_Params_NewSequence()
        {
            Assert.That(() => MacroExpansion(new [] {1,2,3}, 3, null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestMethod]
        public void MacroExpansion_Success_Swapping_1_With_4_5_6()
        {
            IEnumerable<int> enumerable = new[] {1,2,3};
            Assert.That(MacroExpansion(enumerable, 1, new [] {4,5,6}), Is.EqualTo(new [] {4,5,6,2,3}));
        }

        [TestMethod]
        public void MacroExpansion_Success_Swapping_Example()
        {
            IEnumerable<int> enumerable = new[] { 1, 2, 1, 2, 3 };
            Assert.That(MacroExpansion(enumerable, 2, new[] { 7, 8, 9 }), Is.EqualTo(new[] { 1,7,8,9,1,7,8,9,3 }));
        }

        [TestMethod]
        public void MacroExpansion_Success_Swapping_Items_With_Null_Values()
        {
            
        }
    }
}
