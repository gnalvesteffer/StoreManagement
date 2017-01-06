using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagement.Models.Repositories;
using StoreManagement.Models.Data;
using StoreManagement.Models.Utils;

namespace StoreManagement.Tests
{
    [TestClass]
    public class StoreCsvRepositoryTest
    {
        [TestMethod]
        public void SerializeStoresWithCompleteStores()
        {
            StoreCsvSerializationUtil.SerializeStores(
                new Store(1, "Austin", "Jimmy Spunktuni", new DateTime(2017, 1, 6, 8, 30, 0), new DateTime(2017, 1, 6, 16, 30, 0)),
                new Store(2, "Belton", "Harold Gerald", new DateTime(2017, 1, 6, 9, 0, 0), new DateTime(2017, 1, 6, 17, 0, 0)),
                new Store(3, "Killeen", "Ilgor Vychenkovic", new DateTime(2017, 1, 6, 8, 30, 0), new DateTime(2017, 1, 6, 4, 30, 0))
            );
        }

        [TestMethod]
        public void SerializeStoresWithNoArgs()
        {
            StoreCsvSerializationUtil.SerializeStores();
        }

        [TestMethod]
        public void SerializeStoresAndCompareOutput()
        {
            var expected = "1,Austin,Jimmy Spunktuni,08:30AM,04:30PM\r\n";
            var actual = StoreCsvSerializationUtil.SerializeStores(new Store(1, "Austin", "Jimmy Spunktuni", new DateTime(2017, 1, 6, 8, 30, 0), new DateTime(2017, 1, 6, 16, 30, 0)));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerializeStoresWithMissingDataAndCompareOutput()
        {
            var expected = ",Austin,,08:30AM,\r\n";
            var actual = StoreCsvSerializationUtil.SerializeStores(new Store(null, "Austin", null, new DateTime(2017, 1, 6, 8, 30, 0), null));
            Assert.AreEqual(expected, actual);
        }
    }
}
