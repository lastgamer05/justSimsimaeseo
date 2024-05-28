using System;

namespace Text_Baseball
{
    public class Setting
    {
        //int command = Program.Pitcher.pitcher.command;
        //int ballSpeed = Program.Pitcher.pitcher.ballSpeed;

        //int contact = Program.Batter.batter.contact;
        //int battingEye = Program.Batter.batter.battingEye;

        public static float prob_Strike = 50 + (float)(Program.Pitcher.pitcher.command / 2.5);
        public static float prob_Ball = 100 - prob_Strike;
        public static float prob_Hit = 100 + Program.Batter.batter.contact - Program.Pitcher.pitcher.ballSpeed - (Program.Pitcher.pitcher.command / 2);

        public Setting()
        {

        }
    }
}
