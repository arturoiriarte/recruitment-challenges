﻿using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    public interface IOrderFileReader
    {
        IEnumerable<Order> Read(FileStream stream);
    }
}
