import random
import requests
from bs4 import BeautifulSoup
import urllib.request
import os

def test():
    url = "/jogador/samuel-soares/490932?epoca_id=153"
    chopped_url= url.split('/')
    #id_string = url.split('?')[0]
    id_string = chopped_url[3].split('?')[0]
    id = int(id_string)

    url_photos = "https://www.zerozero.pt/foto.php?fk_galeria=0&nchapter=1&tpe=1&ide=490932"
    main_url ="https://www.zerozero.pt"

    try:
            # Send a GET request and retrieve the HTML content
            response = requests.get(url_photos,headers = {'User-agent': randomizeUserAgent()})
            response.raise_for_status()

            # Parse the HTML using BeautifulSoup and lxml parser
            soup = BeautifulSoup(response.text, 'lxml')
            #print(soup.prettify())
            #Finding number of photos
            chapter_tag = soup.find('div',class_='slideshow_bar_chapters').text
            chapters= chapter_tag.split('/')
            currentChapter=int(chapters[0])
            nmaxChapters=int(chapters[1])
            img_tag = soup.find('div',class_='section_620 photopage').find('img')
            src_value = img_tag['src']
            url_photo_download = main_url + src_value
            ###Downloading picture through url
            path_download =  createFolder("Samuel Soares",r'G:/benficafotos')
            name = "Samuel Soares"
            download_img_url(path_download,url_photo_download,name,f"{str(currentChapter)}")


            

        
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

test()      

