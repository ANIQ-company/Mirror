using Mirror;
using TMPro;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    [SyncVar] public int health = 100;
    [SyncVar] public int score = 0;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;


    public void DestroyPlayer()
    {
        transform.position = Vector3.zero;
        health = 100;
        hpText.text = health.ToString() + "/100";
    }

    public void TakeDmg(int dmg)
    {
        health -= dmg;
        hpText.text = health.ToString() + "/100";
    }

    public void KillScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
