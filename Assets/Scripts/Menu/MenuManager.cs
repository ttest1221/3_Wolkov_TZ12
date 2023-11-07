using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager.HideGame();
    }
    public void NewGameClick()
    {
        _gameManager.ShowGame();
    }
}
