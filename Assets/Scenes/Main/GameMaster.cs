using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

public class GameMaster : MonoBehaviour
{

    float nowTime;

    // Use this for initialization
    void Start()
    {
        nowTime = 0;
        ScoreManager.score.Value = 0;
        ScoreManager.score.Where(value => value >= Constants.BlockCount).Subscribe(value =>
        {
            GameOver(nowTime.ToString("F0") + "秒でクリアできた！");
        });
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
    }

    public void GameOver(string resultMessage)
    {
        DataSender.resultMessage = resultMessage;
        SceneManager.LoadScene("ResultScene");
    }
}