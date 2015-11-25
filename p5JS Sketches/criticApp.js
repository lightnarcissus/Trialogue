var graphicsSlider;
var gameplaySlider;
var audioSlider;
var valueSlider;
var overallSlider;

function setup() {
  // create canvas
  createCanvas(710, 400);
  textSize(15)
  noStroke();

  // create sliders
  graphicsSlider = createSlider(0, 255, 100);
  graphicsSlider.position(120, 120);
  gameplaySlider = createSlider(0, 255, 0);
  gameplaySlider.position(120, 150);
  audioSlider = createSlider(0, 255, 255);
  audioSlider.position(120, 180);
  valueSlider = createSlider(0, 255, 255);
  valueSlider.position(120, 210);
  overallSlider = createSlider(0, 255, 255);
  overallSlider.position(120, 240);
}
 
function draw() {
  var graphicsScore = graphicsSlider.value();
  var gameplayScore = gameplaySlider.value();
  var audioScore = audioSlider.value();
  var valueScore = valueSlider.value();
  var overallScore = overallSlider.value();
//  background(r, g, b);
  text("Graphics", 165, 135);
  text("Gameplay", 165, 165);
  text("Audio", 165, 195);
  text("Value", 165, 225);
  text("Overall", 165, 255);

}