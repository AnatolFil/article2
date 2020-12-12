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
            for (int i = 0; i < 100000000; i++)
            {
                if (rand.Next(0, 20) > 10)
                    list.add(i);
                else
                    list.delete(rand.Next(0, i));
            }
            int coutOfEl = list.countOfElements;
            list.add(11);
            Assert.IsTrue(coutOfEl == list.countOfElements - 1);
            Assert.Pass();
        }
    }
}