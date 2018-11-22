﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    class ListNode
    {
        //automatic read-only property Data
        public object Data { get; set; }

        //automatic property next
        public ListNode Next { get; set; }

        //constructor to create ListNode that refers to dataValue
        //and is last node inList
        public ListNode(object dataValue) : this(dataValue, null) { }

        //constructor to crreate ListNode that refers to dataValue
        //and refers to next ListNode in List
        public ListNode(object dataValue, ListNode nextNode)
        {
            Data = dataValue;
            Next = nextNode;
        }
    }
    
    //class List declaration
    public class List
    {
        private ListNode firstNode;
        private ListNode lastNode;
        private string name;//string like "list" to display

        //constructor empty List with specified name
        public List(string listName)
        {
            name = listName;
            firstNode = lastNode = null;
        }

        //constructor empty List with "List" as its name
        public List() : this("list") { }

        //Insert object at front of List. If List is empty,
        //firstNode and lastNode will refer to same object.
        //otherwise, firstNode refers to new node.
        public void InsertAtFront(object insertItem)
        {
            if(IsEmpty())
            {
                firstNode = lastNode = new ListNode(insertItem);
            }
            else
            {
                firstNode = new ListNode(insertItem, firstNode);
            }
        }

        //Insert object at end of List. If List is empty,
        //firstNode and lastNode will refer top same object.
        //OtherWise, lastNode's next property refers to new node.
        public void InsertAtBack(object insertItem)
        {
            if(IsEmpty())
            {
                firstNode = lastNode = new ListNode(insertItem);
            }
            else
            {
                lastNode = lastNode.Next = new ListNode(insertItem);
            }
        }

        //remove first node from List
        public object RemoveFromBack()
        {
            if(IsEmpty())
            {
                throw new EmptyListException(name);
            }

            object removeItem = firstNode.Data;//retrieve data

            //rest firstNode and lastNode references
            if(firstNode == lastNode)
            {
                firstNode = lastNode = null;
            }
            else
            {
                ListNode current = firstNode;

                //loop whie current.Next is not lastNode
                while(current.Next != lastNode)
                {
                    current = current.Next;//move to next node
                }

                //current is new lastNode
                lastNode = current;
                current.Next = null;
            }

            return removeItem;//return removed data
        }

        //return true of List is empty
        public bool IsEmpty()
        {
            return firstNode == null;
        }

        //ouput List contents
        public void Display()
        {
            if(IsEmpty())
            {
                Console.WriteLine($"Empty {name}");
            }
            else
            {
                Console.Write($"the {name} is: ");

                ListNode current = firstNode;

                //ouput current node data while not at end of list
                while(current != null)
                {
                    Console.Write($"{current.Data}");
                    current = current.Next;
                }

                Console.WriteLine("\n");
            }
        }
    }

    //class EmptyListException declaration
    public class EmptyListException : Exception
    {
        //parameterless constructor
        public EmptyListException() : base("The list is empty") { }

        //one-parameter constructor
        public EmptyListException(string name)
            : base($"The {name} is empty") { }

        //two parameter constructor
        public EmptyListException(string exception, Exception inner)
            : base(exception, inner) {  }
    }
}
