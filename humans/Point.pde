public class Point{
  
  float x;
  float y;
  float scaledx;
  float scaledy;
  float MAX = 100;
  float pop = 50;
  float scalingx = (width -120) / MAX;
  float scalingy=90/pop;
  Status stat;
  
  
  Point(float x , float y, Status stat){
   this.x = x;
   this.y = y;
   this.stat=stat;
   
   getText();
   
   
  }
  
  
  
  float getY(){
    return this.y;
  }
  
  float getX(){
    return this.x;
  }
  
  Status getStat(){
    return this.stat;
  }
  
  void drawPoint(){
    
    switch(this.stat){
      case DEAD:
        fill(0);
        stroke(0);
        break;
      case INF:
        fill(color(255,0,0));
        stroke(color(255,0,0));
        break;
      case RCV:
        fill(color(0,100,255));
        stroke(color(0,100,255));
        break;
      case NINF:
        stroke(color(105,105,105));
        fill(color(105,105,105));
        break;
        
    }
    scaleCircle();
    circle(scaledx,scaledy,3);
    line(scaledx,scaledy,scaledx,height);
    
  }
  
  void drawREC(){
    int xdraw;
    int ydraw;
    switch(this.stat){
      case DEAD:
        fill(0);
        stroke(0);
        
       break;
      case INF:
        fill(color(255,0,0));
        stroke(color(255,0,0));
        break;
      case RCV:
        fill(color(0,100,255));
        stroke(color(0,100,255));
        
        break;
      case NINF:
        stroke(color(105,105,105));
        fill(color(105,105,105));
        break;
        
    }
    
     
   
    
  }
  
  void translate(float x , float y){
    this.y =(float) height - y; 
    this.x = (float) x;
    
  }
  
  void scaleCircle(){
    
    scaledy = height - (y * scalingy );
    scaledx = x * scalingx;
  }
  void getText(){
    System.out.println(getX() + " " + getY() + " " + getStat());
  }
  
}
