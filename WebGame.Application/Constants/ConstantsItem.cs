using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Constants
{
    public static class ConstantsItem
    {
        public const int NAME_MAX_LENGHT = 20;
        public const int DESC_MAX_LENGHT = 100;
        public const int VALUE_MIN = 1;
        public const int ATTACK_MIN = 1;
        public const int ATTACK_SPEED_MIN = 1;
    }

    public static class ConstantsEnemy
    {
        public const int NAME_MAX_LENGHT = 20;
        public const int HEALTH_POINT_MIN = 1;
        public const int ATTACK_MIN = 1;
        public const int EXP_REWARD_MIN = 0;
        public const int CASH_REWARD_MIN = 0;
    }

    public static class ConstantsJob
    {
        public const int NAME_MAX_LENGHT = 20;
        public const int DESC_MAX_LENGHT = 100;
        public const int DURATION_MIN = 1;
        public const int REWARD_MIN = 1;
    }

    public static class ConstantsMission
    {
        public const int NAME_MAX_LENGHT = 20;
        public const int DESC_MAX_LENGHT = 100;
        public const int DURATION_MIN = 1;
        public const int REWARD_MIN = 1;
    }

    public static class ConstantsPlayer
    {
        public const int NAME_MAX_LENGHT = 20;
        public const int DESC_MAX_LENGHT = 100;

        public const int DEFAULT_LEVEL = 1;
        public const int DEFAULT_EXP = 0;
        public const int DEFAULT_SKILL_POINTS = 0;
        public const int DEFAULT_CASH = 0;
        public const int DEFAULT_STRENGHT = 10;
        public const int DEFAULT_DEXTERITY = 10;
        public const int DEFAULT_ENDURANCE = 10;
    }
}