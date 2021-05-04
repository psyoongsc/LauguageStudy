package BST;

public class DoubleLinkNode<E extends Comparable<E>> extends Node<E> {
    DoubleLinkNode<E> front;
    DoubleLinkNode<E> back;

    public DoubleLinkNode() {
        this(null, null, null);
    }
    public DoubleLinkNode(E item) {
        this(item, null, null);
    }
    public DoubleLinkNode(E item, DoubleLinkNode<E> front, DoubleLinkNode<E> back) {
        super(item);
        this.front = front; this.back  = back;
    }

    public DoubleLinkNode<E> getFront() { return front; }
    public void setFront(DoubleLinkNode<E> front) { this.front = front; }
    public DoubleLinkNode<E> getBack() { return back; }
    public void setBack(DoubleLinkNode<E> back) { this.back = back; }
}
