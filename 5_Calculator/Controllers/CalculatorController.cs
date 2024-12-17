﻿using _5_Calculator.Data;
using _5_Calculator.Models;
using _5_Calculator.Services;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _5_Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorContext _context;
        private readonly KafkaProducerService<Null, string> _producer;

        public CalculatorController(CalculatorContext context, KafkaProducerService<Null, string> producer)
        {
            _context = context;
            _producer = producer;
        }

        /// <summary>
        /// Отображение страницы Index.
        /// </summary>
        public IActionResult Index()
        {
            var data = _context.DataInputVariants.OrderByDescending(x => x.ID_DataInputVariant).ToList();

            return View(data);
        }

        /// <summary>
        /// Обработка запроса на вычисление.
        /// </summary>
        /// <param name="num1">Первый операнд.</param>
        /// <param name="num2">Второй операнд.</param>
        /// <param name="operation">Тип операции (сложение, вычитание, умножение, деление).</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(double num1, double num2, Operation operation)
        {
            // Подготовка объекта для расчета
            var dataInputVariant = new DataInputVariant
            {
                Operand_1 = num1,
                Operand_2 = num2,
                Type_operation = operation,
            };

            // Отправка данных в Kafka
            await SendDataToKafka(dataInputVariant);

            // Перенаправление на страницу Index
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Callback([FromBody] DataInputVariant inputData)
        {
            // Сохранение данных и результата в базе данных
            SaveDataAndResult(inputData);

            return Ok();
        }

        /// <summary>
        /// Сохранение данных и результата в базе данных.
        /// </summary>
        /// <param name="num1">Первый операнд.</param>
        /// <param name="num2">Второй операнд.</param>
        /// <param name="operation">Тип операции (сложение, вычитание, умножение, деление).</param>
        /// <param name="result">Результат математической операции.</param>
        /// <returns>Объект с данными и результатом.</returns>
        private DataInputVariant SaveDataAndResult(DataInputVariant inputData)
        {
            _context.DataInputVariants.Add(inputData);
            _context.SaveChanges();

            return inputData;
        }

        /// <summary>
        /// Отправка данных в Kafka.
        /// </summary>
        /// <param name="dataInputVariant">Объект с данными и результатом.</param>
        /// <returns>Task.</returns>
        private async Task SendDataToKafka(DataInputVariant dataInputVariant)
        {
            var json = JsonSerializer.Serialize(dataInputVariant);
            await _producer.ProduceAsync("Bogachev", new Message<Null, string> { Value = json });
        }
    }
}
