using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;
    [SerializeField] private TMP_Text _scoreText;

    private void Update()
    {
        _scoreText.text = _totalScore.GetScore().ToString();
    }
}
