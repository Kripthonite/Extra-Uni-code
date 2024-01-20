import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

class CountMultiplesTest {

val CMP_NATURAL_ORDER = { i1: Int, i2: Int -> i1.compareTo(i2) }

    @Test
    fun countMultiples_empty_tree() {
        val tree = emptyBST()
        assertEquals(0, countMultiples(tree, 2))
    }

    @Test
    fun countMultiples_singleNodeBST() {
        val tree = singleNodeBST(10)
        assertEquals(1, countMultiples(tree, 2))
        assertEquals(0, countMultiples(tree, 3))
    }

    @Test
    fun countMultiples_someMultiples() {
        val tree = populatedBST(intArrayOf(30,10,5,12,4,3,11,40,50))
        assertEquals(6, countMultiples(tree, 2))
        assertEquals(3, countMultiples(tree, 3))
    }

    @Test
    fun countMultiples_allMultiples() {
        val tree = populatedBST(intArrayOf(10,5,15,20,25,40,50))
        assertEquals(7, countMultiples(tree, 5))
        assertEquals(0, countMultiples(tree, 6))
    }
}