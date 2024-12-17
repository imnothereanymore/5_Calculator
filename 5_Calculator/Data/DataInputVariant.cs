﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _5_Calculator.Models;

namespace _5_Calculator.Data
{
    public class DataInputVariant
    {
        [Key]
        public int ID_DataInputVariant { get; set; } // Уникальный идентификатор для объекта DataInputVariant

        public double Operand_1 { get; set; } // Первый операнд для операции

        public double Operand_2 { get; set; } // Второй операнд для операции

        public Operation Type_operation { get; set; } // Тип операции (например, сложение, вычитание и т.д.)

        [Column(TypeName = "varchar(128)")]
        public string? Result { get; set; } // Результат выполнения операции
    }
}