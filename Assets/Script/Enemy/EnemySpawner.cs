using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy spawn manager
public class EnemySpawner : MonoBehaviour {

	private const float DISTANCE_TO_PLAYER = 120f;

	[SerializeField] GameObject Enemy;
	[SerializeField] int numEnemy;
	[SerializeField] Transform Spawner;

	public float TimeToSpawn = 1.5f;
	private float TimeLastSpawn;

	private GameObject player;
	private float distanceToEnemy;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		distanceToEnemy = (player.transform.position - this.transform.position).sqrMagnitude;		//controllo se il player si avvicina abbastanza allo spawner

		if(distanceToEnemy < DISTANCE_TO_PLAYER){
			if((Time.time > (TimeToSpawn + TimeLastSpawn)) && numEnemy > 0){
				Instantiate(Enemy,Spawner.position,Spawner.rotation);
				TimeLastSpawn = Time.time;
				numEnemy --;
			}
			if(numEnemy == 0){
				Destroy(this.gameObject);
			}
		}
	}
}
