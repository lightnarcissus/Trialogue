var graphicsSlider;
var gameplaySlider;
var audioSlider;
var valueSlider;
var overallSlider;
var totalScore=0;
var scoresSubmitted=0;
var overallScore=0;
var myFont;
var metaScore=0;
//var socket;
function setup() {
  // create canvas
  createCanvas(1920, 1080);
  textSize(15)
  noStroke();
  myFont=loadFont('assets/Quicksand_Bold.otf', drawText);

  //input
 // socket=io.connect('http://trialogue-critic.herokuapp.com');

  

  input=createInput();
  input.position(width/2+100, height/2+285);

  button = createButton('Submit');
  button.position(width/2+250, height/2+285);
   button.mousePressed(comment);

  // create sliders
  graphicsSlider = createSlider(0, 10, 7);
  graphicsSlider.position(width/2+120, height/2+120);
  gameplaySlider = createSlider(0, 10, 7);
  gameplaySlider.position(width/2+120, height/2+150);
  audioSlider = createSlider(0, 10, 7);
  audioSlider.position(width/2+120, height/2+180);
  valueSlider = createSlider(0, 10, 7);
  valueSlider.position(width/2+120, height/2+210);
  overallSlider = createSlider(0, 10, 7);
  overallSlider.position(width/2+120, height/2+240);
}

function comment()
{
  clear();
  drawText();
  scoresSubmitted++;
  console.log(overallScore);
  var reviewComment=input.value();
   textFont(myFont,20);
  console.log("nice");
  totalScore+=overallScore;
  metaScore=(totalScore/scoresSubmitted)*10;
  text("from "+scoresSubmitted+ " ratings",width/2+165,height/2+316);
  text("Metascore: "+int(metaScore),width/2+165,height/2+347);
  text("Your Review: \n"+reviewComment, width/2+165,height/2+ 377);
  sendScore(overallScore);
//  input.value=null;

}

function drawText()
{
   textFont(myFont,20);
  text("Graphics", width/2+125, height/2+145);
  text("Gameplay",width/2+ 125, height/2+175);
  text("Audio", width/2+125, height/2+205);
  text("Value",width/2+ 125, height/2+235);
  text("Overall",width/2+ 125,height/2+ 265);
}
 
function draw() {
  var graphicsScore = graphicsSlider.value();
  var gameplayScore = gameplaySlider.value();
  var audioScore = audioSlider.value();
  var valueScore = valueSlider.value();
  overallScore = overallSlider.value();

//  totalScore+=overallScore;
 // background(256,256,128);


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