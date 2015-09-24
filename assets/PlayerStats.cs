using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    private string playerIndex;

    void OnStart() {
        playerIndex = Network.player.ToString();
    }

    public string getPlayerIndex() {
        return playerIndex;
    }
}
