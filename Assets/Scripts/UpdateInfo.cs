using UnityEngine;
using UnityEngine.UI;

public class UpdateInfo : MonoBehaviour
{
    private Text value;


    private void Awake()
    {
        value = GetComponent<Text>();

    }

    private void LateUpdate()
    {
        if (value != null)
        {
            if (gameObject.name == "NumCoins")
            {
                value.text = GameManager.Instance.coins.ToString();
            }
            else if (gameObject.name == "ScoreValue")
            {
                value.text = GameManager.Instance.score.ToString();
            }
            else if (gameObject.name == "Level")
            {
                value.text = GameManager.Instance.world.ToString() + "-" + GameManager.Instance.stage.ToString();
            }
            else if (gameObject.name == "NumLives")
            {
                value.text = GameManager.Instance.lives.ToString();
            }
        }
        
    }
}
