using UnityEngine;
using UnityEngine.UI;

public class characterplayer : MonoBehaviour
{
    public Rigidbody rb;
    public float rotationSpeed = 10f;
    public float speed = 3f;
    private float minspeed = 3f;
    private float maxspeed = 6f;
    bool doblespeed;
    public int stamina = 1000;
    public int maxstamina = 1000;
    public Text staminaT;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        staminaT.text = "Сила: " + stamina.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        doblespeed = true;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 position = new Vector3(x, 0, y);
        if (position.magnitude > Mathf.Abs(0.01f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(position), Time.deltaTime * rotationSpeed);
        }

        rb.velocity = Vector3.ClampMagnitude(position, 1) * speed;
        rb.angularVelocity = Vector3.zero;
        if (doblespeed = true && Input.GetKey(KeyCode.LeftShift))
        {
            speed = maxspeed;
            stamina -= 2;
            stamina -= 2;
            staminaT.text = $"Сила: {stamina.ToString()}/{maxstamina.ToString()}";

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = minspeed;
        }
        if (stamina == maxstamina)
        {
            staminaT.text = $"Бодрячком: {stamina.ToString()}";
            doblespeed = true;
            stamina = maxstamina;
        }


        if (stamina < maxstamina)
        {
            staminaT.text = $"Сила: {stamina.ToString()}/{maxstamina.ToString()}";
            stamina++;
            if (stamina < 1)
            {
                stamina = 0;
                staminaT.text = "Сразу видно прогуливал";
                doblespeed = false;
                speed = minspeed;
            }
        }
    }
    public bool Checkstamin()
    {
        return doblespeed;
    }
}

