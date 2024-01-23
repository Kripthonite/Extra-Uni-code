import os
import time
import cv2 as cv
import matplotlib.pyplot as plt
import matplotlib.image as mpimg


# Read the image
#folder_path = r"G:\photodb\counterstrike\Vitality\apEX"
haar_cascadeface = cv.CascadeClassifier('haarface.xml')
haar_cascadeprofile = cv.CascadeClassifier('profileface.xml')


def deletePhoto(photo_path):
    try:
        # Check if the file exists before attempting to delete
        if os.path.exists(photo_path):
            # Delete the file
            os.remove(photo_path)
            print(f"Photo at '{photo_path}' deleted successfully.")
        else:
            print(f"Error: Photo at '{photo_path}' does not exist.")
    except Exception as e:
        print(f"Error: {e}")

def invalidateImg(path):
    # Read the original image
    original_image = cv.imread(path)
    
    # Check if the image is loaded successfully
    if original_image is not None:

        # Set the desired width for resizing
        desired_width = 1920

        # Calculate the corresponding height to maintain the aspect ratio
        aspect_ratio = original_image.shape[1] / original_image.shape[0]
        desired_height = int(desired_width / aspect_ratio)

        # Resize the image
        resized_image = cv.resize(original_image, (desired_width, desired_height))

        # Display the original image with manual resizing enabled
        #cv.namedWindow("Resized Image", cv.WINDOW_NORMAL)
        #cv.imshow("Resized Image", resized_image)

        gray = cv.cvtColor(resized_image,cv.COLOR_BGR2GRAY)
        
        scale_factor_f = 2 # Increase to focus on larger faces
        min_neighbors_f = 4 # Adjust based on the desired balance between detection and filtering
        scale_factor_p = 1.1 # Increase to focus on larger faces
        min_neighbors_p = 4 # Adjust based on the desired balance between detection and filtering

        faces_rect = haar_cascadeface.detectMultiScale(gray,scaleFactor=scale_factor_f,minNeighbors=min_neighbors_f)
        

        profiles_rect = haar_cascadeprofile.detectMultiScale(gray,scaleFactor=scale_factor_p,minNeighbors=min_neighbors_p)
        
        print(f'faces found: {len(faces_rect)}' +" "+ f'profiles found: {len(profiles_rect)}')

        if (not (len(faces_rect) <= 1 and len(profiles_rect)<=1)): #invalidado
            deletePhoto(path)


        """ for(x,y,w,h) in faces_rect:
            cv.rectangle(resized_image, (x,y), (x+w,y+h),(0,0,255),thickness=4)

        for(x,y,w,h) in profiles_rect:
            cv.rectangle(resized_image, (x,y), (x+w,y+h),(0,255,0),thickness=2)  """   

        #cv.imshow('Detected faces',resized_image)
        # Wait for a key press and close the window on any key press
        # Save the annotated image
        """ annotated_image_path = r"G:\photodb\counterstrike\Vitality\apEXout"+r"\apex"+ str(counter)+".jpg"
        cv.imwrite(annotated_image_path, resized_image)    """ 
        cv.waitKey(0)
        cv.destroyAllWindows() 
    else:
        print(f"Error: Unable to load the image at '{path}'.")

#cs_path = r"G:\photodb\counterstrike" ex of arg
def init(folder_path): # use after all desired player photos have been downloaded
    items = os.listdir(folder_path)
    print(len(items))
    for item in items:
        #print(item)
        full_img_path = folder_path + "\\" + item
        invalidateImg(full_img_path)

def filterAllDb(folder_path): # use in the end of all the web scraping
    teams = os.listdir(folder_path)
    for team in teams:
        teams_path = folder_path + "\\" + team
        players = os.listdir(teams_path)
        for player in players:
            player_path = teams_path + "\\" + player
            imgs = os.listdir(player_path)
            for img in imgs:
                full_img_path = player_path + "\\" + img
                invalidateImg(full_img_path)

#filterAllDb(r"G:\photodb\counterstrike")                

    
