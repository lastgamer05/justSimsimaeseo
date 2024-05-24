namespace TextRPG
{
    internal class Program
    {

        enum WeaponType
        {
            None = 0,
            Revolver = 1,
            Shotgun = 2,
            Ak47 = 3,
            Sniper = 4,
        }

        enum GunItem
        {
            None = 0,
            Scope = 1, //사정거리 상승
            Compensator = 2, //명중률 상승

        }

        enum HumanItem
        {
            None = 0,

        }

        struct Player
        {
            public int damage; // 한 번 쏠 때 대미지
            public int mobility; // 이동할 수 있는 거리 (칸)
            public int range; // 사정거리 (칸)
            public int accuracy; // 명중률 (%)
        }

        static WeaponType chooseWeapon()
        {
            Console.WriteLine("사용할 총기를 고르시오");
            Console.WriteLine("1. 리볼버");
            Console.WriteLine("2. 샷건");
            Console.WriteLine("3. 소총");
            Console.WriteLine("4. 저격소총");

            WeaponType weaponType = WeaponType.None;

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    weaponType = WeaponType.Revolver;
                    break;
                case "2":
                    weaponType = WeaponType.Shotgun;
                    break;
                case "3":
                    weaponType = WeaponType.Ak47;
                    break;
                case "4":
                    weaponType = WeaponType.Sniper;
                    break;
            }

            return weaponType;
        }

        static void createPlayer(WeaponType weaponType, out Player player)
        {
            switch (weaponType)
            {
                case WeaponType.Revolver:
                    player.damage = 15;
                    player.mobility = 5;
                    player.range = 5;
                    player.accuracy = 70;  // 한 탄창 수도 만들어서 연사 가능하게 했으면 좋겠음
                    break;                 // 저격은 연발 불가, 소총은 연사 많을수록 정확도 떨어지게
                case WeaponType.Shotgun:
                    player.damage = 80;
                    player.mobility = 3;
                    player.range = 2;
                    player.accuracy = 70;
                    break;
                case WeaponType.Ak47:
                    player.damage = 25;
                    player.mobility = 3;
                    player.range = 10;
                    player.accuracy = 60;
                    break;
                case WeaponType.Sniper:
                    player.damage = 80;
                    player.mobility = 1;
                    player.range = 15;
                    player.accuracy = 80;
                    break;
                default:
                    player.damage = 0;
                    player.mobility = 0;
                    player.range = 0;
                    player.accuracy = 0;
                    break;
            }
        }

        static void Move(Player player)
        {
            Console.WriteLine("상 [w], 하 [s], 좌 [a], 우 [d] 를 입력하시오 ex) wdd");
            Console.WriteLine("이동 가능 횟수 : %d", player.mobility);

            string moving = Console.ReadLine();

            while (moving.Length > player.mobility || moving.Length < 1)
            {
                Console.WriteLine("이동 가능 횟수 : %d", player.mobility);
                moving = Console.ReadLine();
            }

            for (int i = 0; i < moving.Length; i++)
            {
                
            }
            
        }
        static void Game()
        {
            Console.WriteLine("0000000000000000000000000"); //25 X 11
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
            Console.WriteLine("0000000000000000000000000");
        }

        static void Main(string[] args)
        {

            Game();
        }
    }
}