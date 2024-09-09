using UnityEngine;
using UnityEngine.UI;

public class stam : MonoBehaviour
{

    [SerializeField, Header(" Настройки здоровья ")] private float health = 1;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Text hpT;
    [SerializeField] private int hpotn;
    void Start()
    {
        hpT.text = "Здоровье: " + health.ToString();
    }
    void Update()
    {
        Regen();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Applebad")
        {
            health = health - hpotn;
            hpT.text = "Здоровье:" + health.ToString();
            Destroy(other.gameObject);
            
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            hpT.text = "Умер";
        }
    }
    void Regen()
    {
        if (health < maxHealth)
        {
            health = health + 1 * Time.deltaTime;
            hpT.text = "Здоровье:" + health.ToString();
        }
        if (health > maxHealth)
        {
            health = maxHealth;
            hpT.text = "Здоровье:" + health.ToString();
        }
    }
}
