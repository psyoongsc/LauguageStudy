package BST;

public class BinarySearchTree<E extends Comparable<E>> {
    private TreeNode<E> root;

    public BinarySearchTree() { root = null; }
    public BinarySearchTree(TreeNode<E> root) { this.root = root; }

    public TreeNode<E> getRoot() { return root; }
    public void setRoot(TreeNode<E> root) { this.root = root; }

    public void push(TreeNode<E> newNode) {
        if(root == null) {
            root = newNode;
            return;
        }

        push(root, newNode);
    }
    private void push(TreeNode<E> subRoot, TreeNode<E> newNode) {
        if(subRoot.getItem().compareTo(newNode.getItem()) > 0) {
            if(subRoot.getLeft() == null)
                subRoot.setLeft(newNode);
            else
                push(subRoot.getLeft(), newNode);
        }
        else if(subRoot.getItem().compareTo(newNode.getItem()) < 0) {
            if(subRoot.getRight() == null)
                subRoot.setRight(newNode);
            else
                push(subRoot.getRight(), newNode);
        }
    }

    public int getHeight() {
        if(root == null)
            return 0;
        else
            return getHeight(root, 1);
    }
    public int getHeight(TreeNode<E> subRoot, int depth) {
        if(subRoot.isLeaf()) return depth;
        else {
            return Math.max((subRoot.getLeft() != null) ? getHeight(subRoot.getLeft(), depth+1) : -1
                    , (subRoot.getRight() != null) ? getHeight(subRoot.getRight(), depth+1) : -1);
        }
    }

    public void printTree() {
        Queue<TreeNode<E>> q = new Queue<>();
        q.push(new DoubleLinkNode<>(root));

        TreeNode<E> curNode;
        int height = getHeight();
        for(int i=1, j=1; !q.isEmpty(); i++) {
            curNode = q.pop().getItem();

            if(curNode != null) {
                q.push(new DoubleLinkNode<>(curNode.getLeft()));
                q.push(new DoubleLinkNode<>(curNode.getRight()));
            }
            else {
                q.push(new DoubleLinkNode<>(null));
                q.push(new DoubleLinkNode<>(null));
            }

            if(i == Math.pow(2, j)) {
                System.out.println();
                j++;
                if(j>height) return;
            }

            if(curNode == null)
                System.out.print("x ");
            else
                System.out.print(curNode.getItem() + " ");
        }
    }
}
