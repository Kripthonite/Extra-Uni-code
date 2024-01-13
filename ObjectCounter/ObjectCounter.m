


function varargout = imgpro(varargin)
% IMGPRO MATLAB code for imgpro.fig
%      IMGPRO, by itself, creates a new IMGPRO or raises the existing
%      singleton*.
%
%      H = IMGPRO returns the handle to a new IMGPRO or the handle to
%      the existing singleton*.
%
%      IMGPRO('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in IMGPRO.M with the given input arguments.
%
%      IMGPRO('Property','Value',...) creates a new IMGPRO or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before imgpro_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to imgpro_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help imgpro

% Last Modified by GUIDE v2.5 03-Jan-2021 16:46:13

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @imgpro_OpeningFcn, ...
                   'gui_OutputFcn',  @imgpro_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT




% --- Executes just before imgpro is made visible.
function imgpro_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to imgpro (see VARARGIN)
set(handles.savebtn,'visible','off');
% Choose default command line output for imgpro
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes imgpro wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = imgpro_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;



function nmbedit_Callback(hObject, eventdata, handles)
% hObject    handle to nmbedit (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of nmbedit as text
%        str2double(get(hObject,'String')) returns contents of nmbedit as a double


% --- Executes during object creation, after setting all properties.
function nmbedit_CreateFcn(hObject, eventdata, handles)
% hObject    handle to nmbedit (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end


function setname(val)
global x
x = val;

function r = getname
global x
r = x;





% --- Executes on button press in browsebtn.
function browsebtn_Callback(hObject, eventdata, handles)
% hObject    handle to browsebtn (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of browsebtn

    

    [Filename , Pathname] = uigetfile({'*.png';'*.jpg''},'Image Selector');
    if isequal(Filename,0)
       disp('User selected Cancel');
       setname('');
    else
       cla(handles.axes1,'reset');
       disp(['User selected ', fullfile(Pathname,Filename)]);
       name = strcat(Pathname , Filename);
       a = imread(name);
       axes(handles.axes1);
       imshow(a);
       setname(name);
       
    end

    


% --- Executes on button press in calcbtn.
function calcbtn_Callback(hObject, eventdata, handles)
% hObject    handle to calcbtn (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of calcbtn

r = getname;
if isequal(r,'')
    disp('No image selected');
else 
    
    switch get(get(handles.colorgroup,'SelectedObject'),'Tag')
      case 'rdbtnr',  color = 'r';
      case 'rdbtny',  color = 'y';
      case 'rdbtng',  color = 'g';  
      case 'rdbtnb',  color = 'b';
    end      
    img1=imread(r);
    imshow(img1)
    
    

    img1=rgb2gray(img1);
    imshow(img1)

    img2=im2bw(img1,graythresh(img1));
    imshow(img2)
    
    

    
    img2=img2;
    imshow(img2)
    
    SE = strel('disk',4);
    afterOpening = imopen(img2,SE);
    imshow(afterOpening);
    
    afterClosing=imclose(afterOpening,SE);
    imshow(afterClosing);

    [B,L,N] = bwboundaries(afterClosing);
    
    hold on
    a= 0 ; 
    for k=1:length(B),
       boundary = B{k};
       if(k > N)
         plot(boundary(:,2), boundary(:,1), color,'LineWidth',2);
         a=a+1;
         %randomize text position for better visibility
         rndRow = ceil(length(boundary)/(mod(rand*k,7)+1));
         col = boundary(rndRow,2); row = boundary(rndRow,1);
         h = text(col+1, row-1, num2str(L(row,col)-1));
         set(h,'Color',color,'FontSize',14,'FontWeight','bold');
       else
           
         plot(boundary(:,2), boundary(:,1), color,'LineWidth',2);
       end
    end

   if(a~=0)
   else
       a = length(B);
   end
   
       
   set(handles.nmbedit,'string',num2str(a));
   set(handles.savebtn,'visible','on');
end




% --- Executes when selected object is changed in colorgroup.
function colorgroup_SelectionChangedFcn(hObject, eventdata, handles)
% hObject    handle to the selected object in colorgroup 
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
 
switch(get(eventdata.NewValue,'Tag'));
    case 'rdbtnr'
         disp('RED');
    case 'rdbtng'
         disp('GREEN');
    case 'rdbtnb'
         disp('BLUE');
    case 'rdbtny'
         disp('YELLOW');
 
end


% --- Executes on button press in rdbtnr.
function rdbtnr_Callback(hObject, eventdata, handles)
% hObject    handle to rdbtnr (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of rdbtnr


% --- Executes on button press in rdbtny.
function rdbtny_Callback(hObject, eventdata, handles)
% hObject    handle to rdbtny (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of rdbtny


% --- Executes on button press in rdbtnb.
function rdbtnb_Callback(hObject, eventdata, handles)
% hObject    handle to rdbtnb (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of rdbtnb


% --- Executes on button press in rdbtng.
function rdbtng_Callback(hObject, eventdata, handles)
% hObject    handle to rdbtng (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of rdbtng


% --- Executes on button press in savebtn.
function savebtn_Callback(hObject, eventdata, handles)
% hObject    handle to savebtn (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
    
    F = getframe(handles.axes1);
    Image = frame2im(F);
    prompt = 'Image name:';
    imgname = input(prompt,'s');
    if isempty(imgname)
        disp('Save canceled');
    else     
        imwrite(Image, strcat(imgname,'.jpg'));
    end    

    
