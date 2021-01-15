using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using article2;

namespace NUnitTestArticle2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void linkedListRealise1()
        {
            linkedList<int> list = new linkedList<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10000; i++)
            {
                if (rand.Next(0, 20) > 10)
                    list.add(i);
                else
                    list.delete(rand.Next(0, i));
            }
            int coutOfEl = list.countOfElements;
            list.add(11);
            Assert.IsTrue(coutOfEl == list.countOfElements - 1);
            //Assert.Pass();
        }
        [Test]
        public void testDeleteDoublesInLinkedList2()
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10000; i++)
            {
                list.add(i%(10000 / 2));
            }
            list.deleteDoubles();
            Assert.AreEqual((10000 / 2), list.countOfElements);
        }
        [Test]
        public void testDeleteDoublesHashTbInLinkedList2()
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 1000000; i++)
            {
                list.add(i % (1000000 / 2));
            }
            list.deleteDoublesHashTb();
            Assert.AreEqual((1000000 / 2), list.countOfElements);
        }
        [Test]
        public void testfindElForOneLinkedListFromEnd()
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 1000000; i++)
            {
                list.add(i);
            }
            Assert.AreEqual(999999, list.findElForOneLinkedListFromEnd(0).element);
            Assert.AreEqual(999998, list.findElForOneLinkedListFromEnd(1).element);
            Assert.AreEqual(989999, list.findElForOneLinkedListFromEnd(10000).element);
            Assert.AreEqual(0, list.findElForOneLinkedListFromEnd(999999).element);
            //Assert.AreEqual(null, list.findElForOneLinkedListFromEnd(1000000).element);
        }
        [Test]
        public void testfindElForOneLinkedListFromEnd_2pointerRealise()
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 1000000; i++)
            {
                list.add(i);
            }
            Assert.AreEqual(999999, list.findElForOneLinkedListFromEnd_2pointerRealise(0).element);
            Assert.AreEqual(999998, list.findElForOneLinkedListFromEnd_2pointerRealise(1).element);
            Assert.AreEqual(989999, list.findElForOneLinkedListFromEnd_2pointerRealise(10000).element);
            Assert.AreEqual(0, list.findElForOneLinkedListFromEnd_2pointerRealise(999999).element);
           // Assert.AreEqual(null, list.findElForOneLinkedListFromEnd_2pointerRealise(1000000).element);
        }
        [Test]
        public void testfindElFromEnd_recursiveRealise()
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10000; i++)
            {
                list.add(i);
            }
            Assert.AreEqual(9999, list.findElFromEnd_recursiveRealise(0).element);
            Assert.AreEqual(9998, list.findElFromEnd_recursiveRealise(1).element);
            Assert.AreEqual(9899, list.findElFromEnd_recursiveRealise(100).element);
            Assert.AreEqual(0, list.findElFromEnd_recursiveRealise(9999).element);
            // Assert.AreEqual(null, list.findElForOneLinkedListFromEnd_2pointerRealise(1000000).element);
        }
        [Test]
        public void testDeleteMiddleElForOneLinkedList2()
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            int countOfListEl = 10000;
            for (int i = 0; i < countOfListEl; i++)
            {
                list.add(i);
            }
            list.deleteMiddleEl();
            countOfListEl = list.countOfElements;
            Assert.AreEqual((countOfListEl / 2)+1, list.findElFromEnd_recursiveRealise((countOfListEl/2)).element);
            list.deleteMiddleEl();
            countOfListEl = list.countOfElements;
            Assert.AreEqual((countOfListEl / 2) + 2, list.findElFromEnd_recursiveRealise((countOfListEl / 2)-1).element);
            
            for (int i = 0; i < countOfListEl; i++)
                list.deleteMiddleEl();
            Assert.AreEqual(0, list.countOfElements);
        }
    }
}