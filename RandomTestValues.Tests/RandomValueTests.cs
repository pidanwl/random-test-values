﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using Should;
using System.Collections.Generic;
using System.Linq;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomValueTests
    {
        [TestMethod]
        public void RandomStringShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomString1 = RandomValue.String();
            var randomString2 = RandomValue.String();

            randomString1.ShouldNotEqual(randomString2);
        }
        
        [TestMethod]
        public void RandomIntShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomInt1 = RandomValue.Int();
            var randomInt2 = RandomValue.Int();

            randomInt1.ShouldNotEqual(randomInt2);
        }

        [TestMethod]
        public void RandomIntShouldNotExceedMaximumValuePassedIn()
        {
            var randomInt = RandomValue.Int(4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void RandomIntShouldReturnAPositiveNumberIfANegativeMaxIsPassedIn()
        {
            var randomInt = RandomValue.Int(-4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void RandomByteShouldReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomBytes = new List<byte>();

            for (int i = 0; i < 20; i++)
            {
                randomBytes.Add(RandomValue.Byte());
            }

            var groupedbytes = randomBytes.GroupBy(x => x);
            groupedbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void RandomByteShouldNotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomValue.Byte(5);

            randomByte.ShouldBeInRange((byte)0, (byte)5);
        }

        [TestMethod]
        public void RandomSbyteShouldReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomSBytes = new List<sbyte>();

            for (int i = 0; i < 20; i++)
            {
                randomSBytes.Add(RandomValue.SByte());
            }

            var groupedSbytes = randomSBytes.GroupBy(x => x);
            groupedSbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void RandomSByteShouldNotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomValue.SByte(3);

            randomByte.ShouldBeInRange((sbyte)0, (sbyte)3);
        }

        [TestMethod]
        public void RandomUIntShouldNotReturnSomethingDifferentWithEachCall()
        {
            var randomUInt1 = RandomValue.UInt();
            var randomUInt2 = RandomValue.UInt();

            randomUInt1.ShouldNotEqual(randomUInt2);
        }

        [TestMethod]
        public void RandomUIntShouldReturnValuesGreaterThanMaxIntSomeTimes()
        {
            var randomUints = new List<uint>();

            for (int i = 0; i < 50; i++)
            {
                randomUints.Add(RandomValue.UInt());
            }

            var uintsLargerThanMaxInt = randomUints.Where(x => x > int.MaxValue);
            uintsLargerThanMaxInt.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomUIntShouldReturnValueWithinTheRangeOf0AndTheMaxValueProvided()
        {
            var randomUint = RandomValue.UInt(23);

            randomUint.ShouldBeInRange((uint)0, (uint)23);
        }

        [TestMethod]
        public void RandomShortShouldReturnAUniqueNumberEachTimeItIsCalled()
        {
            var randomShort1 = RandomValue.Short();
            var randomShort2 = RandomValue.Short();

            randomShort1.ShouldNotEqual(randomShort2);
        }

        [TestMethod]
        public void RandomShortShouldRespectTheMaxValueSupplied()
        {
            var randomShort = RandomValue.Short(12);

            randomShort.ShouldBeInRange((short)0, (short)12);
        }

        [TestMethod]
        public void RandomUShortShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomUShort1 = RandomValue.UShort();
            var randomUShort2 = RandomValue.UShort();

            randomUShort1.ShouldNotEqual(randomUShort2);
        }

        [TestMethod]
        public void RandomLongShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomBrendan1 = RandomValue.Long();
            var randomBrendan2 = RandomValue.Long();

            randomBrendan1.ShouldNotEqual(randomBrendan2);
        }

        [TestMethod]
        public void RandomLongShouldProduceNumbersThatAreLargeThanInts()
        {
            var randomBrendans = new List<long>();

            for (int i = 0; i < 50; i++)
            {
                randomBrendans.Add(RandomValue.Long());
            }

            var brendansLargerThanMaxInt = randomBrendans.Where(x => x > int.MaxValue);
            brendansLargerThanMaxInt.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomLongShouldProduceOnlyPositiveNumbers()
        {
            var randomBrendans = new List<long>();

            for (int i = 0; i < 50; i++)
            {
                randomBrendans.Add(RandomValue.Long());
            }

            var brendansSmallerThan0 = randomBrendans.Where(x => x < 0);
            brendansSmallerThan0.ShouldBeEmpty();
        }

        [TestMethod]
        public void RandomLongShouldRespectTheMaxValueSupplied()
        {
            var randomBrendan = RandomValue.Long(3000);

            randomBrendan.ShouldBeInRange(0, 3000);
        }

        [TestMethod]
        public void RandomULongShouldProductUniqueNumbersEachTimeItIsCalled()
        {
            var randomULong1 = RandomValue.ULong();
            var randomULong2 = RandomValue.ULong();

            randomULong1.ShouldNotEqual(randomULong2); 
        }

        [TestMethod]
        public void RandomULongShouldProduceSomeNumbersLargerThanMaxLong()
        {
            var randomULongs = new List<ulong>();

            for (int i = 0; i < 50; i++)
            {
                randomULongs.Add(RandomValue.ULong());
            }

            var numbersLargerThanMaxLong = randomULongs.Where(x => x > long.MaxValue);
            numbersLargerThanMaxLong.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomULongShouldRespectTheLargestNumberInput()
        {
            var randomULong = RandomValue.ULong(2000);

            randomULong.ShouldBeInRange((ulong)0, (ulong)2000);
        }

        [TestMethod]
        public void RandomFloatShouldProductUniqueValuesEachTimeItIsCalled()
        {
            var randomFloat1 = RandomValue.Float();
            var randomFloat2 = RandomValue.Float();

            randomFloat1.ShouldNotEqual(randomFloat2);
        }
        
        [TestMethod]
        public void RandomDoubleShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDouble1 = RandomValue.Double();
            var randomDouble2 = RandomValue.Double();

            randomDouble1.ShouldNotEqual(randomDouble2);
        }

        [TestMethod]
        public void RandomCharProducesAUniqueValueEachTimeItIsCalled()
        {
            var randomChar1 = RandomValue.Char();
            var randomChar2 = RandomValue.Char();

            randomChar1.ShouldNotEqual(randomChar2);
        }

        [TestMethod]
        public void RandomBoolShouldProduceTrueApprox50PercentOfTheTime()
        {
            var randomBools = new List<bool>();

            for (int i = 0; i < 50; i++)
            {
                randomBools.Add(RandomValue.Bool());
            }

            var listOfTrues = randomBools.Where(x => x == true);

            listOfTrues.Count().ShouldBeInRange(15, 35);
        }

        [TestMethod]
        public void RandomDecimalShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDecimal1 = RandomValue.Decimal();
            var randomDecimal2 = RandomValue.Decimal();

            randomDecimal1.ShouldNotEqual(randomDecimal2);
        }

        [TestMethod]
        public void RandomEnumShouldReturnAnEmumOfTheCorrectType()
        {
            var randomEnum = RandomValue.Enum<TestEnum>();

            randomEnum.ShouldBeType<TestEnum>();
        }

        [TestMethod]
        public void RandomEnumShouldHitAllTheValuesOfTheEnumIfIteratedEnough()
        {
            var randomEnums = new List<TestEnum>();

            for (int i = 0; i < 50; i++)
            {
                randomEnums.Add(RandomValue.Enum<TestEnum>());
            }

            randomEnums.Where(x => x == TestEnum.More).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Most).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostest).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostestest).ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillBePopulated()
        {
            var testClass = RandomValue.Object<TestObject>();

            testClass.RString.ShouldNotBeDefault();
            testClass.RDecimal.ShouldNotBeDefault();
            testClass.RDouble.ShouldNotBeDefault();
            testClass.RInt.ShouldNotBeDefault();
            testClass.RCollection.ShouldNotBeEmpty();
            testClass.RCollection2.ShouldNotBeEmpty();
            testClass.RList.ShouldNotBeEmpty();
            testClass.RList2.ShouldNotBeEmpty();
            testClass.TestObject2.ShouldNotBeDefault();
            testClass.RTestObject2List.ShouldNotBeEmpty();

            Should.Core.Assertions.Assert.True(
                (int) testClass.REnum == (int) TestEnum.More
                || (int) testClass.REnum == (int) TestEnum.Most
                || (int) testClass.REnum == (int) TestEnum.Mostest
                || (int) testClass.REnum == (int) TestEnum.Mostestest);
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillReturnNullForUnDeterminable()
        {
            var testClass = RandomValue.Object<TestObject>();

            testClass.TestObject2.RObject.ShouldBeType<object>();
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentCollectionEachTime()
        {
            var stringCollection1 = RandomValue.Collection<string>();
            var stringCollection2 = RandomValue.Collection<string>();

            var intCollection1 = RandomValue.Collection<int>();
            var intCollection2 = RandomValue.Collection<int>();

            stringCollection1.ShouldNotEqual(stringCollection2);
            intCollection1.ShouldNotEqual(intCollection2);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomCollectionOfTheSpecifiedSize()
        {
            var stringCollection = RandomValue.Collection<string>(25);
            
            stringCollection.Count.ShouldEqual(25);
        }
    }
}