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

    
    public void TakeDmg(int dmg, NetworkConnectionToClient client)
    {
        health -= dmg;
        Rpc_ShareHealthInfo(health);
        Rpc_UpdatePlayerHealth(client, health);
    }


    [TargetRpc]
    public void Rpc_UpdatePlayerHealth(NetworkConnectionToClient client, int newHealth)
    {
        hpText.text = newHealth.ToString() + "/100";
    }

    [ClientRpc]
    public void Rpc_ShareHealthInfo(int newHealth)
    {
        print("player has " + newHealth + "left!");
    }

    public void KillScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
