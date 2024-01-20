import os
import random
import urllib.request
import cv2 as cv
import numpy as np
import requests
from bs4 import BeautifulSoup
import time
from itertools import cycle

# List of proxy URLs
"""proxies = [
    '165.22.36.164:10001',
    '114.129.2.82:8081',
    '119.28.117.127:31280',
    '27.76.101.67:3128',
    '8.212.4.168:8081',
    '117.250.3.58:8080',
    '104.234.157.21:21278',
    '159.65.186.46:10002',
    '104.234.157.9:21278'
] """

# Create a cycle iterator to rotate through proxies
#proxy_pool = cycle(proxies)

url = 'https://www.zerozero.pt/equipa/benfica?search=1'  # Replace with the URL of the webpage you want to inspect
global_session = requests.Session()

def retrievePlayerInfo(url):
    try:
        # Send a GET request and retrieve the HTML content
        #proxy = next(proxy_pool)
        #proxies = { "https": proxy}
        response = global_session.get(url,headers = {'User-agent': randomizeUserAgent()})
        response.raise_for_status()

        # Parse the HTML using BeautifulSoup and lxml parser
        soup = BeautifulSoup(response.text, 'lxml')
        teamsquad_div = soup.find('div',id='team_squad')
        players =  teamsquad_div.find_all('div', class_="staff")
        dicplayers = {}
        for player in players:
            if 'inactive' not in player['class']:
                number = player.find('div', class_='number').text.strip()
                name_div = player.find('div', class_='name')
                player_href = name_div.find('div', class_='text').find('a')['href']
                player_age = name_div.find('span').text.strip()
                player_name = name_div.find('div', class_='text').find('a').text.strip()

                
                
                #print(f"Number: {number}")
                #print(f"Player Name: {player_name}")
                #print(f"Player Age: {player_age}")
                #print(f"Player Href: {player_href}")
                #print(f"\n")
                
                dicplayers[f'{player_name}'] = player_href

            
        return dicplayers

        
        #print(page_main)
    except requests.exceptions.HTTPError as errh:
        print(f"HTTP Error: {errh}")
    except requests.exceptions.ConnectionError as errc:
        print(f"Error Connecting: {errc}")
    except requests.exceptions.Timeout as errt:
        print(f"Timeout Error: {errt}")
    except requests.exceptions.RequestException as err:
        print(f"An error occurred: {err}")

def getPhotos(dicplayers):
    main_url = "https://www.zerozero.pt/foto.php?fk_galeria=0&nchapter=1&tpe=1&ide="
    base_url = "https://www.zerozero.pt"
    for name, href in dicplayers.items():
        
        chopped_url= href.split('/')
        id_string = chopped_url[3].split('?')[0]
        player_photos_url = main_url + id_string
        path_download = createFolder(name,r'G:/benficafotos')
        
        
        
        try:
            # Send a GET request and retrieve the HTML content
            #proxy = next(proxy_pool)
            #proxies = {"http": proxy, "https": proxy}
            response = global_session.get(player_photos_url,headers = {'User-agent': randomizeUserAgent()})
            #response = global_session.get(player_photos_url,headers = {'User-agent': randomizeUserAgent()},proxies=proxies)
            response.raise_for_status()
            

            # Parse the HTML using BeautifulSoup and lxml parser
            soup = BeautifulSoup(response.text, 'lxml')
            #Finding number of photos
            chapter_tag = soup.find('div',class_='slideshow_bar_chapters').text
            chapters= chapter_tag.split('/')
            currentChapter=int(chapters[0])
            nmaxChapters=int(chapters[1])
            while(currentChapter<=nmaxChapters):
                #proxy = next(proxy_pool)
                #proxies = {"http": proxy, "https": proxy}
                link = incChapterlink(player_photos_url,currentChapter)
                response = global_session.get(link,headers = {'User-agent': randomizeUserAgent()})
                #response = global_session.get(incChapterlink(player_photos_url,currentChapter),headers = {'User-agent': randomizeUserAgent()},proxies=proxies)
                response.raise_for_status()
                #Finding url of photo do download
                soup = BeautifulSoup(response.text, 'lxml')
                img_tag = soup.find('div',class_='section_620 photopage').find('img')
                src_value = img_tag['src']
                #print(main_url + src_value)
                url_photo_download = base_url + src_value
                ###Downloading picture through url
                download_img_url(path_download,url_photo_download,name,f"{str(currentChapter)}")
                currentChapter+=1
                time.sleep(60)
            ##################################################################
            
            

        except requests.exceptions.HTTPError as errh:
            print(f"HTTP Error: {errh}")
        except requests.exceptions.ConnectionError as errc:
            print(f"Error Connecting: {errc}")
        except requests.exceptions.Timeout as errt:
            print(f"Timeout Error: {errt}")
        except requests.exceptions.RequestException as err:
            print(f"An error occurred: {err}")    


def download_img_url(path,url_photo,name,nchapter):
        name = name.replace(" ","")
        full_path=path + "/" + name+nchapter+".jpg"
        urllib.request.urlretrieve(url_photo, full_path)
        print(f"Image saved at '{full_path}' ")

def createFolder(name,path):
    # Specify the path where you want to create the folder
    # Path to the existing folder
    existing_folder_path = path
    #r'G:/benficafotos'
    # Name of the new folder to be created
    new_folder_name = name

    # Path to the new folder
    new_folder_path = os.path.join(existing_folder_path, new_folder_name)



    # Check if the folder already exists
    if not os.path.exists(new_folder_path):
        # Create the new folder
        os.makedirs(new_folder_path)
        print(f"Folder '{new_folder_name}' created inside '{existing_folder_path}'.")
    else:
        print(f"Folder '{new_folder_name}' already exists inside '{existing_folder_path}'.") 

    return new_folder_path

def incChapterlink(url,newchapter):
    #url = "https://www.zerozero.pt/foto.php?fk_galeria=0&nchapter=1&tpe=1&ide="

    # Find the position of 'nchapter=' in the URL
    start_index = url.find('nchapter=')
    print(start_index)

    # Find the position of '&' after 'nchapter='
    end_index = url.find('&', start_index)

    # If '&' is found, replace the substring including 'nchapter' and the current value
    if end_index != -1:
        modified_url = url[:start_index + len('nchapter=')] + str(newchapter) + url[end_index:]
    else:
        # If '&' is not found, replace the substring including 'nchapter' and the current value till the end
        modified_url = url[:start_index + len('nchapter=')] + str(newchapter)
    return modified_url

def randomizeUserAgent():
    # Specify the path to your text file
    file_path = "useragents.txt"
    # Open the file in read mode
    with open(file_path, 'r') as file:
        # Read the entire content of the file
        lines = file.readlines()


    lines = [line.strip() for line in lines]

    num_lines=len(lines)
    random_line_index = random.randint(0, num_lines - 1)
    random_line=lines[random_line_index]
    return random_line             


getPhotos(retrievePlayerInfo(url))
    






