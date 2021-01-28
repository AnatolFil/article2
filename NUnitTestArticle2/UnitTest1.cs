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
        [Test]
        public void testAddForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            linkedList2<int> b = new linkedList2<int>();
            string strA = "";
            string strB = "";
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i=0;i<rand.Next(5,10);i++)
            {
                int intA = rand.Next(0, 9);
                a.add(intA);
                strA = strA.Insert(0, intA.ToString());
            }
            for (int i = 0; i < rand.Next(5, 10); i++)
            {
                int intB = rand.Next(0, 9);
                b.add(intB);
                strB = strB.Insert(0,intB.ToString());
            }
            linkedList2<int>  res = linkedList2<int>.add(a, b);
            string strRes = "";
            for(int i=0;i<res.countOfElements;i++)
            {
                strRes += res.findElForOneLinkedListFromEnd(i).element;
            }
            int expectdRes = Convert.ToInt32(strA) + Convert.ToInt32(strB);
            int intRes = Convert.ToInt32(strRes);
            Assert.AreEqual(expectdRes, intRes);
        }
        [Test]
        public void testIsPalindromForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenghtMas = 10000000;
            int[] mas = new int[lenghtMas];
            for(int i =0;i< lenghtMas; i++)
            {
                mas[i] = rand.Next();
            }
            for (int i = 0; i < lenghtMas; i++)
                a.add(mas[i]);
            for(int i = lenghtMas-1; i>=0; i--)
            {
                a.add(mas[i]);
            }
            Assert.AreEqual(true, a.isPalindrom());
        }
        [Test]
        public void testIsPalindromStackReleaseForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenghtMas = 10000000;
            int[] mas = new int[lenghtMas];
            for (int i = 0; i < lenghtMas; i++)
            {
                mas[i] = rand.Next();
            }
            for (int i = 0; i < lenghtMas; i++)
                a.add(mas[i]);
            for (int i = lenghtMas - 1; i >= 0; i--)
            {
                a.add(mas[i]);
            }
            Assert.AreEqual(true, a.isPalindromStackRelease());
        }
        [Test]
        public void testisPalindromRecursiveReleaseForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenghtMas = 100;
            int[] mas = new int[lenghtMas];
            for (int i = 0; i < lenghtMas; i++)
            {
                mas[i] = rand.Next();
            }
            for (int i = 0; i < lenghtMas; i++)
                a.add(mas[i]);
            for (int i = lenghtMas - 1; i >=0 ; i--)
            {
                a.add(mas[i]);
            }
            Assert.AreEqual(true, a.isPalindromRecursiveRelease());
        }
        [Test]
        public void testAddListElementForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            linkedList2<int> b = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            
            for (int i = 0; i < 10; i++)
            {
                a.add(i);
            }
            for (int i = 10; i < 15; i++)
            {
                b.add(i);
            }
            b.add(a.findElForOneLinkedListFromEnd_2pointerRealise(5));
            for(int i=0;i<5;i++)
            {
                Assert.AreEqual(9-i, b.findElForOneLinkedListFromEnd_2pointerRealise(i).element);
            }
            
        }
        [Test]
        public void testFindIntersectionForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            linkedList2<int> b = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                a.add(i);
            }
            for (int i = 10; i < 15; i++)
            {
                b.add(i);
            }
            b.add(a.findElForOneLinkedListFromEnd_2pointerRealise(5));
            Assert.AreEqual(a.findElForOneLinkedListFromEnd_2pointerRealise(5), linkedList2<int>.findIntersection(a,b));
        }
        [Test]
        public void testCreateCircleForOneLinkedList2()
        {
            linkedList2<int> a = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                a.add(rand.Next());
            }
            a.createCircle(a.findElForOneLinkedListFromEnd_2pointerRealise(5));
            Assert.AreEqual(a.findElForOneLinkedListFromEnd_2pointerRealise(0).nextElement, a.findElForOneLinkedListFromEnd_2pointerRealise(5));
            Assert.AreEqual(a.findElForOneLinkedListFromEnd_2pointerRealise(0).nextElement.nextElement, a.findElForOneLinkedListFromEnd_2pointerRealise(4));
        }
    }
}