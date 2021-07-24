using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Text scoreText;
    private int score;
    #endregion

    #region Mono
    private void Update()
    {
        this.scoreText.text = this.score.ToString();
    }
    #endregion

    #region Score Up
    public void ScoreUp(int scoreValue)
    {
        this.score += scoreValue;
    }
    #endregion
}
