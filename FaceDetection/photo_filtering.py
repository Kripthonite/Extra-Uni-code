import os
import cv2 as cv
from mtcnn import MTCNN
import numpy as np



# Read the image
#folder_path = r"G:\photodb\counterstrike\Vitality\apEX"
#haar_cascadeface = cv.CascadeClassifier('haarface.xml')
#haar_cascadeprofile = cv.CascadeClassifier('profileface.xml')

#detector = MTCNN()
deploy_path =r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\deploy.prototxt.txt"
caffemodel_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\res10_300x300_ssd_iter_140000.caffemodel"
net = cv.dnn.readNetFromCaffe(deploy_path, caffemodel_path)
invalid_images = []  # List to store paths of images to be deleted


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

def display_image(windowname,image,w,h):
    
    

    # Set the size of the window
    cv.namedWindow(windowname, cv.WINDOW_NORMAL)
    cv.resizeWindow(windowname,w,h)  # Set the desired width and height

    # Display the image
    cv.imshow(windowname, image)
    cv.waitKey(0)
    cv.destroyAllWindows()      

def invalidateImg(path):
    # Read the original image
    original_image = cv.imread(path)
    
    # Check if the image is loaded successfully
    if original_image is not None:

        # Set the desired width for resizing
        desired_width = 1000

        # Calculate the corresponding height to maintain the aspect ratio
        aspect_ratio = original_image.shape[1] / original_image.shape[0]
        desired_height = int(desired_width / aspect_ratio)

        # Resize the image
        resized_image = cv.resize(original_image, (desired_width, desired_height))
        blob = cv.dnn.blobFromImage(resized_image, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))
        net.setInput(blob)
        detections = net.forward()

        # Draw bounding boxes around detected faces using OpenCV DNN
        num_faces_found = 0  # Initialize the count
        for i in range(detections.shape[2]):
            confidence = detections[0, 0, i, 2]
            if confidence > 0.5:  # Confidence threshold
                num_faces_found += 1
                box = detections[0, 0, i, 3:7] * np.array([resized_image.shape[1], resized_image.shape[0], resized_image.shape[1], resized_image.shape[0]])
                (startX, startY, endX, endY) = box.astype("int")
                cv.rectangle(resized_image, (startX, startY), (endX, endY), (0, 255, 0), 2)


        #display_image('Expanded Bounding Boxes',resized_image,desired_width,desired_height)
        """ cv.imshow('Expanded Bounding Boxes', resized_image)
        cv.waitKey(0)
        cv.destroyAllWindows() """
        print(f"Number of faces found: {num_faces_found}")
        

        # Display the original image with manual resizing enabled
        #cv.namedWindow("Resized Image", cv.WINDOW_NORMAL)
        #cv.imshow("Resized Image", resized_image)

        if(num_faces_found!=1):
            print(f"invalidated {path}")
            invalid_images.append(path)
    
        
       
        

    else:
        print(f"Error: Unable to load the image at '{path}'.")
        invalid_images.append(path)

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
    
    for invalid_path in invalid_images:
        deletePhoto(invalid_path)

filterAllDb(r"G:\photodb\counterstrike")                

    
