using System;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private Player player;
        private Monster monster;

        public Game()
        {
            player = new Player();
            monster = new Monster();
        }

        public void Start()
        {
            Console.WriteLine("텍스트 RPG 게임에 오신 것을 환영합니다!");

            while (true)
            {
                Console.WriteLine("\n1. 몬스터와 싸우기");
                Console.WriteLine("2. 상태 보기");
                Console.WriteLine("3. 게임 종료");
                Console.Write("선택: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Fight();
                        break;
                    case "2":
                        ShowStatus();
                        break;
                    case "3":
                        Console.WriteLine("게임을 종료합니다.");
                        return;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                        break;
                }
            }
        }

        private void Fight()
        {
            Console.WriteLine("\n몬스터가 나타났습니다!");

            while (player.IsAlive && monster.IsAlive)
            {
                Console.WriteLine("1. 공격하기");
                Console.WriteLine("2. 도망가기");
                Console.Write("선택: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.Attack(monster);
                    if (monster.IsAlive)
                    {
                        monster.Attack(player);
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("도망쳤습니다!");
                    return;
                }
                else
                {
                    Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                }
            }

            if (!player.IsAlive)
            {
                Console.WriteLine("플레이어가 쓰러졌습니다. 게임 오버!");
                Environment.Exit(0);
            }
            else if (!monster.IsAlive)
            {
                Console.WriteLine("몬스터를 물리쳤습니다!");
                player.GainExperience(10);
                monster.Respawn();
            }
        }

        private void ShowStatus()
        {
            Console.WriteLine($"\n플레이어 상태:");
            Console.WriteLine(player);
        }
    }

    class Character
    {
        public int Health { get; protected set; }
        public bool IsAlive => Health > 0;

        public Character(int health)
        {
            Health = health;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{GetType().Name}가 {damage}만큼의 피해를 입었습니다. 남은 체력: {Health}");
        }
    }

    class Player : Character
    {
        public int Level { get; private set; }
        public int Experience { get; private set; }

        public Player() : base(100)
        {
            Level = 1;
            Experience = 0;
        }

        public void Attack(Monster monster)
        {
            Console.WriteLine("플레이어가 몬스터를 공격했습니다!");
            monster.TakeDamage(10);
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
            Console.WriteLine($"플레이어가 {exp}만큼의 경험치를 얻었습니다. 총 경험치: {Experience}");

            if (Experience >= 100)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            Health = 100;
            Experience = 0;
            Console.WriteLine("레벨 업! 레벨이 {0}이 되었습니다.", Level);
        }

        public override string ToString()
        {
            return $"레벨: {Level}, 체력: {Health}, 경험치: {Experience}";
        }
    }

    class Monster : Character
    {
        public Monster() : base(50)
        {
        }

        public void Attack(Player player)
        {
            Console.WriteLine("몬스터가 플레이어를 공격했습니다!");
            player.TakeDamage(10);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (!IsAlive)
            {
                Console.WriteLine("몬스터가 쓰러졌습니다.");
            }
        }

        public void Respawn()
        {
            Health = 50;
            Console.WriteLine("새로운 몬스터가 나타났습니다!");
        }
    }
}
