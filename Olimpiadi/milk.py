s = []
with open('input1.txt') as f:
    for l in f:
        s.append([float(x) for x in l.split()])
j = 0
a = []
for j in range(len(s)):
    for i in s[j]:
        a.append(i)
minimum = 10000000
firma = 0
k = 0
x = 1
y = 2
z = 3
w = 7
while x <= len(a):
    try:
        v1 = (int(a[x])*int(a[y])*(a[z]))/1000
        v2 = (a[x+3]*a[z+3]*a[y+3])/1000
        s1 = (a[x]*a[y])*2 + (a[x]*a[z])*2 +(a[y]*a[z])*2 
        s2 = (a[z+3]*a[x+3])*2 + (a[z+3]*a[y+3])*2 +(a[y+3]*a[x+3])*2 
        c1 = a[w]
        c2 = a[w+1]
        litr = (c2*s1 - s2*c1)/(v2*s1 - v1*s2)
        x+=8
        y+=8
        z+=8
        w+=8
        k += 1
        if litr < minimum:
            minimum = litr
            firma = k
    except:
        break
print( firma, round(minimum, 2))
    
        
    
    
