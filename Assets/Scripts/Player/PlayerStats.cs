using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int maxHp = 100;

    private Text textHP;
    private Image hpBar;

    private void Awake()
    {
        hp = PlayerData.Health;
        textHP = GetComponentInChildren<Text>();
        hpBar = transform.GetChild(2).GetChild(1).GetComponent<Image>();
        textHP.text = hp.ToString();
        hpBar.fillAmount = hp / 100.0f;
    }
    public void GetDamage(int Damage)
    {
        hp -= Damage;
        textHP.text = hp.ToString();
        hpBar.fillAmount = hp / 100.0f;
        if (hp <= 0)
        {
            GameController.INSTANCE.ShowGameOverScreen();
            Destroy(gameObject);
        }
        PlayerData.Health = hp;
    }

}
