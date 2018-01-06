using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject player;
    GameObject ragdoll;

	void Start () {
        if(!ShowDeathScreen.isDead)
            ragdoll = Instantiate(player, CharacterController.PlayerPos, transform.rotation);
	}

    private void Update()
    {
        if (!ShowDeathScreen.isDead)
            ragdoll.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, -1), 0.1f);
    }

}
