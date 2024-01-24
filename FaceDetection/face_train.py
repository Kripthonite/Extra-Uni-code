import os
import cv2 as cv
import numpy as np
from sklearn.svm import SVC
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
import joblib

# Load the FaceNet model
model_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\deploy.prototxt.txt"
weights_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\res10_300x300_ssd_iter_140000.caffemodel"
net = cv.dnn.readNetFromCaffe(model_path, weights_path) 

# Define the path to your dataset
dataset_path = r"G:\photodb\counterstrike"

# Prepare and preprocess dataset
data = {}  # Dictionary to store labels and corresponding lists of images
image_paths = []
labels = []
embeddings = []
def display_image(windowname,image,w,h):
    
    

    # Set the size of the window
    cv.namedWindow(windowname, cv.WINDOW_NORMAL)
    cv.resizeWindow(windowname,w,h)  # Set the desired width and height

    # Display the image
    cv.imshow(windowname, image)
    cv.waitKey(0)
    cv.destroyAllWindows()      

def preprocess_image(img, net=None):
   
    # Set the desired width for resizing
    desired_width = 1000

    # Calculate the corresponding height to maintain the aspect ratio
    aspect_ratio = img.shape[1] / img.shape[0]
    desired_height = int(desired_width / aspect_ratio)

    # Resize the image
    resized_image = cv.resize(img, (desired_width, desired_height))

    

    # Add face detection and cropping using OpenCV DNN
    if net is not None:
        blob = cv.dnn.blobFromImage(resized_image, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))
        net.setInput(blob)
        detections = net.forward()

        # Draw bounding boxes around detected faces using OpenCV DNN
        for i in range(detections.shape[2]):
            confidence = detections[0, 0, i, 2]
            if confidence > 0.5:  # Confidence threshold
                box = detections[0, 0, i, 3:7] * np.array([resized_image.shape[1], resized_image.shape[0], resized_image.shape[1], resized_image.shape[0]])
                (startX, startY, endX, endY) = box.astype("int")
                cv.rectangle(resized_image, (startX, startY), (endX, endY), (0, 255, 0), 2)
                return resized_image

    return resized_image

# Iterate through teams and players to collect image paths and labels
for team in sorted(os.listdir(dataset_path)):
    team_path = os.path.join(dataset_path, team)
    
    for player in sorted(os.listdir(team_path)):
        player_path = os.path.join(team_path, player)
        
        data[f'{team}/{player}'] = []  # Initialize an empty list for each label

        for img_name in sorted(os.listdir(player_path)):
            img_path = os.path.join(player_path, img_name)
            
            # Read the image
            img = cv.imread(img_path)

            # Preprocess the image (resize, normalize, etc.)
            preprocessed_image = preprocess_image(img, net)

            # Create blob from preprocessed image
            blob = cv.dnn.blobFromImage(preprocessed_image, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))
            
            # Forward pass to get embeddings
            net.setInput(blob)
            embedding = net.forward()

            # Append the embedding to the list of images for the corresponding label
            data[f'{team}/{player}'].append(embedding.flatten())

# Convert the dictionary to numpy arrays
X_train = np.concatenate([np.array(embeddings) for embeddings in data.values()])
y_train = np.concatenate([np.full(len(embeddings), label) for label, embeddings in data.items()])

# Split the data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X_train, y_train, test_size=0.1, random_state=42)

# Train a simple SVM classifier
classifier = SVC(kernel='linear', C=1.0)
classifier.fit(X_train, y_train)

# Make predictions on the test set
y_pred = classifier.predict(X_test)

# Evaluate the model
accuracy = accuracy_score(y_test, y_pred)
print(f'Model Accuracy: {accuracy}')

# Save the trained classifier
classifier_save_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\classifier.joblib"
joblib.dump(classifier, classifier_save_path)