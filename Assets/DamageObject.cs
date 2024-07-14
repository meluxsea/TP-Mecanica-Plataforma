using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageObject : MonoBehaviour
{

    public Vector3 respawnPosition = new Vector3(0, 0, 0); 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            StartCoroutine(RespawnPlayer(collision.gameObject));
        }
    }

    private IEnumerator RespawnPlayer(GameObject player)
    {
        player.SetActive(false); 
        yield return new WaitForSeconds(2); 
        player.transform.position = respawnPosition; 
        player.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
