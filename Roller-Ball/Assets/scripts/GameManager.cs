using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace vio.rollerballnormal
{
  public class GameManager : MonoBehaviour
  {
    public static GameManager instance;
    public GameObject ballPrefab;
    public Text ScoreText;
    public Text SpawnCubeCountText;

    public GameObject cubePrefab;
    public int MaxScore;
    public int MaxCubesSpawnedPerFrame;
    public float cubeSpeed = 2f;
    private int currentScore;

    private bool spawnCubes;
    GameObject spawnCubeContainer;
    private void Awake()
    {
      if (instance != null && instance != this)
      {
        Destroy(this.gameObject);
        return;
      }
      instance = this;
    }


    private void Start()
    {
      spawnCubeContainer = createContainer("SpawnCubes");
      spawnCubes = false;
      currentScore = 0;
      DisplayScore();
      SpawnBall();
    }


    private GameObject createContainer(string tagName)
    {
      GameObject container = new GameObject();
      container.name = tagName;
      container.transform.parent = this.transform;
      return container;
    }

    private void DisplayScore()
    {
      ScoreText.text = "Score: " + currentScore;
    }

    private void SpawnBall()
    {
      GameObject spawnedInstance = MonoBehaviour.Instantiate(
                  ballPrefab,
                  new Vector3(0f, 5f, 0f),
                  Quaternion.identity
                );
      spawnedInstance.transform.parent = this.transform;
      Camera.instance.playerBall = spawnedInstance;
    }

    private void Update()
    {
      if (!spawnCubes && (currentScore >= MaxScore))
      {
        spawnCubes = true;
        StartCoroutine(SpawnCubesRoutine());
      }

      SpawnCubeCountText.text = "Spawn Cube Count: " + this.spawnCubeContainer.transform.childCount;
    }

    IEnumerator SpawnCubesRoutine()
    {
      while (spawnCubes)
      {
        for (int i = 0; i < MaxCubesSpawnedPerFrame; i++)
        {
          SpawnCube();
        }
        yield return null;
      }
    }

    private void SpawnCube()
    {
      GameObject spawnedInstance = MonoBehaviour.Instantiate(
                  cubePrefab,
                  new Vector3(0f, 0.5f, 0f),
                  Quaternion.identity
                );
      spawnedInstance.transform.parent = this.transform;
      Rigidbody rb = spawnedInstance.GetComponent<Rigidbody>();
      rb.velocity += Vector3.up * cubeSpeed;
      spawnedInstance.transform.parent = this.spawnCubeContainer.transform;
    }

    public void IncreaseScore()
    {
      currentScore++;
      DisplayScore();
    }

  }
}