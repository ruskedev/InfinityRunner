using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerButton : MonoBehaviour
{
    public static GameControllerButton instance;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnJump() {
        player.OnJump();
    }

    public void OnShoot() {
        player.OnShoot();
    }
}
