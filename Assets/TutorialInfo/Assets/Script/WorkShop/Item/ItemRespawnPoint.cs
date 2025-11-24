using  UnityEngine;
using System.Collections;

public class ItemRespawnPoint : Item
{
    
    public GameObject[] itemPrefabs;   

    public float respawnTime = 5f;   
    private GameObject currentItem;

    void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        if (currentItem != null) return;

       
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject prefabToSpawn = itemPrefabs[randomIndex];


        currentItem = Instantiate(prefabToSpawn, transform.position, transform.rotation);
        
        
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
}