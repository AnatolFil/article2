﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace article2
{
    class Program
    {
        static void Main(string[] args)
        {
            //linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            //int delitel = 10000 / 2;
            //for (int i = 0; i < 10000; i++)
            //{
            //    list.add(i % delitel);
            //}
            //list.deleteDoubles();
            //for (int i=0;i<10000000; i++)
            //{
            //    if (rand.Next(0, 20) > 10)
            //        list.add(i%20);
            //}
            //list.deleteDoublesHashTb();
            linkedList2<int> list = new linkedList2<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.add(rand.Next(0, 200));
            }
            list.devideListByEl(50);
            for (int i = list.countOfElements - 1; i >=0; i--)
                Console.WriteLine(list.findElForOneLinkedListFromEnd_2pointerRealise(i).element);
        }
    }

    public class listElement<T> where T : IComparable<T>
    {
        public T element;
        public listElement<T> nextElement;
        public listElement<T> prevElement;
        private IComparer<T> comparer;
        public listElement(IComparer<T> defaultComparer)
        {
            if (defaultComparer == null) throw new ArgumentNullException();
            comparer = defaultComparer;
        }
        public listElement() : this(Comparer<T>.Default) { }
    }
    public class linkedList2<T> where T : IComparable<T>
    {
        listElement<T> firstElement;
        listElement<T> lastElement;
        public int countOfElements;

        public linkedList2()
        {
            countOfElements = 0;
        }
        public void add(T element)
        {
            listElement<T> newEl = new listElement<T>();
            newEl.element = element;
            if (countOfElements == 0)
            {
                newEl.nextElement = null;
                newEl.prevElement = null;
                firstElement = newEl;
            } else
            {
                newEl.prevElement = lastElement;
                newEl.nextElement = null;
                lastElement.nextElement = newEl;
            }
            lastElement = newEl;
            countOfElements++;
        }
        public void delete(T element)
        {
            if(countOfElements > 0)
            {
                listElement<T> current = firstElement;
                bool isExist = false;
                
                while (current != null)
                {
                    if (current.element.Equals(element))
                    {
                        isExist = true;
                        break;
                    }
                    if (current.nextElement != null)
                        current = current.nextElement;
                    else
                        break;
                }
                if(isExist)
                {
                    if (current == lastElement)
                    {
                        if(current.prevElement != null)
                            current.prevElement.nextElement = null;
                        lastElement = current.prevElement;
                    }
                    else if (current == firstElement)
                    {
                        current.nextElement.prevElement = null;
                        firstElement = current.nextElement;
                    }
                    else
                    {
                        current.nextElement.prevElement = current.prevElement;
                        current.prevElement.nextElement = current.nextElement;
                    }
                    if (isExist)
                        countOfElements--;
                }   
            } 
        }
        public void delete(listElement<T> element)
        {
            if(countOfElements > 0 && element != null)
            {
                if(element == firstElement)
                {
                    if(element.nextElement != null)
                        element.nextElement.prevElement = null;
                    firstElement = element.nextElement;
                } else if(element == lastElement)
                {
                    if(element.prevElement != null)
                        element.prevElement.nextElement = null;
                    lastElement = element.prevElement;
                } else
                {
                    if(element.nextElement != null)
                        element.nextElement.prevElement = element.prevElement;
                    if(element.prevElement != null)
                        element.prevElement.nextElement = element.nextElement;
                }
                countOfElements--;
            }
        }
        public void deleteDoubles()
        {
            if (countOfElements < 2)
                return;
            listElement<T> current = firstElement;
            while (current != lastElement && current != null)
            {
                listElement<T> compareEl = current;
                while(compareEl != null)
                {
                    if (compareEl.nextElement != null && current.element.Equals(compareEl.nextElement.element))
                    {
                        delete(compareEl.nextElement);
                    }
                    compareEl = compareEl.nextElement;
                }
                current = current.nextElement;
            }
        }
        public void deleteDoublesHashTb()
        {
            if(countOfElements > 1)
            {
                Hashtable hashTb = new Hashtable();
                listElement<T> current = firstElement;
                while(current != null)
                {
                    if (hashTb.Contains(current.element))
                    {
                        delete(current);
                    }
                    else
                        hashTb.Add(current.element, current);
                    current = current.nextElement;
                }
             }
        }
        public listElement<T> findElForOneLinkedListFromEnd(int indexFromEnd)
        {
            if(countOfElements > 0 && countOfElements > indexFromEnd)
            {
                listElement<T> current = firstElement;
                int currentCount = 0;
                while(current != null )
                {
                    if (currentCount == countOfElements - indexFromEnd - 1)
                        return current;
                    currentCount++;
                    current = current.nextElement;
                }
            }
            return null;
        }
        public listElement<T> findElForOneLinkedListFromEnd_2pointerRealise(int indexfromEnd)
        {
            if (countOfElements > indexfromEnd)
            {
                //int ffstPointer = 0;
                //int slowdPointer = 0;
                listElement<T> fastPointerEl = firstElement;
                for (int i = 1; i <= indexfromEnd; i++)
                {
                    fastPointerEl = fastPointerEl.nextElement;
                }
                listElement<T> slowPointerEl = firstElement;
                while(fastPointerEl.nextElement != null)
                {
                    fastPointerEl = fastPointerEl.nextElement;
                    slowPointerEl = slowPointerEl.nextElement;
                }
                return slowPointerEl;
            }
            return null;
        }
        public listElement<T> findElFromEnd_recursiveRealise(int indexFromEnd)
        {
            if(countOfElements > indexFromEnd)
            {
                if(indexFromEnd == countOfElements - 1)
                {
                    return firstElement;
                }
                else
                {
                    listElement<T> result = findElFromEnd_recursiveRealise(indexFromEnd + 1);
                    return result.nextElement;
                }
            }
            return null;
        }

        public void deleteMiddleEl()
        {
            if(countOfElements > 0)
            {
                int ends = countOfElements % 2;
                int indexOfMiddle = 0;
                if(ends > 0)
                {
                    indexOfMiddle = countOfElements / 2;
                }
                else
                {
                    indexOfMiddle = (countOfElements / 2) - 1;
                }
                listElement<T> current = firstElement;
                for(int i=0; i < indexOfMiddle; i++)
                {
                    current = current.nextElement;
                }
                delete(current);
            }
        }
        public void devideListByEl(T devider)
        {
            if(countOfElements > 1)
            {
                listElement<T> current = firstElement.nextElement;
                listElement<T> prev = firstElement;
                while (current != null)
                {
                    if (current.element.CompareTo(devider)<0)
                    {
                        prev.nextElement = current.nextElement;
                        current.nextElement = firstElement;
                        firstElement = current;
                        current = prev.nextElement;
                    }
                    else
                    {
                        prev = current;
                        current = current.nextElement;
                    }
                }
            }
        }
        static public linkedList2<int> add (linkedList2<int> a, linkedList2<int> b)
        {
            linkedList2<int> res = new linkedList2<int>();
            res.add(0);
            listElement<int> currentA = a.firstElement;
            listElement<int> currentB = b.firstElement;
            listElement<int> currentRes = res.firstElement;
            while (currentA != null || currentB != null)
            {
                if (currentB != null && currentA != null)
                {
                    currentRes.element += currentA.element + currentB.element;
                    currentA = currentA.nextElement;
                    currentB = currentB.nextElement;
                    if (currentRes.element >= 10)
                    {
                        res.add(1);
                        int rest = currentRes.element % 10;
                        currentRes.element = rest;
                    }
                    else
                        res.add(0);
                    currentRes = currentRes.nextElement;
                    continue;
                }
                else if (currentA != null)
                {
                    currentRes.element += currentA.element;
                    currentA = currentA.nextElement;
                }   
                else if (currentB != null)
                {
                    currentRes.element += currentB.element;
                    currentB = currentB.nextElement;
                } 
                if(currentA != null || currentB != null)
                    res.add(0);
                currentRes = currentRes.nextElement;
            } 
            return res;
        }
        static public linkedList2<int> addRecursive(linkedList2<int> a, linkedList2<int> b)
        {
            linkedList2<int> res = new linkedList2<int>();
            if (a.countOfElements == 1)
            {
                //if (a.firstElement != null && b.firstElement != null)
                //    res.add(a.firstElement.element + b.firstElement.element);
                //else if (a.firstElement != null)
                //    res.add(a.firstElement.element);
                //else
                //    res.add(b.firstElement.element);
            }
                
            return res;
        }
    }
    public class linkedList <T>
    {
        struct listElement
        {
            public T element;
            public int nextElement;
            public int prevElement;
            public bool isAlive;
        }
        
        private listElement[] mas;
        public int countOfElements;
        private int lastInserted;
        private int firstElement;
        private int nextIndForInsertion;
        private int deletedElement;
        public linkedList()
        {
            mas = new listElement[10];
            countOfElements = 0;
            listElement element = new listElement();
            element.nextElement = 0;
            element.prevElement = 0;
            element.isAlive = false;
            mas[0] = element;
            lastInserted = 0;
            firstElement = -1;
            nextIndForInsertion = 0;
            deletedElement = -1;
        }
        public int getTotalLength()
        {
            return mas.Length;
        }
        public void add(T newElement)
        {
            if (countOfElements >= mas.Length)
            {
                listElement[] newMas = new listElement[mas.Length * 2];
                for (int i = 0; i < mas.Length; i++)
                {
                    newMas[i] = mas[i];
                }
                mas = newMas;
                
            }
            int indPlace = -1;
            if (deletedElement > -1)
            {
                indPlace = deletedElement;
                if (mas[deletedElement].nextElement > -1)
                {
                    deletedElement = mas[deletedElement].nextElement;
                }
                else
                    deletedElement = -1;
            }
            else
            {
                indPlace = nextIndForInsertion;
                nextIndForInsertion++;
            }
                listElement newElem = new listElement();
                newElem.element = newElement;
                newElem.nextElement = -1;
                newElem.prevElement = lastInserted;
                newElem.isAlive = true;
                mas[lastInserted].nextElement = indPlace;
                mas[indPlace] = newElem;
                lastInserted = indPlace;
                countOfElements++;
                if (firstElement == -1)
                {
                    firstElement = indPlace;
                }
        }

        public void delete (int indexOfElement)
        {
            if(indexOfElement < mas.Length && mas[indexOfElement].isAlive == true)
            {
                if(indexOfElement == firstElement)
                {
                    if(mas[indexOfElement].nextElement > 0)
                        mas[mas[indexOfElement].nextElement].prevElement = mas[indexOfElement].nextElement;
                    firstElement = mas[indexOfElement].nextElement;
                } else if(indexOfElement == lastInserted)
                {
                    mas[mas[indexOfElement].prevElement].nextElement = mas[indexOfElement].prevElement;
                    lastInserted = mas[indexOfElement].prevElement;
                } else
                {
                    mas[mas[indexOfElement].nextElement].prevElement = mas[indexOfElement].prevElement;
                    mas[mas[indexOfElement].prevElement].nextElement = mas[indexOfElement].nextElement;
                }
                if (deletedElement == -1)
                {
                    deletedElement = indexOfElement;
                    mas[deletedElement].nextElement = -1;
                }     
                else
                {
                    mas[indexOfElement].nextElement = deletedElement;
                    deletedElement = indexOfElement;
                }
                mas[indexOfElement].isAlive = false;
                countOfElements--;
                //if(countOfElements < mas.Length)
            }
        }

        public T getElement(int indexOfElement)
        {
            if(indexOfElement < mas.Length)
            {
                listElement resElement = mas[indexOfElement];
                return resElement.element;
            }
            return default(T);
        }
    }
    
}
