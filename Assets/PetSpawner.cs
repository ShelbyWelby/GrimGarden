using UnityEngine;
using Mirror;

public class PetSpawner : NetworkBehaviour
{
    public GameObject petPrefab; // Assign in Inspector

    [Command]
    void CmdSpawnPet()
    {
        GameObject pet = Instantiate(petPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(pet, connectionToClient); // Spawn with client ownership
    }

    void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.P))
        {
            CmdSpawnPet(); // Press P to spawn as the local player
        }
    }
}
