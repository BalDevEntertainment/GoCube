using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsComponent : MonoBehaviour {

	public Button AdsButton;

	public string placementId = "rewardedVideo";

	void Start ()
	{
		if (AdsButton) AdsButton.onClick.AddListener(ShowAd);
	}

	void Update ()
	{
		if (AdsButton) AdsButton.interactable = Advertisement.IsReady(placementId);
	}

	void ShowAd ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
}
