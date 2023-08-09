using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour, IObgectDestroy
{
    [SerializeField] private TriggerDamage _triggerDamage;
    [SerializeField] private float _lifeTime;
    private Vector3 _defaultPosition;

    private void Awake()
    {
        _defaultPosition = transform.localPosition;
        _triggerDamage.Init(this);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }

    public void Destroy(GameObject gameObject)
    {
        gameObject.SetActive(false);
        transform.localPosition = _defaultPosition;
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
