using UnityEngine;
using UnityEngine.UI;

public class stam : MonoBehaviour
{

    [SerializeField, Header(" ��������� �������� ")] private float health = 1;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Text hpT;
    [SerializeField] private int hpotn;
    void Start()
    {
        hpT.text = "��������: " + health.ToString();
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
            hpT.text = "��������:" + health.ToString();
            Destroy(other.gameObject);
            
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            hpT.text = "����";
        }
    }
    void Regen()
    {
        if (health < maxHealth)
        {
            health = health + 1 * Time.deltaTime;
            hpT.text = "��������:" + health.ToString();
        }
        if (health > maxHealth)
        {
            health = maxHealth;
            hpT.text = "��������:" + health.ToString();
        }
    }
}
