namespace BuckyStates
{
    public enum BuckyMechStates
    {
        Jump, Run, Idle
    }

    public enum BuckShootingStates
    {
        /**
         * U --> UP
         * D --> Down
         * F --> Forward
         * B --> Backward
         * UF --> Up Forward
         * UB --> Up Backward
         * DF --> Down Forward
         * DB --> Down Backward
         */
        
        U, D, F, B, UF, DF, UB, DB
    }
}