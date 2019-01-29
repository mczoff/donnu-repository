using NUnit.Framework;
using ProductionCode1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode.NUnitTests
{
    [TestFixture]
    public class ArrayProcessorTests
    {
        [Test]
        public void SortAndFilterThrowArgumentNullException()
        {
            ArrayProcessor arrayProcessor = new ArrayProcessor();

            Assert.Throws<ArgumentNullException>(() => 
            {
                arrayProcessor.SortAndFilter(null);
            });
        }

        [Test]
        public void SortAndFilterTestArray()
        {
            int[] array = new[] { 1222, 9999, -2323, 299, 1, 5, 1999, 2000 };
            ArrayProcessor arrayProcessor = new ArrayProcessor();

            int[] resultArray = arrayProcessor.SortAndFilter(array);

            CollectionAssert.AreEqual(resultArray, new[] { 1222, 1999, 2000, 9999});
        }

        [Test]
        public void SortAndFilterNotChangeSourceArray()
        {
            int[] array = new[] { 1222, 9999, -2323, 299, 1, 5, 1999, 2000 };
            int[] tmpArray = array.ToArray();

            ArrayProcessor arrayProcessor = new ArrayProcessor();

            arrayProcessor.SortAndFilter(array);

            CollectionAssert.AreEqual(array, tmpArray);
        }
    }
}
