import random


global strike, ball, out
strike = 0
ball = 0
out = 0

def initCount():
    global strike, ball
    strike = 0
    ball = 0


class Pitcher:
    def __init__(self, ballSpeed, command, ballStrength, hp):
        self.ballSpeed = ballSpeed # 헛스윙 확률이 높아짐
        self.command = command # 스트 확률, 헛스윙 확률, 땅볼 확률이 높아짐
        self.ballStrength = ballStrength # 뜬공 확률 높아짐
        self.hp = hp # 낮아질수록 위 스탯들 낮아짐

    def pitch(self, course):
        '''prob_strike = 50 + (self.command / 2.5)
        prob_ball = 100 - prob_strike
        prob_deadBall = prob_ball * 0.2
        prob_wildPitch = prob_ball * 0.1

        rand = random.randrange(100)

        if rand < prob_strike:
            print("스트라이크")'''
        courseNum = 0
        if course == 1: # 상단 스윙
            courseNum = 1
        elif course == 2: # 중단 스윙
            courseNum = 2
        else: # 하단 스윙
            courseNum = 3
        return courseNum



class Batter:
    def __init__(self, power, contact, speed, battingEye):
        self.power = power # 장타, 홈런을 칠 확률이 높아짐
        self.contact = contact # 스윙 시에 공을 맞출 확률이 높아짐
        self.speed = speed # 주루 플레이 성공 확률이 높아짐
        self.battingEye = battingEye # 볼인 공을 골라낼 확률이 높아짐


def swing(batter_choice, pitcher_choice, accruracy):
    global strike, ball, out
    if batter_choice == pitcher_choice:
        rand = random.randint(0, 100)
        if rand < accruracy:
            print("안타!")
            initCount()
        else:
            print("땅볼 아웃!")
            initCount()
            out += 1
    else:
        print("헛스윙!")
        strike += 1


def batterMode(p1, b1):
    is3Out = False
    isOnBase = False

    global strike, ball, out

    if strike == 3:
        out += 1
    if out == 3:
        is3Out = True

    while not is3Out and not isOnBase:
        print()
        print("{}s {}b {}out".format(strike, ball, out))
        print("타석에 들어섰다!")
        print("1. 스윙한다")
        print("2. 지켜본다")
        choice = int(input())
        print()

        if choice == 1:
            pitcher_choice = random.randint(1, 3)
            print("1. 상단스윙")
            print("2. 중단스윙")
            print("3. 하단스윙")
            batter_choice = int(input())
            accuracy = 100 + b1.contact - p1.ballSpeed - p1.command # 안타, 홈런칠 확률
            swing(batter_choice, pitcher_choice, accuracy)
    return is3Out



def game():
    print("1. 타자모드")
    print("2. 투수모드 (아직 준비중)")
    choice = int(input())
    print()

    if choice == 1:
        pitcher1 = Pitcher(50, 50, 50, 50)

        while True:
            print("능력치를 설정해 주세요 (합이 200 이하여야 함)")
            power = int(input("파워 : "))
            contact = int(input("컨택 : "))
            speed = int(input("스피드 : "))
            battingEye = int(input("선구안 : "))
            statSum = power + contact + speed + battingEye

            if statSum <= 200:
                break;


        batter1 = Batter(power, contact, speed, battingEye)

        batterMode(pitcher1, batter1)




game()


