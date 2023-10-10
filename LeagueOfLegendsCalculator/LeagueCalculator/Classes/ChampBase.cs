using System.Collections.Generic;

namespace LeagueCalculator.Classes
{
    public class ChampBase
    {
        public ChampStats baseStats;
        public Dictionary<int, double> healthAtEachLevel;
        public Dictionary<int, double> healthRegenAtEachLevel;
        public Dictionary<int, double> resourceAtEachLevel;
        public Dictionary<int, double> resourceRegenAtEachLevel;
        public Dictionary<int, double> armorAtEachLevel;
        public Dictionary<int, double> magicResistAtEachLevel;
        public Dictionary<int, double> attackDamageAtEachLevel;
        public Dictionary<int, double> abilityPowerAtEachLevel;
        public Dictionary<int, double> critDamageAtEachLevel;
        public Dictionary<int, double> moveSpeedAtEachLevel;
        public Dictionary<int, double> attackSpeedAtEachLevel;
        public Dictionary<int, double> attackWindUpAtEachLevel;
        public Dictionary<int, double> attackSpeedRatioAtEachLevel;
        public Dictionary<int, double> attackSpeedBonusAtEachLevel;

        public ChampBase()
        {
            baseStats = new ChampStats();
            healthAtEachLevel = new Dictionary<int, double>();
            healthRegenAtEachLevel = new Dictionary<int, double>();
            resourceAtEachLevel = new Dictionary<int, double>();
            resourceRegenAtEachLevel = new Dictionary<int, double>();
            armorAtEachLevel = new Dictionary<int, double>();
            magicResistAtEachLevel = new Dictionary<int, double>();
            attackDamageAtEachLevel = new Dictionary<int, double>();
            abilityPowerAtEachLevel = new Dictionary<int, double>();
            critDamageAtEachLevel = new Dictionary<int, double>();
            moveSpeedAtEachLevel = new Dictionary<int, double>();
            attackSpeedAtEachLevel = new Dictionary<int, double>();
            attackWindUpAtEachLevel = new Dictionary<int, double>();
            attackSpeedRatioAtEachLevel = new Dictionary<int, double>();
            attackSpeedBonusAtEachLevel = new Dictionary<int, double>();
        }

        public void SetBaseStats(double hp, double hp5, double re, double re5, double armor, double mr, double ad, 
            double ap, double crit, double ms, double atkSpd, double windUp, double atkSpdRatio, double atkSpdBonus)
        {
            baseStats.health = hp;
            baseStats.healthRegen = hp5;
            baseStats.resource = re;
            baseStats.resourceRegen = re5;
            baseStats.armor = armor;
            baseStats.magicResist = mr;
            baseStats.attackDamage = ad;
            baseStats.abilityPower = ap;
            baseStats.critDamage = crit;
            baseStats.moveSpeed = ms;
            baseStats.attackSpeed = atkSpd;
            baseStats.attackWindUp = windUp;
            baseStats.attackSpeedRatio = atkSpdRatio;
            baseStats.attackSpeedBonus = atkSpdBonus;
        }

        public void CalculateHealthAtEachLevel(double hpAtLvl2, double hpAtLvl3)
        {
            healthAtEachLevel = CalculateStatAtEachLevel(healthAtEachLevel, baseStats.health, hpAtLvl2, hpAtLvl3);
        }

        public void CalculateHealthRegenAtEachLevel(double hpRegnAtLvl2, double hpRegnAtLvl3)
        {
            healthRegenAtEachLevel = CalculateStatAtEachLevel(healthRegenAtEachLevel, baseStats.healthRegen, hpRegnAtLvl2, hpRegnAtLvl3);
        }

        public void CalculateResourceAtEachLevel(double reAtLvl2, double reAtLvl3)
        {
            resourceAtEachLevel = CalculateStatAtEachLevel(resourceAtEachLevel, baseStats.health, reAtLvl2, reAtLvl3);
        }

        public void CalculateResourceRegenAtEachLevel(double reRegnAtLvl2, double reRegnAtLvl3)
        {
            resourceRegenAtEachLevel = CalculateStatAtEachLevel(resourceRegenAtEachLevel, baseStats.resourceRegen, reRegnAtLvl2, reRegnAtLvl3);
        }

        public void CalculateArmorAtEachLevel(double armorAtLvl2, double armorAtLvl3)
        {
            armorAtEachLevel = CalculateStatAtEachLevel(armorAtEachLevel, baseStats.armor, armorAtLvl2, armorAtLvl3);
        }

        public void CalculateMagicResistAtEachLevel(double mrAtLvl2, double mrAtLvl3)
        {
            magicResistAtEachLevel = CalculateStatAtEachLevel(magicResistAtEachLevel, baseStats.magicResist, mrAtLvl2, mrAtLvl3);
        }

        public void CalculateAttackDamageAtEachLevel(double adAtLvl2, double adAtLvl3)
        {
            attackDamageAtEachLevel = CalculateStatAtEachLevel(attackDamageAtEachLevel, baseStats.attackDamage, adAtLvl2, adAtLvl3);
        }

        public void CalculateAbilityPowerAtEachLevel()
        {
            abilityPowerAtEachLevel = CalculateStatAtEachLevel(abilityPowerAtEachLevel, 0, 0, 0);
        }

        public void CalculateCritDamageAtEachLevel(double critAtLvl2, double critAtLvl3)
        {
            critDamageAtEachLevel = CalculateStatAtEachLevel(critDamageAtEachLevel, baseStats.critDamage, critAtLvl2, critAtLvl3);
        }

        public void CalculateMoveSpeedAtEachLevel(double msAtLvl2, double msAtLvl3)
        {
            moveSpeedAtEachLevel = CalculateStatAtEachLevel(moveSpeedAtEachLevel, baseStats.moveSpeed, msAtLvl2, msAtLvl3);
        }

        public void CalculateAttackSpeedAtEachLevel(double asAtLvl2, double asAtLvl3)
        {
            attackSpeedAtEachLevel = CalculateStatAtEachLevel(attackSpeedAtEachLevel, baseStats.attackSpeed, asAtLvl2, asAtLvl3);
        }

        public void CalculateAttackWindUpAtEachLevel(double windAtLvl2, double windAtLvl3)
        {
            attackWindUpAtEachLevel = CalculateStatAtEachLevel(attackWindUpAtEachLevel, baseStats.attackWindUp, windAtLvl2, windAtLvl3);
        }

        public void CalculateAttackSpeedRatioAtEachLevel(double asRAtLvl2, double asRAtLvl3)
        {
            attackSpeedRatioAtEachLevel = CalculateStatAtEachLevel(attackSpeedRatioAtEachLevel, baseStats.attackSpeedRatio, asRAtLvl2, asRAtLvl3);
        }

        public void CalculateAttackSpeedBonusAtEachLevel(double asBonusAtLvl2, double asBonusAtLvl3)
        {
            attackSpeedBonusAtEachLevel = CalculateStatAtEachLevel(attackSpeedBonusAtEachLevel, baseStats.attackSpeedBonus, asBonusAtLvl2, asBonusAtLvl3);
        }

        public void SetAllStatsAtEachLevel(double hpAtLvl2, double hpAtLvl3, double hpRegnAtLvl2, double hpRegnAtLvl3, double reAtLvl2, double reAtLvl3, double reRegnAtLvl2, double reRegnAtLvl3,
            double armorAtLvl2, double armorAtLvl3, double mrAtLvl2, double mrAtLvl3, double adAtLvl2, double adAtLvl3, double critAtLvl2, double critAtLvl3, double msAtLvl2, double msAtLvl3,
            double asAtLvl2, double asAtLvl3, double windAtLvl2, double windAtLvl3, double asRAtLvl2, double asRAtLvl3, double asBonusAtLvl2, double asBonusAtLvl3)
        {
            CalculateHealthAtEachLevel(hpAtLvl2, hpAtLvl3);
            CalculateHealthRegenAtEachLevel(hpRegnAtLvl2, hpRegnAtLvl3);
            CalculateResourceAtEachLevel(reAtLvl2, reAtLvl3);
            CalculateResourceRegenAtEachLevel(reRegnAtLvl2, reRegnAtLvl3);
            CalculateArmorAtEachLevel(armorAtLvl2, armorAtLvl3);
            CalculateMagicResistAtEachLevel(mrAtLvl2, mrAtLvl3);
            CalculateAttackDamageAtEachLevel(adAtLvl2, adAtLvl3);
            CalculateAbilityPowerAtEachLevel();
            CalculateCritDamageAtEachLevel(critAtLvl2, critAtLvl3);
            CalculateMoveSpeedAtEachLevel(msAtLvl2, msAtLvl3);
            CalculateAttackSpeedAtEachLevel(asAtLvl2, asAtLvl3);
            CalculateAttackWindUpAtEachLevel(windAtLvl2, windAtLvl3);
            CalculateAttackSpeedRatioAtEachLevel(asRAtLvl2, asRAtLvl3);
            CalculateAttackSpeedBonusAtEachLevel(asBonusAtLvl2, asBonusAtLvl3);
        }

        public Dictionary<int, double> CalculateStatAtEachLevel(Dictionary<int, double> statAtEachLevel, double baseStat, double statAtLvl2, double statAtLvl3, int? levels = 18)
        {
            if (statAtLvl2 == 0 && statAtLvl3 == 0)
            {
                for (int i = 1; i <= levels; i++)
                {
                    statAtEachLevel.Add(i, 0);
                }
            }
            else
            {
                double lvl2Flat = statAtLvl2 - baseStat;
                double lvl3Flat = statAtLvl3 - statAtLvl2;
                double growVal = lvl3Flat - lvl2Flat;

                statAtEachLevel.Add(1, baseStat);
                statAtEachLevel.Add(2, statAtLvl2);
                statAtEachLevel.Add(3, statAtLvl3);

                int numRuns = 2;

                for (int i = 4; i <= levels; i++)
                {
                    numRuns++;
                    statAtEachLevel.Add(i, (statAtEachLevel[i - 1] + (lvl2Flat + (growVal * numRuns))));
                }
            }

            return statAtEachLevel;
        }
    }
}
