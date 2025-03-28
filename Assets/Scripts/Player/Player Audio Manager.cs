using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerAudioManager : MonoBehaviour
{
    public GameObject[] players; // Array com os 4 jogadores
    private StudioListener[] fmodListeners = new StudioListener[4];

    void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            // Criar um GameObject para simular um Audio Listener do FMOD para cada jogador
            GameObject listenerObject = new GameObject("FMOD_Listener_Player" + (i + 1));
            listenerObject.transform.parent = players[i].transform; // Anexa ao jogador
            listenerObject.transform.localPosition = Vector3.zero;

            // Adicionar o componente de listener do FMOD
            fmodListeners[i] = listenerObject.AddComponent<StudioListener>();
        }

    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            // Atualiza a posição do Listener para cada jogador
            RuntimeManager.SetListenerLocation(players[i]);
        }
    }
}
