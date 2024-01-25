import os
import cv2 as cv
import numpy as np
from sklearn.svm import SVC
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
import joblib
from keras.preprocessing.image import ImageDataGenerator
from sklearn.model_selection import GridSearchCV

# Load the FaceNet model
model_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\deploy.prototxt.txt"
weights_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\res10_300x300_ssd_iter_140000.caffemodel"
net = cv.dnn.readNetFromCaffe(model_path, weights_path) 

# Define the path to your dataset
dataset_path = r"G:\photodb\counterstrike"


datagen = ImageDataGenerator(
    rotation_range=20,
    width_shift_range=0.2,
    height_shift_range=0.2,
    shear_range=0.2,
    zoom_range=0.2,
    horizontal_flip=True,
    brightness_range=[0.8, 1.2],
    rescale=1./255  # normalize pixel values
)


""" #to get more variety for each image
def apply_augmentation(img):
    # Random horizontal flip
    if np.random.rand() > 0.5:
        img = cv.flip(img, 1)  # 1 for horizontal flip

    # Random rotation (between -15 and 15 degrees)
    angle = np.random.uniform(-15, 15)
    rows, cols, _ = img.shape
    rotation_matrix = cv.getRotationMatrix2D((cols / 2, rows / 2), angle, 1)
    img = cv.warpAffine(img, rotation_matrix, (cols, rows))

    # Random brightness adjustment
    brightness_factor = np.random.uniform(0.7, 1.3)
    img = np.clip(img * brightness_factor, 0, 255).astype(np.uint8)

    return img """

def display_image(windowname,image,w,h):
    


    # Set the size of the window
    cv.namedWindow(windowname, cv.WINDOW_NORMAL)
    cv.resizeWindow(windowname,w,h)  # Set the desired width and height

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

def getData():
    data = {}  # Dictionary to store labels and corresponding lists of images
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
                preprocessed_image = preprocess_face(img,use_grayscale=True)
                
                
                # Create blob from preprocessed image
                blob = cv.dnn.blobFromImage(preprocessed_image, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))
                
                # Forward pass to get embeddings
                net.setInput(blob)
                embedding = net.forward()
                # Append the embedding to the list of images for the corresponding label
                
                
                #data augmentation
                img2augment = cv.cvtColor(preprocessed_image, cv.COLOR_BGR2RGB)
                img2augment= np.reshape(img2augment, (1,) + img2augment.shape)
                augmented_images = [datagen.flow(img2augment).next()[0] for _ in range(6)]
                for augmented in augmented_images:
                    augmented = preprocess_face(augmented,use_grayscale=True)
                    blob = cv.dnn.blobFromImage(augmented, scalefactor=1.0, size=(300, 300), mean=(104, 177, 123))
                    net.setInput(blob)
                    embedding = net.forward()
                    data[f'{team}/{player}'].append(embedding.flatten())

                data[f'{team}/{player}'].append(embedding.flatten())
                
    return data

def HyperParams(X_train, y_train):
    # Create an SVM model
    svm_model = SVC()

    # Define a parameter grid for grid search
    param_grid = {
        'kernel': ['linear', 'poly', 'rbf', 'sigmoid'],
        'C': [0.1, 1, 10, 100]  # Adjust the values based on your needs
    }

    # Create GridSearchCV object
    grid_search = GridSearchCV(svm_model, param_grid, cv=5, scoring='accuracy')

    # Fit the grid search to the data
    grid_search.fit(X_train, y_train)

    # Get the best hyperparameter values
    best_kernel = grid_search.best_params_['kernel']
    best_C = grid_search.best_params_['C']

    
    return SVC(kernel=best_kernel, C=best_C)

def train(data):

    # Convert the dictionary to numpy arrays
    X_train = np.concatenate([np.array(embeddings) for embeddings in data.values()])
    print(len(X_train))
    y_train = np.concatenate([np.full(len(embeddings), label) for label, embeddings in data.items()])
    print(len(y_train))

    # Split the data into training and testing sets
    X_train, X_test, y_train, y_test = train_test_split(X_train, y_train, test_size=0.1, random_state=42)

    

    classifier = SVC(kernel='rbf', C=100)

    #USE THIS WHEN NEW DATA ARRIVES , FINE TUNING OF MODEL
    #classifier = HyperParams(X_train,y_train)
    #params = classifier.get_params()
    #print(f"C: {params['C']}")  
    #print(f"Kernel: {params['kernel']}") 

    classifier.fit(X_train, y_train)

    # Make predictions on the test set
    y_pred = classifier.predict(X_test)
    

    # Evaluate the model
    accuracy = accuracy_score(y_test, y_pred)
    print(f'Model Accuracy: {accuracy}')

    # Save the trained classifier
    classifier_save_path = r"C:\Users\Usuario\Desktop\projetomiguel\FaceDetection\classifier.joblib"
    joblib.dump(classifier, classifier_save_path)

train(getData())    