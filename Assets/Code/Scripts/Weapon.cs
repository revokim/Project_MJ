namespace MJ.Weapon
{
    // 모든 종류의 무기에 공통적으로 들어가는 요소들을 지정합니다.
    public class Weapon
    {
        private float _weaponDamage; // 공격력
        private float _attackInterval; // 공격 속도
        private float _tickDamageRate; // 지속 피해 주기
        private float _weaponDurability; // 내구도
        private int _weaponLevel; // 무기 레벨 (강화 레벨)
    }

    public class DummyWeapon : Weapon
    {
        private int _dummyVar;
    }
}