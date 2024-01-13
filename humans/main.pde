
import uibooster.*;
import uibooster.components.*;
import uibooster.model.*;
import uibooster.model.formelements.*;
import uibooster.utils.*;
import controlP5.*;
import grafica.*;


int population= 50;
int circleradius= 10;
int MAX = 100;
Humans humans[] = new Humans[population];
Point plots[] = new Point[MAX*4];
int taxaMortalidade;
int taxaRecovery;
int counterDead = 0 ;
int counterRCV = 0;
int currenttime;
int myColor = color(0,0,0);
ControlP5 cp5;
boolean quarentena=false;

int setuptime;
int countertime=0;





void createMan(){
  float xpos,ypos;
  
  
  for(int i = 0; i < population ; i++){
    Status myVar = Status.NINF;
    
    if(i==population-1){
       
       myVar = Status.INF;
     }
     
  
    
    xpos = random(circleradius,width-circleradius);
    ypos = random(circleradius,height-circleradius-100);
    Humans man = new Humans(myVar,i,xpos,ypos);
    humans[i] = man;
    
  }
  
}



void setup() {
  size(500,500);
  cp5 = new ControlP5(this);
  setuptime = millis()/1000;
  background(255);
  frameRate(1000);
  smooth();
  String[] args = {"STATS"};
  //SecondApplet sa = new SecondApplet();
  //PApplet.runSketch(args, sa);
  createMan();
  //taxaMortalidade = new UiBooster().showSlider("Qual é a taxa de mortalidade do vírus?", "Taxa de Mortalidade", 
    //            0, 100, 4, 50, 10);
                
  //taxaRecovery = new UiBooster().showSlider("Qual é a taxa de recuperação do vírus?", "Taxa de Recuperação", 
               // 0, 100, 4, 50, 10);
  
  cp5.addSlider("taxaMortalidade")
     .setPosition(width - 100,height-80)
     .setRange(0,25)
     .setWidth(70)
     .setValue(4)
     .setColorCaptionLabel(255) 
     .setColorForeground(255)
     .setColorActive(255)
     ;
 cp5.addSlider("taxaRecovery")
    .setPosition(width - 100,height-40)
    .setRange(0,25)
    .setWidth(70)
    .setValue(4)
    .setColorCaptionLabel(255) 
    
    ;


 cp5.getController("taxaMortalidade").getCaptionLabel().align(ControlP5.BOTTOM, ControlP5.BOTTOM_OUTSIDE).setPaddingX(0);
 cp5.getController("taxaRecovery").getCaptionLabel().align(ControlP5.BOTTOM, ControlP5.BOTTOM_OUTSIDE).setPaddingX(0);

}
 


void draw (){
  currenttime = millis()/1000;
  
  //System.out.println(currenttime);
  
  int countDead = displayDEAD();
  int countRCV = displayRCV();
  int countINF = displayInfected();
  int countNINF = population - (countDead + countINF + countRCV);
  

  
  

  
  if(currenttime == MAX){noLoop(); }
  background(255); 
  stroke(0);
  line(0,height-100,width,height-100);//horizontal
  line(width-120,height-100,width-120,height);//vertical
  stroke(0);
  
  fill(0);
  text(currenttime,10,10);
  fill(255, 0,0);
  text("INFECTED: " + countINF, 50,10);
  fill(0, 100, 255);
  text("RCV: " + countRCV, 135,10);
  fill(0);
  text("DEAD: " + countDead, 185, 10);
  //int segundos = millis()/1000; 
  
   
     
      
 if(currenttime - setuptime >= 1){
    int idxbase =(countertime)*4;
    plots[idxbase] = new Point(countertime, countDead , Status.DEAD);
    
    plots[idxbase+1] = new Point(countertime, countRCV , Status.RCV);
    
    plots[idxbase+2] = new Point(countertime, countINF , Status.INF);
    
    plots[idxbase+3] = new Point(countertime, countNINF , Status.NINF);
    
    countertime++;
    setuptime = currenttime;
  }
  
  
  for(Point px : plots){
    if(px!=null){px.drawPoint();}
    
  }
   if(quarentena){
     drawBoundaries();
   }
   
  noStroke();
   for(int i = 0 ; i < population ; i++){ 
       humans[i].checkCollisions();
       
       for(int b=0; b < population ; b++){
        if(b!=i){
        if(humans[i].checkCollision(humans[b])){
           if(humans[i].stat == Status.INF && (humans[b].stat== Status.NINF) ){
           
           
           humans[b].changeVar(Status.INF);
           
           
        }
                  
      }
        
    }
      
      
      humans[i].drawCircle();
      
      
       }
     }
     
     
     
     
   for(int i = 0 ; i < population ; i++){
     boolean waschanged = false;
     if(humans[i].stat == Status.INF){
     if((currenttime - humans[i].creation) % 20 == 0 && currenttime - humans[i].creation  != 0){
       int porcentagemDead =(int) random(100);
       int porcentagemRCV =(int) random(100);
       
       if(porcentagemDead < taxaMortalidade){
           
           humans[i].changeVar(Status.DEAD);
           humans[i].xSpeed = 0;
           humans[i].ySpeed = 0;
           waschanged = true;
         }
       if(!waschanged){
       if(porcentagemRCV < taxaRecovery){humans[i].changeVar(Status.RCV);} 
     }
        
     }
    
   }
     
    
   }
   
 
   
 }
   
  
  




  
int displayInfected(){
  int counter = 0;
  for (int i = 0 ; i < population; i ++){
    if(humans[i].stat == Status.INF){
      counter ++;
    
    
    }  
  
  }
  return counter;
  }
  
  int displayRCV(){
  int counter = 0;
  for (int i = 0 ; i < population; i ++){
    if(humans[i].stat == Status.RCV){
      counter ++;
    
    
    }  
  
  }
  return  counter;
  }
  
  
  
  int displayDEAD (){
  int counter = 0;
  for (int i = 0 ; i < population; i ++){
    if(humans[i].stat == Status.DEAD){
      counter ++;
    
    
    }  
  
  }
  return counter;
  }
    
 
  
 void keyReleased() {
  if (key == 'i' || key== 'i') {
    int counterinf = displayInfected()/3;
    int counter = 0;
    quarentena=!quarentena;
    for(int i = 0 ; i < population ; i++){
      humans[i].quarentena=!(humans[i].quarentena);
    }
    for(Humans h : humans){
      if(h.xposi > width - 120 && h.yposi > height - 300 ){
       h.xposi = (int) random(width -120);
       h.yposi = (int) random(height - 300);
      }
    }
    
      for(int i = 0 ; i < population ; i++){
        if(humans[i].isolamento){humans[i].isolamento = false;}
        if(counter < counterinf){
         if(humans[i].stat == Status.INF){
          humans[i].xposi = (int) random(width -120,width);
          humans[i].yposi = (int) random(height -300, height -100);
          humans[i].isolamento = true;
          counter++;
         }
       }
        
   }
   
  
   
   
   
  }
 }
  
  

   
    
    
 
  

  



void drawBoundaries(){
   fill(0);
   stroke(0);
   line(width-120,height-100,width-120,height-300);//vertical
   line(width-120,height - 300,width,height-300);//horizontal
 }
 
  

/*public class SecondApplet extends PApplet {

  public void settings() {
    size(200, 200);
  }
  
  public void draw() {
    background(255);
    fill(0);
    
  }
}*/
