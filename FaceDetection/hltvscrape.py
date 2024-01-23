from itertools import cycle
import os
import random
import time
from bs4 import BeautifulSoup
import requests
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import undetected_chromedriver.v2 as uc
from undetected_chromedriver.v2 import Chrome, ChromeOptions
from seleniumbase import SB
import pyautogui
import photo_filtering as pf

main_url = "https://www.hltv.org"
cs_path = "G:\photodb\counterstrike"
number_photos_per_player = 1

def createFolder(name,path):
    # Specify the path where you want to create the folder
    # Path to the existing folder
    existing_folder_path = path
    
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

def saveimg(path,sb):
    
    window_position = (sb.driver.execute_script("return window.screenX"),
                           sb.driver.execute_script("return window.screenY"))
    window_size = (sb.driver.execute_script("return window.innerWidth"),
                       sb.driver.execute_script("return window.innerHeight"))
                   
    bcs = [  # bcs stands for Browser Center on Screen.
            window_position[0] + int(window_size[0] / 2),
            window_position[1] + int(window_size[1] / 2),
    ]
     # Using pyautogui to save image.
    pyautogui.moveTo(bcs[0], bcs[1])
    pyautogui.click()
    time.sleep(1)
    pyautogui.moveTo(bcs[0], bcs[1])
    pyautogui.rightClick()
    pyautogui.moveTo(bcs[0] + 25, bcs[1] + 35)
    pyautogui.click()
    time.sleep(2)
    pyautogui.typewrite(path)
    time.sleep(2)
    pyautogui.hotkey('enter')
    




with SB(uc=True,incognito=True) as sb:
    sb.open(main_url)
    sb.click('#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll')
    btn_allow_cookies_id = "CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"
    soup = BeautifulSoup(sb.get_page_source(), 'lxml')
    team_info = soup.find_all('div', class_="col-box rank")
    
    for team_div in team_info:
        # Find the <a> tag inside the <div> for team name and href
        team_a = team_div.find('a', class_="text-ellipsis")
        team_name = team_a.text
        team_href = team_a['href']

        print(f"Team Name: {team_name}")
        print(f"Team Href: {team_href}")
        formatted_team_name = team_name.strip() ## remove whitespace if exists
        team_folder_path = createFolder(formatted_team_name,cs_path)
        team_path = main_url + team_href
        sb.open(team_path)
        soup = BeautifulSoup(sb.get_page_source(), 'lxml')
        players = soup.find_all('a',class_="col-custom")
        for player in players:
            player_href = player['href']
            player_name = player['title']
            print(f"Player Name: {player_name}")
            print(f"Player Href: {player_href}")
            player_folder_path= createFolder(player_name,team_folder_path)
            items = os.listdir(player_folder_path)
            number_of_items = len(items)
            if(number_of_items>=number_photos_per_player):
                continue
            player_path = main_url+player_href
            sb.open(player_path)
            soup = BeautifulSoup(sb.get_page_source(),'lxml')
            
            divs = soup.find_all('a',class_="moreButton")
            #print(divs)
            target_text = "All photos of "+player_name
            photos_gallery = None
            for div in divs:
                if div.get_text(strip=True) == target_text:
                    photos_gallery=div
                    break
            
            gallery_href = photos_gallery['href']
            gallery_path = main_url+gallery_href
            sb.open(gallery_path)
            soup = BeautifulSoup(sb.get_page_source(),'lxml')
            photos_ids = soup.find_all('div',class_='col')
            
            
            #print(photos_ids)
            counter = 1
            number = number_photos_per_player
            if(len(photos_ids)<number_photos_per_player): #if there's no sufficient photos to achieve number_photos_per_player , download all available
                number = len(photos_ids)

            for photo_id in photos_ids:
                if(counter>number):
                    break
                
                photo_a=photo_id.find('a')
                if(photo_a!=None):
                   photo_href = photo_a['href']
                   path_to_download = main_url+photo_href
                   sb.open(path_to_download)
                   soup = BeautifulSoup(sb.get_page_source(),'lxml')
                   player_tags = soup.find('div',class_='players')
                   player_tags_a = player_tags.find_all('a')
                   if(len(player_tags_a)>1): #disregard photos than more with 1 player tag
                       continue
                   if(counter<=number_of_items): #if program breaks, it'll restart at where it's supposed
                       counter+=1
                       continue

                   sb.click_link_text("Download")
                   path_to_save = player_folder_path + "\\" + player_name+str(counter)+".jpg"
                   if(not os.path.exists(path_to_save)):
                        saveimg(path_to_save,sb)
                   counter+=1

            print(player_folder_path)

pf.filterAllDb(cs_path)                  
                 

            


                   
                   
                   

            


    


 

















