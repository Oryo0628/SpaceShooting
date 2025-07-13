using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public Image[] heartImages; // ハートUIの配列（Inspectorで設定）
    public GameOverUI gameOverUI;

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHearts();

        if (currentHP <= 0)
        {
            GameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = i < currentHP;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.ShowGameOverUI();
        gameObject.SetActive(false); // プレイヤーを非アクティブにして操作不能にする
    }
}
