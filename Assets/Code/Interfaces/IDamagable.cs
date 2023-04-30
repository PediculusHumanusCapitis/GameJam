interface IDamagable
{
    int MaxHealth { get; set; }
    void ApplyDamage(int countDamage);
}
