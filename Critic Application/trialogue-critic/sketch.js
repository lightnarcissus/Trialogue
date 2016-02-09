var graphicsSlider;
var gameplaySlider;
var audioSlider;
var valueSlider;
var overallSlider;
var totalScore=0;
var scoresSubmitted=0;
var overallScore=0;
var metaScore=0;
//var socket;
function setup() {
  // create canvas
  createCanvas(1920, 1080);
  textSize(15)
  noStroke();

  //input
 // socket=io.connect('http://trialogue-critic.herokuapp.com');

  

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
  clear();
  
  scoresSubmitted++;
  console.log(overallScore);
  var reviewComment=input.value();
  console.log("nice");
  totalScore+=overallScore;
  metaScore=(totalScore/scoresSubmitted)*10;
  text("from "+scoresSubmitted+ " ratings",165,316);
  text("Metascore: "+int(metaScore),165,347);
  text("Your Review: \n"+reviewComment, 165, 377);
  sendScore(overallScore);
//  input.value=null;

}
 
function draw() {
  var graphicsScore = graphicsSlider.value();
  var gameplayScore = gameplaySlider.value();
  var audioScore = audioSlider.value();
  var valueScore = valueSlider.value();
  overallScore = overallSlider.value();

//  totalScore+=overallScore;
 // background(256,256,128);
  text("Graphics", 165, 135);
  text("Gameplay", 165, 165);
  text("Audio", 165, 195);
  text("Value", 165, 225);
  text("Overall", 165, 255);

//  text("Total Score"+totalScore,165,316)

// socket.on('score',
//     // When we receive data
//     function(data) {
//       console.log("Got Score: " + data);
//       // Draw a blue circle
//       fill(0,0,255);
//       noStroke();
//       text("SCORE:" + data, 165, 397);
//     }
//   );

}

function sendScore(score)
{
 // socket.emit('score', score);
  console.log("My score is: "+score);
}