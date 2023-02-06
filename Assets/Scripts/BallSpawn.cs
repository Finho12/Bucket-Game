using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{



    // Lista de bolinhas: Publico
   public List<GameObject> prefabs;

    // Ponto de origem: Publico
    public Vector3 originPoint = new Vector3(0, 0, 0);

    // Intervalo
    public float interval = 1;

    // Cooldown
    private float cooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure game is active
        if(!GameManager.Instance.isGameActive){
            return;
        }
        // Spawn ball according to interval
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f){
            cooldown = interval;
            SpawnBall();
        }
    }

    private void SpawnBall(){
        // Get Prefab
        int prefabIndex = Random.Range(0, prefabs.Count);
        GameObject prefab = prefabs[prefabIndex];

        // Get position
        var gameWidth = GameManager.Instance.gameWidth;
        float xOffset = Random.Range(-gameWidth / 2f, gameWidth / 2f);
       Vector3 position = originPoint + new Vector3(xOffset, 0, 0);
        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Spawn Ball
        Instantiate(prefab, position, rotation);

    }
}
