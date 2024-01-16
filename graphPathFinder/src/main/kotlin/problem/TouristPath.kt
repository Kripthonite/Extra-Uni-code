package problem

import graphCollections.GraphStructure
import java.io.File
import java.io.PrintWriter
import java.util.*

private const val DIR = "src/main/resources/"
private var noNodes=0
private var noArcs=0

fun main(args:Array<String> ) {
    TouristPath(args)
}
fun TouristPath(args:Array<String>, debugg: String? = null) {
    if (args.size != 1) {
        println("Not Enough Arguments")
        return
    }
    var cmd = debugg?.split(' ') ?: readln().split(' ')
    val g = GraphStructure<Int, Int>()
    read(args[0],g)
    while(true){
        if(cmd[0] == "e"){
            println("Exiting program...")
            break
        }
        if(cmd[0] == "path" && cmd.size == 4) {
            val result = findShortestPath(cmd[1].toInt(),cmd[2].toInt(),g)
            writeOutput(cmd[3],cmd[1].toInt(),cmd[2].toInt(),result.first, result.second)
        }
        if (debugg == null)
            cmd =  readln().split(' ')
        else
            break
    }
}

fun  dijkstra(idS : Int , idT : Int , graph: GraphStructure<Int, Int>): Pair<IntArray,Array<Int?>> {
    val visited = BooleanArray(graph.vertices.size+10)
    val dist = IntArray(graph.vertices.size+10){ Int.MAX_VALUE}
    val prev = arrayOfNulls<Int>(graph.vertices.size+10)
    dist[idS]=0
    val q =  PriorityQueue {x: Pair<Int, Int>, y: Pair<Int, Int> -> x.second.compareTo(y.second)}
    q.add(Pair(idS,0))
    while(!q.isEmpty()){
        val pair = q.poll()
        val idx = pair.first
        val minValue = pair.second
        visited[idx]=true
        if(dist[idx] < minValue) continue
        val edges = graph.vertices[idx]!!.edges
        for(adj in edges){
            if(visited[adj.adjacent]) continue
            val newDist = dist[idx] + adj.weight
            if(newDist < dist[adj.adjacent]){
                prev[adj.adjacent]= idx
                dist[adj.adjacent] = newDist
                q.add(Pair(adj.adjacent, newDist))
            }
            if(idx == idT) return Pair(dist , prev)
        }
    }
    return Pair(dist,prev)
}

fun findShortestPath( idS: Int, idT: Int,graph: GraphStructure<Int, Int>): Pair<Int,List<Int>> {
    val pair = dijkstra(idS , idT ,graph)
    val dist = pair.first
    val prev = pair.second
    val path = LinkedList<Int>()
    if(dist[idT]==Int.MAX_VALUE) return Pair(0,path)
    var at = idT
    while(at != idS){
        path.add(at)
        if(prev[at] == null) return Pair(0,emptyList())
        at = prev[at]!!
    }
    path.add(idS)

    return Pair(dist[idT],path.reversed())
}

fun writeOutput(output: String, idStart : Int , idEnd : Int , cost : Int , path : List<Int>){
    val fileName = DIR + output
    val writer = createWriter(fileName)
    if(path.isEmpty()){
        writer.println("Não há caminho entre $idStart e $idEnd ")
    }
    else {
        writer.println("O caminho mais curto entre $idStart e $idEnd tem custo $cost e é:")
        for (v in path) {
            writer.println(v)
        }
    }
    writer.close()
}
fun createWriter(fileName: String) = PrintWriter(fileName)

fun read(file : String,g : GraphStructure<Int, Int>){
    File(DIR + file).forEachLine {
        if(it[0]=='p') {
            val arguments = it.split(" ").toList()
            noNodes = arguments[2].toInt()
            noArcs = arguments[3].toInt()
        }
        if(it[0]=='a'){
            val arguments = it.split(" ").toList()
            g.addVertex(arguments[1].toInt(),arguments[1].toInt())
            g.addVertex(arguments[2].toInt(),arguments[2].toInt())
            g.addEdge(arguments[1].toInt(),arguments[2].toInt(),arguments[3].toInt())
        }
    }
}



