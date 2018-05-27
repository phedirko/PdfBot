using System;
using System.Collections.Generic;
using System.Text;

namespace PdfBot.Services.Models
{
    public class GenericMessage<T>
    {
        public GenericMessage(T data, bool isWarmup = false)
        {
            Data = data;
            IsWarmup = isWarmup;
        }
        public T Data { get; }

        public bool IsWarmup { get; }
    }
}
