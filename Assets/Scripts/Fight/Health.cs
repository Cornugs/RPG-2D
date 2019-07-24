using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int baseHealth;
    private int currentHealth;
    public UnityEvent onDie;
    public int CurrentHealth
    {
        get {
            return currentHealth;
        } set {
            if (value > 0 && value <= baseHealth)
            {
                currentHealth = value;
            } else if (value > baseHealth) {
                currentHealth = baseHealth;
            } else {
                currentHealth = 0;
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = baseHealth;
    }

    public void ModifyCurrentHealth(int quantify)
    {
        CurrentHealth += quantify;
    }
}
