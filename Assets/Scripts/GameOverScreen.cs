
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public Text time;
    // Start is called before the first frame update
    public void Setup(float PlayingTime)
    {
        gameObject.SetActive(true);
        if (PlayingTime < 60)
        {
            time.text = (PlayingTime).ToString() + "   SECONDS";
        }
        else
        {

            time.text = (PlayingTime/60).ToString() + "   MINUTS";
        }
       
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
