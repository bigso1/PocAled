using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float hp;
    [SerializeField] protected int fullHP;
    [SerializeField] private bool startDamaged = false;
    [SerializeField] private bool hpLock;
    private float resetHPState;
    [SerializeField] private float origineResetHPState;
    public bool inList;
    public EnnemiesCounter myList; 
    
    protected virtual void Start()
    {
        resetHPState = origineResetHPState;
        if (!startDamaged) hp = fullHP;
    }

    public void TakeDamage(float damages)
    {
        if(hpLock) return;
        hp -= damages;
        if(hp<=0) Nolife();
        //hpLock = true;
    }
    
    protected virtual void Nolife()
    {
        if (inList)
        {
            myList.Removal(this.transform);
        }
    }
}
