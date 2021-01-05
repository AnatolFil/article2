using System;
using System.Collections;

namespace article2
{
    class Program
    {
        static void Main(string[] args)
        {
            //linkedList2<int> list = new linkedList2<int>();
            //Random rand = new Random(DateTime.Now.Millisecond);
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
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 1000000; i++)
            {
                list.add(i);
            }
            int el = list.findElForOneLinkedListFromEnd_2pointerRealise(0).element;
            el = list.findElForOneLinkedListFromEnd_2pointerRealise(1).element;
            Console.WriteLine("Hello World!");
        }
    }

    public class listElement<T>
    {
        public T element;
        public listElement<T> nextElement;
        public listElement<T> prevElement;
    }
    public class linkedList2<T>
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
