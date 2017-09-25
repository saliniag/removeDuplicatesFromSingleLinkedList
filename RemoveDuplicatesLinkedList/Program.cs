using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatesLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            // Pushing data in the linked list.
            LinkedList list = new LinkedList();
            list.add(5); list.add(4); list.add(3); list.add(2); list.add(1); list.add(1);

            // Print the original and removed duplicates linked list.
            Console.WriteLine("Original linked list");
            list.print();
            //removeDuplicates(list);
            removeDuplWithoutBuffer(list);

            Console.WriteLine("\n linked list after duplicates removal");
            list.print();
           

        }
        //with a auxillary storage




        static void removeDuplicates(LinkedList list)
        {
            if (list.head == null)
            {
                return;
            }
            else
            {
                HashSet<int> entries = new HashSet<int>();
                Node current = list.head;
                Node prev = null;
                while (current != null)
                {
                    if (entries.Contains(current.data))
                    {
                        prev.next = current.next;
                    }
                    else
                    {
                        entries.Add(current.data);
                        prev = current;
                    }
                    current = current.next;
                }
            }
        }

        //without buffer

        static void removeDuplWithoutBuffer(LinkedList list)
        {
            //keep two pointers 
            //one at fi location other will traverse the list to check for duplicates

            if (list.head == null)
            {
                return;
            }
            else
            {
                Node current = list.head;
                while (current != null)
                {
                    Node iterator = current;
                    while (iterator.next != null)
                    {
                        if (current.data == iterator.next.data)
                        {
                            iterator.next = iterator.next.next;
                        }
                        else
                        {
                            iterator = iterator.next;
                        }
                    }
                    current = current.next;

                }
            }

        }
        //create a single linked list
        class Node
        {
            public int data;
            public Node next, random; //next and random pointers
            public Node(int data)
            {
                this.data = data;
                this.next = null;
                this.random = null;

            }
        }
        class LinkedList
        {
            public Node head;
            //constructor
            public LinkedList()
            {
                this.head = null;

            }
            public LinkedList(Node h)
            {
                this.head = h;
            }

            //add a node
            public void add(int data)
            {
                Node newNode = new Node(data); //create a node
                //check if head is null
                if (this.head == null)
                {
                    this.head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = newNode;
                }
            }
            // Method to print the list.
            public void print()
            {
                Node temp = head;
                while (temp != null)
                {
                    //  Node random = temp.random;
                    //   int randomData = (random != null) ? random.data : -1;
                    Console.WriteLine("Data = " + temp.data);
                    temp = temp.next;
                }
            }
        }
    }
}
