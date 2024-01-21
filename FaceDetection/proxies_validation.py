import random
import threading
import queue
import time
import requests

q = queue.Queue()
valid_proxies= queue.Queue()
site = "https://www.zerozero.pt/"
cropped_site = site.split(".")[1]
user_agents = []


def fillqueue():
    global q
    with open("proxies.txt","r") as f:
        proxies = f.read().split("\n")
        for p in proxies:
            q.put(p)

def check_proxies():
    global q 
    while not q.empty():
        proxy=q.get()
        try:
            res = requests.get(site,headers = {'User-agent': randomizeUserAgent()}, proxies = {"http": proxy ,"https": proxy})

        except:
            continue
        if res.status_code == 200:
            print(proxy)
            valid_proxies.put(proxy)
        
def readUserAgent():
    global user_agents
    # Specify the path to your text file
    file_path = "useragents.txt"
    # Open the file in read mode
    with open(file_path, 'r') as file:
        # Read the entire content of the file
        lines = file.readlines()

    lines = [line.strip() for line in lines]
    user_agents = lines
    

def randomizeUserAgent():
    global user_agents
    num_lines=len(user_agents)
    random_line_index = random.randint(0, num_lines - 1)
    random_line=user_agents[random_line_index]
    return random_line

def WriteToFile():
    global valid_proxies
    global cropped_site
    save_name = cropped_site + "validproxies.txt"
    with open(save_name, "w") as file:
        while not valid_proxies.empty():
            proxy=valid_proxies.get()
            file.write(proxy+"\n")
    print("file saved: "+save_name)

def WriteToArr():
    global valid_proxies
    return list(valid_proxies.queue)
            

        
def thr():
    threads = []
    for _ in range(20):
        t = threading.Thread(target=check_proxies)
        t.start()
        threads.append(t)

    # Wait for all threads to finish
    for thread in threads:
        thread.join()

    # All proxies have been checked
    print("All proxies checked.")

def smth():
    start_time = time.time()  # Record the start time
    print("starting...")
    readUserAgent()
    fillqueue()
    thr()
    WriteToFile()
    end_time = time.time()  # Record the end time
    elapsed_time = end_time - start_time
    print(f"Total time taken: {elapsed_time:.2f} seconds")


smth()



  
