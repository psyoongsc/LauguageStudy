package BST;

public class Main {

    public static void main(String[] args) {
        // Queue Test
//        Queue<Integer> q = new Queue<>();
//
//        q.push(new DoubleLinkNode<Integer>(1));
//        q.print();
//        q.push(new DoubleLinkNode<Integer>(2));
//        q.print();
//        System.out.println(" OK> Popped Item : " + q.pop().getItem());
//        q.print();
//        System.out.println(" OK> Popped Item : " + q.pop().getItem());
//        q.print();
//        q.push(new DoubleLinkNode<Integer>(3));
//        q.print();

        BinarySearchTree<Integer> bst = new BinarySearchTree<>();

        bst.push(new TreeNode<Integer>(1));
        bst.push(new TreeNode<Integer>(2));
        bst.push(new TreeNode<Integer>(4));
//        bst.push(new TreeNode<Integer>(5));
        bst.push(new TreeNode<Integer>(3));

        System.out.println(bst.getHeight());

        bst.printTree();
    }
}
