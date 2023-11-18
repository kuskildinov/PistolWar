using UnityEngine;
using TMPro;

public class FinalScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _finalScore;
   public void Initialize()
    {
        _finalScore = PlayerPrefs.GetInt("TotalScore");
        _scoreText.text = _finalScore.ToString();
    }
}
