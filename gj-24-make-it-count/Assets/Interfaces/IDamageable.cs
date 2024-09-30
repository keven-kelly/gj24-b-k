using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    public int Health {  get; set; }
    public bool Targetable { get; set; }
    public bool Invinceible { get; set; }
    public void OnHit(int damage, Vector2 knockback);
    public void OnHit(int damage);
    public void OnObjectDestroyed();

}
