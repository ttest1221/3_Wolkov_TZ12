using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject _hole;

    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnMouseUp()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        var hole = Instantiate(_hole, new Vector3(x, y, 0), transform.localRotation);
        hole.transform.SetParent(this.transform);
        _gameManager.bullets++;
        _gameManager.TextsUpdate();
    }
}
