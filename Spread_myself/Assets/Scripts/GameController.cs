using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public Factor player, enemy;
    public int children=0;
    [SerializeField]
    private GameObject gameClear, gameOver, Dead;
    [SerializeField]
    private Slider playerHp, enemyHp;
    private bool clear = false, over = false, dead = false;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        playerHp.value = Player.instance.GetPower() / 3;
        enemyHp.value = Enemy.instance.GetPower() / 3;
    }

    public void GameClear()
    {
        if (over || !dead) return;
        gameClear.SetActive(true);
        clear = true;
    }

    public void GameOver()
    {
        if (clear) return;
        gameOver.SetActive(true);
        over = true;
    }

    public void EnemyDead()
    {
        dead = true;
        Dead.SetActive(true);
        if (children == 0) GameClear();
    }

}
