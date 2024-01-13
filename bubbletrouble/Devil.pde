public class Devil{
  public int xposi , yposi;
  public int dvlwidth , dvlheight;
  public int dvlwidths;
  float xSpeed;
  PImage devile;
  PImage bg;
  
  
 public Devil(int x , int y){
   xposi = x;
   yposi = y;
   
   devile = loadImage("devile.png");
   bg = loadImage("stonewall.jpg");
   dvlwidth =70 ;
   dvlheight = 90;
 }
  
  public void updatePos(float xSpeed, float ySpeed , boolean fasten){
   this.xSpeed = xSpeed;
   if(xposi + xSpeed > 0 && xposi + xSpeed < width-50){
     if(fasten){
       xSpeed =xSpeed * 2;
     }
     xposi += xSpeed; 
     yposi += ySpeed;  
    }
 }
 
 public boolean CollideWball(ball bola){
   float r = bola.size/2; 
   // temporary variables to set edges for testing
  float testX = bola.x;
  float testY = bola.y;

  // which edge is closest?
  if (bola.x < xposi + 10)         testX = xposi + 10;      // test left edge
  else if (bola.x > xposi+dvlwidth-20) testX = xposi+dvlwidth - 20;   // right edge
  if (bola.y < yposi + 15)         testY = yposi + 15;      // top edge
  else if (bola.y > yposi+dvlheight) testY = yposi + dvlheight;   // bottom edge

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
    
     
  
  public void drawDvl(){
    
   //declaration
    image(bg, 0, 0);
    PImage fuse = get( xposi , yposi , dvlwidth , dvlheight);
    
    //resizing
    bg.resize(width,height);
    
    //dvlwidths = slim ? 40:dvlwidth;
    
    devile.resize(dvlwidth , dvlheight);
    fuse.resize(dvlwidth , dvlheight);
    //show
    PImage newImg = createImage( devile.width, devile.height, ARGB );
    
    //image(fuse,xposi , yposi , dvlwidth , dvlheight); 
    
    for( int x = 0; x < devile.width; x++ ){
  for( int y = 0; y < devile.height; y++ ){
    int i = ( ( y * devile.width ) + x );
    if( devile.pixels[i] == color(255,255,255) ){
      newImg.pixels[i] = fuse.pixels[i];
    } 
    else {
      newImg.pixels[i] = devile.pixels[i];
    }
  }
}
stroke(0);
image(newImg,xposi , yposi );



    
    
    
      
    
    
   
  }
  
 
  
  
}
