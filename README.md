# LestaTestTask
Тестовое задание по направлению "ПРОГРАММИРОВАНИЕ" в Lesta Games Academy


<h1>Исходеые файлы</h1>
<a href="https://github.com/DimaVor/LestaTestTask/tree/main/Assets/Scripts">В папке со скриптами</a> находятся:
Игровая модель - /GameModel, описывающая логику отдельно от Unity.

Скрипты  отвечающие за связь модели и визуальных элементов - /UnityGameLogic.

Побочные скрипты для различных аспектов игры.

<a href="https://github.com/DimaVor/LestaTestTask/tree/main/Assets">В папке Assets</a> находятся все файлы, использованные для реализации игры 

 
 
<h1>Геймплейное видео</h1>
Тут вы можете ознакомиться с геймплейным видео


<h1>Игровой процесс</h1>
Из стартового меню вы попадаете на сцену с самой игрой.

Во время игры вы можете выбирать и перемещать фишку одного из 3-х типов (В данной реализации - вода, воздух, огонь) ![image](https://user-images.githubusercontent.com/64017890/198563680-756fa8e8-5e73-4fe3-9a2c-6fd5f44ef94e.png)

Фишка выбирается кликом на нее, при повторном клике выбор отменяется, если кликнуть на пустое поле на одной линии с выбранной фишкой и если между этими полем и фишкой нет преград, то фишка переместится на выбранное пустое поле.

После каждого перемещения производится проверка, не закончилась ли игра.
Игра заканчивается, если все 5 фишек каждого типа займут свой столбец.
После проигранной победной анимации появляется кнопка с возможностью переиграть уровень.

Блок (В данной реализации - землю) выбрать нельзя, как и пустое поле

![image](https://user-images.githubusercontent.com/64017890/198564047-f54a321d-db38-43f4-a2b6-fff73e2a8338.png)

<h1>P.S</h1>
В игровую логику внесено лишь одно несоответствие тз: Фишку в данной реализации можно двигать не только на соседнее пустое поле, но и через несколько пустых полей, расположенных в одной строке или столбце, при этом счетчик шагов засчитывает каждую пройденную клетку за 1 шаг

Сделано это для ускорения игрового процесса
