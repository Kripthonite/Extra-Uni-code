import java.util.*

data class Node<E>(var item: E, var left: Node<E>?, var right: Node<E>?)

fun <E> isComplete(root: Node<E>?): Boolean {
    // create a queue for level order traversal
    val q: Queue<Node<E>> = LinkedList()
    var result = Int.MAX_VALUE
    var level = 0

    if (root != null)
        q.add(root)
    // traverse until the queue is empty
    while (!q.isEmpty()) {
        var size = q.size
        level++
        // traverse for complete level
        while (size > 0) {
            val temp = q.remove()
            // check for left child
            temp.left?.let { left ->
                q.add(left)
                // if leaf node
                if (left.left == null && left.right == null) {
                    // if it's first leaf node, then update result
                    if (result == Int.MAX_VALUE)
                        result = level
                    else
                        if (result != level) return false
                }
            }
            // check for right child
            temp.right?.let { right ->
                q.add(right)
                // if leaf node
                if (right.left == null && right.right == null) {
                    // if it's first leaf node, then update result
                    if (result == Int.MAX_VALUE)
                        result = level
                    else
                        if (result != level) return false
                }
            }
            size--
        }
    }
    return true
}

fun <E> isBST(node:Node<E>?, cmp:Comparator<E>):Boolean{
    if(node == null)
        return true

    if (valid(node.left , node.item, cmp,true) && valid(node.right, node.item, cmp,false))
        return isBST(node.left, cmp) && isBST(node.right, cmp)

    return false
}

fun <E> valid(root:Node<E>?, nodeVal: E, cmp: Comparator<E>, lessThan: Boolean): Boolean{
    if (root == null)
        return true
    return if (lessThan) {
        if (cmp.compare(root.item,nodeVal) > 0)
            return false
        valid(root.left, nodeVal, cmp, true) && valid(root.right, nodeVal, cmp, true)
    } else {
        if (cmp.compare(root.item,nodeVal) < 0)
            return false
        valid(root.left, nodeVal, cmp, false) && valid(root.right, nodeVal, cmp, false)
    }
}

fun countMultiples(root: Node<Int>?, k: Int): Int {
    var count = 0
    val queue: Queue<Node<Int>> = LinkedList()

    if(root != null)
        queue.add(root)
    // Do level order traversal using queue.
    while (!queue.isEmpty()) {
        val nodetemp = queue.remove()

        if(nodetemp.item % k == 0)
            count++
        if (nodetemp.left != null)
            queue.add(nodetemp.left)
        if (nodetemp.right != null)
            queue.add(nodetemp.right)
    }
    return count
}