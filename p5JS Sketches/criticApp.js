var graphicsSlider;
var gameplaySlider;
var audioSlider;
var valueSlider;
var overallSlider;
var totalScore=0;
overallScore;
function setup() {
  // create canvas
  createCanvas(710, 400);
  textSize(15)
  noStroke();

  //input

  input=createInput();
  input.position(100, 285);

  button = createButton('Submit');
  button.position(250, 285);
   button.mousePressed(comment);

  // create sliders
  graphicsSlider = createSlider(0, 10, 7);
  graphicsSlider.position(120, 120);
  gameplaySlider = createSlider(0, 10, 7);
  gameplaySlider.position(120, 150);
  audioSlider = createSlider(0, 10, 7);
  audioSlider.position(120, 180);
  valueSlider = createSlider(0, 10, 7);
  valueSlider.position(120, 210);
  overallSlider = createSlider(0, 10, 7);
  overallSlider.position(120, 240);
}

function comment()
{
  console.log(overallScore);
  var reviewComment=input.value();
  console.log("nice");
  totalScore+=overallScore;
  text("Total Score: "+totalScore,165,316)

}
 
function draw() {
  var graphicsScore = graphicsSlider.value();
  var gameplayScore = gameplaySlider.value();
  var audioScore = audioSlider.value();
  var valueScore = valueSlider.value();
  overallScore = overallSlider.value();

//  totalScore+=overallScore;
//  background(r, g, b);
  text("Graphics", 165, 135);
  text("Gameplay", 165, 165);
  text("Audio", 165, 195);
  text("Value", 165, 225);
  text("Overall", 165, 255);

 // text("Total Score"+totalScore,165,316)

}