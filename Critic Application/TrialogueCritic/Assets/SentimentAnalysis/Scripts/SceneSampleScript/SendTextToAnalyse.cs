using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using UnitySentiment;

public class SendTextToAnalyse : MonoBehaviour {

	public GameObject oscControl;

	public SentimentAnalysis predictionObject ;
	public InputField textToSend;

	public Image ChangeSentimentalColor;
	public Color PositiveResponse;
	public Color NegativeResponse;
	public Color NeutralResponse;

	public Text PositivePercent;
	public Text NegativePercent;
	public Text NeutralPercent;

	private bool responseFromThread = false;
	private bool threadStarted = false;
	private Vector3 SentimentAnalysisResponse;

	private int randSlider=0;
	public Slider graphics;
	public Slider gameplay;
	public Slider audio;
	public Slider value;
	public Slider overall;

	public Image gameplayFill;
	public Image graphicsFill;
	public Image audioFill;
	public Image valueFill;
	public Image overallFill;

	public Color offColor;
	public Color negativeColor;
	public Color onColor;

	void OnEnable() 
	{
		
		Application.runInBackground = true;
		overallFill.color = offColor;
		graphicsFill.color = offColor;
		gameplayFill.color = offColor;
		audioFill.color = offColor;
		valueFill.color = offColor;
		// Initialize the local database
		predictionObject.Initialize();
		// Listedn to the Events
		// Sentiment analysis response
		SentimentAnalysis.OnAnlysisFinished += GetAnalysisFromThread;
		// Error response
		SentimentAnalysis.OnErrorOccurs += Errors;

		InvokeRepeating ("DecreaseInterest", 1f, 5f);
	}

	void OnDestroy()
	{
		// Unload Listeners
		SentimentAnalysis.OnAnlysisFinished -= GetAnalysisFromThread;
		SentimentAnalysis.OnErrorOccurs -= Errors;
	}

	public void SendPredictionText()
	{
		// Thread-safe computations
		predictionObject.PredictSentimentText(textToSend.text);

		if (!threadStarted)
		{// Thread Started
			threadStarted = true;
			StartCoroutine(WaitResponseFromThread());
		}

		//send text to Player
		oscControl.GetComponent<oscControl_Critic> ().HeadlineChanged ();
	}

	// Sentiment Analysis Thread
	private void GetAnalysisFromThread(Vector3 analysisResult)
	{		
		SentimentAnalysisResponse = analysisResult;
		responseFromThread = true;
		//trick to call method to the main Thread
	}

	private IEnumerator WaitResponseFromThread()
	{
		while(!responseFromThread) // Waiting For the response
		{
			yield return null;
		}
		// Main Thread Action
		PrintAnalysis();
		// Reset
		responseFromThread = false;
		threadStarted = false;
	}

	private void PrintAnalysis()
	{
		PositivePercent.text = SentimentAnalysisResponse.x + " % : Positive"; 
		NegativePercent.text = SentimentAnalysisResponse.y + " % : Negative";
		NeutralPercent.text = SentimentAnalysisResponse.z + " % : Neutral";

		randSlider = Random.Range (0, 5);
		if ( SentimentAnalysisResponse.x >  SentimentAnalysisResponse.y &&  SentimentAnalysisResponse.x >  SentimentAnalysisResponse.z)
		{
			switch (randSlider) {
			case 0:
				overallFill.color = onColor;
				graphicsFill.color = offColor;
				gameplayFill.color = offColor;
				audioFill.color = offColor;
				valueFill.color = offColor;
				if (overall.value <= overall.value + (0.2f * (float)textToSend.text.Length))
					overall.value += 0.2f * (float)textToSend.text.Length;
				else
					overall.value = 10;
				break;
			case 1:
				overallFill.color = offColor;
				graphicsFill.color = offColor;
				gameplayFill.color = onColor;
				audioFill.color = offColor;
				valueFill.color = offColor;
				if (gameplay.value <= gameplay.value + (0.2f * (float)textToSend.text.Length))
					gameplay.value += 0.2f * (float)textToSend.text.Length;
				else
					gameplay.value = 10;
				break;

			case 2:
				overallFill.color = offColor;
				graphicsFill.color = onColor;
				gameplayFill.color = offColor;
				audioFill.color = offColor;
				valueFill.color = offColor;
				if (graphics.value <= graphics.value + (0.2f * (float)textToSend.text.Length))
					graphics.value += 0.2f * (float)textToSend.text.Length;
				else
					graphics.value = 10;
				break;
			case 3:
				overallFill.color = offColor;
				graphicsFill.color = offColor;
				gameplayFill.color = offColor;
				audioFill.color = onColor;
				valueFill.color = offColor;
				if (audio.value <= audio.value + (0.2f * (float)textToSend.text.Length))
					audio.value += 0.2f * (float)textToSend.text.Length;
				else
					audio.value = 10;
				break;
			case 4:
				overallFill.color = offColor;
				graphicsFill.color = offColor;
				gameplayFill.color = offColor;
				audioFill.color = offColor;
				valueFill.color = onColor;
				if (value.value <= value.value + (0.2f * (float)textToSend.text.Length))
					value.value += 0.2f * (float)textToSend.text.Length;
				else
					value.value = 10;
				break;
				
			}
			ChangeSentimentalColor.color = PositiveResponse;
//			if (overall.value <= overall.value + (0.2f * (float)textToSend.text.Length))
//				overall.value += 0.2f * (float)textToSend.text.Length;
//			else
//				overall.value = 10;
		}
		else if (SentimentAnalysisResponse.y >  SentimentAnalysisResponse.x &&  SentimentAnalysisResponse.y >  SentimentAnalysisResponse.z)
		{
			ChangeSentimentalColor.color = NegativeResponse;
			switch (randSlider) {
			case 0:
				overallFill.color = negativeColor;
				graphicsFill.color = offColor;
				gameplayFill.color = offColor;
				audioFill.color = offColor;
				valueFill.color = offColor;
				if (overall.value >= overall.value - (0.2f * (float)textToSend.text.Length))
					overall.value -= 0.2f * (float)textToSend.text.Length;
				else
					overall.value = 0;
				break;

			case 1:
				overallFill.color = offColor;
				graphicsFill.color = offColor;
				gameplayFill.color = negativeColor;
				audioFill.color = offColor;
				valueFill.color = offColor;
				if (gameplay.value >= gameplay.value - (0.2f * (float)textToSend.text.Length))
					gameplay.value -= 0.2f * (float)textToSend.text.Length;
				else
					gameplay.value = 0;
				break;

			case 2:
				overallFill.color = offColor;
				graphicsFill.color = negativeColor;
				gameplayFill.color = offColor;
				audioFill.color = offColor;
				valueFill.color = offColor;
				if (graphics.value >= graphics.value - (0.2f * (float)textToSend.text.Length))
					graphics.value -= 0.2f * (float)textToSend.text.Length;
				else
					graphics.value = 0;
				
				break;
			case 3:
				overallFill.color = offColor;
				graphicsFill.color = offColor;
				gameplayFill.color = offColor;
				audioFill.color = negativeColor;
				valueFill.color = offColor;
				if (audio.value >= audio.value - (0.2f * (float)textToSend.text.Length))
					audio.value -= 0.2f * (float)textToSend.text.Length;
				else
					audio.value = 0;
				break;
			case 4:
				overallFill.color = offColor;
				graphicsFill.color = offColor;
				gameplayFill.color = offColor;
				audioFill.color = offColor;
				valueFill.color =negativeColor;
				if (value.value >= value.value - (0.2f * (float)textToSend.text.Length))
					value.value -= 0.2f * (float)textToSend.text.Length;
				else
					value.value = 0;
				break;

			}
			if (overall.value >= overall.value - (0.2f * (float)textToSend.text.Length))
				overall.value -= 0.2f * (float)textToSend.text.Length;
			else
				overall.value = 0;
		}
		else if (SentimentAnalysisResponse.z >  SentimentAnalysisResponse.x &&  SentimentAnalysisResponse.z >  SentimentAnalysisResponse.y)
		{
			ChangeSentimentalColor.color = NeutralResponse;

		}
	}

	void DecreaseInterest(Slider slider)
	{
		if (slider.value >= 1)
			slider.value -= 1;
		else
			slider.value = 0;
	}

	// Sentiment Analysis Thread
	private void Errors(int errorCode, string errorMessage)
	{
		Debug.Log(errorMessage + "\nCode: " + errorCode);
	}
}