MaxN = int(input())
combinations = 0
a = []
for n in range(1, 100):
    a.append(2**n)
for x in a:
    combinations += int((MaxN/(x-1)))
print(combinations)