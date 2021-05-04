package BST;

public class Queue<E extends Comparable<E>> {
    private DoubleLinkNode<E> head;
    private DoubleLinkNode<E> tail;

    public Queue() { head = null; tail = null; }
    public Queue(DoubleLinkNode<E> head, DoubleLinkNode<E> tail) { this.head = head; this.tail = tail; }

    public void push(DoubleLinkNode<E> newNode) {
        if(isEmpty()) {
            head = new DoubleLinkNode<>(newNode.getItem(), null, null);
            tail = head;
        }
        else {
            head = new DoubleLinkNode<>(newNode.getItem(), null, head);
            head.getBack().setFront(head);
        }
    }
    public DoubleLinkNode<E> pop() {
        if(!isEmpty()) {
            DoubleLinkNode<E> tmpNode = tail;

            tail = tail.getFront();
            if(!isEmpty())
                tail.setBack(null);

            return tmpNode;
        }
        else
            return null;
    }

    public boolean isEmpty() {
        return (tail == null);
    }

    public void print() {
        if(!isEmpty()) {
            System.out.print(" | ");
            for (DoubleLinkNode<E> curNode = head; curNode != null; curNode = curNode.getBack()) {
                System.out.print(curNode.getItem() + " | ");
            }
            System.out.println();
        }
        else {
            System.out.println(" Error> Queue is Empty!");
        }
    }
}
