using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

    public int Hp;
    public int MaxHp;
    public float invincabilityDelay;
    public float timer;
    public GameObject particleWhenDestoyed;
    public Color flashColor;
    private Color normalColor;
    private SpriteRenderer sprite;
    private CameraShake cam;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        normalColor = sprite.material.color;
        cam = FindObjectOfType<CameraShake>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Hp <= 0 && timer <= 0)
        {
            if(particleWhenDestoyed !=null)
            {
                Instantiate(particleWhenDestoyed, gameObject.transform.position, gameObject.transform.rotation);
            }

            Destroy(gameObject);
            cam.Shake(0.1f, 0.2f);
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }

	}

    public void ChangeHealth(int healthToChange)
    {
        if(timer <= 0)
        {
            Hp += healthToChange;
            timer = invincabilityDelay;
            StartCoroutine("Flash");
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 5; i++)
        {
            sprite.material.color = flashColor;
            yield return new WaitForSeconds(.1f);
            sprite.material.color = normalColor;
            yield return new WaitForSeconds(.1f);
        }
    }
}
