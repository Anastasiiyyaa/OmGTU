def vvoddano():
    print('Введите общее количество домиков: ')
    n = int(input())
    grani = []
    for i in range(1, n+1):
        err = True
        while err:
            try:
                data_koord = input(f'Введите координаты {i}-го домика x и y (через пробел): ')
                x, y = map(int, data_koord.split())
                prov = any(gran[1]==x and gran[2]==y for gran in grani)
                if prov:
                    print('Домик с такими координатами уже есть')
                else:
                    grani.append((i, x, y))
                    err = False
            except:
                print('Неверный формат, введите два числа через пробел')
    print('Данные сохранены')
    return grani, n
def printvvod(grani, n):
    output = 'Количество домиков: {}\n'.format(n)
    output+='{:15}{:15}{:15}\n'.format('№', 'x', 'y')
    for gran in grani:
        output+='{:0}{:15}{:15}\n'.format(*gran)
    return output
def reshans(grani, n):
    vesa = []
    for b in range(n-1):
        for a in range(b+1, n):
            x1, y1 = grani[b][1], grani[b][2]
            x2, y2 = grani[a][1], grani[a][2]
            distance = ((x2 - x1)**2 + (y2 - y1)**2)**0.5
            vesa.append((distance, b, a))
    vesa.sort()
    graf = [u for u in range(n)]
    ans = 0
    for weight, start, end in vesa:
        if graf[start] != graf[end]: 
            ans += weight
            print('Пара домиков, между которыми установлено соединение:')
            print('{:15}{:15}{:15}'.format('№', 'x', 'y'))
            for j in range(0, len(grani)):
                if grani[j][0]==(graf[start]+1):
                    print('{:0}{:15}{:15}'.format(grani[j][0], grani[j][1], grani[j][2]))
            for k in range(0, len(grani)):
                if grani[k][0]==(graf[end]+1):
                    print('{:0}{:15}{:15}'.format(grani[k][0], grani[k][1], grani[k][2]))
            old_group, new_group = graf[start], graf[end]
            for i in range(n):
                if graf[i] == new_group:
                    graf[i] = old_group
    print('Ответ: ', ans)
def ogranichenie():
    err = True
    vvod = 0
    while err:
        try:
            vvod = int(input())
            if vvod<=6 and vvod>=1:
                err = False
            else:
                print('Введите число от 1 до 6')
        except:
            print('Введите число')
    return vvod
def ogranichenieforobn():
    err = True
    vvod = 0
    while err:
        try:
            vvod = int(input())
            if (vvod==0 or vvod==1):
                err = False
            else:
                print('Введите 0 или 1')
        except:
            print('Введите число')
    return vvod
class Menu:
    def run(self):
        data = None  
        while (True):
            print('Выберите: ')
            print('1. Условие задачи')
            print('2. Ввести данные для задачи')
            print('3. Вывести введённые данные')
            print('4. Решение и ответ')
            print('5. Информация об авторе программы')
            print('6. Выход')
            command = ogranichenie()
            match command:
                case 1:
                    print('Условие задачи:')
                    print('Задание 10.')
                    with open('zadacha.txt', 'r', encoding = 'utf-8') as file:
                        zadacha = file.read()
                    print(zadacha)
                case 2:
                    print('Введите требуемые данные')
                    if data is None:
                        data = vvoddano()  
                    else:
                        print('Уже есть введённые данные. Хотите обновить? (1 - да, 0 - нет)')
                        ob = ogranichenieforobn()
                        if ob == 1:
                            data = vvoddano()  
                        else:
                            print('Данные не изменены')
                case 3:
                    if data is None:
                        print('Сначала введите данные')
                    else:
                        print(printvvod(*data))
                case 4:
                    if data is None:
                        print('Сначала введите данные')
                    else:
                        reshans(*data)
                case 5:
                    print('Работу выполнила:')
                    print('Завьялова Анастасия Николаевна ФИТ-232')
                case 6:
                    break

if __name__ == "__main__":
    menu = Menu()
    menu.run()