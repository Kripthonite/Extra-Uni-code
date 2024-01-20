import org.junit.jupiter.api.Assertions
import org.junit.jupiter.api.Assertions.assertFalse
import org.junit.jupiter.api.Assertions.assertTrue
import org.junit.jupiter.api.Test

class isBSTTest {

    val CMP_NATURAL_ORDER = { i1: Int, i2: Int -> i1.compareTo(i2) }

    @Test
    fun isBST_empty_trees() {
        val tree = emptyBST()
        assertTrue(isBST(tree,CMP_NATURAL_ORDER))
    }

    @Test
    fun isBST_singleNodeBST() {
        var tree = singleNodeBST(10)
        assertTrue(isBST(tree,CMP_NATURAL_ORDER))
        tree = add(tree, 0, CMP_NATURAL_ORDER)
        Assertions.assertEquals(1, height(tree))
        assertTrue(isBST(tree,CMP_NATURAL_ORDER))
        tree.left=Node(20,null,null)
        assertFalse(isBST(tree,CMP_NATURAL_ORDER))
        tree.left=null
        tree = add(tree, 0, CMP_NATURAL_ORDER)
        tree = add(tree, 20, CMP_NATURAL_ORDER)
        Assertions.assertEquals(1, height(tree))
        assertTrue(isBST(tree,CMP_NATURAL_ORDER))
        tree.right=Node(6,null,null)
        assertFalse(isBST(tree,CMP_NATURAL_ORDER))
  }

    @Test
    fun isBST_notBSTLeft() {
        val tree = singleNodeBST(40)
        val left=singleNodeBST(20)
        val right=singleNodeBST(60)
        tree?.let{it.left=left}
        tree?.let{it.right=right}
        left?.left=singleNodeBST(10)
        left?.right=singleNodeBST(50)
        right?.left=singleNodeBST(45)
        right?.right=singleNodeBST(80)
        assertFalse(isBST(tree,CMP_NATURAL_ORDER))
    }

    @Test
    fun isBST_notBSTRight() {
        val tree = singleNodeBST(40)
        val left=singleNodeBST(20)
        val right=singleNodeBST(60)
        tree?.let{it.left=left}
        tree?.let{it.right=right}
        left?.left=singleNodeBST(10)
        left?.right=singleNodeBST(30)
        right?.left=singleNodeBST(35)
        right?.right=singleNodeBST(80)
        assertFalse(isBST(tree,CMP_NATURAL_ORDER))
    }

    @Test
    fun isBST_isBST() {
        val tree = singleNodeBST(40)
        val left=singleNodeBST(20)
        val right=singleNodeBST(60)
        tree?.let{it.left=left}
        tree?.let{it.right=right}
        left?.left=singleNodeBST(10)
        left?.right=singleNodeBST(30)
        right?.left=singleNodeBST(50)
        right?.right=singleNodeBST(80)
        assertTrue(isBST(tree,CMP_NATURAL_ORDER))
    }


}