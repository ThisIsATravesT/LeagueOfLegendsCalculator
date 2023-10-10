using System.Collections.Generic;
using LeagueCalculator.Classes;

namespace LeagueCalculator.Champs
{
    public class Aatrox : ChampBase
    {
        public int currentLevel;
        public Dictionary<int, double> passiveDamageAtEachLevel;

        public Dictionary<int, double> QDamageCast1AtEachLevel;
        public Dictionary<int, double> QAdScalingCast1AtEachLevel;
        public Dictionary<int, double> QDamageCast2AtEachLevel;
        public Dictionary<int, double> QAdScalingCast2AtEachLevel;
        public Dictionary<int, double> QDamageCast3AtEachLevel;
        public Dictionary<int, double> QAdScalingCast3AtEachLevel;

        public Dictionary<int, double> WDamageAtEachLevel;
        public Dictionary<int, double> WAdScalingAtEachLevel;

        public Dictionary<int, double> EDamageAtEachLevel;
        public Dictionary<int, double> EAdScalingAtEachLevel;

        public Dictionary<int, double> RDamageAtEachLevel;
        public Dictionary<int, double> RAdScalingAtEachLevel;

        public Dictionary<int, double> EstimatedBaseQWERDamageAtEachLevel;

        public Aatrox()
        {
            currentLevel = 1;
            passiveDamageAtEachLevel = new Dictionary<int, double>();
            QDamageCast1AtEachLevel = new Dictionary<int, double>();
            QAdScalingCast1AtEachLevel = new Dictionary<int, double>();
            QDamageCast2AtEachLevel = new Dictionary<int, double>();
            QAdScalingCast2AtEachLevel = new Dictionary<int, double>();
            QDamageCast3AtEachLevel = new Dictionary<int, double>();
            QAdScalingCast3AtEachLevel = new Dictionary<int, double>();
            WDamageAtEachLevel = new Dictionary<int, double>();
            WAdScalingAtEachLevel = new Dictionary<int, double>();
            EDamageAtEachLevel = new Dictionary<int, double>();
            EAdScalingAtEachLevel = new Dictionary<int, double>();
            RDamageAtEachLevel = new Dictionary<int, double>();
            RAdScalingAtEachLevel = new Dictionary<int, double>();
            EstimatedBaseQWERDamageAtEachLevel = new Dictionary<int, double>();

            SetBaseStats(580, 3, 0, 0, 38, 32, 60, 0, 175, 345, 0.651, 19.737, 0, 2.5);
            SetAllStatsAtEachLevel(644.8, 712.75, 3.72, 4.47, 0, 0, 0, 0, 40.34, 42.79, 32.9, 33.84, 63.6, 67.38, 175, 175, 345, 345, 0.651, 0.651, 19.737, 19.737, 0, 0, 1.8, 3.69);
            CreatePassive();
            CreateQ();
            CreateW();
            CreateE();
            CreateR();
            CalculateEstBaseQWERDamageAtEachLevel();
        }

        public void CreatePassive()
        {
            passiveDamageAtEachLevel = CalculateStatAtEachLevel(passiveDamageAtEachLevel, 5, 5.41, 5.82);
        }

        // Values based on sweet-spot damage
        public void CreateQ()
        {
            QDamageCast1AtEachLevel = CalculateStatAtEachLevel(QDamageCast1AtEachLevel, 16, 48, 80, 5);
            QAdScalingCast1AtEachLevel = CalculateStatAtEachLevel(QAdScalingCast1AtEachLevel, 96, 104, 112, 5);

            QDamageCast2AtEachLevel = CalculateStatAtEachLevel(QDamageCast2AtEachLevel, 20, 60, 100, 5);
            QAdScalingCast2AtEachLevel = CalculateStatAtEachLevel(QAdScalingCast2AtEachLevel, 120, 130, 140, 5);

            QDamageCast3AtEachLevel = CalculateStatAtEachLevel(QDamageCast3AtEachLevel, 24, 72, 120, 5);
            QAdScalingCast3AtEachLevel = CalculateStatAtEachLevel(QAdScalingCast3AtEachLevel, 144, 156, 168, 5);
        }

        // Values based on tether not broken bonus
        public void CreateW()
        {
            WDamageAtEachLevel = CalculateStatAtEachLevel(WDamageAtEachLevel, 60, 80, 100, 5);
            WAdScalingAtEachLevel = CalculateStatAtEachLevel(WAdScalingAtEachLevel, 80, 80, 80, 5);
        }

        // Utility skill
        public void CreateE()
        {
            EDamageAtEachLevel = CalculateStatAtEachLevel(EDamageAtEachLevel, 0, 0, 0, 5);
            EAdScalingAtEachLevel = CalculateStatAtEachLevel(EAdScalingAtEachLevel, 0, 0, 0, 5);
        }

        // Utility skill
        public void CreateR()
        {
            RDamageAtEachLevel = CalculateStatAtEachLevel(RDamageAtEachLevel, 0, 0, 0, 5);
            RAdScalingAtEachLevel.Add(1, 20);
            RAdScalingAtEachLevel.Add(2, 30);
            RAdScalingAtEachLevel.Add(3, 40);
        }

        // Based on typical skill order (build from blitz.gg and/or op.gg)
        // Q E W Q Q R Q E Q E R E E W W R W W
        public void CalculateEstBaseQWERDamageAtEachLevel()
        {
            EstimatedBaseQWERDamageAtEachLevel.Add(1, GetBaseQDamageTotalForChainAtLevel(1, 1));
            EstimatedBaseQWERDamageAtEachLevel.Add(2, GetBaseQDamageTotalForChainAtLevel(2, 1));
            EstimatedBaseQWERDamageAtEachLevel.Add(3, (GetBaseQDamageTotalForChainAtLevel(3, 1) + GetBaseWDamageTotalForChainAtLevel(3, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(4, (GetBaseQDamageTotalForChainAtLevel(4, 2) + GetBaseWDamageTotalForChainAtLevel(4, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(5, (GetBaseQDamageTotalForChainAtLevel(5, 3) + GetBaseWDamageTotalForChainAtLevel(5, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(6, (GetBaseQDamageTotalForChainAtLevelWithRActive(6, 3, 1) + GetBaseWDamageTotalForChainAtLevelWithRActive(6, 1, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(7, (GetBaseQDamageTotalForChainAtLevelWithRActive(7, 4, 1) + GetBaseWDamageTotalForChainAtLevelWithRActive(7, 1, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(8, (GetBaseQDamageTotalForChainAtLevelWithRActive(8, 4, 1) + GetBaseWDamageTotalForChainAtLevelWithRActive(8, 1, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(9, (GetBaseQDamageTotalForChainAtLevelWithRActive(9, 5, 1) + GetBaseWDamageTotalForChainAtLevelWithRActive(9, 1, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(10, (GetBaseQDamageTotalForChainAtLevelWithRActive(10, 5, 1) + GetBaseWDamageTotalForChainAtLevelWithRActive(10, 1, 1)));
            EstimatedBaseQWERDamageAtEachLevel.Add(11, (GetBaseQDamageTotalForChainAtLevelWithRActive(11, 5, 2) + GetBaseWDamageTotalForChainAtLevelWithRActive(11, 1, 2)));
            EstimatedBaseQWERDamageAtEachLevel.Add(12, (GetBaseQDamageTotalForChainAtLevelWithRActive(12, 5, 2) + GetBaseWDamageTotalForChainAtLevelWithRActive(12, 1, 2)));
            EstimatedBaseQWERDamageAtEachLevel.Add(13, (GetBaseQDamageTotalForChainAtLevelWithRActive(13, 5, 2) + GetBaseWDamageTotalForChainAtLevelWithRActive(13, 1, 2)));
            EstimatedBaseQWERDamageAtEachLevel.Add(14, (GetBaseQDamageTotalForChainAtLevelWithRActive(14, 5, 2) + GetBaseWDamageTotalForChainAtLevelWithRActive(14, 2, 2)));
            EstimatedBaseQWERDamageAtEachLevel.Add(15, (GetBaseQDamageTotalForChainAtLevelWithRActive(15, 5, 2) + GetBaseWDamageTotalForChainAtLevelWithRActive(15, 3, 2)));
            EstimatedBaseQWERDamageAtEachLevel.Add(16, (GetBaseQDamageTotalForChainAtLevelWithRActive(16, 5, 3) + GetBaseWDamageTotalForChainAtLevelWithRActive(16, 3, 3)));
            EstimatedBaseQWERDamageAtEachLevel.Add(17, (GetBaseQDamageTotalForChainAtLevelWithRActive(17, 5, 3) + GetBaseWDamageTotalForChainAtLevelWithRActive(17, 4, 3)));
            EstimatedBaseQWERDamageAtEachLevel.Add(18, (GetBaseQDamageTotalForChainAtLevelWithRActive(18, 5, 3) + GetBaseWDamageTotalForChainAtLevelWithRActive(18, 5, 3)));
        }

        public double GetBaseQDamageTotalForChainAtLevel(int champLevel, int skillLevel)
        {
            double cast1 = QDamageCast1AtEachLevel[skillLevel] + (attackDamageAtEachLevel[champLevel] * QAdScalingCast1AtEachLevel[skillLevel] / 100);
            double cast2 = QDamageCast2AtEachLevel[skillLevel] + (attackDamageAtEachLevel[champLevel] * QAdScalingCast2AtEachLevel[skillLevel] / 100);
            double cast3 = QDamageCast3AtEachLevel[skillLevel] + (attackDamageAtEachLevel[champLevel] * QAdScalingCast3AtEachLevel[skillLevel] / 100);

            return cast1 + cast2 + cast3;
        }

        public double GetBaseQDamageTotalForChainAtLevelWithRActive(int champLevel, int skillLevel, int rSkillLevel)
        {
            double cast1 = QDamageCast1AtEachLevel[skillLevel] + ((attackDamageAtEachLevel[champLevel] + (attackDamageAtEachLevel[champLevel] * RAdScalingAtEachLevel[rSkillLevel] / 100)) * QAdScalingCast1AtEachLevel[skillLevel] / 100);
            double cast2 = QDamageCast2AtEachLevel[skillLevel] + ((attackDamageAtEachLevel[champLevel] + (attackDamageAtEachLevel[champLevel] * RAdScalingAtEachLevel[rSkillLevel] / 100)) * QAdScalingCast2AtEachLevel[skillLevel] / 100);
            double cast3 = QDamageCast3AtEachLevel[skillLevel] + ((attackDamageAtEachLevel[champLevel] + (attackDamageAtEachLevel[champLevel] * RAdScalingAtEachLevel[rSkillLevel] / 100)) * QAdScalingCast3AtEachLevel[skillLevel] / 100);

            return cast1 + cast2 + cast3;
        }

        public double GetBaseWDamageTotalForChainAtLevel(int champLevel, int skillLevel)
        {
            return WDamageAtEachLevel[skillLevel] + (attackDamageAtEachLevel[champLevel] * WAdScalingAtEachLevel[skillLevel] / 100);
        }

        public double GetBaseWDamageTotalForChainAtLevelWithRActive(int champLevel, int skillLevel, int rSkillLevel)
        {
            return WDamageAtEachLevel[skillLevel] + ((attackDamageAtEachLevel[champLevel] + (attackDamageAtEachLevel[champLevel] * RAdScalingAtEachLevel[rSkillLevel] / 100)) * WAdScalingAtEachLevel[skillLevel] / 100);
        }
    }
}
