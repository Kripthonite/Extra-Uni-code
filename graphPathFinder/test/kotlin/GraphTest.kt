
import graphCollections.GraphStructure
import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Assertions.assertTrue
import org.junit.jupiter.api.Test

class GraphTest {

    @Test
    fun graph_empty() {
        val graph = GraphStructure<Int, String>()
        assertEquals(0, graph.size)
        assertEquals("", graph.toString())
    }

    @Test
    fun graph_singleton() {
        val graph = GraphStructure<Int, String>()
        graph.addVertex(1, "V1")
        graph.addVertex(1, "V1")
        assertEquals(1, graph.size)
        assertEquals("1 -> []\n", graph.toString())
        assertEquals("V1", graph.getVertex(1)!!.data)
        graph.addEdge(1, 2,0)
        graph.addEdge(1, 3,0)
        assertEquals("1 -> [(1,2), (1,3)]\n", graph.toString())
        assertTrue(graph.getEdge(1, 2) != null)
        assertTrue(graph.getEdge(1, 3) != null)
        graph.addEdge(1, 4,0)
        assertTrue(graph.getEdge(1, 4) != null)
        var count=0
        graph.forEach { count++}
        assertTrue(1==count)
    }

    @Test
    fun graph_equalElements() {
        val graph = GraphStructure<Int, String>()
        val setV: MutableSet<String> = mutableSetOf()
        for (id in 1..4)
            graph.addVertex(id, "V$id")
        assertEquals(4, graph.size)
        for (id in 1..4) for (id2 in 1..4)
            if (id2 != id) graph.addEdge(id, id2,0)
        for (v in graph)
            setV.add(v.data)
        assertEquals(setV, mutableSetOf("V1", "V2", "V3", "V4"))
        for (id in 1..4) {
            val setE: MutableSet<Int> = mutableSetOf()
            for (e in graph.getVertex(id)!!.getAdjacencies())
                setE.add(e!!.adjacent)
            val set2 = mutableSetOf(1, 2, 3, 4)
            set2.remove(id)
            assertEquals(setE, set2)
        }
    }

    @Test
    fun graph_someElements() {
        val graph = GraphStructure<Int, String>()
        for (id in 0..99)
            graph.addVertex(id, "V$id")
        assertEquals(100, graph.size)
        for (id in 0..99) for (id2 in 0..99)
            if (id2 != id) graph.addEdge(id, id2,0)
        for (id in 0..99) for (id2 in 0..99)
            if (id2 != id) graph.addEdge(id, id2,0)
        val setV: MutableSet<String> = mutableSetOf()
        for (id in 0..99) {
            val vertex=graph.getVertex(id)
            if(vertex!=null) setV.add(vertex.data)
        }
        val set: MutableSet<String> = mutableSetOf()
        for (id in 0..99)
            set.add("V$id")
        assertEquals(setV, set)
    }
}