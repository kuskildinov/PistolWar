public class ScoreRoot : CompositeRoot
{
    public TotalScore _currentPlayerScore;

    public override void Compose()
    {
        _currentPlayerScore.ScoreChanged(0); ;
    }
}
