namespace Text_Baseball
{
    public class Program
    {
        public static int m_strike, m_ball, m_outCount = 0;
        public static bool m_is3Out, m_isOnBase = false;

        public class Pitcher
        {
            public static Pitcher pitcher = new Pitcher();

            public int ballSpeed, command, ballStrength, hp;

            public Pitcher()
            {
                ballSpeed = 0;
                command = 0;
                ballStrength = 0;
                hp = 0;
            }

            public void createRandPitcher()
            {
                Random random = new Random();

                ballSpeed = random.Next(40, 51);
                command = random.Next(40, 51);
                ballStrength = random.Next(40, 51);
                hp = random.Next(40, 51);
            }
        }

        public class Batter
        {
            public static Batter batter = new Batter();

            public int power, contact, speed, battingEye;

            public Batter()
            {
                power = 0;
                contact = 0;
                speed = 0;
                battingEye = 0;
            }

            public static void swing()
            {
                Random rand = new Random();
                string pitcher_choice = Convert.ToString(rand.Next(1, 4));

                Console.WriteLine("\n1. 상단스윙");
                Console.WriteLine("2. 중단스윙");
                Console.WriteLine("3. 하단스윙");

                string batter_choice = Console.ReadLine();

                if (batter_choice == pitcher_choice)
                {
                    int rando = rand.Next(0, 100);
                    if (rando < Setting.prob_Hit)
                    {
                        Console.WriteLine("\n안타!");
                        init_Count();
                        m_isOnBase = true;
                    }
                    else
                    {
                        Console.WriteLine("\n유격수 앞 땅볼!");
                        init_Count();
                        m_outCount++;
                    }
                }
                else
                {
                    Console.WriteLine("\n헛스윙!");
                    m_strike++;
                }

                check_Count();
            }

            public static void looking()
            {
                Random random = new Random();
                int rand = random.Next(0, 100);
                
                if(rand < Setting.prob_Strike)
                {
                    Console.WriteLine("스트라이크!");
                    m_strike++;
                }
                else
                {
                    Console.WriteLine("볼");
                    m_ball++;
                }

                check_Count();
            }
        }

        public static void init_Count()
        {
            m_strike = 0;
            m_ball = 0;
        }
        public static void init_Setting()
        {
            m_strike = 0;
            m_ball = 0;
            m_outCount = 0;
            m_isOnBase = false;
            m_is3Out = false;
        }
        public static void check_Count()
        {
            if (m_strike == 3)
            {
                Console.WriteLine("삼진!");
                init_Count();
                m_outCount++;

            }
            if (m_outCount == 3)
            {
                Console.WriteLine("쓰리아웃!");
                init_Count();
                m_is3Out = true;
            }
            if (m_ball == 4)
            {
                Console.WriteLine("볼넷!");
                init_Count();
                m_isOnBase = true;
            }
        }

        

        static Batter createStat(Batter batter)
        {
            while (true)
            {
                Console.WriteLine("능력치를 설정해주세요 (합이 250이하여야 함)");
                Console.Write("파워 : ");
                string stpower = Console.ReadLine();
                Console.Write("컨택 : ");
                string stcontact = Console.ReadLine();
                Console.Write("주루 : ");
                string stspeed = Console.ReadLine();
                Console.Write("선구안 : ");
                string stbattingEye = Console.ReadLine();

                int power = Convert.ToInt32(stpower);
                int contact = Convert.ToInt32(stcontact);
                int speed = Convert.ToInt32(stspeed);
                int battingEye = Convert.ToInt32(stbattingEye);
                int sumStat = power + contact + speed + battingEye;

                batter.power = power;
                batter.contact = contact;
                batter.speed = speed;
                batter.battingEye = battingEye;

                if(sumStat <= 250 && sumStat > 0)
                {
                    break;
                }
                
            }

            return batter;
        }

        static void createStat(Pitcher pitcher)
        {
            while (true)
            {
                Console.WriteLine("능력치를 설정해주세요 (합이 250이하여야 함)");
                Console.Write("파워 : ");
                string stpower = Console.ReadLine();
                Console.Write("컨택 : ");
                string stcontact = Console.ReadLine();
                Console.Write("주루 : ");
                string stspeed = Console.ReadLine();
                Console.Write("선구안 : ");
                string stbattingEye = Console.ReadLine();

                int power = Convert.ToInt32(stpower);
                int contact = Convert.ToInt32(stcontact);
                int speed = Convert.ToInt32(stspeed);
                int battingEye = Convert.ToInt32(stbattingEye);
                int sumStat = power + contact + speed + battingEye;
                if (sumStat <= 250)
                {
                    break;
                }
            }
        }

        static void batterMode(Batter batter, Pitcher pitcher)
        {
            pitcher.createRandPitcher();

            Console.WriteLine("타석에 들어섭니다.");
            m_is3Out = false;
            m_isOnBase = false;
            while (m_is3Out == false && m_isOnBase == false)
            {
                situation();
                Console.WriteLine("\n1. 스윙한다");
                Console.WriteLine("2. 지켜본다");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Batter.swing();
                        break;
                    case "2":
                        Batter.looking();
                        break;
                    default:
                        Console.WriteLine("잘못 입력했습니다.");
                        break;
                }
            }
            if(m_is3Out == true)
            {
                Console.WriteLine("\n3OUT이 되었습니다.");
            }
            else if(m_isOnBase == true)
            {
                Console.WriteLine("\n출루에 성공했습니다!");
            }
        }

        static void situation()
        {
            Console.WriteLine($"{m_strike}S {m_ball}B {m_outCount}OUT");
        }

       
        static void Main(string[] args)
        {
            Batter batter = new Batter();
            Pitcher pitcher = new Pitcher();

            while (true)
            {
                init_Setting();

                Console.WriteLine("1. 타자모드");
                Console.WriteLine("2. 투수모드 (아직 준비 안됨)");
                Console.WriteLine("3. 구단모드 (아직 준비 안됨)");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        createStat(batter);
                        batterMode(batter, pitcher);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                }
            }
        }
    }
}