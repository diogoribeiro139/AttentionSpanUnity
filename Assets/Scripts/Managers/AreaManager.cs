using UnityEngine;
using System.Collections.Generic;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance { get; private set; }
    private HashSet<GameObject> playersInTrigger = new HashSet<GameObject>();

    [Header("Configuração da Área")]
    public Transform exitPoint; // Posição para onde os jogadores serão teleportados
    public Collider2D triggerZone; // Trigger da área

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playersInTrigger.Contains(other.gameObject))
        {
            playersInTrigger.Add(other.gameObject);
            CheckPlayers();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrigger.Remove(other.gameObject);
        }
    }

    private void CheckPlayers()
    {
        if (playersInTrigger.Count == 4) // Só muda de área se os 4 jogadores estiverem no trigger
        {
            MovePlayersToNextArea();
        }
    }

    private void MovePlayersToNextArea()
    {
        foreach (GameObject player in playersInTrigger)
        {
            Vector3 newPosition = new Vector3(exitPoint.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = newPosition;
        }

        playersInTrigger.Clear(); // Esvazia a lista para próxima troca de área
    }
}