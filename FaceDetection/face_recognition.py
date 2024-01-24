import cv2 as cv
import numpy as np
from sklearn.svm import SVC
import joblib

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
    desired_width = 1920

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

# Load the trained classifier
classifier_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\classifier.joblib"
classifier = joblib.load(classifier_path)

# Load the FaceNet model
model_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\deploy.prototxt.txt"
weights_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\res10_300x300_ssd_iter_140000.caffemodel"
net = cv.dnn.readNetFromCaffe(model_path, weights_path)

# Assuming you have a new image called 'new_image.jpg'
new_image_path = r"G:\photodb\counterstrike\Natus Vincere\iM\iM2.jpg"
new_image = cv.imread(new_image_path)

# Preprocess the new image
preprocessed_image = preprocess_image(new_image, net)

# Create a blob from the preprocessed image
blob = cv.dnn.blobFromImage(preprocessed_image, scalefactor=1.0, size=(160, 160), mean=(104, 177, 123))

# Forward pass to get the embedding
net.setInput(blob)
embedding = net.forward()

# Predict the label for the new image's embedding
predicted_label = classifier.predict([embedding.flatten()])

print(f'Predicted Label: {predicted_label[0]}')

cv.imshow('New Image with Predicted Label', new_image)
cv.putText(new_image, f'Predicted Label: {predicted_label[0]}', (10, 30), cv.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2, cv.LINE_AA)
cv.waitKey(0)
cv.destroyAllWindows()
