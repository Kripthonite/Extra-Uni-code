public class ball{
  float x , y ;
  float size;
  float xSpeed;
  float ySpeed;
  float r,g,b;
  ball(float x , float y , float size, float xSpeed , float ySpeed){
    this.x =  x ;
    this.y = y ;
    this.xSpeed = xSpeed;
    this.ySpeed = ySpeed;
    this.size = size;
    this.r = random(255);
    this.g = random(255);
    this.b = random(255);
  }
  
  ball(float x , float y , float size, float xSpeed , float ySpeed , float r , float g , float b){
    this.x =  x ;
    this.y = y ;
    this.xSpeed = xSpeed;
    this.ySpeed = ySpeed;
    this.size = size;
    this.r = r;
    this.g = g;
    this.b = b;
  }
  
   public void updatePos(boolean frozen){
     
     float r = size/2; 
    
    if ( (x<r) || (x>width-r)){ 
      xSpeed = -xSpeed; 
    }  
    
    if( (y<r) || (y>height-r)) { 
      ySpeed = -ySpeed;  
    }
     if(!frozen){
       this.x += xSpeed;
       this.y += ySpeed;
     }
     
   }
   
  void drawBall(){
    stroke(color(r,g,b));
    strokeWeight(1);
    fill(r,g,b);
    circle(x,y,size);
  }
  
 
}
