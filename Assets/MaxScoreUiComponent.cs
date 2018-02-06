using System.Collections;
using System.Collections.Generic;
using GoCube.Domain.Provider;
using GoCube.Domain.Score;
using UnityEngine;
using UnityEngine.UI;

public class MaxScoreUiComponent : MonoBehaviour {

	private ScoreService _scoreService;
	private Text _maxScoreText;

	void Start()
	{
		_scoreService = ServiceProvider.ProvideScore();
		_scoreService.MaxScoreReached += OnMaxScoreChanged;
		_maxScoreText = GetComponent<Text>();
		_maxScoreText.text = "Max Score: " + _scoreService.FindMaxScore().ToString("0000");
	}

	private void OnDestroy()
	{
		_scoreService.MaxScoreReached -= OnMaxScoreChanged;
		_scoreService.ClearScore();
	}

	private void OnMaxScoreChanged(int score)
	{
		_maxScoreText.text = "Max Score: " + score.ToString("0000");
	}
}
