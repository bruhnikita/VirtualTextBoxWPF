using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VirtualTextbook
{
    public partial class MainWindow : Window
    {
        private List<Question> questions;
        private int score;

        public MainWindow()
        {
            InitializeComponent();
            LoadTheory();
            LoadQuestions();
        }

        private void LoadTheory()
        {
            TheoryTextBox.Text = "Основы программирования\r\n\r\nПрограммирование — это процесс написания и разработки кода для создания программного обеспечения. Оно включает в себя написание инструкций, которые компьютер будет выполнять для выполнения определенных задач. Основные концепции программирования включают в себя:\r\n\r\nПеременные и типы данных:\r\n\r\nПеременные — это именованные области памяти, которые используются для хранения данных.\r\nОсновные типы данных включают целые числа (int), числа с плавающей точкой (float, double), строки (string) и логические значения (bool).\r\nУсловия:\r\n\r\nУсловные операторы позволяют выполнять разные действия в зависимости от условий. Основные операторы включают if, else if и else.\r\nЦиклы:\r\n\r\nЦиклы позволяют повторять набор инструкций. Наиболее распространенные типы циклов включают for, while и do-while.\r\nФункции:\r\n\r\nФункции (или методы) — это блоки кода, которые выполняют определенную задачу и могут принимать параметры и возвращать значения.\r\nМассивы и коллекции:\r\n\r\nМассивы — это структуры данных, которые хранят несколько значений одного типа.\r\nКоллекции, такие как списки и словари, предлагают более гибкие способы работы с группами данных.\r\nОбъектно-ориентированное программирование (ООП):\r\n\r\nООП — это парадигма программирования, которая организует код в объекты, которые содержат как данные, так и методы для работы с этими данными. Основные понятия включают классы, наследование и полиморфизм.\r\nОшибка и обработка исключений:\r\n\r\nОшибки — это проблемы, которые возникают во время выполнения программы. Обработка исключений позволяет разработчикам управлять ошибками и предотвращать сбои программы.";
        }

        private void LoadQuestions()
        {
            questions = new List<Question>
            {
                 new Question("Что такое переменная в программировании?", "Именованная область памяти", new[] { "Именованная область памяти", "Способ выполнения кода", "Система хранения данных" }),
                 new Question("Какой из следующих типов данных используется для хранения логических значений?", "bool", new[] { "int", "string", "bool" }),
                 new Question("Что делает оператор if?", "Проверяет условие и выполняет код, если оно истинно", new[] { "Проверяет условие и выполняет код, если оно истинно", "Переводит текст в нижний регистр", "Объявляет переменную" }),
                 new Question("Какой цикл будет выполняться как минимум один раз?", "do-while", new[] { "for", "while", "do-while" }),
                 new Question("Что такое функция?", "Блок кода, выполняющий определенную задачу", new[] { "Блок кода, выполняющий определенную задачу", "Структура данных", "Переменная" }),
                 new Question("Что такое массив?", "Структура данных для хранения нескольких значений одного типа", new[] { "Структура данных для хранения нескольких значений одного типа", "Набор функций", "Система обработки ошибок" }),
                 new Question("Какое из следующих понятий относится к ООП?", "Наследование", new[] { "Наследование", "Логика", "Итерация" }),
                 new Question("Что делает обработка исключений?", "Управляет ошибками во время выполнения", new[] { "Управляет ошибками во время выполнения", "Создает новые переменные", "Оптимизирует производительность" }),
                 new Question("Какой из этих типов данных используется для работы с текстом?", "string", new[] { "int", "string", "bool" }),
                 new Question("Какой метод позволяет добавить элемент в список в C#?", "Add", new[] { "Add", "Insert", "Push" })
            };

            foreach (var question in questions)
            {
                StackPanel questionPanel = new StackPanel { Margin = new Thickness(5) };

                TextBlock questionText = new TextBlock { Text = question.Text, FontWeight = FontWeights.Bold };
                questionPanel.Children.Add(questionText);

                foreach (var answer in question.Answers)
                {
                    RadioButton answerButton = new RadioButton
                    {
                        Content = answer,
                        GroupName = question.Text
                    };
                    questionPanel.Children.Add(answerButton);
                }

                QuestionsContainer.Items.Add(questionPanel);
            }
        }


        private void CheckAnswers_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            foreach (var item in QuestionsContainer.Items)
            {
                if (item is StackPanel questionPanel)
                {
                    foreach (var child in questionPanel.Children)
                    {
                        if (child is RadioButton answerButton && answerButton.IsChecked == true)
                        {
                            if (answerButton.Content.ToString() == questions[QuestionsContainer.Items.IndexOf(item)].CorrectAnswer)
                            {
                                score++;
                            }
                        }
                    }
                }
            }

            ResultsTextBox.Text = $"Ваш результат: {score}/{questions.Count}";
            SaveResults(score);
        }

        private void SaveResults(int score)
        {
            MessageBox.Show("Результаты сохранены!");
        }
    }

    public class Question
    {
        public string Text { get; }
        public string CorrectAnswer { get; }
        public string[] Answers { get; }

        public Question(string text, string correctAnswer, string[] answers)
        {
            Text = text;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }
}
