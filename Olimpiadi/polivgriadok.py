m = 10
n = 5
l = 7
p = [1, 2, 3, 20]
#цикл
for k in p:
    s1 = (n+m)*2 + 2*l
    if k > 1:
        for i in range (2, k+1):
            s1 += (n+m)*2 + (i-1)*2*m + 2*l
    print('При k = ', k, ':', s1)
#формула
for k in p:
    s2 = k*(n+m)*2 + 2*l*k + (k-1)*k*m
    print('При k = ', k,  ':', s2)