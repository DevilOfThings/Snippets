using System;

namespace Chapter3.StacksAndQueues {

    public class NoSuchElementFoundException : Exception {

    }
    internal class QueueNode<T> {

        public T data;
        public QueueNode<T> next;

        public QueueNode(T data) {
            this.data = data;
        }
    }

    class MyQueue<T> {
        
        private QueueNode<T> first;
        private QueueNode<T> last;

        public void add(T item) {
            QueueNode<T> t = new QueueNode<T>(item);

            if(last != null) {
                last.next = t;
            }

            last = t;
            if(first == null) {
                first = last;
            }
        }

        public T remove() {
            if(first == null) throw new NoSuchElementFoundException();
            T datata = first.data;
            first = first.next;
            if(first ==null) {
                last =null;
            }

            return datata;
        }

        public T peek() {
            if(first ==null) throw new NoSuchElementFoundException();
            return first.data;
        }

        public bool isEmpty() {
            return first ==null;
        }
    }
}