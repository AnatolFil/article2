﻿using System;

namespace article2
{
    class Program
    {
        static void Main(string[] args)
        {
            linkedList2<int> list = new linkedList2<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
            {
                list.add(i % 5);
            }
            list.deleteDoubles();
            for (int i=0;i<10000; i++)
            {
                if (rand.Next(0, 20) > 10)
                    list.add(i%20);
            }
            list.deleteDoubles();
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
