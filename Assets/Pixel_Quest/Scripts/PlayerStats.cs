using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class PlayerStats : MonoBehaviour
{
    public int CoinCounter = 0;
    public int Health = 3;
    public int _maxHealth = 3;
    public Transform respawnPoint;
    private PlayerUIController _playerUIController;

    private void Start()
    {
        _playerUIController = GetComponent<PlayerUIController>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    Health--;
                    _playerUIController.UpdateHealth(Health, _maxHealth);
                    if (Health <= 0)
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                    }
                    else
                    {
                        transform.position = respawnPoint.position;
                    }
                    break;
                }
            case "Finish":
                {
                    string nextLevel = collision.GetComponent<LevelGoal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    CoinCounter++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (Health < 3)
                    {
                        Health++;
                        Destroy(collision.gameObject);
                    }
                    _playerUIController.UpdateHealth(Health, _maxHealth);
                    break;
                }
            case "Respawn":
                {
                    respawnPoint.position = collision.transform.Find("Point").position;
                    break;
                }
        }
    }
}

