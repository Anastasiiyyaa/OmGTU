n, m = map(int, input('Введите общее количество пунктов и количество дорог (через пробел): \n').split())
grani = []
for i in range(m):
    start, end, weight = map(int, input('Введите номер начального пункта, конечного, их вес (через пробел): ' '\n').split())
    grani.append([weight, start, end])
grani.sort()
graf = [i for i in range(n)]
ans = 0
for weight, start, end in grani:
    if graf[start-1] != graf[end- 1]:
        ans += weight
        a = graf[start-1]
        b = graf[end-1]
        for i in range(n):
            if graf[i] == b:
                graf[i] = a
print(ans)