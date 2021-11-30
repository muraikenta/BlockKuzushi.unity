using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

public class GameMaster : MonoBehaviour
{

    void Awake()
    {
        GameState.reset();
        GameState.score.Where(value => value >= Constants.BlockCount).Subscribe(value =>
        {
            GameOver();
        });
    }

    void FixedUpdate()
    {
        GameState.time.Value += Time.deltaTime;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }
}