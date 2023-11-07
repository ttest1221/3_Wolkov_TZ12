using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private bool _isRed;
    [SerializeField] private bool _isEgg;

    private bool isDroped = false;
    private Rigidbody2D _rigidbody;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnMouseUp()
    {
        if(isDroped == false)
        {
            if (_isRed == true)
            {
                _gameManager.time--;
                _gameManager.TextsUpdate();
            }
            if (_isEgg == true)
                _gameManager.GameOver();
            if (_isRed == false && _isEgg == false)
            {
                _gameManager.score++;
                _gameManager.time++;
            }
            isDroped = true;
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.gravityScale = 1;
            _rigidbody.AddForce(new Vector2(50f, 50f));
            _gameManager.bullets++;
            _gameManager.TextsUpdate();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DownWall")
            Destroy(this.gameObject);
    }
}
