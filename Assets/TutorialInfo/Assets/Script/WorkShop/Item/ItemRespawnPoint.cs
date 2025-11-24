using UnityEngine;
using System.Collections;

public class ItemRespawnPoint : Item
{
    public GameObject[] itemPrefabs;

    public float respawnTime = 5f;

    [Header("Respawn Area")]
    public Vector3 areaSize = new Vector3(5f, 0f, 5f);  // ขนาดของพื้นที่สุ่ม

    private GameObject currentItem;

    void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        if (currentItem != null) return;

        // สุ่มตำแหน่งภายในกรอบ
        Vector3 randomOffset = new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2),
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        Vector3 spawnPos = transform.position + randomOffset;

        // เลือก prefab แบบสุ่ม
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject prefabToSpawn = itemPrefabs[randomIndex];

        // สร้างไอเท็ม
        currentItem = Instantiate(prefabToSpawn, spawnPos, transform.rotation);

        // เชื่อม event pickup
        ItemPickup pickup = currentItem.GetComponent<ItemPickup>();
        if (pickup != null)
        {
            pickup.onPickedUp += OnItemPickedUp;
        }
    }

    void OnItemPickedUp()
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
            currentItem = null;
        }

        StartCoroutine(RespawnAfterDelay());
    }

    IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnItem();
    }

    // แสดงกรอบใน Scene View
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }
}