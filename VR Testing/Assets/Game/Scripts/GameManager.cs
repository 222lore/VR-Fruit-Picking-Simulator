using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<GameObject> objects = new List<GameObject>();
	public List<GameObject> fruitPrefabs = new List<GameObject>();
    public Transform treeLookDir;
    // Start is called before the first frame update
    void Start()
    {
		foreach(GameObject obj in objects) {
			//Debug.Log("X:" + obj.transform.position.x + "Y:" + obj.transform.position.y);
			Vector3 position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
			Quaternion rotation = obj.transform.rotation;
			int fruitSpawningIndex = Random.Range(0, fruitPrefabs.Count);
			GameObject fruit = Instantiate(fruitPrefabs[fruitSpawningIndex],  position, rotation);
            //fruit.transform.LookAt(obj.transform);
            fruit.transform.LookAt(treeLookDir);
            // Quaternion lookRotation = Quaternion.LookRotation(treeLookDir.position);
            // Vector3 rot = Quaternion.Lerp(fruit.transform.rotation, lookRotation, Time.deltaTime).eulerAngles;
            // fruit.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            // Debug.Log("Fruit spawned at " + fruit.transform.position
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
