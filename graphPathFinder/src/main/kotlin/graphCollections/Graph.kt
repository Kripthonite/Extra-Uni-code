package graphCollections

interface Graph<I, D>: Iterable<Graph.Vertex<I, D>> {
    interface Vertex<I, D> {
        val id: I
        val data: D
        fun setData(newData: D): D
        fun getAdjacencies(): MutableSet<Edge<I>?>
    }
    interface Edge<I> {
        val id: I
        val adjacent: I
        val weight:Int

    }
    val size: Int
    fun addVertex(id: I, d: D): D?
    fun addEdge(id: I, idAdj: I, w:Int): I?
    fun getVertex(id: I): Vertex<I, D>?
    fun getEdge(id: I, idAdj: I): Edge<I>?
    override operator fun iterator(): Iterator<Vertex<I, D>>
}


