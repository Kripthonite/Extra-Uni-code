package graphCollections
import java.util.LinkedList

class GraphStructure<I, D>: Graph<I, D> {
    class Vertex<I,D>(override val id: I, override var data : D) : Graph.Vertex<I, D> {
        var edges = LinkedList<Edge<I>>()
        override fun getAdjacencies(): MutableSet<Graph.Edge<I>?> = edges.toMutableSet()
        override fun setData(newData: D): D {
            this.data = newData
            return newData
        }
    }

    class Edge<I>(override val id: I,override val adjacent: I,override val weight: Int) : Graph.Edge<I>

    val vertices : HashMap<I, Vertex<I, D>> = HashMap()

    override val size: Int
        get() = vertices.size

    override fun addVertex(id: I, d: D): D? {
        if(vertices.containsKey(id))return null
        vertices[id] = Vertex(id, d)
        return d
    }
    override fun addEdge(id: I, idAdj: I, w: Int): I? {
        val v = getVertex(id) ?: return null

        v.edges.add(Edge(id,idAdj,w))
        return idAdj
    }
    override fun getVertex(id: I): Vertex<I, D>? {
        if (vertices.containsKey(id))
            return vertices[id]
        return null
    }
    override fun getEdge(id: I, idAdj: I): Edge<I>? {
        val v = getVertex(id) ?: return null
        for(e in v.edges) {
            if(e.adjacent == idAdj) return e
        }
        return null
    }
    override fun iterator(): Iterator<Graph.Vertex<I, D>> {
        return object : Iterator<Graph.Vertex<I, D>> {
            private val iterator = vertices.values.iterator()

            override fun hasNext(): Boolean {
                return iterator.hasNext()
            }

            override fun next(): Graph.Vertex<I, D> {
                return iterator.next()
            }
        }
    }

    override fun toString(): String {
        var s=""
        for(v in vertices){
            s +=  "${v.key} -> ["
            val size = v.value.edges.size -1
            var count = 0
            for(e in v.value.edges){
                s += if(count != size){
                    "(${e.id},${e.adjacent}), "
                }else{
                    "(${e.id},${e.adjacent})"
                }
                count++
            }
            s += "]\n"
        }
        return s
    }
}