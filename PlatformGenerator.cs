using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 30f;

    [SerializeField] private Transform PlatformGroup1;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;
    public Camera camera;
    private string gameOver = "GameOver";
    public Transform startingPoint;

    private Vector3 lastEndingPoint;

    private void Awake() {

        lastEndingPoint = startingPoint.position;
    } 

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndingPoint) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnPlatformGroup();
        }

        if (camera.transform.position.y > player.transform.position.y + 10)
        {
            SceneManager.LoadScene("GameOver");
        }

}

        private void SpawnPlatformGroup()
        {
            Transform randPlatformGroup = levelPartList[Random.Range(0, levelPartList.Count)];
            Transform PlatformGroupTransform = SpawnPlatformGroup(randPlatformGroup, lastEndingPoint);
            lastEndingPoint = PlatformGroupTransform.Find("EndingPoint").position;
        }
        private Transform SpawnPlatformGroup(Transform platformGroup, Vector3 SpawnPosition) 
        {  
        Transform platformTransform = Instantiate(platformGroup, SpawnPosition, Quaternion.identity);
            return platformTransform;
        }
  
}

