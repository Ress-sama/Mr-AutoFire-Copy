using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int hp=100;
    private SpriteRenderer sr;

    private Text textHP;
    private Image hpBar;

    private void Awake()
    {
        textHP = GetComponentInChildren<Text>();
        sr = GetComponent<SpriteRenderer>();
        hpBar = transform.GetChild(1).GetChild(1).GetComponent<Image>();
    }

    private void Update()
    {
        sr.color = Color.Lerp(sr.color,Color.white,0.01f);
    }
    public void GetDamage(int Damage)
    {
        sr.color = Color.red;
        hp -= Damage;
        textHP.text = hp.ToString();
        hpBar.fillAmount = hp / 100.0f;
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }

}
