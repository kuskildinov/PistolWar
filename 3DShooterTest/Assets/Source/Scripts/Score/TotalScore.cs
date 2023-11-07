using UnityEngine;

public class TotalScore : MonoBehaviour
{
    private int _totalScore;

    public void Initialize()
    {
        _totalScore = 0;
        PlayerPrefs.SetInt("TotalScore",_totalScore);
    }

    public void ScoreChanged(int newScore)
    {
        _totalScore += newScore;
        PlayerPrefs.SetInt("TotalScore", _totalScore);
    }

    public int GetScore()
    {
        return _totalScore;
    }
}
