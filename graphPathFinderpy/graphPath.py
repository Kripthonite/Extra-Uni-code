from collections import defaultdict, deque
import numpy as np
import pymongo
from queue import PriorityQueue




myclient = pymongo.MongoClient("mongodb://localhost:27017/")
noNodes = 0
noEdges = 0

DIR = "resources/"


class Edge:
    def __init__(self, dst, weight):
        self.dst = dst
        self.weight = weight

def connectDB():
    
    mydb = myclient["PathFinder"]
    return mydb        

def insertDocument(col , src , dst , cost , path):
    document = {
    'src': src,
    'dst': dst,
    'cost': cost,
    'path': path
}
    col.insert_one(document) 



   


def tourist_path():
    
    graph = defaultdict(list)

    while True:
        cmd = input().split()
        if cmd[0] == "e":
            print("Exiting program...")
            break

        if cmd[0] == "path" and len(cmd) == 5:
            #TODO memoization with mongodb
            mydb = connectDB()
            mycol = mydb[cmd[1]]
            myquery = { "src": int(cmd[2]) , "dst": int(cmd[3])}
            data = mycol.find_one(myquery,{ "_id": 0 })
            
            if not data: #se não encontrar na base de dados quanto ao ponto de saída e chegada
                read(cmd[1], graph)
                result = find_shortest_path(int(cmd[2]), int(cmd[3]), graph,mycol)
                write_output(cmd[4], int(cmd[2]), int(cmd[3]), result[0], result[1])
                insertDocument(mycol,int(cmd[2]),int(cmd[3]),result[0],result[1])#escrever documento na db
                print("Guardado na DB")
                
            else:
                cost_value = data.get('cost', None)
                path = data.get('path',None)
                write_output(cmd[4], int(cmd[2]), int(cmd[3]), cost_value, path)
                print("Escrito pela DB")
           

        else:
            break

    myclient.close()

       


# Program to read the entire file using read() function and populating graph.
def read(p, g):
    file_name = DIR + p
    file = open(file_name, "r")
    lines = file.readlines()
    for line in lines:
        if line[0] == 'p':
            arguments = line.split(" ")
            noNodes = int(arguments[2])
            noEdges = int(arguments[3])
        if line[0] == 'a':
            arguments = line.split(" ")
            src = int(arguments[1])
            dst = int(arguments[2])
            weight = int(arguments[3])
            edge = Edge(dst, weight)
            g[src].append(edge)


    # print(graph.keys())
    file.close()

    ############################


def write_output(output, id_start, id_end, cost, path):
    file_name = DIR + output
    with open(file_name, 'w') as writer:
        if not path:
            writer.write(f"Não há caminho entre {id_start} e {id_end}\n")
        else:
            writer.write(f"O caminho mais curto entre {id_start} e {id_end} tem custo {cost} e é:\n")
            for v in path:
                writer.write(f"{v}\n")

### TODO , create documents for path between src and dst with respective weights and paths.
def dijkstra(id_s, id_t, graph,collection):
    visited = [False] * (len(graph) + 10)
    dist = [float('inf')] * (len(graph) + 10)
    prev = [None] * (len(graph) + 10)

    dist[id_s] = 0
    q = PriorityQueue()

    q.put((id_s, 0))

    while not q.empty():
        idx, min_value = q.get()

        if visited[idx] or dist[idx] < min_value:
            continue

        visited[idx] = True

        edges = graph[idx]

        for adj in edges:
            if visited[adj.dst]:
                continue

            new_dist = dist[idx] + adj.weight

            if new_dist < dist[adj.dst]:
                prev[adj.dst] = idx
                dist[adj.dst] = new_dist
                q.put((adj.dst, new_dist))
                insertDocument(collection, id_s, adj.dst, new_dist, path_to_node(prev, id_s, adj.dst))



            if idx == id_t:
                return dist, prev

    return dist, prev


def find_shortest_path(id_s, id_t, graph,collection):
    pair = dijkstra(id_s, id_t, graph,collection)
    dist, prev = pair
    path = deque()

    if dist[id_t] == float('inf'):
        return 0, list(path)

    at = id_t
    while at != id_s:
        path.append(at)
        if prev[at] is None:
            return 0, []
        at = prev[at]

    path.append(id_s)
   

    return dist[id_t], list(reversed(path))

def path_to_node(prev, start, end):
    # Helper function to extract the path from the source to the destination node
    path = deque()
    at = end
    while at != start:
        path.append(at)
        if prev[at] is None:
            return []  # No path found
        at = prev[at]
    path.append(start)
    return list(reversed(path))


if __name__ == "__main__":
    tourist_path()
