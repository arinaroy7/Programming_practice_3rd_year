﻿using System.Linq; // Функций linq много, почитать 
using System.Linq.Expressions;

var data = new int[] {2, 4, 5, 6, 3, 2, 1, 44}; //коллекция список лучших покупателей
Console.WriteLine(string.Join(",", data));

var best = data.Where(i => i  > 10);
Console.WriteLine(string.Join(",", best));

//Join склеивает все элементы и выводит через запятую

//функция order по умолчанию сортирует по возрастанию
//функция orderDe...

// Стрелочная функция 
// Функция Where фильтрует Where(i => i % 2 == 0);  f12 - вызв файл с документацией Ordet(); сортируем по возр
// .Select(x => x*2) Умножает на два

// делегаты - это тип переменной, в который можно складывать функции  - записать
// слева от стрелки аргументы, стрелка это способ обьявить функцию/создание локальной функции, справа от стрелки обьявление функции?
// ДЗ: поэксперементировать с линк запросами. Создать массив содерж
// строки и остав строки, которые только длиннее трех символов. Привести к верхнему регистру и отсорт по алфавиту 
//where будет передано проверка на длину strign to upper
//почитать про Linq