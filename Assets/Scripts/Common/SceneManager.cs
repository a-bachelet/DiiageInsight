using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Player;

    //Instance du joueur dans la scène
    private GameObject _player;

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.Find("Player");
        if (_player == null)
        {
            _player = Instantiate(Player);
            _player.name = "Player";
        }
        _player.transform.SetPositionAndRotation(SpawnPoint.position, SpawnPoint.rotation);
    }
}
