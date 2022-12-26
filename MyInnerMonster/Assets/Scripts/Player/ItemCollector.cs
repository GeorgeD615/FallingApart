using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int candys = 0;
    [SerializeField] private TMPro.TextMeshProUGUI FlowerCounter;
    public CandyCounter _candysFromPrevLevel;

    private void Start()
    {
        candys = _candysFromPrevLevel.candys;
    }

    void Update()
    {
        FlowerCounter.text = candys.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            candys += collision.GetComponent<Candy>().points;
            collision.GetComponent<Candy>().points = 0;
            FindObjectOfType<AudioManager>().Play("candy");
            Destroy(collision.gameObject);
            FlowerCounter.text = candys.ToString();
        }
    }
}

