using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe")]
    public GameObject pipePrefab;

    [Header("Coin")]
    public GameObject coinPrefab;
    public float coinOffsetX = 0.5f;

    [Header("Spawn Position")]
    public float spawnX = 12f;

    [Header("Pipe Spacing")]
    public float pipeSpacing = 7f;

    [Header("Pipe Gap Height")]
    public float minY = -2f;
    public float maxY = 2f;

    public float pipeGap = 3f;

    [Header("Pipe Speed")]
    public float minSpeed = 3f;
    public float maxSpeed = 6f;

    [Header("Difficulty")]
    public float timeToMaxSpeed = 60f;

    private float spawnTimer = 0f;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = minSpeed;

        SpawnPipe();
    }

    void Update()
    {
        float progress = Mathf.Clamp01(
            Time.timeSinceLevelLoad / timeToMaxSpeed
        );

        currentSpeed = Mathf.Lerp(
            minSpeed,
            maxSpeed,
            progress
        );

        foreach (PipeMovement pipe in PipeMovement.allPipes)
        {
            pipe.SetSpeed(currentSpeed);
        }

        float spawnInterval = pipeSpacing / currentSpeed;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer -= spawnInterval;

            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        // สุ่มตำแหน่งช่อง
        float gapY = Random.Range(minY, maxY);

        // สร้าง Pipe
        GameObject pipe = Instantiate(
            pipePrefab,
            new Vector3(spawnX, gapY, 0f),
            Quaternion.identity
        );

        // ตั้งความเร็ว Pipe
        PipeMovement movement = pipe.GetComponent<PipeMovement>();

        if (movement != null)
        {
            movement.SetSpeed(currentSpeed);
        }

        // หา Grid
        Transform grid = pipe.transform.Find("Grid");

        if (grid != null)
        {
            Transform topPipe = grid.Find("TopPipe");
            Transform bottomPipe = grid.Find("BottomPipe");

            if (topPipe != null)
            {
                topPipe.localPosition = new Vector3(
                    0f,
                    pipeGap / 2f,
                    0f
                );
            }

            if (bottomPipe != null)
            {
                bottomPipe.localPosition = new Vector3(
                    0f,
                    -pipeGap / 2f,
                    0f
                );
            }
        }

        // =========================
        // สร้าง Coin
        // =========================

        if (coinPrefab != null)
        {
            GameObject coin = Instantiate(
                coinPrefab,
                Vector3.zero,
                Quaternion.identity,
                pipe.transform
            );

            coin.transform.localPosition = new Vector3(
                coinOffsetX,
                0f,
                0f
            );
        }
    }
}