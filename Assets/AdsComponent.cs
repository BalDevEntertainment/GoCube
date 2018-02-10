﻿using System;
using Assets.GoCube.Domain.Ads;
using GoCube.Domain.Provider;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsComponent : MonoBehaviour {

	public Button AdsButton;
	public event Action<ResultType> OnAdsVideoResult = delegate {  };
	public string placementId = "rewardedVideo";
	private AdsService adsService;

	void Start ()
	{
		adsService = ServiceProvider.ProvideAdsService();
		if (AdsButton) AdsButton.onClick.AddListener(ShowAd);
	}

	void Update ()
	{
		if (AdsButton) AdsButton.interactable = Advertisement.IsReady(placementId);
	}

	void ShowAd () {
		adsService.VideoAdExecuted += result => { OnAdsVideoResult(result.ResultType); };
		adsService.PlayVideoReward();
	}
}
