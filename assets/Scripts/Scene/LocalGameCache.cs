using UnityEngine;
using System.Collections;

public class LocalGameCache : MonoBehaviour {
	static public GameObject localPlayer;
    static public string localPlayerIndex;
	static public GameObject localTarget;

    static public ArrayList getOtherPlayers() {
        print(localPlayerIndex);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        ArrayList otherPlayers = new ArrayList();
        foreach (GameObject p in players) {
            if(p.GetComponent<PlayerStats>().getPlayerIndex()!=localPlayerIndex) {
                otherPlayers.Add(p);
            }
        }
        return otherPlayers;
    }
}
