def input_graph():
    n = int(input("Введите количество вершин: "))
    matrix = []

    for i in range(n):
        print(f"Введите строку {i + 1} матрицы смежности, разделенную пробелами (0 - если соединения нет):")
        m = list(map(int, input().split()))
        if len(m) != n:
            print(f"Строка должна содержать {n} чисел. Попробуйте ввести строку {i + 1} снова.")
            return input_graph()
        matrix.append(m)

    for i in range(n):
        for j in range(n):
            if i != j and matrix[i][j] == 0:
                matrix[i][j] = float('infinity')

    return n, matrix
n, matrix = input_graph()
start = int(input('Введите начальную вершину')) - 1
lambd = [float('infinity')]*n
lambd[start] = 0
pred = [-1]*n
for z in range(n-1):
    for i in range(n):
        for j in range(n):
            if matrix[i][j] !=  float('infinity'):
                if lambd[j] > lambd[i] + matrix[i][j]:
                    lambd[j] = lambd[i] + matrix[i][j]
                    pred[j] = i
ans = 0
if ans == 0:
    for i in range(n):
        for j in range(n):
            if matrix[i][j] !=  float('infinity'):
                if (lambd[j] > lambd[i] + matrix[i][j]):
                    print('В графе существует цикл отрицательного веса')
                    ans +=1
    if ans == 0:
        for i in range(n):
            print('Расстояние от вершины ', start+1, ' до вершины ', i+1, ' = ', lambd[i])
