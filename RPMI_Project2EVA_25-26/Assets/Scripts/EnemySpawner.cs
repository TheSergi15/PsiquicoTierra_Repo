using UnityEngine;
using System.Collections.Generic;

public class LockedDoor : MonoBehaviour
{
    public GameObject enemyPrefab;    // El enemigo que quieres spawnear
    public Transform[] spawnPoints;  // Puntos exactos (círculos azules)
    public LockedDoor DoorToUnlock;  // La puerta que se abrirá al limpiar la sala

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private bool hasSpawned = false;

    public List<GameObject> EnemiesInRoom { get; private set; }

    // Esta función la llamaremos cuando el jugador entre a la habitación
    public void SpawnEnemies()
    {
        if (hasSpawned) return; // No spawnear más de una vez

        foreach (Transform point in spawnPoints)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }

        // Le pasamos la lista de enemigos a la puerta para que sepa a quién vigilar
        if (DoorToUnlock != null)
        {
            DoorToUnlock.EnemiesInRoom = new List<GameObject>(spawnedEnemies);
        }

        hasSpawned = true;
    }
}
