import cv2 as cv
import numpy as np
import joblib

def display_image(windowname,image):
    
    
    
    # Display the image
    cv.imshow(windowname, image)
    cv.waitKey(0)
    cv.destroyAllWindows()      

def preprocess_face(img, target_size=(300, 300), use_grayscale=False):
    #norm_img = cv.resize(img, target_size)
    norm_img = cv.cvtColor(img, cv.COLOR_BGR2RGB)
    if(use_grayscale):
        norm_img = cv.cvtColor(norm_img, cv.COLOR_BGR2RGB)
    norm_img = np.zeros((norm_img.shape[0], norm_img.shape[1]))
    norm_img = cv.normalize(img, norm_img, 0, 255, cv.NORM_MINMAX)
    return norm_img 

def getImages(img, net=None):
   
    """ # Set the desired width for resizing
    desired_width = 1920

    # Calculate the corresponding height to maintain the aspect ratio
    aspect_ratio = img.shape[1] / img.shape[0]
    desired_height = int(desired_width / aspect_ratio)

    # Resize the image
    resized_image = cv.resize(img, (desired_width, desired_height)) """

    

    # Add face detection and cropping using OpenCV DNN
    if net is not None:
        blob = cv.dnn.blobFromImage(img, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))
        net.setInput(blob)
        detections = net.forward()

        # Draw bounding boxes around detected faces using OpenCV DNN
        for i in range(detections.shape[2]):
            confidence = detections[0, 0, i, 2]
            if confidence > 0.5:  # Confidence threshold
                box = detections[0, 0, i, 3:7] * np.array([img.shape[1], img.shape[0], img.shape[1], img.shape[0]])
                (startX, startY, endX, endY) = box.astype("int")
                cropped_face = img[startY:endY, startX:endX].copy()
                cv.rectangle(img, (startX, startY), (endX, endY), (0, 255, 0), 2)
                
                return img , cropped_face , startX , startY

    return img

# Load the trained classifier
classifier_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\classifier.joblib"
classifier = joblib.load(classifier_path)

# Load the FaceNet model
model_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\deploy.prototxt.txt"
weights_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\res10_300x300_ssd_iter_140000.caffemodel"
net = cv.dnn.readNetFromCaffe(model_path, weights_path)

# Assuming you have a new image called 'new_image.jpg'
new_image_path = r"G:\photodb\b1t-featured.png"
new_image = cv.imread(new_image_path)

# Get Cropped and original with face detected highlighted

detected_image, cropped_face , startX , startY = getImages(new_image, net)

cropped_face = preprocess_face(cropped_face,use_grayscale=True)

#display_image("resized",preprocessed_image)

# Create a blob from the preprocessed image
blob = cv.dnn.blobFromImage(cropped_face, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))

# Forward pass to get the embedding
net.setInput(blob)
embedding = net.forward()

# Predict the label for the new image's embedding
predicted_label = classifier.predict([embedding.flatten()])

# Use decision_function to get confidence scores
confidence_scores_all = classifier.decision_function([embedding.flatten()])
confidence_scores = confidence_scores_all[0, classifier.classes_ == predicted_label[0]]


print(f'Predicted Label: {predicted_label[0]}')
print(f'Predicted Confidence: {confidence_scores[0]}')


cv.putText(detected_image, predicted_label[0], (startX,startY-10), cv.FONT_HERSHEY_COMPLEX_SMALL, 0.4, (0, 255, 0), 1, cv.LINE_AA)
cv.imshow('New Image with Predicted Label', detected_image)
cv.waitKey(0)
cv.destroyAllWindows()
