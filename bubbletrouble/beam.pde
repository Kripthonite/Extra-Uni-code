public class beam{
  float x,y,ySpeed;
  float yact;
  int creation ;
  boolean enlarge=false;
  
  public beam(float x , float y ,float ySpeed){
    this.x=x;
    this.y=y;
    this.ySpeed=ySpeed;
    yact = y;
    this.creation = (int)millis()/1000;
  }
  
  public void updateBeam(){
     yact = yact + ySpeed;
     
  }
  
  public void drawBeam(boolean enlarge){
    y = enlarge ? height : y;
    updateBeam();
    strokeWeight(2);
    stroke(color(255,0,0));
    
    line(x,y,x,yact);
  }
  
  
  
  public boolean collide(ball bola){
    
   float r = bola.size/2; 
   // temporary variables to set edges for testing
  float testX = bola.x;
  float testY = bola.y;

  // which edge is closest?
  if (bola.x < x - 1)         testX = x -1;      // test left edge
  else if (bola.x > x + 1) testX = x +1;   // right edge
  if (bola.y < yact )         testY = yact;      // top edge
  else if (bola.y > y) testY = y;   // bottom edge

  // get distance from closest edges
  float distX = bola.x-testX;
  float distY = bola.y-testY;
  float distance = sqrt( (distX*distX) + (distY*distY) );

  // if the distance is less than the radius, collision!
  if (distance <= r) {
    return true;
  }
  return false;
   
   
 
  }
  
  
  public boolean collide(PowerUps pwr){
    if(!(yact<pwr.y + pwr.alt)){return false;}
    if(!(x > pwr.x && x < pwr.x + pwr.lg)){return false;}
    
    return true;
  }
  
 
}
