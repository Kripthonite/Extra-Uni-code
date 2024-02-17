from ultralytics import YOLO




# Load a model
model = YOLO("yolov8n.pt")  # build a new model from scratch

# Use the model
results = model.train(data="config.yaml", epochs=5)  # train the model