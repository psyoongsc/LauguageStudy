package BST;

public class Node<E extends Comparable<E>>{
    protected E item;
    private Node<E> next;

    public Node() {
        super();
        item = null;
        next  = null;
    }
    protected Node(E item) {
        super();
        this.item = item;
        this.next = null;
    }
    public Node(E item, Node<E> next) {
        super();
        this.item = item;
        this.next = next;
    }

    public E getItem() { return item; }
    public void setItem(E item) { this.item = item; }
    public Node<E> getNext() { return next; }
    public void setNext(Node<E> next) { this.next = next; }
}
