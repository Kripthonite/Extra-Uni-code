boolean[] keys;
float dX, dY;
ArrayList<ball> balls = new ArrayList();
int level = 1;
boolean gameOver = false;
PImage bg;
float setuptime;
float pwruptime;
Devil dvl;
float speedfactor;
beam bam;
ball b1 = null;
ball b2 = null;
ball removed=null;
PowerUps pwrup = null;
float lastSpeeddvl=0;
boolean frozen , enl , slim ,  fasten;

public void settings(){
  size(500,300,P3D);
  
  
}


void setup(){
  setuptime = millis()/1000;
  dvl = new Devil(width/2,height - 70);
  for(int i = 0 ; i< level ; i++){
    balls.add(new ball(random(150,250),150,50,random(-1,1),random(-1,1)));
  }
  
  
  bg = loadImage("stonewall.jpg");
  keys = new boolean[2];
  keys[0]= false;
  keys[1]= false;
  
  
  
  
}

void draw(){
    background(255);
    int current =millis()/1000;

    if(!gameOver){
       if(current - setuptime >= 15){
        pwrup = new PowerUps(current);
      
        setuptime = current;
      }
      dvl.drawDvl();  
      
      if(keys[0]){dvl.updatePos(-2,0,fasten);}
      if(keys[1]){dvl.updatePos(2,0,fasten);}
      if(bam!=null){
        
          
          bam.drawBeam(enl);
          if(bam.yact<0){bam=null;}
        
      
    }
    if(current - pwruptime >= 10 && pwruptime != 0){
      frozen = enl = slim =  fasten = false;
      pwruptime = 0;
      
    }
      
    if(pwrup!=null){
      //boundaries da powerup
      pwrup.drawPwr();
      if(pwrup.y < 0 ){pwrup = null;}
      //colisao com beam
      if(bam!=null){
        if(bam.collide(pwrup)){
          pwruptime = millis()/1000;
          switch(pwrup.getPWR()){
            case enl:
              
              enl = true;
              //c = color(100,200,100);
              break;
            case frozen:
              frozen = true;
              //c = color(100, 200, 217);
              break;
            case fasten:
              fasten=true;
              //c = color(213, 159, 21);
              break;
           
          }
          
          pwrup=null;
      
        }
      }
      
      
      
    }
    
    
    
      
      for(ball b : balls){
        
        if(b!=null){
          b.drawBall();
          b.updatePos(frozen);
          if(dvl.CollideWball(b)){gameOver =true;}
          if(bam!=null){
          if(bam.collide(b)){
            if(b.size > 10){
              b1 =new ball((b.x-b.size/3),b.y,b.size/3,b.xSpeed * -1.10,b.ySpeed * 1.1 , b.r , b.g , b.b);
              b2 =new ball(b.x+b.size/3,b.y,b.size/3,b.xSpeed * 1.10,b.ySpeed * 1.1 , b.r , b.g , b.b);
            }
            
            removed =b;
            bam=null;  
      }
          }
        }
         
        
        
    }
     if(b2 != null && b1!= null){
       balls.add(b1);
       balls.add(b2);
       b1 = null;
       b2 = null;
     }
     if(removed!=null){
     balls.remove(removed);
     removed=null;
   
 }
    }else{
      text("RESTART (Y/N)",200,150);
      if (keyPressed) {
        if (key == 'y' || key == 'Y') {
          restart();
      }else if(key == 'n' || key == 'N'){
        exit();
      }
   }
}
    
    
   
    if(balls.isEmpty()){
      background(255);
      text("NEXT LVL (Y/N)",200,150);
      if (keyPressed) {
        if (key == 'y' || key == 'Y') {
          level++;
          setup();
      }else if(key == 'n' || key == 'N'){
        exit();
      }
       
     
      }
    }
    
    

  
  
  

  
  
  
    
 
  
}
void restart(){
  balls.clear();
  gameOver = false;
  bam = null;
  setup();
}
void keyPressed(){
  
  if (key == CODED){
    switch(keyCode){
      case LEFT:
        keys[0]=true;
       
        break;
      case RIGHT: 
        keys[1]=true;
      
        break;
      case UP: 
        System.out.println("shoot");
        bam = new beam(dvl.xposi+10,dvl.yposi+15,-2);
        
        break;
        
      
    }
    
     
  }
  }
  
   void keyReleased()
 {
    if (key == CODED){
    switch(keyCode){
      case LEFT:
        keys[0]=false;
       
        break;
      case RIGHT: 
        keys[1]=false;
      
        break;
     
        
      
    }
    
     
  }
} 
    
   
