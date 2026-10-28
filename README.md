# Лабораторный практикум по ООП (C# / .NET)

Репозиторий содержит программный код, входные/выходные данные и оформленные отчеты (в форматах **Markdown** и **Word DOCX по ГОСТу**) со скриншотами по всем 12 лабораторным работам дисциплины **«Объектно-ориентированное программирование»** (СКФУ).

- **Студент:** Мухамеджанов Э. Т.
- **Группа:** ПИН-б-о-24-1
- **Направление подготовки:** 09.03.03 «Прикладная информатика»
- **Институт:** Институт цифрового развития (Кафедра прикладной информатики)
- **Вариант:** №7
- **Среда разработки и компиляции:** .NET Framework 4.8 / C# 5 (`csc.exe`)

---

## 📂 Структура репозитория

```text
AllLabsOOP/
│
├── Lab01/ ... Lab12/               # Исходные коды всех 12 лабораторных работ
│
├── Reports/                         # Оформленные отчеты по всем 12 работам
│   ├── LR01_Report.md ... LR12_Report.md       # Отчеты в формате Markdown
│   ├── LR01_Report.docx ... LR12_Report.docx   # Документы Word по ГОСТ 7.32-2017
│   ├── Reports_Word_Mukhamedzhanov.zip         # Архив всех 12 Word отчетов
│   └── screens/                                # Скриншоты и UML-диаграммы
│
├── Tools/
│   └── ScreenshotHelper.ps1         # Утилита автоматической генерации скриншотов
│
└── LR_part1_OOP (2).pdf             # Методические указания (Часть 1, работы 1-12)
```

---

## 📑 Список выполненных лабораторных работ

| № | Название лабораторной работы | Вариант 7 (Индивидуальное задание) | Отчет MD | Отчет Word (ГОСТ) |
|---|---|---|:---:|:---:|
| **1** | Разработка консольного приложения | Визитная карточка студента и формула $U = \frac{35}{a} \cdot z + z \cdot a - \frac{a + E \cdot t}{4}$ | [LR01.md](Reports/LR01_Report.md) | [LR01.docx](Reports/LR01_Report.docx) |
| **2** | Перенаправление потоков ввода-вывода | Чтение из `input.txt`, проверка ОДЗ (`ERROR`), запись в `output.txt` | [LR02.md](Reports/LR02_Report.md) | [LR02.docx](Reports/LR02_Report.docx) |
| **3** | Управление потоком выполнения (циклы) | Знакопеременный ряд $s = -\frac{Y X^2}{1 \cdot 3} + \frac{X Y^3}{2 \cdot 4} - \dots$ (`for`, `while`, `do..while`) | [LR03.md](Reports/LR03_Report.md) | [LR03.docx](Reports/LR03_Report.docx) |
| **4** | Одномерные массивы | Генератор псевдослучайных чисел, чтение массива, вывод кратных 5 | [LR04.md](Reports/LR04_Report.md) | [LR04.docx](Reports/LR04_Report.docx) |
| **5** | Многомерные массивы | Матрица $3 \times 4$, суммы по строкам и средние арифметические по столбцам | [LR05.md](Reports/LR05_Report.md) | [LR05.docx](Reports/LR05_Report.docx) |
| **6** | Классы. Объектное моделирование | Класс `MatrixMxN`, методы `GetMax()`, `GetMin()`, переключение Debug/Release | [LR06.md](Reports/LR06_Report.md) | [LR06.docx](Reports/LR06_Report.docx) |
| **7** | Конструкторы и перегрузка методов | Класс `Cube`, вычисление $V=a^3$, $S=6a^2$, $d=a\sqrt{3}$, перегрузка `Info()` | [LR07.md](Reports/LR07_Report.md) | [LR07.docx](Reports/LR07_Report.docx) |
| **8** | Проектирование иерархии классов | Иерархия `Машины` $\to$ `Авиасредство`/`Грузовик` $\to$ `Вертолет`/`Истребитель` | [LR08.md](Reports/LR08_Report.md) | [LR08.docx](Reports/LR08_Report.docx) |
| **9** | Полиморфизм на основе интерфейсов | Интерфейсы `ICalculable` и `IDisplayable`, классы IT-инфраструктуры | [LR09.md](Reports/LR09_Report.md) | [LR09.docx](Reports/LR09_Report.docx) |
| **10** | Многомодульность и динамические библиотеки | Библиотека `MatrixLib.dll`, расчет суммы главной диагонали $M1$ и побочной $M2$ | [LR10.md](Reports/LR10_Report.md) | [LR10.docx](Reports/LR10_Report.docx) |
| **11** | Обработка данных в файлах (CSV и LINQ) | Анализ датасета сотрудников `employees.csv` с помощью LINQ-запросов | [LR11.md](Reports/LR11_Report.md) | [LR11.docx](Reports/LR11_Report.docx) |
| **12** | Событийно-ориентированное программирование | Windows Forms GUI: $Q = \sin(h + d / e^{0.1}) - o_1 + \sin(f) + \sqrt{\|\sin(b)\|}$ | [LR12.md](Reports/LR12_Report.md) | [LR12.docx](Reports/LR12_Report.docx) |

📦 **[Скачать все отчеты в Word (ZIP-архив)](Reports/Reports_Word_Mukhamedzhanov.zip)**

---

## 🛠️ Сборка и запуск проектов

Все проекты адаптированы для сборки через стандартный компилятор `csc.exe` платформы .NET Framework 4.8:

```powershell
# Пример компиляции консольного проекта:
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /out:Program.exe Program.cs

# Пример компиляции библиотеки DLL (ЛР 10):
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:library /out:MatrixLib.dll FileMatrix.cs

# Пример компиляции Windows Forms приложения (ЛР 12):
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /out:MainForm.exe Program.cs
```
