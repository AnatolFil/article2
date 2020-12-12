using System;

namespace article2
{
    class Program
    {
        static void Main(string[] args)
        {
            linkedList<int> list = new linkedList<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i=0;i<100000000; i++)
            {
                if (rand.Next(0, 20) > 10)
                    list.add(i);
                else
                    list.delete(rand.Next(0, i));
            }
            for(int i=0;i<list.getTotalLength();i++)
            {
                Console.Write(list.getElement(i) + "  ");
            }
            Console.WriteLine("Hello World!");
        }
    }
    public class linkedList2<T>
    {
        struct listElement<T>
        {
            public T element;
            public listElement<T> nextElement { get; set; }
            public listElement<T> prevElement { get; set; }
        }
        T firstElement;
        T lastElement;
        public int countOfElements;
        public void add(T element)
        {

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
