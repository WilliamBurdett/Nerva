using UnityEngine;
using System.Collections;

public class LevelPreferencesScript : MonoBehaviour {
	public float maxHeight;
	public float minHeight;
	public float terrainHeight;

	public float getMaxHeight(){
		return maxHeight;
	}
	
	public float getMinHeight(){
		return minHeight;
	}
	
	public float getTerrainHeight(){
		return terrainHeight;
	}
}
