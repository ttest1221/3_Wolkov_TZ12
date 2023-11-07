using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bullets;
    [SerializeField] private Text _time;
    [SerializeField] private Text _gameOverScore;
    [SerializeField] private Text _gameOverBestScore;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _gamePrototype;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _menuScreen;

    private GameObject game;
    public int score;
    public int bestScore;
    public int bullets;
    public int time;

    private void Update()
    {
        if (time == 0)
            GameOver();
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        time--;
        TextsUpdate();
        StartCoroutine(Timer());
    }
    public void ShowGame()
    {
        score = 0;
        time = 10;
        bullets = 0;
        _gameScreen.SetActive(true);
        _menu.SetActive(true);
        _menuScreen.SetActive(false);
        game = Instantiate(_gamePrototype, new Vector3(0.004548237f, 2.018868f, 11.03652f), new Quaternion(0, 0, 0, 0));
        StartCoroutine(Timer());
        TextsUpdate();
    }
    public void HideGame()
    {
        _gameScreen.SetActive(false);
        _menuScreen.SetActive(true);
    }
    
    public void TextsUpdate()
    {
        _scoreText.text = "Score :" + score.ToString();
        _bullets.text = "Bullets :" + bullets.ToString();
        _time.text = "Time :" + time.ToString();
        _gameOverScore.text = "Текущий счет " +  score.ToString();
        _gameOverBestScore.text = "Лучший счет " + bestScore.ToString();
    }
    public void GameOver()
    {
        StopAllCoroutines();
        _menu.SetActive(false);
        if (bestScore < score)
            bestScore = score;
        TextsUpdate();
        Destroy(game);
        HideGame();
        
        
    }
    
}
