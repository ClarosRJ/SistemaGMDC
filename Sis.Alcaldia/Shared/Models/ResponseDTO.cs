﻿namespace Sis.Alcaldia.Shared.Models
{
	public class ResponseDTO<T>
    {
        public bool status { get; set; }
        public string? msg { get; set; }
        public T? value { get; set; }
    }
}
