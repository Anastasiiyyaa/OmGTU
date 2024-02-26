import math

print('Введите количество солдат: ')

count=int(input())

an1=int(math.log(count,2))
if count > 4:
    an2=int(2**(an1-1)- abs((2**an1 + 2**(an1+1))/2 - count))
else:
    an2=0
print(an2)