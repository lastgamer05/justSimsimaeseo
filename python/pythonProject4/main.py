import random

isSame = True

strike = 0
ball = 0
out = 0

tryNumber = 9


# 무작위 수 추출
while isSame == True:
    ans1 = random.randint(0, 9)
    ans2 = random.randint(0, 9)
    ans3 = random.randint(0, 9)

    if ans1 == ans2 or ans2 == ans3 or ans1 == ans3:
        isSame = True
    else:
        isSame = False

# 무작위 수 리스트로 만들기
listAns = [ans1, ans2, ans3]

#
def pitch(ch1, ch2, ch3):
    global strike
    global ball
    global out

    strike = 0
    ball = 0

    if ch1 in listAns:
        if ch1 == ans1:
            strike += 1
        else:
            ball += 1

    if ch2 in listAns:
        if ch2 == ans2:
            strike += 1
        else:
            ball += 1

    if ch3 in listAns:
        if ch3 == ans3:
            strike += 1
        else:
            ball += 1

    if ch1 not in listAns and ch2 not in listAns and ch3 not in listAns:
        out += 1

    print("%dS %dB %dOUT" %(strike, ball, out))

    return 0


def win():
    print("축하드립니다")
    print("승리하셨습니다")

def GameOver():
    print("패배하셨습니다")
    print("정답은 {}이었습니다".format(listAns))


while tryNumber > 0:
    choice = input("세 수를 입력하세요\n예)3 4 5\n")

    choice1 = int(choice[0])
    choice2 = int(choice[2])
    choice3 = int(choice[4])

    pitch(choice1, choice2, choice3)

    if strike == 3:
        win()
        break

    if out == 3:
        GameOver()
        break

    tryNumber -= 1