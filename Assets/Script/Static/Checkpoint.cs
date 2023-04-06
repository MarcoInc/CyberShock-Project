using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

//save manager
public static void savePoint(){
		SaveGame.ActiveCheckpoints();
		SaveGame.SaveX(PlayerController.instance.transform.position.x);
		SaveGame.SaveY(PlayerController.instance.transform.position.y);
		SaveGame.SaveZ(PlayerController.instance.transform.position.z);
		SaveGame.SaveLives(Status.instance.GetLives());
		SaveGame.SavePoints(Status.instance.GetPoints());
		SaveGame.SaveTimer(Status.instance.GetMinutes(), Status.instance.GetSeconds());
	}
}
