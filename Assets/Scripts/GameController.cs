using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    private int fruitCount = 0;
    public int winFruitCount = 20; 
    public GameObject winUI; 

    public Vector3 respawnPosition = new Vector3(0, 0, 0);

    // Referencia al jugador para respawn
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddFruit()
    {
        fruitCount++;
        if (fruitCount >= winFruitCount)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        // Mostrar UI de victoria
        if (winUI != null)
        {
            winUI.SetActive(true);
        }
        
        Time.timeScale = 0.5f; 
        StartCoroutine(RestartSceneAfterDelay(2)); 
    }

    private IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); 
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCoroutine());
    }

    private IEnumerator RespawnPlayerCoroutine()
    {
        player.SetActive(false); 
        yield return new WaitForSeconds(2); 
        player.transform.position = respawnPosition; 
        player.SetActive(true); 
    }
}

