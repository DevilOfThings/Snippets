using System;

namespace Chapter2.LinkedLists {
    class Node {
        Node Next;
        int data;

        public Node(int d) {
            data = d;
        }

        void AppendToTail(int d) {
            Node end = new Node(d);

            Node n = this;
            while(n.Next != null) {
                n = n.Next;
            }

            n.Next = end;
        }

        Node deleteNode(Node head, int d) {
            
            if(head ==null) return null;

            Node n = head;

            if(n.data == d) {
                return head.Next;
            }

            while(n.Next !=null) {
                if(n.Next.data == d) {
                    n.Next = n.Next.Next;
                    return head;
                }
                n =n.Next;
            }

            return head;
        }
    }
}