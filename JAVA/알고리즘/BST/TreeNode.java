package BST;

public class TreeNode<E extends Comparable<E>> extends Node<E> implements Comparable<TreeNode<E>> {
    private TreeNode<E> left;
    private TreeNode<E> right;

    public TreeNode(E item) {
        this(item, null, null);
    }
    public TreeNode(E item, TreeNode<E> left, TreeNode<E> right) {
        super(item);
        this.left = left; this.right = right;
    }

    public TreeNode<E> getLeft() { return left; }
    public void setLeft(TreeNode<E> left) { this.left = left; }
    public TreeNode<E> getRight() { return right; }
    public void setRight(TreeNode<E> right) { this.right = right; }

    public boolean isLeaf() {
        return left == null && right == null;
    }

    @Override
    public int compareTo(TreeNode<E> o) {
        return super.item.compareTo(o.getItem());
    }
}
