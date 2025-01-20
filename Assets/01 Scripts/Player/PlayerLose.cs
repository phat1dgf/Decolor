using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLose : MonoBehaviour,IGetHit
{
    [SerializeField] GameOverManager _gameOverCanvas;
    [SerializeField] float _playerHP = 10;
    [SerializeField] Slider _playerHealthBar;
    [SerializeField] GameObject _player;
   

    Coroutine waitPlayerDie;
    private void Start()
    {   
        waitPlayerDie = StartCoroutine(WaitingForDie());
    }
    private void Update()
    {
        HealthBarUpdate();
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverCanvas.GameOver();
    }

    public void GetHit(float dmg)
    {
        if (_playerHP <= 0) GameOver();
        this._playerHP -= dmg * Time.deltaTime * 2;
    }
    IEnumerator WaitingForDie()
    {
        yield return new WaitUntil(() => this._playerHP <= 0);
        this.GameOver();
    }
    private void OnDisable()
    {
        if (waitPlayerDie != null)
        {
            StopCoroutine(waitPlayerDie);
            waitPlayerDie = null;
        }
    }
    private void OnDestroy()
    {
        if (waitPlayerDie != null)
        {
            StopCoroutine(waitPlayerDie);
            waitPlayerDie = null;
        }
    }
    private void HealthBarUpdate()
    {
        if (_player.transform.localScale.x == -1)
        {
            _playerHealthBar.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            _playerHealthBar.transform.localScale = Vector3.one;
        }
        _playerHealthBar.value = _playerHP;
    }
}
