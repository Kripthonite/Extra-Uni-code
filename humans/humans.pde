

enum Status{
  INF,
  RCV,
  NINF,
  DEAD
}

public class Humans {
  float xSpeed; 
  float ySpeed;
  int idx;
  int r;
  int g;
  int b;
  boolean quarentena=false;
  boolean isolamento = false;
  boolean changedvel = false;
 
  float xposi, yposi;
  int circlewidth= 10;
  int creation=0;
  Status stat;
  boolean checkrcv , checkdead;
  
   
  Humans(Status status, int i,float xpos, float ypos){
    stat=status;
    idx=i;
    xposi = xpos;
    yposi = ypos;
    xSpeed = random(-1, 1); 
    ySpeed = random(-1, 1);
    changeColor(stat);
    
    
      
    
   }
 
  
  void update() {
   
    xposi += xSpeed; 
    yposi += ySpeed;  
  }
  
  void checkCollisions() { 
    
    float r = circlewidth/2; 
    
    if ( (xposi<r) || (xposi>width-r)){ 
      xSpeed = -xSpeed; 
    }  
    
    if( (yposi<r) || (yposi>height-r-100)) { 
      ySpeed = -ySpeed;  
    }
    if(quarentena){
      if(isolamento){
        if(xposi < width -120 +r+1 && (height-300<yposi && yposi < height - 100)){
          xSpeed = -xSpeed;
          
         }
        if(yposi < height - 300 + r+1 && (width-120<xposi&&xposi<width)){
          ySpeed = -ySpeed;
          
        } 
        
      }else{
        if((xposi > width-120-r-1&&(height -300<yposi&&yposi<height - 100))){
           xSpeed = -xSpeed;
          
        }
    
        if(yposi > height -300-r-1 && (width-120<xposi&&xposi<width)){
          ySpeed = -ySpeed;
          
        }
      }
       if(isolamento&&!changedvel){
        ySpeed*=0.2;
        xSpeed*=0.2;
        changedvel=true;
      }else if(changedvel&&!isolamento){
        ySpeed*=5;
        xSpeed*=5;
        changedvel = false;
      }
    }
    
    
    
    
   
    update();
  }
  
  void changeColor(Status stat){
      
     switch(stat) {
      case INF:
        r = 255;
        g = 0;
        b = 0;
       
        break;
      case RCV:
        r =0;
        g =100;
        b =255;
        
        break;
      case NINF:
        g = 105;
        b = 105;
        r = 105;
        
        break;
      case DEAD:
        g = 0;
        b = 0;
        r = 0;
        
        break;
    }
  }
  

  void drawCircle(){
    ellipse(xposi, yposi ,circlewidth,circlewidth);
    fill(r,g,b);
  }
  
  void changeVar(Status statc){
    this.stat = statc;
    changeColor(this.stat);
    if(statc == Status.INF){
      this.startimer();
     
    }
  }
  
  void startimer(){
    this.creation = (int)millis()/1000;
    
  }
   
  boolean checkCollision(Humans other) {
    if(this.calcdist(other)<=circlewidth){
      other.xSpeed=-(other.xSpeed);
      other.ySpeed=-(other.ySpeed);
      this.xSpeed = -(this.xSpeed);
      this.ySpeed = -(this.ySpeed);
      
      
      return true;
    }
   
    return false;
   
    
  }
  
  float calcdist(Humans other){
    float distx = other.xposi - this.xposi;
    float disty = other.yposi - this.yposi;
    float distx2 = pow(distx , 2); 
    float disty2 = pow(disty , 2); 
    float catetos = distx2 + disty2;
    float result =  sqrt(catetos);
    return result;
  }
  
  
  
 
  
}
